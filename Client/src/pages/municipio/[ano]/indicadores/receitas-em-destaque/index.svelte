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
        run: "Municipio.Indicador.ReceitasEmDestaque",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      conveniosDaUniao: data.reduce((a, b) => a + b.conveniosDaUniao, 0),
      conveniosDoEstado: data.reduce((a, b) => a + b.conveniosDoEstado, 0),
      fpm: data.reduce((a, b) => a + b.fpm, 0),
      icms: data.reduce((a, b) => a + b.icms, 0),
      iptu: data.reduce((a, b) => a + b.iptu, 0),
      ipva: data.reduce((a, b) => a + b.ipva, 0),
      iss: data.reduce((a, b) => a + b.iss, 0),
      itbi: data.reduce((a, b) => a + b.itbi, 0)
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
  <title>Receitas em destaque</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Convênios da União
        <Sort key="conveniosDaUniao" on:sort={onSortNumber} />
      </th>
      <th>
        Convênios do Estado
        <Sort key="conveniosDoEstado" on:sort={onSortNumber} />
      </th>
      <th>
        FPM
        <Sort key="fpm" on:sort={onSortNumber} />
      </th>
      <th>
        ICMS
        <Sort key="icms" on:sort={onSortNumber} />
      </th>
      <th>
        IPTU
        <Sort key="iptu" on:sort={onSortNumber} />
      </th>
      <th>
        IPVA
        <Sort key="ipva" on:sort={onSortNumber} />
      </th>
      <th>
        ISS
        <Sort key="iss" on:sort={onSortNumber} />
      </th>
      <th>
        ITBI
        <Sort key="itbi" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <RealComBarra
          label="Convênios da União"
          value={row.conveniosDaUniao}
          total={totais.conveniosDaUniao} />
        <RealComBarra
          label="Convênios do Estado"
          value={row.conveniosDoEstado}
          total={totais.conveniosDoEstado} />
        <RealComBarra label="FPM" value={row.fpm} total={totais.fpm} />
        <RealComBarra label="ICMS" value={row.icms} total={totais.icms} />
        <RealComBarra label="IPTU" value={row.iptu} total={totais.iptu} />
        <RealComBarra label="IPVA" value={row.ipva} total={totais.ipva} />
        <RealComBarra label="ISS" value={row.iss} total={totais.iss} />
        <RealComBarra label="ITBI" value={row.itbi} total={totais.itbi} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Convênios da União" total={totais.conveniosDaUniao} />
      <Total label="Convênios do Estado" total={totais.conveniosDoEstado} />
      <Total label="FPM" total={totais.fpm} />
      <Total label="ICMS" total={totais.icms} />
      <Total label="IPTU" total={totais.iptu} />
      <Total label="IPVA" total={totais.ipva} />
      <Total label="ISS" total={totais.iss} />
      <Total label="ITBI" total={totais.itbi} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
