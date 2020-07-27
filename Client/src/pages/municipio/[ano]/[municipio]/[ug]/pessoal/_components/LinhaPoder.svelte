<script>
  import EvolucaoAnualDespesa from "./EvolucaoAnualDespesa.svelte";
  import CardDespesa from "./CardDespesa.svelte";
  import CardDespesaPerCapita from "./CardDespesaPerCapita.svelte";

  export let titulo;

  export let pessoalDespesa;
  export let rankingDespesa;
  export let pessoalDespesaPerCapita;
  export let rankingDespesaPerCapita;
  export let evolucaoAnual;
</script>

<div class="text-xl p-1">
  {titulo}
  <hr />
</div>
<div class="flex flex-wrap w-full">
  <div class="xl:w-1/5 lg:w-1/2 sm:w-1/2 w-full p-1">
    <CardDespesa model={pessoalDespesa} posicaoRanking={rankingDespesa} />
  </div>

  <div class="xl:w-1/5 lg:w-1/2 sm:w-1/2 w-full p-1">
    <CardDespesaPerCapita
      model={pessoalDespesaPerCapita}
      posicaoRanking={rankingDespesaPerCapita} />
  </div>

  <div class="xl:w-1/5 lg:w-1/2 sm:w-1/2 w-full p-1">
    <slot name="limite" />
  </div>

  <div class="xl:w-2/5 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualDespesa model={evolucaoAnual} />
  </div>
</div>
