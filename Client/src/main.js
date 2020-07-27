import HMR from '@sveltech/routify/hmr'
import "./tailwind.css";
import App from "./App.svelte";

const app = HMR(App, {
	target: document.body
}, 'routify-app');

export default app;