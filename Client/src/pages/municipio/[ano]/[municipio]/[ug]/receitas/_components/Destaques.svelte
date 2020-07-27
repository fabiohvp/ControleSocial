<script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../../utils/api.js";
  import Icon from "fa-svelte";

  import { faCar } from "@fortawesome/free-solid-svg-icons/faCar";
  import { faCogs } from "@fortawesome/free-solid-svg-icons/faCogs";
  import { faExchangeAlt } from "@fortawesome/free-solid-svg-icons/faExchangeAlt";
  import { faHandHoldingUsd } from "@fortawesome/free-solid-svg-icons/faHandHoldingUsd";
  import { faHandshake } from "@fortawesome/free-solid-svg-icons/faHandshake";
  import { faHouseDamage } from "@fortawesome/free-solid-svg-icons/faHouseDamage";
  import { faShoppingCart } from "@fortawesome/free-solid-svg-icons/faShoppingCart";
  import OilRig from "../../../../../../../components/Icons/OilRig.svelte";

  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Destaque from "./Destaque.svelte";

  import * as receitaApi from "../../../../../../../stores/municipio/receita.js";

  const titles = {
    conveniosDaUniao:
      "Valor recebido a partir convênios entre a União e o Município",
    conveniosDoEstado:
      "Valor recebido a partir convênios entre o Estado e o Município",
    fpm: "Fundo de Participação dos Municípios",
    icms:
      "Imposto sobre Operações relativas à Circulação de Mercadorias e Prestação de Serviços de Transporte Interestadual e Intermunicipal e de Comunicação",
    iptu: "Imposto Predial e Territorial Urbano",
    ipva: "Imposto sobre a Propriedade de Veículos Automotores",
    iss: "Imposto Sobre Serviço",
    itbi: "Imposto sobre a Transmissão de Bens Imóveis",
    royaltiesDaUniao: "Royalties de Petróleo",
    royaltiesDoEstado: "Royalties de Petróleo"
  };

  const store = api.createStore();
  $: refresh($params);

  async function refresh(params) {
    const ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;

    await api.post(
      api.getApiUrl("DWControleSocial"),
      getDestaqueSumArrecadada(
        receitaApi.receitaDestaqueConveniosDaUniao,
        ano,
        municipio
      )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueConveniosDoEstado,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueFPM,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueICMS,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueIPTU,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueIPVA,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueISS,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueITBI,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueRoyaltiesDaUniao,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumArrecadada(
            receitaApi.receitaDestaqueRoyaltiesDoEstado,
            ano,
            municipio
          )
        ),
      { store }
    );
  }

  function getDestaqueSumArrecadada(destaque, ano, municipio) {
    const workflow = destaque(ano, municipio, receitaApi.receitaSumArrecadada);

    return [
      {
        id: workflow[0].id,
        run: "Municipio.Receita.FiltrarPorAno",
        args: [ano],
        continue: true,
        evaluate: false
      }
    ].concat(workflow);
  }
</script>

<style>
  .destaque {
    @apply float-left;
    width: 50%;
    height: 50%;
  }
</style>

<div>
  <div class="lg:w-1/3 w-full float-left py-2 pr-1">
    <Widget>
      <span slot="title">Receitas próprias do Município em destaque</span>
      <span slot="tooltip">
        Destaque das mais relevantes receitas arrecadadas pelo próprio
        Município.
      </span>
      <div class="h-32">
        <span class="destaque" title={titles.iptu}>
          <Destaque
            model={$store.receitaDestaqueIPTU}
            workflow={receitaApi.receitaDestaqueIPTU}
            title={titles.iptu}>
            <span slot="icon">
              <Icon icon={faHouseDamage} />
            </span>
            <span slot="title">IPTU</span>
          </Destaque>
        </span>

        <span class="destaque" title={titles.itbi}>
          <Destaque
            model={$store.receitaDestaqueITBI}
            workflow={receitaApi.receitaDestaqueITBI}
            title={titles.itbi}>
            <span slot="icon">
              <Icon icon={faExchangeAlt} />
            </span>
            <span slot="title">ITBI</span>
          </Destaque>
        </span>

        <span class="destaque" title={titles.iss}>
          <Destaque
            model={$store.receitaDestaqueISS}
            workflow={receitaApi.receitaDestaqueISS}
            title={titles.iss}>
            <span slot="icon">
              <Icon icon={faCogs} />
            </span>
            <span slot="title">ISS</span>
          </Destaque>
        </span>
      </div>
    </Widget>
  </div>

  <div class="lg:w-1/3 w-full float-left py-2 px-1">
    <Widget>
      <span slot="title">Transferências do Estado em destaque</span>
      <span slot="tooltip">
        Destaque das mais relevantes transferências realizadas pelo Estado para
        o Município para amenizar as desigualdades regionais e promover o
        equilíbrio sócio-econômico entre os municípios.
      </span>
      <div class="h-32">
        <div class="destaque" title={titles.icms}>
          <Destaque
            model={$store.receitaDestaqueICMS}
            workflow={receitaApi.receitaDestaqueICMS}
            title={titles.icms}>
            <span slot="icon">
              <Icon icon={faShoppingCart} />
            </span>
            <span slot="title">ICMS</span>
          </Destaque>
        </div>

        <div class="destaque" title={titles.ipva}>
          <Destaque
            model={$store.receitaDestaqueIPVA}
            workflow={receitaApi.receitaDestaqueIPVA}
            title={titles.ipva}>
            <span slot="icon">
              <Icon icon={faCar} />
            </span>
            <span slot="title">IPVA</span>
          </Destaque>
        </div>

        <div class="destaque" title={titles.conveniosDoEstado}>
          <Destaque
            model={$store.receitaDestaqueConveniosDoEstado}
            workflow={receitaApi.receitaDestaqueConveniosDoEstado}
            title={titles.conveniosDoEstado}>
            <span slot="icon">
              <Icon icon={faHandshake} />
            </span>
            <span slot="title">Convênios</span>
          </Destaque>
        </div>

        <div class="destaque" title={titles.royaltiesDoEstado}>
          <Destaque
            model={$store.receitaDestaqueRoyaltiesDoEstado}
            workflow={receitaApi.receitaDestaqueRoyaltiesDoEstado}
            title={titles.royaltiesDoEstado}>
            <span slot="icon">
              <OilRig />
            </span>
            <span slot="title">Petróleo</span>
          </Destaque>
        </div>
      </div>
    </Widget>
  </div>

  <div class="lg:w-1/3 w-full float-left py-2 pl-1">
    <Widget>
      <span slot="title">Transferências da União em destaque</span>
      <span slot="tooltip">
        Destaque das mais relevantes transferências realizadas pela União para o
        Município para amenizar as desigualdades regionais e promover o
        equilíbrio sócio-econômico entre os municípios.
      </span>
      <div class="h-32">
        <div class="destaque" title={titles.fpm}>
          <Destaque
            model={$store.receitaDestaqueFPM}
            workflow={receitaApi.receitaDestaqueFPM}
            title={titles.fpm}>
            <span slot="icon">
              <Icon icon={faHandHoldingUsd} />
            </span>
            <span slot="title">FPM</span>
          </Destaque>
        </div>

        <div class="destaque" title={titles.conveniosDaUniao}>
          <Destaque
            model={$store.receitaDestaqueConveniosDaUniao}
            workflow={receitaApi.receitaDestaqueConveniosDaUniao}
            title={titles.conveniosDaUniao}>
            <span slot="icon">
              <Icon icon={faHandshake} />
            </span>
            <span slot="title">Convênios</span>
          </Destaque>
        </div>

        <div class="destaque" title={titles.royaltiesDaUniao}>
          <Destaque
            model={$store.receitaDestaqueRoyaltiesDaUniao}
            workflow={receitaApi.receitaDestaqueRoyaltiesDaUniao}
            title={titles.royaltiesDaUniao}>
            <span slot="icon">
              <OilRig />
            </span>
            <span slot="title">Petróleo</span>
          </Destaque>
        </div>
      </div>
    </Widget>
  </div>
</div>
