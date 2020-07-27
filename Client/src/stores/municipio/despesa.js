export function despesaDestaqueDiarias(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueDiarias",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "String.Like",
      args: ["ClassificacaoNatureza.CodigoCompleto", ["3___14%", "4___14%"]],
      continue: true,
      evaluate: false,
    },
    ...fnSelectorWorkflow(ano, ug),
  ];
}

export function despesaDestaqueMaterialDeConsumo(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueMaterialDeConsumo",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "String.Like",
      args: ["ClassificacaoNatureza.CodigoCompleto", ["3___30%", "4___30%"]],
      continue: true,
      evaluate: false,
    },
    ...fnSelectorWorkflow(ano, ug),
  ];
}

export function despesaDestaqueMaterialPermanente(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueMaterialPermanente",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "String.Like",
      args: ["ClassificacaoNatureza.CodigoCompleto", ["3___52%", "4___52%"]],
      continue: true,
      evaluate: false,
    },
    ...fnSelectorWorkflow(ano, ug),
  ];
}

export function despesaDestaqueObras(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueObras",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "String.Like",
      args: ["ClassificacaoNatureza.CodigoCompleto", ["3___51%", "4___51%"]],
      continue: true,
      evaluate: false,
    },
    ...fnSelectorWorkflow(ano, ug),
  ];
}

export function despesaEmpenhada(ano, ug) {
  return [
    {
      id: "despesaEmpenhada",
      run: "Municipio.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.Empenhada",
      args: [],
    },
  ];
}

export function despesaEvolucaoAnual(ano, ug, quantidade = 5) {
  return [
    {
      id: "despesaEvolucaoAnual",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.EvolucaoAnual",
      args: [ano, quantidade],
    },
  ];
}

export function despesaEvolucaoMensal(ano, ug) {
  return [
    {
      id: "despesaEvolucaoMensal",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.EvolucaoMensal",
      args: [ano],
    },
  ];
}

export function despesaLiquidada(ano, ug) {
  return [
    {
      id: "despesaLiquidada",
      run: "Municipio.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.Liquidada",
      args: [],
    },
  ];
}

export function despesaMaioresLiquidadaPorFuncao(ano, ug, quantidade = 5) {
  return [
    {
      id: "despesaMaioresLiquidadaPorFuncao",
      run: "Municipio.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.MaioresLiquidadaPorFuncao",
      args: [ano, quantidade],
    },
  ];
}

export function despesaPaga(ano, ug) {
  return [
    {
      id: "despesaPaga",
      run: "Municipio.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.Paga",
      args: [],
    },
  ];
}

export function despesaPrevisaoInicial(ano, ug) {
  return [
    {
      id: "despesaPrevisaoInicial",
      run: "Municipio.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.PrevisaoInicial",
      args: [],
    },
  ];
}

export function despesaRemessaAtual(ano, ug) {
  return [
    {
      id: "despesaRemessaAtual",
      run: "Municipio.Despesa.FiltrarPorAnoECodigo1",
      args: [ano, ug],
      continue: true,
      evaluate: false,
    },
    {
      run: "Municipio.Despesa.RemessaAtual",
      args: [],
    },
  ];
}

export function despesaSumLiquidada() {
  return [
    {
      id: "despesaSumLiquidada",
      run: "Municipio.Despesa.Liquidada",
    },
  ];
}
