export function pessoalExecutivoDespesa(ano, municipio) {
  return [
    {
      id: "pessoalExecutivoDespesa",
      run: "Municipio.Pessoal.Executivo.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Executivo.Despesa",
      args: []
    }
  ];
}

export function pessoalExecutivoDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalExecutivoDespesaPerCapita",
      run: "Municipio.Pessoal.Executivo.FiltrarPorAnoECodigo",
      args: [ano, municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Executivo.DespesaPerCapita",
      args: []
    }
  ];
}

export function pessoalExecutivoEvolucaoAnual(ano, municipio, quantidade = 5) {
  return [
    {
      id: "pessoalExecutivoEvolucaoAnual",
      run: "Municipio.Pessoal.Executivo.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Pessoal.Executivo.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function pessoalExecutivoRankingDespesa(ano, municipio) {
  return [
    {
      id: "pessoalExecutivoRankingDespesa",
      run: "Municipio.Pessoal.Executivo.RankingDespesa",
      args: [ano, municipio]
    }
  ];
}

export function pessoalExecutivoRankingDespesaPerCapita(ano, municipio) {
  return [
    {
      id: "pessoalExecutivoRankingDespesaPerCapita",
      run: "Municipio.Pessoal.Executivo.RankingDespesaPerCapita",
      args: [ano, municipio]
    }
  ];
}
