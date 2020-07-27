<script>
  import Loading from "../Navigation/Loading.svelte";
  import Chart from "./Chart.svelte";

  import "echarts/lib/chart/bar";
  import "echarts/lib/chart/line";
  import "echarts/lib/component/legend";
  import "echarts/lib/component/tooltip";

  export let xAxis = {};
  export let yAxis;
  export let series;
  export let grid = undefined;
  export let legends = undefined;
  export let tooltip = undefined;
  export let options = undefined;

  let chart;

  $: if (series && chart) {
    chart.update();
  }

  function onRender({ detail: chart }) {
    chart.showLoading();

    chart.setOption({
      grid,
      tooltip: {
        trigger: "axis",
        axisPointer: {
          type: "cross",
          crossStyle: {
            color: "#999"
          }
        },
        ...tooltip
      },
      legend: {
        bottom: -5,
        textStyle: {
          fontSize: 10
        },
        ...legends
      },
      xAxis,
      yAxis,
      series,
      ...options
    });

    chart.hideLoading();
  }
</script>

{#if series}
  <div class="h-full">
    &nbsp;
    <div style="margin-top:-40px;height:calc(100% + 20px)">
      <Chart bind:this={chart} on:render={onRender} />
    </div>
  </div>
{:else}
  <Loading />
{/if}
