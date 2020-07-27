<script>
  import Widget from "../../components/Widget/Widget.svelte";
  import Series from "../../components/Chart/Series.svelte";
  import Loading from "../../components/Navigation/Loading.svelte";

  export let model;
  export let seriesName;
  export let seriesProperty;

  const meses = [
    "Jan",
    "Fev",
    "Mar",
    "Abr",
    "Mai",
    "Jun",
    "Jul",
    "Ago",
    "Set",
    "Out",
    "Nov",
    "Dez"
  ];
  const options = {
    legend: {
      show: false
    }
  };
  const yAxis = { show: false };
  const xAxis = [
    {
      type: "category",
      data: meses,
      axisPointer: {
        type: "shadow"
      }
    }
  ];

  let series;
  let tooltipRef = { innerHTML: "" };

  $: refresh(model);

  function refresh(model) {
    if (!model) {
      return;
    }
    const values = [];

    model.value.forEach(o => {
      values.push(o[seriesProperty]);
    });

    series = [
      {
        type: "bar",
        name: seriesName,
        data: values
      }
    ];
  }
</script>

<Widget noTooltip={tooltipRef.innerHTML.trim().length === 0}>
  <span slot="title">Evolução mensal</span>
  <span slot="tooltip" bind:this={tooltipRef}>
    <slot name="tooltip" />
  </span>
  <div class="h-48">
    {#if model}
      <Series {xAxis} {yAxis} {series} {options} />
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
