<script>
  import { params } from "@sveltech/routify";
  import axios from "axios";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";

  import api from "../../../../../utils/api.js";
  import { sortNumber, sortString } from "../../../../../utils/sorting.js";

  import Total from "../_components/Total.svelte";
  import Barra from "../_components/Barra.svelte";
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

    const res = await axios.post(api.getApiUrl("ControleSocial"), [
      {
        run: "Municipio.Indicador.EducacaoFUNDEB",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      quantidadeAlunos: data.reduce((a, b) => a + b.quantidadeAlunos, 0),
      destinado: data.reduce((a, b) => a + b.recebido, 0),
      recebido: data.reduce((a, b) => a + b.recebido, 0)
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
  <title>Educação FUNDEB</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Alunos
        <Sort key="quantidadeAlunos" on:sort={onSortNumber} />
      </th>
      <th>
        Destinado
        <Sort key="destinado" on:sort={onSortNumber} />
      </th>
      <th>
        Recebido
        <Sort key="recebido" on:sort={onSortNumber} />
      </th>
      <th>
        Destinado X Recebido
        <Sort key="destinadoXRecebido" on:sort={onSortNumber} />
      </th>
      <th>
        Aplicação no Magistério
        <Sort key="aplicacaoMagisterio" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <td data-label="Alunos" class="text-right" title={row.quantidadeAlunos}>
          {row.quantidadeAlunos}
          <Barra
            value={(row.quantidadeAlunos * 100) / totais.quantidadeAlunos} />
        </td>
        <RealComBarra
          label="Destinado"
          value={row.destinado}
          total={totais.destinado} />
        <RealComBarra
          label="Recebido"
          value={row.recebido}
          total={totais.recebido} />
        <PercentualComBarra
          label="Destinado X Recebido"
          value={row.destinadoXRecebido} />
        <PercentualComBarra
          label="Aplicação no Magistério"
          value={row.aplicacaoMagisterio} />
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Alunos" total={totais.quantidadeAlunos} />
      <Total label="Destinado" total={totais.destinado} />
      <Total label="Recebido" total={totais.recebido} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
