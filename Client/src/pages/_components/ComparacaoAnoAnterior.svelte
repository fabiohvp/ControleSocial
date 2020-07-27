<script>
  import Widget from "../../components/Widget/Widget.svelte";
  import Series from "../../components/Chart/Series.svelte";
  import Loading from "../../components/Navigation/Loading.svelte";

  export let model;
  export let seriesProperty;

  const tooltip = {
    axisPointer: {
      type: "shadow"
    }
  };
  let series;
  let xAxis;

  const yAxis = {
    type: "value",
    position: "top",
    splitLine: { lineStyle: false /*{ type: "dashed" }*/ }
  };

  $: render(model);

  function render(model) {
    if (!model || !model.value) {
      return;
    }

    const anos = [];
    const data = [];

    for (let i = 1; i < model.value.length; i++) {
      const anterior = model.value[i - 1][seriesProperty];
      const atual = model.value[i][seriesProperty];

      data.push(Math.round(100 - (anterior * 100) / atual));
      anos.push(model.value[i].ano);
    }

    xAxis = {
      type: "category",
      axisTick: { show: false },
      data: anos
    };

    series = [
      {
        type: "bar",
        label: {
          normal: {
            show: true,
            formatter: "{c}%"
          }
        },
        data
      }
    ];
  }
</script>

<Widget>
  <span slot="title">
    <slot name="title" />
  </span>
  <span slot="tooltip">
    Possibilita comparar o montante arrecadado no exercício (ano) em relação à
    arrecadação ocorrida no exercício anterior.
  </span>
  <div class="h-48">
    {#if model}
      <Series {xAxis} {yAxis} {series} {tooltip} />
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
