<script>
  import { route } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import PrestacaoContaMensal from "../_components/PrestacaoContaMensal.svelte";
  import ReceitaXDespesaEvolucaoAnual from "../../../../../_components/ReceitaXDespesaEvolucaoAnual.svelte";
  import ReceitaXDespesaEvolucaoMensal from "../../../../../_components/ReceitaXDespesaEvolucaoMensal.svelte";
  import ReceitaXDespesa from "../../../../../_components/ReceitaXDespesa.svelte";
  import CardArrecadada from "./_components/CardArrecadada.svelte";
  import ComparacaoAnoAnterior from "../../../../../_components/ComparacaoAnoAnterior.svelte";
  import ComposicaoArrecadada from "./_components/ComposicaoArrecadada.svelte";
  import Destaques from "./_components/Destaques.svelte";
  import Treemap from "./_components/Treemap.svelte";

  import * as despesaApi from "../../../../../../stores/municipio/despesa.js";
  import * as gestaoApi from "../../../../../../stores/municipio/gestao.js";
  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";
  import * as receitaApi from "../../../../../../stores/municipio/receita.js";

  const store = api.createStore();
  $: refresh($route);

  async function refresh({ params }) {
    console.log("receitas");
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
        .concat(despesaApi.despesaPaga(ano, municipio))
        .concat(despesaApi.despesaPrevisaoInicial(ano, municipio))
        .concat(receitaApi.receitaComposicaoArrecadada(ano, municipio))
        .concat(receitaApi.receitaEvolucaoAnual(ano, municipio, 6))
        .concat(receitaApi.receitaEvolucaoMensal(ano, municipio))
        .concat(receitaApi.receitaPrevisaoInicial(ano, municipio)),
      { store }
    );

    $store.despesaRemessaAtual = {
      value: $store.despesaEvolucaoAnual.value.find(o => o.ano === ano)
    };
    $store.receitaRemessaAtual = {
      value: $store.receitaEvolucaoAnual.value.find(o => o.ano === ano)
    };

    $store.receitaComposicaoArrecadada = {
      value: {
        operacoesDeCredito: $store.receitaDestaqueOperacoesDeCredito.value,
        receitasDoMunicipio: $store.receitaDestaqueReceitasDoMunicipio.value,
        transferenciaDaUniao: $store.receitaDestaqueTransferenciasDaUniao.value,
        transferenciaDoEstado:
          $store.receitaDestaqueTransferenciasDoEstado.value,
        outrasTransferencias: $store.receitaDestaqueOutrasTransferencias.value
      }
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
    <CardArrecadada remessa={$store.receitaRemessaAtual} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <ComposicaoArrecadada
      composicaoArrecadada={$store.receitaComposicaoArrecadada} />
  </div>

  <div class="xl:w-1/3 lg:w-1/3 sm:w-1/2 w-full p-1">
    <ReceitaXDespesa
      remessaReceita={$store.receitaRemessaAtual}
      remessaDespesa={$store.despesaRemessaAtual} />
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <ReceitaXDespesaEvolucaoAnual
      view="receita"
      receita={$store.receitaEvolucaoAnual}
      despesa={$store.despesaEvolucaoAnual}>
      <span slot="title">Evolução anual da Receita</span>
      <span slot="tooltip">
        Possibilita comparar os gastos realizados com o montante arrecadado no
        exercício e identificar a ocorrência de déficit (despesa maior que
        receita) ou superávit (receita maior que despesa).
      </span>
    </ReceitaXDespesaEvolucaoAnual>
  </div>

  <div class="xl:w-1/2 lg:w-1/2 sm:w-1/2 w-full p-1">
    <ComparacaoAnoAnterior
      model={$store.receitaEvolucaoAnual}
      seriesProperty="arrecadada">
      <span slot="title">Arrecadação comparada ao ano anterior</span>
    </ComparacaoAnoAnterior>
  </div>

  <div class="w-full p-1">
    <Destaques />
  </div>

  <div class="w-full p-1">
    <ReceitaXDespesaEvolucaoMensal
      view="receita"
      receita={$store.receitaEvolucaoMensal}
      despesa={$store.despesaEvolucaoMensal}>
      <span slot="title">Evolução mensal da Receita</span>
      <span slot="tooltip">
        Possibilita comparar os gastos realizados com o montante arrecadado no
        exercício e identificar a ocorrência de déficit (despesa maior que
        receita) ou superávit (receita maior que despesa).
      </span>
    </ReceitaXDespesaEvolucaoMensal>
  </div>

  <!-- <div class="w-full p-1">
    <Treemap />
  </div> -->
</div>
