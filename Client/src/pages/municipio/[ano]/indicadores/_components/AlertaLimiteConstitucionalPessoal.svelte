<script>
  import Icon from "fa-svelte";
  import { faThumbsDown } from "@fortawesome/free-regular-svg-icons/faThumbsDown";
  import { faThumbsUp } from "@fortawesome/free-regular-svg-icons/faThumbsUp";
  import { faHandPaper } from "@fortawesome/free-regular-svg-icons/faHandPaper";

  export let value;
  export let config = {};
</script>

{#if value > config.limite}
  <span
    class="text-red-800"
    title={`Ultrapassou o limite máximo ${config.limite}%`}>
    <Icon icon={faThumbsDown} />
  </span>
{:else if value > config.limitePrudencial}
  <span
    class="text-orange-500"
    title={`Ultrapassou o limite prudencial ${config.limitePrudencial}%`}>
    <Icon icon={faHandPaper} />
  </span>
{:else if value > config.limiteAlerta}
  <span
    class="text-yellow-400"
    title={`Ultrapassou o limite de alerta ${config.limiteAlerta}%`}>
    <Icon icon={faHandPaper} />
  </span>
{:else}
  <span class="text-blue-800" title={`Obedeceu o limite de ${config.limite}%`}>
    <Icon icon={faThumbsUp} />
  </span>
{/if}
