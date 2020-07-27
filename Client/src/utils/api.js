import { writable } from "svelte/store";
import axios from "axios";
import * as guid from "./guid.js";
let _token;
export const store = writable({});
export const token = createTokenStore();

const apiProtocol = "http";
const apiPort = 8999;
const apiDomain = "localhost";

const socketProtocol = "ws";
const socketPort = 8999;
const socketDomain = apiDomain;


function createTokenStore() {
	_token = localStorage.getItem("user");

	if (_token) {
		_token = JSON.parse(_token);
	}

	const { subscribe, set } = writable(_token);

	function signIn(user) {
		if (user) {
			user.roles = user.roles.split(",");
			localStorage.setItem("user", JSON.stringify(user));
			_token = user;
			set(_token);
		}
		else {
			signOut();
		}
	}

	function signOut() {
		localStorage.removeItem("user");
		_token = undefined;
		set(_token);
	}

	function isAuthenticated() {
		if (_token) {
			const expirationDate = new Date(_token.expiration);
			if (new Date() > expirationDate) {
				signOut();
				return false;
			}
			return true;
		}
		return false;
	}

	function hasRoles(roles) {
		if (_token) {
			if (roles) {
				return _token.roles.indexOf(roles) > -1;
			}
			return true;
		}
		return false;
	}

	return {
		subscribe,
		signIn,
		signOut,
		isAuthenticated,
		hasRoles
	};
}

function getApiUrl(endpoint) {
	return `${apiProtocol}://${apiDomain}:${apiPort}/api/${endpoint}`;
}

function getSocketUrl(endpoint = "socket") {
	return `${socketProtocol}://${socketDomain}:${socketPort}/${endpoint}`;
}

function createSocket() {
	const socket = new WebSocket(getSocketUrl());

	socket.guid = guid.create();
	socket.autoClose = true;

	socket.onopen = function (event) {
		//console.log("[socket:open] Connection established", event);
		socket.send(JSON.stringify({ type: "handshake", value: socket.guid }));
	};

	socket.onclose = function (event) {
		if (event.wasClean) {
			//console.log("[socket:close] Connection closed cleanly", event);
		} else {
			// e.g. server process killed or network down
			// event.code is usually 1006 in this case
			console.warn("[socket:close] Connection died", event);
		}
	};

	socket.onerror = function (error) {
		console.warn("[socket:error]", error);
	};

	return socket;
}

export function createStore() {
	return writable({});
}

function get(endpoint, config = null) {
	config = getConfig(config);
	return axios.get(endpoint, config);
}

axios.interceptors.response.use(function (response) {
	return response;
}, function (error) {
	error.response.Message = error.response.statusText;
	return Promise.resolve({
		data: [{
			error: error.response
		}]
	});
});

function post(endpoint, data, config = null) {
	config = getConfig(config);
	return axios.post(endpoint, data, config);
}

function getConfig(config) {
	if (!config) {
		config = {};
	}

	const socket = config.socket || createSocket();
	const headers = {
		"socket-guid": socket.guid
	};

	if (_token) {
		headers.Authorization = `Bearer ${_token.token}`;
	}

	config = {
		socket,
		headers,
		...config
	};

	const onMessage = config.socket.onmessage;
	const onTransformResponse = config.transformResponse;

	config.socket.onmessage = function (event) {
		let preventDefault = false;

		if (onMessage) {
			preventDefault = onMessage(event);
		}

		if (preventDefault !== true) {
			const json = JSON.parse(event.data);
			pushResult(config, json);
		}
	};

	config.transformResponse = axios.defaults.transformResponse.concat((json) => {
		if (config.socket.autoClose) {
			config.socket.close();
		}
		let preventDefault = false;

		if (onTransformResponse) {
			preventDefault = onTransformResponse(json);
		}

		if (preventDefault !== true) {
			for (let i in json) {
				pushResult(config, json[i]);
			}
		}
		return json;
	});

	return config;
}

function pushResult(config, json) {
	if (config.store && json.id) {
		config.store.update(s => {
			s[json.id] = json
			return s;
		});
	}
}

export default {
	createSocket,
	createStore,
	get,
	getApiUrl,
	post,
	token
}