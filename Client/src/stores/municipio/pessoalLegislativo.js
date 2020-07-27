export function pessoalLegislativoDespesa(ano, municipio) {
  return [
    {
      id: "pessoalLegislativoDespesa",
      run: "Municipio.Pessoal.Legislativo.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Legislativo.Despesa",
      args: []
    }
  ];
}

export function pessoalLegislativoDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalLegislativoDespesaPerCapita",
      run: "Municipio.Pessoal.Legislativo.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Legislativo.DespesaPerCapita",
      args: []
    }
  ];
}

export function pessoalLegislativoEvolucaoAnual(
  ano,
  municipio,
  quantidade = 5
) {
  return [
    {
      id: "pessoalLegislativoEvolucaoAnual",
      run: "Municipio.Pessoal.Legislativo.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Legislativo.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function pessoalLegislativoRankingDespesa(ano, municipio) {
  return [
    {
      id: "pessoalLegislativoRankingDespesa",
      run: "Municipio.Pessoal.Legislativo.RankingDespesa",
      args: [ano, municipio]
    }
  ];
}

export function pessoalLegislativoRankingDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalLegislativoRankingDespesaPerCapita",
      run: "Municipio.Pessoal.Legislativo.RankingDespesaPerCapita",
      args: [ano, municipio]
    }
  ];
}
