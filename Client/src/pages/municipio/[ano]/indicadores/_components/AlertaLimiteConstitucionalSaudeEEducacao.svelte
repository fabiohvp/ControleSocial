<script>
  import Icon from "fa-svelte";
  import { faThumbsDown } from "@fortawesome/free-regular-svg-icons/faThumbsDown";
  import { faThumbsUp } from "@fortawesome/free-regular-svg-icons/faThumbsUp";

  export let value;
  export let config = {};
</script>

{#if value >= config.limite}
  <span class="text-blue-800" title={`Obedeceu o limite de ${config.limite}%`}>
    <Icon icon={faThumbsUp} />
  </span>
{:else}
  <span
    class="text-red-800"
    title={`Ultrapassou o limite máximo ${config.limite}%`}>
    <Icon icon={faThumbsDown} />
  </span>
{/if}
