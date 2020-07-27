<script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import EvolucaoAnualAplicacao from "./_components/EvolucaoAnualAplicacao.svelte";
  import EvolucaoAnualAplicacaoPerCapita from "./_components/EvolucaoAnualAplicacaoPerCapita.svelte";
  import EvolucaoAnualLimiteConstitucional from "./_components/EvolucaoAnualLimiteConstitucional.svelte";
  import EvolucaoAnualReceitaXAplicacao from "./_components/EvolucaoAnualReceitaXAplicacao.svelte";
  import CardAplicacao from "./_components/CardAplicacao.svelte";
  import CardAplicacaoPerCapita from "./_components/CardAplicacaoPerCapita.svelte";
  import LimiteConstitucionalEducacao from "../_components/LimiteConstitucionalEducacao.svelte";
  import PrestacaoContaMensal from "../_components/PrestacaoContaMensal.svelte";

  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";
  import * as educacaoApi from "../../../../../../stores/municipio/educacao.js";

  let ano;
  let data = {};
  let limite;

  $: api && refresh($params);
  $: if (data.educacaoAplicacao) {
    limite = data.educacaoAplicacao.value.limiteConstitucional;
  }

  function refresh(params) {
    ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;
    data = {};

    api.post(
      api.getApiUrl("ControleSocial"),
      educacaoApi
        .educacaoEvolucaoAnual(ano, municipio)
        .concat(educacaoApi.educacaoEvolucaoAnualPerCapita(ano, municipio))
        .concat(educacaoApi.educacaoRankingAplicacao(ano, municipio))
        .concat(educacaoApi.educacaoRankingAplicacaoPerCapita(ano, municipio))
        .concat(prestacaoContaApi.prestacaoContaPCB(ano, municipio))
    );
  }

  function onResult({ detail: json }) {
    if (!data[json.id]) {
      switch (json.id) {
        case "educacaoEvolucaoAnual":
          data["educacaoAplicacao"] = {
            id: "educacaoAplicacao",
            value: json.value.find(o => o.ano === ano)
          };
          data[json.id] = json;
          break;
        case "educacaoEvolucaoAnualPerCapita":
          data["educacaoAplicacaoPerCapita"] = {
            id: "educacaoAplicacaoPerCapita",
            value: json.value.find(o => o.ano === ano)
          };
          data[json.id] = json;
          break;
        default:
          data[json.id] = json;
          break;
      }
    }
  }
</script>

<svelte:head>
  <title>Educação</title>
</svelte:head>

<div class="pl-1">
  <PrestacaoContaMensal model={data.prestacaoContaPCB} />
</div>

<div class="flex flex-wrap w-full">
  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <CardAplicacao
      model={data.educacaoAplicacao}
      posicaoRanking={data.educacaoRankingAplicacao} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <CardAplicacaoPerCapita
      model={data.educacaoAplicacaoPerCapita}
      posicaoRanking={data.educacaoRankingAplicacaoPerCapita} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalEducacao {limite} height={48} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualAplicacao model={data.educacaoEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualReceitaXAplicacao model={data.educacaoEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualLimiteConstitucional model={data.educacaoEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualAplicacaoPerCapita
      model={data.educacaoEvolucaoAnualPerCapita} />
  </div>
</div>
