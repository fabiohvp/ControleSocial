<script>
  import Icon from "fa-svelte";
  import { faThumbsUp } from "@fortawesome/free-solid-svg-icons/faThumbsUp";
  import Loading from "../../../../../../components/Navigation/Loading.svelte";
  import Gauge from "../../../../../../components/Chart/Gauge.svelte";
  import Widget from "../../../../../../components/Widget/Widget.svelte";

  export let limite;
  export let height = 40;
  let serie = null;

  $: serie = {
    title: {
      show: false
    },
    axisLine: {
      lineStyle: {
        width: 35,
        color: [[0.15, "#e68465"], [1, "#617e8c"]]
      }
    },
    detail: {
      formatter: function() {
        return limite > 15
          ? "Obedeceu o limite mínimo anual de 15% da receita"
          : "Não obedeceu o limite mínimo de 15% da receita";
      },
      color: "#000",
      fontWeight: "normal",
      fontSize: 14
    },
    data: [{ value: limite }]
  };
</script>

<Widget>
  <span slot="title">Saúde</span>
  <span slot="tooltip">
    A Constituição Federal estabelece que o município deve aplicar o limite
    mínimo de 15% da soma dos recursos de impostos e transferências em ações e
    serviços públicos de saúde.
  </span>
  <div class="h-{height}">
    {#if limite}
      <div class="text-center h-full">
        <span class="text-3xl">
          <Icon icon={faThumbsUp} />
          {limite} %
        </span>
        <div class="h-full" style="margin-top:-.8em;">
          <Gauge {serie} />
        </div>
      </div>
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
