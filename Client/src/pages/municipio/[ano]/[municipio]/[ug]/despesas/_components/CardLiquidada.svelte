<script>
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import { format } from "../../../../../../../utils/number.js";

  export let remessa;
  // export let numeroHabitantes;
</script>

<Widget>
  <span slot="title">Despesa liquidada</span>
  <span slot="tooltip">
    Informações diversas sobre a despesa liquidada no ano.
  </span>
  <div class="h-48">
    {#if remessa}
      <div class="text-center">
        <span class="text-sm">R$</span>
        <span class="text-4xl font-bold">
          {format(remessa.value.liquidada)}
        </span>
      </div>
      <!-- <div>
        <span class="text-base">Per capita</span>
        <span class="text-base float-right font-bold">
          {remessa.value.liquidada / numeroHabitantes.value}
        </span>
      </div> -->
    {:else}
      <Loading />
    {/if}
  </div>
</Widget>
