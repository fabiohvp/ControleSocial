<script>
  import Loading from "../Navigation/Loading.svelte";
  import Chart from "./Chart.svelte";
  import "echarts/lib/chart/pie";
  import "echarts/lib/component/legendScroll";
  import "echarts/lib/component/tooltip";

  export let data;
  export let legends = undefined;
  export let tooltip = undefined;
  export let options = undefined;

  let chart = { update: () => {} };

  $: if (data) {
    chart.update();
  }

  function onRender({ detail: chart }) {
    chart.showLoading();

    chart.setOption({
      tooltip: {
        trigger: "item",
        formatter: "{b}<br>{c} ({d}%)",
        ...tooltip
      },
      legend: {
        type: "plain",
        orient: "vertical",
        left: "52%",
        top: 10,
        icon: "circle",
        ...legends
      },
      series: [
        {
          type: "pie",
          radius: ["50%", "80%"],
          center: ["20%", "50%"],
          label: {
            normal: {
              show: false
            }
          },
          data
        }
      ],
      ...options
    });

    chart.hideLoading();
  }
</script>

{#if data}
  <Chart bind:this={chart} on:render={onRender} />
{:else}
  <Loading />
{/if}
