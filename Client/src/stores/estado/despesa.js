export function despesaDestaqueDiarias(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueDiarias",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Destaque.Diarias",
      args: [],
      continue: true,
      evaluate: false
    },
    ...fnSelectorWorkflow(ano, ug)
  ];
}

export function despesaDestaqueMaterialDeConsumo(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueMaterialDeConsumo",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Destaque.MaterialDeConsumo",
      args: [],
      continue: true,
      evaluate: false
    },
    ...fnSelectorWorkflow(ano, ug)
  ];
}

export function despesaDestaqueMaterialPermanente(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueMaterialPermanente",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Destaque.MaterialPermanente",
      args: [],
      continue: true,
      evaluate: false
    },
    ...fnSelectorWorkflow(ano, ug)
  ];
}

export function despesaDestaqueObras(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "despesaDestaqueObras",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Destaque.Obras",
      args: [],
      continue: true,
      evaluate: false
    },
    ...fnSelectorWorkflow(ano, ug)
  ];
}

export function despesaEmpenhada(ano, ug) {
  return [
    {
      id: "despesaEmpenhada",
      run: "Estado.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Empenhada",
      args: []
    }
  ];
}

export function despesaEvolucaoAnual(ano, ug, quantidade = 5) {
  return [
    {
      id: "despesaEvolucaoAnual",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function despesaEvolucaoMensal(ano, ug) {
  return [
    {
      id: "despesaEvolucaoMensal",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.EvolucaoMensal",
      args: [ano]
    }
  ];
}

export function despesaLiquidada(ano, ug) {
  return [
    {
      id: "despesaLiquidada",
      run: "Estado.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Liquidada",
      args: []
    }
  ];
}

export function despesaMaioresLiquidadaPorFuncao(ano, ug, quantidade = 5) {
  return [
    {
      id: "despesaMaioresLiquidadaPorFuncao",
      run: "Estado.Despesa.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.MaioresLiquidadaPorFuncao",
      args: [ano, quantidade]
    }
  ];
}

export function despesaPaga(ano, ug) {
  return [
    {
      id: "despesaPaga",
      run: "Estado.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.Paga",
      args: []
    }
  ];
}

export function despesaPrevisaoInicial(ano, ug) {
  return [
    {
      id: "despesaPrevisaoInicial",
      run: "Estado.Despesa.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.PrevisaoInicial",
      args: []
    }
  ];
}

export function despesaRemessaAtual(ano, ug) {
  return [
    {
      id: "despesaRemessaAtual",
      run: "Estado.Despesa.FiltrarPorAnoECodigo1",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Despesa.RemessaAtual",
      args: []
    }
  ];
}

export function despesaSumLiquidada() {
  return [
    {
      id: "despesaSumLiquidada",
      run: "Estado.Despesa.Liquidada"
    }
  ];
}
