<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import RealComBarra from "../_components/RealComBarra.svelte";
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
        run: "Municipio.Indicador.DespesasEmDestaque",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      diarias: data.reduce((a, b) => a + b.diarias, 0),
      materialDeConsumo: data.reduce((a, b) => a + b.materialDeConsumo, 0),
      materialPermanente: data.reduce((a, b) => a + b.materialPermanente, 0),
      obras: data.reduce((a, b) => a + b.obras, 0)
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
  <title>Despesas em destaque</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Diárias
        <Sort key="diarias" on:sort={onSortNumber} />
      </th>
      <th>
        Material de consumo
        <Sort key="materialDeConsumo" on:sort={onSortNumber} />
      </th>
      <th>
        Material permanente
        <Sort key="materialPermanente" on:sort={onSortNumber} />
      </th>
      <th>
        Obras
        <Sort key="obras" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <RealComBarra
          label="Diárias"
          value={row.diarias}
          total={totais.diarias} />
        <RealComBarra
          label="Material de consumo"
          value={row.materialDeConsumo}
          total={totais.materialDeConsumo} />
        <RealComBarra
          label="Material permanente"
          value={row.materialPermanente}
          total={totais.materialPermanente} />
        <RealComBarra label="Obras" value={row.obras} total={totais.obras} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Diárias" total={totais.diarias} />
      <Total label="Material de consumo" total={totais.materialDeConsumo} />
      <Total label="Material permanente" total={totais.materialPermanente} />
      <Total label="Obras" total={totais.obras} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
