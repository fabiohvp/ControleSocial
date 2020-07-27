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
        run: "Municipio.Indicador.ComposicaoReceitaArrecadada",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      operacoesDeCredito: data.reduce((a, b) => a + b.operacoesDeCredito, 0),
      receitasDoMunicipio: data.reduce((a, b) => a + b.receitasDoMunicipio, 0),
      transferenciaDaUniao: data.reduce(
        (a, b) => a + b.transferenciaDaUniao,
        0
      ),
      transferenciaDoEstado: data.reduce(
        (a, b) => a + b.transferenciaDoEstado,
        0
      ),
      outrasTransferencias: data.reduce(
        (a, b) => a + b.outrasTransferencias,
        0
      ),
      arrecadada: data.reduce((a, b) => a + b.arrecadada, 0)
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
  <title>Composição da Receita Arrecadada</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Receitas próprias
        <Sort key="receitasDoMunicipio" on:sort={onSortNumber} />
      </th>
      <th>
        Estado
        <Sort key="transferenciaDoEstado" on:sort={onSortNumber} />
      </th>
      <th>
        União
        <Sort key="transferenciaDaUniao" on:sort={onSortNumber} />
      </th>
      <th>
        Operações de crédito
        <Sort key="operacoesDeCredito" on:sort={onSortNumber} />
      </th>
      <th>
        Outras
        <Sort key="outrasTransferencias" on:sort={onSortNumber} />
      </th>
      <th>
        Arrecadada
        <Sort key="arrecadada" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <RealComBarra
          label="Receitas próprias"
          value={row.receitasDoMunicipio}
          total={totais.receitasDoMunicipio} />
        <RealComBarra
          label="Estado"
          value={row.transferenciaDoEstado}
          total={totais.transferenciaDoEstado} />
        <RealComBarra
          label="União"
          value={row.transferenciaDaUniao}
          total={totais.transferenciaDaUniao} />
        <RealComBarra
          label="Operações de crédito"
          value={row.operacoesDeCredito}
          total={totais.operacoesDeCredito} />
        <RealComBarra
          label="Outras"
          value={row.outrasTransferencias}
          total={totais.outrasTransferencias} />
        <RealComBarra
          label="Arrecadada"
          value={row.arrecadada}
          total={totais.arrecadada} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Receitas próprias" total={totais.receitasDoMunicipio} />
      <Total label="Estado" total={totais.transferenciaDoEstado} />
      <Total label="União" total={totais.transferenciaDaUniao} />
      <Total label="Operações de crédito" total={totais.operacoesDeCredito} />
      <Total label="Outras" total={totais.outrasTransferencias} />
      <Total label="Arrecadada" total={totais.arrecadada} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
