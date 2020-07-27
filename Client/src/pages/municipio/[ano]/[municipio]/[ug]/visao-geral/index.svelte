<!-- <script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../utils/api.js";

  import CamaraMunicipal from "./_components/CamaraMunicipal.svelte";
  import LimiteConstitucionalEducacao from "../_components/LimiteConstitucionalEducacao.svelte";
  import LimiteConstitucionalPessoalConsolidado from "../_components/LimiteConstitucionalPessoalConsolidado.svelte";
  import LimiteConstitucionalPessoalExecutivo from "../_components/LimiteConstitucionalPessoalExecutivo.svelte";
  import LimiteConstitucionalPessoalLegislativo from "../_components/LimiteConstitucionalPessoalLegislativo.svelte";
  import LimiteConstitucionalSaude from "../_components/LimiteConstitucionalSaude.svelte";
  import ObrigacoesJuntoAoTCEES from "./_components/ObrigacoesJuntoAoTCEES.svelte";
  import PrefeituraMunicipal from "./_components/PrefeituraMunicipal.svelte";
  import ReceitaXDespesa from "./_components/ReceitaXDespesa.svelte";

  import * as despesaApi from "../../../../../../stores/municipio/despesa.js";
  import * as gestaoApi from "../../../../../../stores/municipio/gestao.js";
  import * as receitaApi from "../../../../../../stores/municipio/receita.js";

  $: refresh($params);

  function refresh(params) {
    const ano = parseInt(params.ano);
    const municipio = params.municipio;

    const camaraMunicipalPCA = gestaoApi.gestaoSituacaoPrestacaoContaAnual(
      ano,
      municipio + "L0200001"
    );
    camaraMunicipalPCA[0].id =
      "gestaoSituacaoPrestacaoContaAnualCamaraMunicipal";
    const prefeituraMunicipalPCA = gestaoApi.gestaoSituacaoPrestacaoContaAnual(
      ano,
      municipio + "E0700001"
    );
    prefeituraMunicipalPCA[0].id =
      "gestaoSituacaoPrestacaoContaAnualPrefeituraMunicipal";

    // api.post(
    //   api.getApiUrl("ControleSocial"),
    //   camaraMunicipalPCA
    //     .concat(despesaApi.despesaRemessaAtual(ano, municipio))
    //     .concat(prefeituraMunicipalPCA)
    //     .concat(receitaApi.receitaRemessaAtual(ano, municipio))
    // );
  }
</script> -->

<!-- <div class="flex flex-wrap w-full">
  <div class="xl:w-1/4 lg:w-1/4 sm:w-1/2 w-full p-1">
    <ReceitaXDespesa
      remessaReceita={$store.receitaRemessaAtual}
      remessaDespesa={data.despesaRemessaAtual} />
  </div>

  <div class="xl:w-1/4 lg:w-1/4 sm:w-1/2 w-full p-1">
    <ObrigacoesJuntoAoTCEES
      obrigacoes={[{ ano: 2017, situacao: 1 }, { ano: 2018, situacao: 1 }, { ano: 2019, situacao: -1 }]} />
  </div>

  <div class="xl:w-1/4 lg:w-1/4 sm:w-1/2 w-full p-1">
    <PrefeituraMunicipal
      obrigacao={data.gestaoSituacaoPrestacaoContaAnualPrefeituraMunicipal} />
  </div>

  <div class="xl:w-1/4 lg:w-1/4 sm:w-1/2 w-full p-1">
    <CamaraMunicipal
      obrigacao={data.gestaoSituacaoPrestacaoContaAnualCamaraMunicipal} />
  </div>

  <div class="xl:w-1/5 lg:w-1/5 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalSaude limite={11.54} />
  </div>

  <div class="xl:w-1/5 lg:w-1/5 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalEducacao limite={35.54} />
  </div>

  <div class="xl:w-1/5 lg:w-1/5 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalPessoalConsolidado limite={40.88} />
  </div>

  <div class="xl:w-1/5 lg:w-1/5 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalPessoalExecutivo limite={54} />
  </div>

  <div class="xl:w-1/5 lg:w-1/5 sm:w-1/2 w-full p-1">
    <LimiteConstitucionalPessoalLegislativo limite={5.8} />
  </div>
</div> -->
