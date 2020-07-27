<script>
  import { format2Decimals } from "../../../../../utils/number.js";

  export let height = "10px";
  export let value;
  export let isPositivo = v => v >= 0;

  $: absoluteValue = Math.abs(value);
  $: formatted = format2Decimals(value);

  $: marginLeft =
    absoluteValue > 100 ? "" : `margin-left:${100 - absoluteValue}%;`;
</script>

<style>
  .positive {
    background-color: #2872a8;
  }

  .negative {
    background-color: #b37476;
  }
</style>

<div
  class="w-full text-right"
  style={`height:${height}`}
  title={formatted + '%'}>
  <div
    class="h-full"
    class:positive={isPositivo(value)}
    class:negative={!isPositivo(value)}
    style={`width:${absoluteValue}%;max-width:100%;min-width:1px;${marginLeft}`} />
</div>
