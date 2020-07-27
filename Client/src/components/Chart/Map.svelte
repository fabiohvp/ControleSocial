<script>
  import Loading from "../Navigation/Loading.svelte";
  import Chart from "./Chart.svelte";
  import { es } from "../../stores/map.js";
  import "echarts/lib/chart/map";

  export let data;
  export let tooltip = undefined;
  export let visualMap = undefined;
  export let options = undefined;

  let chart = { update: () => {} };

  $: if (data) {
    chart.update();
  }

  function onRender({ detail: chart }) {
    chart.showLoading();

    es.subscribe(data => {
      echarts.registerMap("ES", data);

      chart.setOption({
        aspectScale: 1,
        tooltip: {
          trigger: "item",
          formatter: "{b}",
          ...tooltip
        },
        visualMap: {
          min: 0,
          max: 0,
          inRange: {
            color: ["#67809f"]
          },
          show: false,
          ...visualMap
        },
        series: [
          {
            name: "ES",
            type: "map",
            map: "ES",
            itemStyle: {
              borderColor: "#eee"
            }
          }
        ],
        ...options
      });
    });

    chart.hideLoading();
  }
</script>

{#if data}
  <div class="h-full">
    &nbsp;
    <div style="margin-top:-40px;height:calc(100% + 40px)">
      <Chart bind:this={chart} on:render={onRender} />
    </div>
  </div>
{:else}
  <Loading />
{/if}
