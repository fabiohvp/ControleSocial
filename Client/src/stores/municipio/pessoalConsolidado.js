export function pessoalConsolidadoDespesa(ano, municipio) {
  return [
    {
      id: "pessoalConsolidadoDespesa",
      run: "Municipio.Pessoal.Consolidado.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Consolidado.Despesa",
      args: []
    }
  ];
}

export function pessoalConsolidadoDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalConsolidadoDespesaPerCapita",
      run: "Municipio.Pessoal.Consolidado.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Consolidado.DespesaPerCapita",
      args: []
    }
  ];
}

export function pessoalConsolidadoEvolucaoAnual(
  ano,
  municipio,
  quantidade = 5
) {
  return [
    {
      id: "pessoalConsolidadoEvolucaoAnual",
      run: "Municipio.Pessoal.Consolidado.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Consolidado.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function pessoalConsolidadoRankingDespesa(ano, municipio) {
  return [
    {
      id: "pessoalConsolidadoRankingDespesa",
      run: "Municipio.Pessoal.Consolidado.RankingDespesa",
      args: [ano, municipio]
    }
  ];
}

export function pessoalConsolidadoRankingDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalConsolidadoRankingDespesaPerCapita",
      run: "Municipio.Pessoal.Consolidado.RankingDespesaPerCapita",
      args: [ano, municipio]
    }
  ];
}
