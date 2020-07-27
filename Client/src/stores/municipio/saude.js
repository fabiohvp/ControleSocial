export function saudeEvolucaoAnual(ano, municipio, quantidade = 5) {
  return [
    {
      id: "saudeEvolucaoAnual",
      run: "Municipio.Saude.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Saude.EvolucaoAnual",
      args: [ano, quantidade]
    }
  ];
}

export function saudeEvolucaoAnualPerCapita(ano, municipio, quantidade = 5) {
  return [
    {
      id: "saudeEvolucaoAnualPerCapita",
      run: "Municipio.Saude.FiltrarPorCodigo",
      args: [municipio],
      continue: true,
      evaluate: false
    },
    {
      run: "Municipio.Saude.EvolucaoAnualPerCapita",
      args: [ano, quantidade]
    }
  ];
}

export function saudeRankingAplicacao(ano, municipio) {
  return [
    {
      id: "saudeRankingAplicacao",
      run: "Municipio.Saude.RankingAplicacao",
      args: [ano, municipio]
    }
  ];
}

export function saudeRankingAplicacaoPerCapita(ano, municipio) {
  return [
    {
      id: "saudeRankingAplicacaoPerCapita",
      run: "Municipio.Saude.RankingAplicacaoPerCapita",
      args: [ano, municipio]
    }
  ];
}
