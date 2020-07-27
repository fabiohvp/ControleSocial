<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { mesesAbreviados } from "../../../../../utils/date.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import RealComBarra from "../_components/RealComBarra.svelte";
  import PercentualComBarra from "../_components/PercentualComBarra.svelte";
  import Total from "../_components/Total.svelte";

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
        run: "Municipio.Indicador.Receitas",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      arrecadada: data.reduce((a, b) => a + b.arrecadada, 0),
      perCapita: data.reduce((a, b) => a + b.perCapita, 0),
      prevista: data.reduce((a, b) => a + b.prevista, 0)
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
  <title>Receitas</title>
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
        Arrecadada
        <Sort key="arrecadada" on:sort={onSortNumber} />
      </th>
      <th>
        Per capita
        <Sort key="perCapita" on:sort={onSortNumber} />
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
          label="Arrecadada"
          value={row.arrecadada}
          total={totais.arrecadada} />
        <RealComBarra
          label="Per capita"
          value={row.perCapita}
          total={totais.perCapita} />
        <PercentualComBarra label="Desempenho" value={row.desempenho} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Prevista" total={totais.prevista} />
      <Total label="Arrecadada" total={totais.arrecadada} />
      <Total label="Per capita" total={totais.perCapita} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
