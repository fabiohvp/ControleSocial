<script>
  import { route } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import PrestacaoContaMensal from "../_components/PrestacaoContaMensal.svelte";
  import ReceitaXDespesaEvolucaoAnual from "../../../../../_components/ReceitaXDespesaEvolucaoAnual.svelte";
  import ReceitaXDespesaEvolucaoMensal from "../../../../../_components/ReceitaXDespesaEvolucaoMensal.svelte";
  import ReceitaXDespesa from "../../../../../_components/ReceitaXDespesa.svelte";
  import CardLiquidada from "./_components/CardLiquidada.svelte";
  import ComparacaoAnoAnterior from "../../../../../_components/ComparacaoAnoAnterior.svelte";
  import Destaques from "./_components/Destaques.svelte";
  import MaioresDespesasPorFuncao from "./_components/MaioresDespesasPorFuncao.svelte";
  import Treemap from "./_components/Treemap.svelte";

  import * as despesaApi from "../../../../../../stores/municipio/despesa.js";
  import * as gestaoApi from "../../../../../../stores/municipio/gestao.js";
  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";
  import * as receitaApi from "../../../../../../stores/municipio/receita.js";

  const store = api.createStore();
  $: refresh($route);

  async function refresh({ params }) {
    console.log("despesas");
    const ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;

    await api.post(
      api.getApiUrl("DWControleSocial"),
      prestacaoContaApi
        .prestacaoContaMensal(
          ano,
          ug === "consolidado" ? municipio + "E0700001" : municipio
        )
        .concat(despesaApi.despesaEvolucaoAnual(ano, municipio))
        .concat(despesaApi.despesaEvolucaoMensal(ano, municipio))
        .concat(despesaApi.despesaLiquidada(ano, municipio))
        .concat(despesaApi.despesaMaioresLiquidadaPorFuncao(ano, municipio))
        .concat(despesaApi.despesaPaga(ano, municipio))
        .concat(despesaApi.despesaPrevisaoInicial(ano, municipio))
        .concat(receitaApi.receitaEvolucaoAnual(ano, municipio, 6))
        .concat(receitaApi.receitaEvolucaoMensal(ano, municipio))
        .concat(receitaApi.receitaPrevisaoInicial(ano, municipio)),
      { store }
    );

    $store.despesaRemessaAtual = {
      value: $store.despesaEvolucaoAnual.value.find((o) => o.ano === ano),
    };
    $store.receitaRemessaAtual = {
      value: $store.receitaEvolucaoAnual.value.find((o) => o.ano === ano),
    };
  }
</script>

<svelte:head>
  <title>CIDADES - PLATAFORMA PARA TRANSPARÊNCIA PÚBLICA</title>
</svelte:head>

<div class="pl-1">
  <PrestacaoContaMensal model={$store.prestacaoContaMensal} />
</div>

<div class="flex flex-wrap w-full">
  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <CardLiquidada remessa={$store.despesaRemessaAtual} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <MaioresDespesasPorFuncao
      despesasPorFuncao={$store.despesaMaioresLiquidadaPorFuncao} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <ReceitaXDespesa
      remessaReceita={$store.receitaRemessaAtual}
      remessaDespesa={$store.despesaRemessaAtual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <ReceitaXDespesaEvolucaoAnual
      view="despesa"
      receita={$store.receitaEvolucaoAnual}
      despesa={$store.despesaEvolucaoAnual}>
      <span slot="title">Evolução anual da Despesa</span>
      <span slot="tooltip">
        Possibilita comparar os gastos realizados com o montante arrecadado no
        exercício e identificar a ocorrência de déficit (despesa maior que
        receita) ou superávit (receita maior que despesa).
      </span>
    </ReceitaXDespesaEvolucaoAnual>
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <ComparacaoAnoAnterior
      model={$store.despesaEvolucaoAnual}
      seriesProperty="empenhada">
      <span slot="title">Despesa empenhada em relação ao ano anterior</span>
    </ComparacaoAnoAnterior>
  </div>

  <div class="w-full p-1">
    <Destaques />
  </div>

  <div class="w-full p-1">
    <ReceitaXDespesaEvolucaoMensal
      view="despesa"
      receita={$store.receitaEvolucaoMensal}
      despesa={$store.despesaEvolucaoMensal}>
      <span slot="title">Evolução mensal das Despesas</span>
      <span slot="tooltip">
        PossPossibilita comparar os gastos realizados com o montante arrecadado
        no exercício e identificar a ocorrência de déficit (despesa maior que
        receita) ou superávit (receita maior que despesa).
      </span>
    </ReceitaXDespesaEvolucaoMensal>
  </div>

  <!-- <div class="w-full p-1">
    <Treemap />
  </div> -->
</div>
