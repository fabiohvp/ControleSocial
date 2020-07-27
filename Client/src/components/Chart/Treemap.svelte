<script>
  import Loading from "../Navigation/Loading.svelte";
  import Chart from "./Chart.svelte";

  import "echarts/lib/chart/treemap";
  import "echarts/lib/component/tooltip";

  export let name = "Visão geral";
  export let data;
  export let levels = undefined;
  export let tooltip = undefined;
  export let options = undefined;

  let chart;

  $: if (data && chart) {
    chart.update();
  }

  function onRender({ detail: chart }) {
    chart.showLoading();

    chart.setOption({
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
      series: [
        {
          type: "treemap",
          roam: false,
          name,
          data,
          levels,
          leafDepth: 1
          //animation: false
        }
      ],
      ...options
    });

    chart.hideLoading();
  }
</script>

{#if data}
  <div class="h-full">
    &nbsp;
    <div style="margin-top:-40px;height:calc(100% + 20px)">
      <Chart bind:this={chart} on:render={onRender} />
    </div>
  </div>
{:else}
  <Loading />
{/if}
