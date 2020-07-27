<script>
  import Icon from "fa-svelte";
  import { faInfoCircle } from "@fortawesome/free-solid-svg-icons/faInfoCircle";
  import Tooltip from "../../components/Navigation/Tooltip.svelte";

  export let noTooltip = false;
  let tooltip;

  function showTooltip(e) {
    tooltip.show(e);
  }

  function hideTooltip(e) {
    tooltip.hide(e);
  }
</script>

<div class="float-left rounded w-full" style="border:1px solid #f0f0f0;">
  <div class="bg-gray-100 flex justify-between text-sm">
    <span class="w-full relative border-b pl-2 leading-loose">
      <p class="w-full font-semibold">
        <slot name="title" />
      </p>
      <span
        class:hidden={noTooltip}
        class="absolute top-0 right-0"
        on:mouseover={showTooltip}
        on:mouseout={hideTooltip}>
        <Tooltip bind:this={tooltip}>
          <span slot="icon" class="text-gray-400 hover:text-gray-700 pr-2">
            <Icon icon={faInfoCircle} />
          </span>
          <span class="leading-none">
            <slot name="tooltip" />
          </span>
        </Tooltip>
      </span>
    </span>
  </div>
  <div class="bg-white p-2 md:p-1">
    <slot />
  </div>
</div>
