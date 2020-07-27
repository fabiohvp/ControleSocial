<script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";

  $: refresh($params);

  function refresh(params) {
    const ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;

    api.post(
      api.getApiUrl("DWControleSocial"),
      prestacaoContaApi.prestacaoContaMensal(ano, municipio)
    );
  }
</script>

<svelte:head>
  <title>Obrigações junto ao TCE-ES</title>
</svelte:head>

<p class="text-lg m-2 border-b">
  Situações das remessas de dados obrigatórias dos órgãos públicos do município
  para o Tribunal de Contas
</p>

<div class="flex flex-wrap w-full">
  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1" />

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1" />

  <div class="w-full p-1" />
</div>
