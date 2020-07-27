<script>
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";

  export let model;
  export let posicaoRanking;
</script>

<Widget>
  <span slot="title">Aplicação</span>
  <span slot="tooltip">
    Este é o valor aplicado em manutenção e desenvolvimento do ensino, exceto o
    gasto com remuneração de professores.
  </span>
  <div class="h-48">
    {#if model && posicaoRanking}
      <div class="text-center">
        <span class="text-sm">R$</span>
        <span class="text-4xl font-bold">{model.value.aplicacao}</span>
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
