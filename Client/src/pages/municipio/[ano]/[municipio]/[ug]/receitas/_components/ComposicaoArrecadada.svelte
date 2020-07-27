<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Doughnut from "../../../../../../../components/Chart/Doughnut.svelte";

  export let composicaoArrecadada;

  let data;

  $: render(composicaoArrecadada);

  function render(composicaoArrecadada) {
    if (!composicaoArrecadada) {
      return;
    }

    console.log(composicaoArrecadada);
    data = [
      {
        name: "Receitas do município",
        value: composicaoArrecadada.value.receitasDoMunicipio
      },
      {
        name: "Transferências do estado",
        value: composicaoArrecadada.value.transferenciaDoEstado
      },
      {
        name: "Transferências da união",
        value: composicaoArrecadada.value.transferenciaDaUniao
      },
      {
        name: "Operações de crédito",
        value: composicaoArrecadada.value.operacoesDeCredito
      },
      {
        name: "Outras transferências",
        value: composicaoArrecadada.value.outrasTransferencias
      }
    ];
  }
</script>

<Widget>
  <span slot="title">Composição da receita arrecadada</span>
  <span slot="tooltip">
    Distribuição da origem das receitas do município. Este indicador demonstra o
    grau de dependência que o município tem de transferências do Estado e da
    União, apontando se possui arrecadação sustentável ou não.
  </span>
  <div class="h-48">
    <Doughnut {data} />
  </div>
</Widget>
