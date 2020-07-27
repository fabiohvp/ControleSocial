<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Doughnut from "../../../../../../../components/Chart/Doughnut.svelte";

  export let despesasPorFuncao;

  let data;

  $: render(despesasPorFuncao);

  function render(despesasPorFuncao) {
    if (!despesasPorFuncao) {
      return;
    }

    data = despesasPorFuncao.value.map(d => {
      return {
        name: d.nome,
        value: d.valor
      };
    });
  }
</script>

<Widget>
  <span slot="title">Maiores despesas por função</span>
  <span slot="tooltip">
    Cinco maiores despesas liquidadas, classificadas por função.
  </span>
  <div class="h-48">
    <Doughnut {data} />
  </div>
</Widget>
