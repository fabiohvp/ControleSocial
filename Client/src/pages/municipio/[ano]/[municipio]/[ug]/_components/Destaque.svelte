<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import api from "../../../../../../utils/api.js";
  import { format } from "../../../../../../utils/number.js";
  import Loading from "../../../../../../components/Navigation/Loading.svelte";
  import Modal from "../../../../../../components/Navigation/Modal.svelte";
  import EvolucaoAnual from "../../../../../_components/EvolucaoAnual.svelte";
  import EvolucaoMensal from "../../../../../_components/EvolucaoMensal.svelte";

  const ano = parseInt($params.ano);
  const ug = $params.ug;
  const municipio = ug === "consolidado" ? $params.municipio : ug;

  export let model;
  export let workflow;
  export let workflowAnual;
  export let workflowMensal;
  export let title;
  export let seriesName;
  export let seriesProperty;

  let modalRef;
  let seriesEvolucaoAnual;
  let seriesEvolucaoMensal;

  function getDestaqueEvolucaoAnual(ano, municipio) {
    const workflows = workflow(ano, municipio, workflowAnual);
    workflows[0].id = "destaqueEvolucaoAnual";
    return workflows;
  }

  function getDestaqueEvolucaoMensal(ano, municipio) {
    const workflows = workflow(ano, municipio, workflowMensal);
    workflows[0].id = "destaqueEvolucaoMensal";
    return workflows;
  }

  async function onClick() {
    modalRef.show();

    if (!seriesEvolucaoAnual || !seriesEvolucaoMensal) {
      const res = await axios.post(
        api.getApiUrl("DWControleSocial"),
        getDestaqueEvolucaoAnual(ano, municipio).concat(
          getDestaqueEvolucaoMensal(ano, municipio)
        )
      );

      if (res.data[0].id === "destaqueEvolucaoAnual") {
        seriesEvolucaoAnual = res.data[0];
        seriesEvolucaoMensal = res.data[1];
      } else {
        seriesEvolucaoAnual = res.data[1];
        seriesEvolucaoMensal = res.data[0];
      }
    }
  }
</script>

<style>
  .destaque {
    color: #364b60;
    @apply w-full;
    @apply h-full;
    @apply float-left;
    @apply cursor-pointer;
  }
</style>

<span style="position:relative;">
  <span class="destaque" on:click={onClick}>
    <div class="text-3xl h-full float-left px-2">
      <slot name="icon" />
    </div>
    <div class="text-lg w-full">
      <slot name="title" />
    </div>
    {#if model}
      <div class="text-lg w-full font-bold">{format(model.value)}</div>
    {:else}
      <Loading />
    {/if}
  </span>

  <Modal bind:this={modalRef} class="w-full">
    <span slot="header">{title}</span>
    <hr class="mb-3" />

    {#if seriesEvolucaoAnual && seriesEvolucaoMensal}
      <div class="mb-3">
        <EvolucaoAnual
          model={seriesEvolucaoAnual}
          {seriesName}
          {seriesProperty} />
      </div>
      <div>
        <EvolucaoMensal
          model={seriesEvolucaoMensal}
          {seriesName}
          {seriesProperty} />
      </div>
    {:else}
      <Loading />
    {/if}
  </Modal>
</span>
