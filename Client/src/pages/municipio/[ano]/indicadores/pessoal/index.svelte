<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import RealComBarra from "../_components/RealComBarra.svelte";
  import PercentualComBarra from "../_components/PercentualComBarra.svelte";
  import Total from "../_components/Total.svelte";
  import LimiteConstitucional from "../_components/AlertaLimiteConstitucionalPessoal.svelte";

  const configLimiteConstitucionalConsolidado = {
    limite: 60,
    limitePrudencial: 57,
    limiteAlerta: 54
  };

  const configLimiteConstitucionalExecutivo = {
    limite: 54,
    limitePrudencial: 51.3,
    limiteAlerta: 48.6
  };

  const configLimiteConstitucionalLegislativo = {
    limite: 6,
    limitePrudencial: 5.7,
    limiteAlerta: 5.4
  };

  let loading = true;
  let rows = [];
  let page = 0; //first page
  let pageSize = 100;
  let totais = {};

  $: refresh($params);

  async function refresh(params) {
    const ano = parseInt(params.ano);
    loading = true;

    const res = await axios.post(api.getApiUrl("ControleSocial"), [
      {
        run: "Municipio.Indicador.Pessoal",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      despesaConsolidada: data.reduce((a, b) => a + b.despesaConsolidada, 0),
      despesaConsolidadaPerCapita: data.reduce(
        (a, b) => a + b.despesaConsolidadaPerCapita,
        0
      ),
      despesaExecutivo: data.reduce((a, b) => a + b.despesaExecutivo, 0),
      despesaExecutivoPerCapita: data.reduce(
        (a, b) => a + b.despesaExecutivoPerCapita,
        0
      ),
      despesaLegislativo: data.reduce((a, b) => a + b.despesaLegislativo, 0),
      despesaLegislativoPerCapita: data.reduce(
        (a, b) => a + b.despesaLegislativoPerCapita,
        0
      )
    };

    rows = res.data[0].value;
    loading = false;
  }

  function onCellClick(row) {
    //alert(JSON.stringify(row));
  }

  function onSortString({ detail: { dir, key } }) {
    rows = sortString(rows, dir, key);
  }

  function onSortNumber({ detail: { dir, key } }) {
    rows = sortNumber(rows, dir, key);
  }
</script>

<svelte:head>
  <title>Pessoal</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr role="row" class="h-10">
      <th
        class="text-center border-0 border-b border-dashed border-gray-300"
        colspan="1"
        rowspan="1" />
      <th
        class="text-center border-0 border-b border-dashed border-gray-300"
        colspan="3"
        title="Despesas Pessoais"
        rowspan="1">
        Consolidada
      </th>
      <th
        class="text-center border border-t-0 border-dashed border-gray-300"
        colspan="3"
        title="Despesas com Executivo"
        rowspan="1">
        Executivo
      </th>
      <th
        class="text-center border-0 border-b border-dashed border-gray-300"
        colspan="3"
        title="Despesas com Legislativo"
        rowspan="1">
        Legislativo
      </th>
    </tr>
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Despesa
        <Sort key="despesaConsolidada" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="despesaConsolidadaPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        LRF
        <Sort
          key="despesaConsolidadaLimiteConstitucional"
          on:sort={onSortNumber} />
      </th>
      <th>
        Despesa
        <Sort key="despesaExecutivo" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="despesaExecutivoPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        LRF
        <Sort
          key="despesaExecutivoLimiteConstitucional"
          on:sort={onSortNumber} />
      </th>
      <th>
        Despesa
        <Sort key="despesaLegislativo" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="despesaLegislativoPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        LRF
        <Sort
          key="despesaLegislativoLimiteConstitucional"
          on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <RealComBarra
          label="Despesa"
          value={row.despesaConsolidada}
          total={totais.despesaConsolidada} />
        <RealComBarra
          label="Per capita"
          value={row.despesaConsolidadaPerCapita}
          total={totais.despesaConsolidadaPerCapita} />
        <PercentualComBarra
          label="Limite constitucional"
          isPositivo={v => v < configLimiteConstitucionalConsolidado.limite}
          value={row.despesaConsolidadaLimiteConstitucional}>
          <LimiteConstitucional
            config={configLimiteConstitucionalConsolidado}
            value={row.despesaConsolidadaLimiteConstitucional} />
        </PercentualComBarra>
        <RealComBarra
          label="Despesa"
          value={row.despesaExecutivo}
          total={totais.despesaExecutivo} />
        <RealComBarra
          label="Per capita"
          value={row.despesaExecutivoPerCapita}
          total={totais.despesaExecutivoPerCapita} />
        <PercentualComBarra
          label="Limite constitucional"
          isPositivo={v => v < configLimiteConstitucionalExecutivo.limite}
          value={row.despesaExecutivoLimiteConstitucional}>
          <LimiteConstitucional
            config={configLimiteConstitucionalExecutivo}
            value={row.despesaExecutivoLimiteConstitucional} />
        </PercentualComBarra>
        <RealComBarra
          label="Despesa"
          value={row.despesaLegislativo}
          total={totais.despesaLegislativo} />
        <RealComBarra
          label="Per capita"
          value={row.despesaLegislativoPerCapita}
          total={totais.despesaLegislativoPerCapita} />
        <PercentualComBarra
          label="Limite constitucional"
          isPositivo={v => v < configLimiteConstitucionalLegislativo.limite}
          value={row.despesaLegislativoLimiteConstitucional}>
          <LimiteConstitucional
            config={configLimiteConstitucionalLegislativo}
            value={row.despesaLegislativoLimiteConstitucional} />
        </PercentualComBarra>
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Despesa" total={totais.despesaConsolidada} />
      <Total label="Per capita" total={totais.despesaConsolidadaPerCapita} />
      <td />
      <Total label="Despesa" total={totais.despesaExecutivo} />
      <Total label="Per capita" total={totais.despesaExecutivoPerCapita} />
      <td />
      <Total label="Despesa" total={totais.despesaLegislativo} />
      <Total label="Per capita" total={totais.despesaLegislativoPerCapita} />
      <td />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
