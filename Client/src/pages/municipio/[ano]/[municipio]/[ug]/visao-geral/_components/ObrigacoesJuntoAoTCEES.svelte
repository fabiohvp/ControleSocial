<script>
  import Icon from "fa-svelte";
  import { faCheckCircle } from "@fortawesome/free-solid-svg-icons/faCheckCircle";
  import { faExclamationCircle } from "@fortawesome/free-solid-svg-icons/faExclamationCircle";
  import Widget from "../../../../../../../components/Widget/Widget.svelte";

  export let obrigacoes;
</script>

<style>
  .obrigacao {
    position: relative;
  }

  .obrigacao:not(:last-child)::after {
    content: " ";
    position: absolute;
    background-color: #ccc;
    height: 1px;
    width: calc(100% - 3.8rem);
    left: calc(50% + 1.9rem);
    top: 50%;
    z-index: 1;
  }

  .emDia {
    color: green;
  }

  .emAtraso {
    color: red;
  }
</style>

<Widget noTooltip={true}>
  <span slot="title">Obrigações junto ao TCE-ES</span>
  <div class="h-40 text-center">
    {#each obrigacoes as item, index (item)}
      <div class="obrigacao float-left w-1/{obrigacoes.length}">
        <div class="text-6xl">
          {#if item.situacao >= 0}
            <span class="emDia">
              <Icon icon={faCheckCircle} />
            </span>
          {:else}
            <span class="emAtraso">
              <Icon icon={faExclamationCircle} />
            </span>
          {/if}
        </div>
        <div>{item.ano}</div>
      </div>
    {/each}
  </div>
</Widget>
