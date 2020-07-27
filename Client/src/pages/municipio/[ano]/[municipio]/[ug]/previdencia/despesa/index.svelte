<script context="module">
  export async function preload(page, session) {
    return { params: page.params };
  }
</script>

<script>
  import { onMount } from "svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Gauge from "../../../../../../../components/Chart/Gauge.svelte";

  export let params;
  let data;

  onMount(async () => {
    const { ano, municipio, ug } = params;

    const res = await fetch(
      `municipio/${ano}/${municipio}/${ug}/despesa/data.json`
    );

    if (res.status === 200) {
      data = await res.json();
    } else {
      //this.error(res.status, data.message);
    }
  });
</script>

<svelte:head>
  <title>Despesas - Previdência</title>
</svelte:head>

<div class="flex flex-wrap w-full">
  <Widget class="xl:w-1/4 lg:w-1/3 sm:w-1/2 w-full">
    <span slot="title">Saúde</span>
    <span slot="tooltip">
      A Constituição Federal estabelece que o município deve aplicar o limite
      mínimo de 15% da soma dos recursos de impostos e transferências em ações e
      serviços públicos de saúde.
    </span>
    <div class="h-48">
      <Gauge {data} />
    </div>
  </Widget>
</div>
