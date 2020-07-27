<script>
  import Destaque from "../../_components/Destaque.svelte";

  import {
    receitaEvolucaoAnual,
    receitaEvolucaoMensal
  } from "../../../../../../../stores/municipio/receita.js";

  export let model;
  export let workflow;
  export let title;
</script>

<Destaque
  {model}
  {workflow}
  workflowAnual={receitaEvolucaoAnual}
  workflowMensal={receitaEvolucaoMensal}
  {title}
  seriesName="Receita arrecadada"
  seriesProperty="arrecadada">
  <span slot="icon">
    <slot name="icon" />
  </span>
  <span slot="title">
    <slot name="title" />
  </span>
</Destaque>
