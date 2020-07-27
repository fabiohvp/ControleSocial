<script>
  import Destaque from "../../_components/Destaque.svelte";

  import {
    despesaEvolucaoAnual,
    despesaEvolucaoMensal
  } from "../../../../../../../stores/municipio/despesa.js";

  export let model;
  export let workflow;
  export let title;
</script>

<Destaque
  {model}
  {workflow}
  workflowAnual={despesaEvolucaoAnual}
  workflowMensal={despesaEvolucaoMensal}
  {title}
  seriesName="Despesa liquidada"
  seriesProperty="liquidada">
  <span slot="icon">
    <slot name="icon" />
  </span>
  <span slot="title">
    <slot name="title" />
  </span>
</Destaque>
