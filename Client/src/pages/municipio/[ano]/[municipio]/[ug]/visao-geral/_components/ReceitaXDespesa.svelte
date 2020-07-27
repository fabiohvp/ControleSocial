<script>
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Series from "../../../../../../../components/Chart/Series.svelte";

  export let remessaReceita;
  export let remessaDespesa;

  const grid = {
    left: 130,
    top: 30,
    height: "80%"
  };
  const tooltip = {
    trigger: "axis",
    axisPointer: {
      type: "shadow"
    }
  };
  let series;
  let xAxis;
  let yAxis;

  $: render(remessaReceita, remessaDespesa);

  function render(remessaReceita, remessaDespesa) {
    if (!remessaReceita || !remessaDespesa) {
      series = null;
      return;
    }

    yAxis = {
      type: "category",
      data: [
        "Receita prevista",
        "Receita arrecadada",
        "Despesa prevista",
        "Despesa liquidada"
      ]
    };

    xAxis = {
      type: "value",
      show: false
    };
    try {
      series = [
        {
          type: "bar",
          position: "left",
          data: [
            remessaReceita.value.previsaoInicial,
            remessaReceita.value.arrecadada,
            remessaDespesa.value.previsaoInicial,
            remessaDespesa.value.liquidada
          ]
        }
      ];
    } catch {
      console.log(remessaReceita, remessaDespesa);
    }
  }
</script>

<Widget noTooltip={true}>
  <span slot="title">Receitas X Despesas</span>
  <div class="h-40">
    <Series {grid} {xAxis} {yAxis} {series} {tooltip} />
  </div>
</Widget>
