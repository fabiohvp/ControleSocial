export function gestaoNumeroHabitantes(ano, municipio) {
  return [
    {
      id: "gestaoNumeroHabitantes",
      run: "Municipio.Gestao.NumeroHabitantes",
      args: [ano, municipio]
    }
  ];
}

export function gestaoSituacaoPrestacaoContaAnual(ano, municipio) {
  return [
    {
      id: "gestaoSituacaoPrestacaoContaAnual",
      run: "Municipio.Gestao.SituacaoPrestacaoContaAnual",
      args: [ano, municipio]
    }
  ];
}
