<script>
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";

  export let model;
  export let posicaoRanking;
</script>

<Widget>
  <span slot="title">Despesa per capita</span>
  <span slot="tooltip">
    A Constituição Federal estabelece que o município deve aplicar o limite
    mínimo de 25% da receita resultante de impostos, incluídas transferências de
    impostos, para a manutenção e desenvolvimento do ensino."}
  </span>
  <div class="h-48">
    {#if model && posicaoRanking}
      <div class="text-center">
        <span class="text-sm">R$</span>
        <span class="text-4xl font-bold">{model.value.despesaPerCapita}</span>
      </div>
      <div>
        <span class="text-base">Média municipal</span>
        <span class="text-base float-right font-bold">
          {model.value.mediaMunicipal}
        </span>
      </div>
      <div>
        <span class="text-base">Posição</span>
        <span class="text-base float-right font-bold">
          {posicaoRanking.value}º
        </span>
      </div>
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
