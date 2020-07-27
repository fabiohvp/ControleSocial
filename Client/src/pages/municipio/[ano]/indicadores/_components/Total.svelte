<script>
  import { format2Decimals } from "../../../../../utils/number.js";

  export let label;
  export let total;
</script>

<td data-label={label} class="text-right font-bold">
  <slot />
  {format2Decimals(total)}
</td>
