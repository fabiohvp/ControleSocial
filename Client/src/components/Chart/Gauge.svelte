<script>
  import Loading from "../Navigation/Loading.svelte";
  import Chart from "./Chart.svelte";
  import "echarts/lib/chart/gauge";
  import "echarts/lib/component/tooltip";

  export let serie;
  export let tooltip = undefined;
  export let options = undefined;

  let chart = { update: () => {} };

  $: if (serie || options) {
    chart.update();
  }

  function onRender({ detail: chart }) {
    chart.showLoading();

    chart.setOption({
      tooltip: {
        formatter: "{c} {b}",
        ...tooltip
      },
      series: [
        {
          type: "gauge",
          min: 0,
          max: 100,
          startAngle: 180,
          endAngle: 0,
          radius: "100%",
          splitNumber: 1,
          axisLabel: {
            show: false
          },
          axisLine: {
            lineStyle: {
              width: 35
            }
          },
          axisTick: {
            show: false
          },
          itemStyle: {
            color: "#000"
          },
          pointer: {
            length: "90%"
          },
          splitLine: {
            show: false
          },
          detail: {
            formatter: function(value) {
              value = (value + "").split(".");
              value.length < 2 && value.push("00");
              return (
                ("00" + value[0]).slice(-2) +
                "." +
                (value[1] + "00").slice(0, 2)
              );
            },
            color: "#000",
            fontWeight: "normal",
            fontSize: 14
          },
          ...serie
        }
      ],
      ...options
    });

    chart.hideLoading();
  }
</script>

{#if serie}
  <div class="h-full">
    &nbsp;
    <div style="margin-top:-15px;height:100%;">
      <Chart bind:this={chart} on:render={onRender} />
    </div>
  </div>
{:else}
  <Loading />
{/if}
