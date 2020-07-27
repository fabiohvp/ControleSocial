export function educacaoEvolucaoAnual(ano, municipio, quantidade = 5) {
  return [
    {
      id: "educacaoEvolucaoAnual",
      run: "Municipio.Educacao.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Educacao.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function educacaoEvolucaoAnualPerCapita(ano, municipio, quantidade = 5) {
  return [
    {
      id: "educacaoEvolucaoAnualPerCapita",
      run: "Municipio.Educacao.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Educacao.EvolucaoAnualPerCapita",
      args: [ano, quantidade]
    }
  ];
}

export function educacaoRankingAplicacao(ano, municipio) {
  return [
    {
      id: "educacaoRankingAplicacao",
      run: "Municipio.Educacao.RankingAplicacao",
      args: [ano, municipio]
    }
  ];
}

export function educacaoRankingAplicacaoPerCapita(ano, municipio) {
  return [
    {
      id: "educacaoRankingAplicacaoPerCapita",
      run: "Municipio.Educacao.RankingAplicacaoPerCapita",
      args: [ano, municipio]
    }
  ];
}
