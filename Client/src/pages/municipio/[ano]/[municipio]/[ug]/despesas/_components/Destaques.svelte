<script>
  import { params } from "@sveltech/routify";
  import api from "../../../../../../../utils/api.js";
  import Icon from "fa-svelte";

  import { faBed } from "@fortawesome/free-solid-svg-icons/faBed";
  import { faCubes } from "@fortawesome/free-solid-svg-icons/faCubes";
  import { faHammer } from "@fortawesome/free-solid-svg-icons/faHammer";
  import { faBarcode } from "@fortawesome/free-solid-svg-icons/faBarcode";

  import Widget from "../../../../../../../components/Widget/Widget.svelte";
  import Destaque from "./Destaque.svelte";

  import * as despesaApi from "../../../../../../../stores/municipio/despesa.js";

  const titles = {
    diarias: "Despesas com diárias",
    materialPermanente: "Despesas com equipamentos e material permanente",
    obras: "Despesas com obras e instalações",
    materialDeConsumo: "Despesas com material de consumo",
  };

  const store = api.createStore();
  $: refresh($params);

  async function refresh(params) {
    const ano = parseInt(params.ano);
    const ug = params.ug;
    const municipio = ug === "consolidado" ? params.municipio : ug;

    await api.post(
      api.getApiUrl("DWControleSocial"),
      getDestaqueSumLiquidada(despesaApi.despesaDestaqueDiarias, ano, municipio)
        .concat(
          getDestaqueSumLiquidada(
            despesaApi.despesaDestaqueMaterialDeConsumo,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumLiquidada(
            despesaApi.despesaDestaqueMaterialPermanente,
            ano,
            municipio
          )
        )
        .concat(
          getDestaqueSumLiquidada(
            despesaApi.despesaDestaqueObras,
            ano,
            municipio
          )
        ),
      { store }
    );
  }

  function getDestaqueSumLiquidada(destaque, ano, municipio) {
    const workflow = destaque(ano, municipio, despesaApi.despesaSumLiquidada);

    return [
      {
        id: workflow[0].id,
        run: "Municipio.Despesa.FiltrarPorAno",
        args: [ano],
        continue: true,
        evaluate: false,
      },
    ].concat(workflow);
  }
</script>

<style>
  .destaque {
    @apply float-left;
    height: 100%;
  }
</style>

<div class="w-full float-left">
  <Widget>
    <span slot="title">Transferências do Estado em destaque</span>
    <span slot="tooltip">
      Destaque das mais relevantes transferências realizadas pelo Estado para o
      Município para amenizar as desigualdades regionais e promover o equilíbrio
      sócio-econômico entre os municípios.
    </span>
    <div>
      <div class="destaque w-full md:w-1/4" title={titles.diarias}>
        <Destaque
          model={$store.despesaDestaqueDiarias}
          workflow={despesaApi.despesaDestaqueDiarias}
          title={titles.diarias}>
          <span slot="icon">
            <Icon icon={faBed} />
          </span>
          <span slot="title">Diárias</span>
        </Destaque>
      </div>

      <div class="destaque w-full md:w-1/4" title={titles.materialPermanente}>
        <Destaque
          model={$store.despesaDestaqueMaterialPermanente}
          workflow={despesaApi.despesaDestaqueMaterialPermanente}
          title={titles.materialPermanente}>
          <span slot="icon">
            <Icon icon={faCubes} />
          </span>
          <span slot="title">Material permanente</span>
        </Destaque>
      </div>

      <div class="destaque w-full md:w-1/4" title={titles.obras}>
        <Destaque
          model={$store.despesaDestaqueObras}
          workflow={despesaApi.despesaDestaqueObras}
          title={titles.obras}>
          <span slot="icon">
            <Icon icon={faHammer} />
          </span>
          <span slot="title">Obras</span>
        </Destaque>
      </div>

      <div class="destaque w-full md:w-1/4" title={titles.materialDeConsumo}>
        <Destaque
          model={$store.despesaDestaqueMaterialDeConsumo}
          workflow={despesaApi.despesaDestaqueMaterialDeConsumo}
          title={titles.materialDeConsumo}>
          <span slot="icon">
            <Icon icon={faBarcode} />
          </span>
          <span slot="title">Material de consumo</span>
        </Destaque>
      </div>
    </div>
  </Widget>
</div>
