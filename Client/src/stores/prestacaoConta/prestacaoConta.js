import axios from "axios";

const cache = {};

export function prestacaoContaPCA(ano, ug) {
	return [
		{
			id: "prestacaoContaPCA",
			run: "PrestacaoConta.PCA",
			args: [ano, ug]
		}
	];
}

export function prestacaoContaPCB(ano, ug) {
	if (ug.length === 3) {
		ug = ug + "E0700001";
	}

	return [
		{
			id: "prestacaoContaPCB",
			run: "PrestacaoConta.PCB",
			args: [ano, ug]
		}
	];
}

export function prestacaoContaEstado(ano, ug) {
	return [
		{
			id: "prestacaoContaEstado",
			run: "PrestacaoConta.Estado",
			args: [ano, ug]
		}
	];
}

export function prestacaoContaPCF(ano, ug) {
	return [
		{
			id: "prestacaoContaPCF",
			run: "PrestacaoConta.PCF",
			args: [ano, ug]
		}
	];
}

export function prestacaoContaMensal(ano, ug) {
	return [
		{
			id: "prestacaoContaMensal",
			run: "PrestacaoContaMensal.FiltrarPorAnoECodigo",
			args: [ano, ug],
			continue: true,
			evaluate: false
		},
		{
			run: "PrestacaoContaMensal.Atual",
			args: []
		}
	];
}

export function prestacaoContaPessoal(ano, ug) {
	return [
		{
			id: "prestacaoContaPessoal",
			run: "PrestacaoConta.Pessoal",
			args: [ano, ug]
		}
	];
}

export async function get(prestacaoContaWorkflow) {
	const res = await axios.post(
		"http://localhost:9000/api/ControleSocial", //todo: consertar isso
		prestacaoContaWorkflow
	);

	cache[prestacaoContaWorkflow] = res.data;
	return res.data;
}
