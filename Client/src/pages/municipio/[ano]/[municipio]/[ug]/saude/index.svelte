<script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import EvolucaoAnualAplicacao from "./_components/EvolucaoAnualAplicacao.svelte";
  import EvolucaoAnualAplicacaoPerCapita from "./_components/EvolucaoAnualAplicacaoPerCapita.svelte";
  import EvolucaoAnualLimiteConstitucional from "./_components/EvolucaoAnualLimiteConstitucional.svelte";
  import EvolucaoAnualReceitaXAplicacao from "./_components/EvolucaoAnualReceitaXAplicacao.svelte";
  import CardAplicacao from "./_components/CardAplicacao.svelte";
  import CardAplicacaoPerCapita from "./_components/CardAplicacaoPerCapita.svelte";
  import LimiteConstitucionalSaude from "../_components/LimiteConstitucionalSaude.svelte";
  import PrestacaoContaMensal from "../_components/PrestacaoContaMensal.svelte";

  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";
  import * as saudeApi from "../../../../../../stores/municipio/saude.js";

  let ano;
  let data = {};
  let limite;

  $: api && refresh($params);
  $: if (data.saudeAplicacao) {
    limite = data.saudeAplicacao.value.limiteConstitucional;
  }

  function refresh(params) {
    ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;
    data = {};

    api.post(
      api.getApiUrl("ControleSocial"),
      saudeApi
        .saudeEvolucaoAnual(ano, municipio)
        .concat(saudeApi.saudeEvolucaoAnualPerCapita(ano, municipio))
        .concat(saudeApi.saudeRankingAplicacao(ano, municipio))
        .concat(saudeApi.saudeRankingAplicacaoPerCapita(ano, municipio))
        .concat(prestacaoContaApi.prestacaoContaPCB(ano, municipio))
    );
  }

  function onResult({ detail: json }) {
    if (!data[json.id]) {
      switch (json.id) {
        case "saudeEvolucaoAnual":
          data["saudeAplicacao"] = {
            id: "saudeAplicacao",
            value: json.value.find(o => o.ano === ano)
          };
          data[json.id] = json;
          break;
        case "saudeEvolucaoAnualPerCapita":
          data["saudeAplicacaoPerCapita"] = {
            id: "saudeAplicacaoPerCapita",
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
  <title>Saúde</title>
</svelte:head>

<div class="pl-1">
  <PrestacaoContaMensal model={data.prestacaoContaPCB} />
</div>

<div class="flex flex-wrap w-full">
  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <CardAplicacao
      model={data.saudeAplicacao}
      posicaoRanking={data.saudeRankingAplicacao} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <CardAplicacaoPerCapita
      model={data.saudeAplicacaoPerCapita}
      posicaoRanking={data.saudeRankingAplicacaoPerCapita} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalSaude {limite} height={48} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualAplicacao model={data.saudeEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualReceitaXAplicacao model={data.saudeEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualLimiteConstitucional model={data.saudeEvolucaoAnual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <EvolucaoAnualAplicacaoPerCapita model={data.saudeEvolucaoAnualPerCapita} />
  </div>
</div>
