<script>
  import Barra from "./Barra.svelte";
  import { format2Decimals } from "../../../../../utils/number.js";

  export let label;
  export let value;
  export let isPositivo = v => v >= 0;

  $: formatted = format2Decimals(value);
</script>

<td data-label={label} class="text-right" title={formatted + '%'}>
  <slot />
  {formatted}%
  <Barra {value} {isPositivo} />
</td>
