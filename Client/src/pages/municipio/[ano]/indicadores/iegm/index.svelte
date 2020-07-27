<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import IEGMComBarra from "../_components/IEGMComBarra.svelte";

  let loading = true;
  let rows = [];
  let page = 0; //first page
  let pageSize = 100;

  $: refresh($params);

  async function refresh(params) {
    const ano = parseInt(params.ano);
    loading = true;
    //checar se o ano é valido, senão redirecionar para o ano correto

    const res = await axios.post(api.getApiUrl("ControleSocial"), [
      {
        run: "Municipio.Indicador.IEGM",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
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
  <title>IEGM</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Municipal
        <Sort key="municipal" on:sort={onSortNumber} />
      </th>
      <th>
        Educação
        <Sort key="educacao" on:sort={onSortNumber} />
      </th>
      <th>
        Saúde
        <Sort key="saude" on:sort={onSortNumber} />
      </th>
      <th>
        Planejamento
        <Sort key="planejamento" on:sort={onSortNumber} />
      </th>
      <th>
        Fiscal
        <Sort key="fiscal" on:sort={onSortNumber} />
      </th>
      <th>
        Meio ambiente
        <Sort key="meioAmbiente" on:sort={onSortNumber} />
      </th>
      <th>
        Segurança
        <Sort key="seguranca" on:sort={onSortNumber} />
      </th>
      <th>
        Tecnologia da Informação
        <Sort key="tecnologiaDaInformacao" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <IEGMComBarra label="Municipal" value={row.municipal} />
        <IEGMComBarra label="Educação" value={row.educacao} />
        <IEGMComBarra label="Saúde" value={row.saude} />
        <IEGMComBarra label="Planejamento" value={row.planejamento} />
        <IEGMComBarra label="Fiscal" value={row.fiscal} />
        <IEGMComBarra label="Meio ambiente" value={row.meioAmbiente} />
        <IEGMComBarra label="Segurança" value={row.seguranca} />
        <IEGMComBarra
          label="Tecnologia da Informação"
          value={row.tecnologiaDaInformacao} />
      </Row>
    {/each}
  </tbody>

  <span slot="bottom" />
</Table>
