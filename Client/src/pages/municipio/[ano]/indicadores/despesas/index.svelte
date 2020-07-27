<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { mesesAbreviados } from "../../../../../utils/date.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import Total from "../_components/Total.svelte";
  import RealComBarra from "../_components/RealComBarra.svelte";
  import PercentualComBarra from "../_components/PercentualComBarra.svelte";

  let loading = true;
  let rows = [];
  let page = 0; //first page
  let pageSize = 100;
  let totais = {};

  $: refresh($params);

  async function refresh(params) {
    const ano = parseInt(params.ano);
    loading = true;

    const res = await axios.post(api.getApiUrl("DWControleSocial"), [
      {
        run: "Municipio.Indicador.Despesas",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      empenhada: data.reduce((a, b) => a + b.empenhada, 0),
      empenhadaPerCapita: data.reduce((a, b) => a + b.empenhadaPerCapita, 0),
      liquidada: data.reduce((a, b) => a + b.liquidada, 0),
      liquidadaPerCapita: data.reduce((a, b) => a + b.liquidadaPerCapita, 0),
      paga: data.reduce((a, b) => a + b.paga, 0),
      pagaPerCapita: data.reduce((a, b) => a + b.pagaPerCapita, 0),
      prevista: data.reduce((a, b) => a + b.prevista, 0),
      resultadoOrcamentario: data.reduce(
        (a, b) => a + b.resultadoOrcamentario,
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
  <title>Despesas</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th style="width:20px;">Mês</th>
      <th>
        Prevista
        <Sort key="prevista" on:sort={onSortNumber} />
      </th>
      <th>
        Empenhada
        <Sort key="empenhada" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="empenhadaPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        Liquidada
        <Sort key="liquidada" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="liquidadaPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        Paga
        <Sort key="paga" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="pagaPerCapita" on:sort={onSortNumber} />
      </th>
      <th>
        Resultado orçamentário
        <Sort key="resultadoOrcamentario" on:sort={onSortNumber} />
      </th>
      <th>
        Desempenho
        <Sort key="desempenho" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <td class="text-center">{mesesAbreviados[row.mes - 1]}</td>
        <RealComBarra
          label="Prevista"
          value={row.prevista}
          total={totais.prevista} />
        <RealComBarra
          label="Empenhada"
          value={row.empenhada}
          total={totais.empenhada} />
        <RealComBarra
          label="Per capita"
          value={row.empenhadaPerCapita}
          total={totais.empenhadaPerCapita} />
        <RealComBarra
          label="Liquidada"
          value={row.liquidada}
          total={totais.liquidada} />
        <RealComBarra
          label="Per capita"
          value={row.liquidadaPerCapita}
          total={totais.liquidadaPerCapita} />
        <RealComBarra label="Paga" value={row.paga} total={totais.paga} />
        <RealComBarra
          label="Per capita"
          value={row.pagaPerCapita}
          total={totais.pagaPerCapita} />
        <RealComBarra
          label="Resultado orçamentário"
          value={row.resultadoOrcamentario}
          total={totais.resultadoOrcamentario} />
        <PercentualComBarra label="Desempenho" value={row.desempenho} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Prevista" total={totais.prevista} />
      <Total label="Empenhada" total={totais.empenhada} />
      <Total label="Per capita" total={totais.empenhadaPerCapita} />
      <Total label="Liquidada" total={totais.liquidada} />
      <Total label="Per capita" total={totais.liquidadaPerCapita} />
      <Total label="Paga" total={totais.paga} />
      <Total label="Per capita" total={totais.pagaPerCapita} />
      <Total
        label="Resultado orçamentário"
        total={totais.resultadoOrcamentario} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
