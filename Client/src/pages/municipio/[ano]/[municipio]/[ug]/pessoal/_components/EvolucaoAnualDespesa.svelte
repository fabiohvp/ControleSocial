<script>
  import EvolucaoAnual from "../../../../../../_components/EvolucaoAnual.svelte";
  import Loading from "../../../../../../../components/Navigation/Loading.svelte";

  export let model;
</script>

<div class="mb-3">
  <EvolucaoAnual {model} seriesName="Despesa" seriesProperty="despesa">
    <span slot="tooltip">
      Evolução dos recursos aplicados em saúde nos últimos exercícios.
    </span>
  </EvolucaoAnual>
</div>
