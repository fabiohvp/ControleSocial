<script>
  import Widget from "../../components/Widget/Widget.svelte";
  import Series from "../../components/Chart/Series.svelte";
  import Loading from "../../components/Navigation/Loading.svelte";

  export let model;
  export let seriesName;
  export let seriesProperty;
  let tooltipRef = { innerHTML: "" };

  const options = {
    legend: {
      show: false
    }
  };
  const yAxis = { show: false };

  let xAxis;
  let series;

  $: refresh(model);

  function refresh(model) {
    if (!model) {
      return;
    }
    const anos = [];
    const values = [];

    model.value.forEach(o => {
      anos.push(o.ano);
      values.push(o[seriesProperty]);
    });

    xAxis = [
      {
        type: "category",
        data: anos,
        axisPointer: {
          type: "shadow"
        }
      }
    ];

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
  <span slot="title">Evolução anual</span>
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
