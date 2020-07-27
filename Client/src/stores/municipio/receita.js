const composicao = {
	operacoesDeCredito: ano => ano >= anoInicioUsoEmentarioReceita ? ["2111", "2112", "2118", "2119", "2121", "2122", "2128", "2129"] : ["2111", "2114", "2119", "2122", "2123", "2129"],
	receitasDoMunicipio: ano => ano >= anoInicioUsoEmentarioReceita ? ["11", "12", "13", "14", "15", "16", "19", "22", "23", "29"] : ["11", "12", "13", "14", "15", "16", "19", "22", "23", "25"],
	transferenciaDaUniao: ano => ano >= anoInicioUsoEmentarioReceita ? ["1718", "2418"] : ["1721", "1761", "2421", "2471"],
	transferenciaDoEstado: ano => ano >= anoInicioUsoEmentarioReceita ? ["1728", "1758", "2428"] : ["1722", "1724", "1762", "2422", "2472"]
};
const anoInicioUsoEmentarioReceita = 2016

export function receitaArrecadada(ano, ug) {
	return [
		{
			id: "receitaArrecadada",
			run: "Municipio.Receita.FiltrarPorAnoECodigo",
			args: [ano, ug],
			continue: true,
			evaluate: false
		},
		{
			run: "Municipio.Receita.Arrecadada",
			args: []
		}
	];
}

export function receitaComposicaoArrecadada(ano, ug) {
	const workflows = [receitaDestaqueOperacoesDeCredito, receitaDestaqueReceitasDoMunicipio, receitaDestaqueTransferenciasDaUniao, receitaDestaqueTransferenciasDoEstado, receitaDestaqueOutrasTransferencias]
		.map(fnSelectorWorkflow => {
			const workflow = fnSelectorWorkflow(ano, ug, receitaSumArrecadada);

			return [
				{
					id: workflow[0].id,
					run: "Municipio.Receita.FiltrarPorAno",
					args: [ano],
					continue: true,
					evaluate: false
				}
			].concat(workflow);
		});
	return workflows.reduce((acc, prev) => acc.concat(prev), []);
}

export function receitaDestaqueConveniosDaUniao(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueConveniosDaUniao",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["171-----810"] : ["1761"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueConveniosDoEstado(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueConveniosDoEstado",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["172-----810"] : ["1762"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueFPM(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueFPM",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["171-----80121", "171-----80131", "171-----80141"] : ["17210102", "17210103", "17210104"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueICMS(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueICMS",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["172-----80111", "171-----80611"] : ["17220101", "17220103", "17213600"]],
			continue: true,
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueIPTU(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueIPTU",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["111-----8011"] : ["1112020", "1911380", "1913110", "1931110"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueIPVA(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueIPVA",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["172-----80121"] : ["17220102"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueISS(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueISS",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["111-----8023", "111-----8024"] : ["11130501", "11130502", "19114000", "19131300", "19311300"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueITBI(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueITBI",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano >= anoInicioUsoEmentarioReceita ? ["111-----8014"] : ["11120800", "19113900", "19131200", "19311200"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueOperacoesDeCredito(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueOperacoesDeCredito",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", composicao.operacoesDeCredito(ano)],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueOutrasTransferencias(
	ano,
	ug,
	fnSelectorWorkflow
) {
	const codigos = composicao.operacoesDeCredito(ano)
		.concat(composicao.receitasDoMunicipio(ano))
		.concat(composicao.transferenciaDaUniao(ano))
		.concat(composicao.transferenciaDoEstado(ano));

	return [
		{
			id: "receitaDestaqueOutrasTransferencias",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", codigos, true], //not
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueReceitasDoMunicipio(
	ano,
	ug,
	fnSelectorWorkflow
) {
	return [
		{
			id: "receitaDestaqueReceitasDoMunicipio",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", composicao.receitasDoMunicipio(ano)],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueRoyaltiesDaUniao(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueRoyaltiesDaUniao",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano > anoInicioUsoEmentarioReceita ? ["1321"] : ano === anoInicioUsoEmentarioReceita ? ["1321"] : ["1325"], true], //not
			continue: true,
			evaluate: false
		},
		{
			run: "String.EndsWith",
			args: ["ClassificacaoFonteRecurso.CodigoFonteReduzida", ano > anoInicioUsoEmentarioReceita ? ["540"] : ano === anoInicioUsoEmentarioReceita ? ["605"] : ["605"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueRoyaltiesDoEstado(ano, ug, fnSelectorWorkflow) {
	return [
		{
			id: "receitaDestaqueRoyaltiesDoEstado",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", ano > anoInicioUsoEmentarioReceita ? ["1321"] : ano === anoInicioUsoEmentarioReceita ? ["1321"] : ["1325"], true], //not
			continue: true,
			evaluate: false
		},
		{
			run: "String.EndsWith",
			args: ["ClassificacaoFonteRecurso.CodigoFonteReduzida", ano > anoInicioUsoEmentarioReceita ? ["140", "240", "530"] : ano === anoInicioUsoEmentarioReceita ? ["120", "207", "604"] : ["604"]],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueTransferenciasDaUniao(
	ano,
	ug,
	fnSelectorWorkflow
) {
	return [
		{
			id: "receitaDestaqueTransferenciasDaUniao",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", composicao.transferenciaDaUniao(ano)],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaDestaqueTransferenciasDoEstado(
	ano,
	ug,
	fnSelectorWorkflow
) {
	return [
		{
			id: "receitaDestaqueTransferenciasDoEstado",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "String.StartsWith",
			args: ["ClassificacaoNatureza.CodigoCompleto", composicao.transferenciaDoEstado(ano)],
			continue: true,
			evaluate: false
		},
		...fnSelectorWorkflow(ano, ug)
	];
}

export function receitaEvolucaoAnual(ano, ug, quantidade = 5) {
	return [
		{
			id: "receitaEvolucaoAnual",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "Municipio.Receita.EvolucaoAnual",
			args: [ano, quantidade]
		}
	];
}

export function receitaEvolucaoMensal(ano, ug) {
	return [
		{
			id: "receitaEvolucaoMensal",
			run: "Municipio.Receita.FiltrarPorCodigo",
			args: [ug],
			continue: true,
			evaluate: false
		},
		{
			run: "Municipio.Receita.EvolucaoMensal",
			args: [ano]
		}
	];
}

export function receitaPrevisaoInicial(ano, ug) {
	return [
		{
			id: "receitaPrevisaoInicial",
			run: "Municipio.Receita.FiltrarPorAnoECodigo",
			args: [ano, ug],
			continue: true,
			evaluate: false
		},
		{
			run: "Municipio.Receita.PrevisaoInicial",
			args: []
		}
	];
}

export function receitaRemessaAtual(ano, ug) {
	return [
		{
			id: "receitaRemessaAtual",
			run: "Municipio.Receita.FiltrarPorAnoECodigo1",
			args: [ano, ug],
			continue: true,
			evaluate: false
		},
		{
			run: "Municipio.Receita.RemessaAtual",
			args: []
		}
	];
}

export function receitaSumArrecadada() {
	return [
		{
			id: "receitaSumArrecadada",
			run: "Municipio.Receita.Arrecadada"
		}
	];
}
