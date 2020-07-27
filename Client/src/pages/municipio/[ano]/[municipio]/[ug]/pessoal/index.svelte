<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import api from "../../../../../../utils/api.js";
  import Loading from "../../../../../../components/Navigation/Loading.svelte";

  import LinhaPoder from "./_components/LinhaPoder.svelte";
  import PrestacaoContaMensal from "../_components/PrestacaoContaMensal.svelte";
  import LimiteConstitucionalPessoalConsolidado from "../_components/LimiteConstitucionalPessoalConsolidado.svelte";
  import LimiteConstitucionalPessoalExecutivo from "../_components/LimiteConstitucionalPessoalExecutivo.svelte";
  import LimiteConstitucionalPessoalLegislativo from "../_components/LimiteConstitucionalPessoalLegislativo.svelte";

  import * as prestacaoContaApi from "../../../../../../stores/prestacaoConta/prestacaoConta.js";
  import * as pessoalConsolidadoApi from "../../../../../../stores/municipio/pessoalConsolidado.js";
  import * as pessoalExecutivoApi from "../../../../../../stores/municipio/pessoalExecutivo.js";
  import * as pessoalLegislativoApi from "../../../../../../stores/municipio/pessoalLegislativo.js";

  let ano;

  let promiseConsolidado;
  let promiseExecutivo;
  let promiseLegislativo;

  $: refresh($params);

  function refresh(params) {
    ano = parseInt(params.ano);
    const municipio = params.municipio;

    const workflowsConsolidado = pessoalConsolidadoApi
      .pessoalConsolidadoDespesa(ano, municipio)
      .concat(
        pessoalConsolidadoApi.pessoalConsolidadoDespesaPerCapita(ano, municipio)
      )
      .concat(
        pessoalConsolidadoApi.pessoalConsolidadoEvolucaoAnual(ano, municipio)
      )
      .concat(
        pessoalConsolidadoApi.pessoalConsolidadoRankingDespesa(ano, municipio)
      )
      .concat(
        pessoalConsolidadoApi.pessoalConsolidadoRankingDespesaPerCapita(
          ano,
          municipio
        )
      );

    const workflowsExecutivo = pessoalExecutivoApi
      .pessoalExecutivoDespesa(ano, municipio)
      .concat(
        pessoalExecutivoApi.pessoalExecutivoDespesaPerCapita(ano, municipio)
      )
      .concat(pessoalExecutivoApi.pessoalExecutivoEvolucaoAnual(ano, municipio))
      .concat(
        pessoalExecutivoApi.pessoalExecutivoRankingDespesa(ano, municipio)
      )
      .concat(
        pessoalExecutivoApi.pessoalExecutivoRankingDespesaPerCapita(
          ano,
          municipio
        )
      );

    const workflowsLegislativo = pessoalLegislativoApi
      .pessoalLegislativoDespesa(ano, municipio)
      .concat(
        pessoalLegislativoApi.pessoalLegislativoDespesaPerCapita(ano, municipio)
      )
      .concat(
        pessoalLegislativoApi.pessoalLegislativoEvolucaoAnual(ano, municipio)
      )
      .concat(
        pessoalLegislativoApi.pessoalLegislativoRankingDespesa(ano, municipio)
      )
      .concat(
        pessoalLegislativoApi.pessoalLegislativoRankingDespesaPerCapita(
          ano,
          municipio
        )
      );

    promiseConsolidado = getData(workflowsConsolidado);
    promiseExecutivo = getData(workflowsExecutivo);
    promiseLegislativo = getData(workflowsLegislativo);
  }

  async function getData(workflows) {
    return axios.post(api.getApiUrl("ControleSocial"), workflows).then(r => {
      const data = {};

      for (let i in r.data) {
        data[r.data[i].id] = r.data[i];
      }

      return data;
    });
  }
</script>

<svelte:head>
  <title>Pessoal</title>
</svelte:head>

<!-- <div class="pl-1">
  <PrestacaoContaMensal model={data.prestacaoContaPessoalConsolidado} />
</div> -->

{#await promiseConsolidado}
  <Loading />
{:then dataConsolidado}
  <LinhaPoder
    titulo="Consolidado"
    pessoalDespesa={dataConsolidado.pessoalConsolidadoDespesa}
    rankingDespesa={dataConsolidado.pessoalConsolidadoRankingDespesa}
    pessoalDespesaPerCapita={dataConsolidado.pessoalConsolidadoDespesaPerCapita}
    rankingDespesaPerCapita={dataConsolidado.pessoalConsolidadoRankingDespesaPerCapita}
    evolucaoAnual={dataConsolidado.pessoalConsolidadoEvolucaoAnual}>
    <span slot="limite">
      <LimiteConstitucionalPessoalConsolidado
        limite={dataConsolidado.pessoalConsolidadoDespesa.value.limiteConstitucional}
        height={48} />
    </span>
  </LinhaPoder>
{/await}

{#await promiseExecutivo}
  <Loading />
{:then dataExecutivo}
  <LinhaPoder
    titulo="Executivo"
    pessoalDespesa={dataExecutivo.pessoalExecutivoDespesa}
    rankingDespesa={dataExecutivo.pessoalExecutivoRankingDespesa}
    pessoalDespesaPerCapita={dataExecutivo.pessoalExecutivoDespesaPerCapita}
    rankingDespesaPerCapita={dataExecutivo.pessoalExecutivoRankingDespesaPerCapita}
    evolucaoAnual={dataExecutivo.pessoalExecutivoEvolucaoAnual}>
    <span slot="limite">
      <LimiteConstitucionalPessoalExecutivo
        limite={dataExecutivo.pessoalExecutivoDespesa.value.limiteConstitucional}
        height={48} />
    </span>
  </LinhaPoder>
{/await}

{#await promiseLegislativo}
  <Loading />
{:then dataLegislativo}
  <LinhaPoder
    titulo="Legislativo"
    pessoalDespesa={dataLegislativo.pessoalLegislativoDespesa}
    rankingDespesa={dataLegislativo.pessoalLegislativoRankingDespesa}
    pessoalDespesaPerCapita={dataLegislativo.pessoalLegislativoDespesaPerCapita}
    rankingDespesaPerCapita={dataLegislativo.pessoalLegislativoRankingDespesaPerCapita}
    evolucaoAnual={dataLegislativo.pessoalLegislativoEvolucaoAnual}>
    <span slot="limite">
      <LimiteConstitucionalPessoalLegislativo
        limite={dataLegislativo.pessoalLegislativoDespesa.value.limiteConstitucional}
        height={48} />
    </span>
  </LinhaPoder>
{/await}
