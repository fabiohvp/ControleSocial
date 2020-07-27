export function receitaArrecadada(ano, ug) {
  return [
    {
      id: "receitaArrecadada",
      run: "Estado.Receita.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Arrecadada",
      args: []
    }
  ];
}

export function receitaComposicaoArrecadada(ano, ug) {
  return [
    {
      id: "receitaComposicaoArrecadada",
      run: "Estado.Receita.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.ComposicaoArrecadada",
      args: []
    }
  ];
}

export function receitaDestaqueConveniosDaUniao(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "receitaDestaqueConveniosDaUniao",
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.ConveniosDaUniao",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.ConveniosDoEstado",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.FPM",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.ICMS",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.IPTU",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.IPVA",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.ISS",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.ITBI",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Composicao.OperacoesDeCredito",
      args: [],
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
  return [
    {
      id: "receitaDestaqueOutrasTransferencias",
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Composicao.OutrasTransferencias",
      args: [],
      continue: true,
      evaluate: false
    },
    ...fnSelectorWorkflow(ano, ug)
  ];
}

export function receitaDestaqueReceitasDoEstado(ano, ug, fnSelectorWorkflow) {
  return [
    {
      id: "receitaDestaqueReceitasDoEstado",
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Composicao.ReceitasDoEstado",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.RoyaltiesDaUniao",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Destaque.RoyaltiesDoEstado",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Composicao.TransferenciasDaUniao",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.Composicao.TransferenciasDoEstado",
      args: [],
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
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function receitaEvolucaoMensal(ano, ug) {
  return [
    {
      id: "receitaEvolucaoMensal",
      run: "Estado.Receita.FiltrarPorCodigo",
      args: [ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.EvolucaoMensal",
      args: [ano]
    }
  ];
}

export function receitaPrevisaoInicial(ano, ug) {
  return [
    {
      id: "receitaPrevisaoInicial",
      run: "Estado.Receita.FiltrarPorAnoECodigo",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.PrevisaoInicial",
      args: []
    }
  ];
}

export function receitaRemessaAtual(ano, ug) {
  return [
    {
      id: "receitaRemessaAtual",
      run: "Estado.Receita.FiltrarPorAnoECodigo1",
      args: [ano, ug],
      continue: true,
      evaluate: false
    },
    {
      run: "Estado.Receita.RemessaAtual",
      args: []
    }
  ];
}

export function receitaSumArrecadada() {
  return [
    {
      id: "receitaSumArrecadada",
      run: "Estado.Receita.Arrecadada"
    }
  ];
}
