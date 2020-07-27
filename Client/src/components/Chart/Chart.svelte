<script context="module">
  export function getHorizontalMarkLine(value, label) {
    return {
      data: [
        {
          xAxis: 0,
          yAxis: value,
          symbol: "none",
          lineStyle: {
            normal: {
              color: "#ec663c"
            }
          },
          label: {
            normal: {
              show: true,
              position: "end",
              formatter: label
            }
          }
        }
      ]
    };
  }
</script>

<script>
  import { createEventDispatcher, onDestroy, onMount } from "svelte";
  import { visible as drawerVisible } from "../Drawer/Drawer.svelte";
  import echarts from "echarts/lib/echarts";

  const dispatch = createEventDispatcher();

  let element;
  let instance;
  let width;

  onMount(async () => {
    instance = echarts.init(element);
  });

  onDestroy(() => {
    if (instance) {
      instance.dispose();
    }
  });

  $: width & $drawerVisible & resize();

  export function getInstance() {
    return instance;
  }

  export function getElement() {
    return element;
  }

  export function update() {
    dispatch("render", instance);
  }

  export function resize() {
    if (!instance) {
      return;
    }
    instance.resize();
  }
</script>

<svelte:window bind:innerWidth={width} />
<div bind:this={element} style="height:100%;width:100%;" />
