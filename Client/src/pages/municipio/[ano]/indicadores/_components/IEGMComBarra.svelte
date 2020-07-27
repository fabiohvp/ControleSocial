<script>
  import Barra from "./Barra.svelte";

  export let label;
  export let value;
  export let isPositivo = v => v >= 0;

  let formatted = "";

  $: switch (value) {
    case 1:
      formatted = "A";
      break;
    case 2:
      formatted = "B+";
      break;
    case 3:
      formatted = "B";
      break;
    case 4:
      formatted = "C+";
      break;
    case 5:
      formatted = "C";
      break;
    default:
      formatted = "?";
      break;
  }

  function getPercentual(value) {
    if (!value) {
      value = 6;
    }
    value = 6 - value;
    return (value * 100) / 5;
  }
</script>

<td data-label={label} class="text-right" title={formatted}>
  <slot />
  {formatted}
  <Barra value={getPercentual(value)} {isPositivo} />
</td>
