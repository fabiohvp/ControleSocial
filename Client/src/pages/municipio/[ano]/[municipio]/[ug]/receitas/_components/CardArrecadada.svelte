<script>
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import { format } from "../../../../../../../utils/number.js";

  export let remessa;
  // export let numeroHabitantes;
</script>

<Widget>
  <span slot="title">Receita arrecadada</span>
  <span slot="tooltip">
    É o montante total (impostos, taxas, contribuições e outras fontes de
    recursos) incorporado ao patrimônio que serve para custear as despesas
    públicas e as necessidades de investimentos públicos.
  </span>
  <div class="h-48">
    {#if remessa}
      <div class="text-center">
        <span class="text-sm">R$</span>
        <span class="text-4xl font-bold">
          {format(remessa.value.arrecadada)}
        </span>
      </div>
      <!-- <div>
        <span class="text-base">Per capita</span>
        <span class="text-base float-right font-bold">
          {remessa.value.arrecadada / numeroHabitantes.value}
        </span>
      </div> -->
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
