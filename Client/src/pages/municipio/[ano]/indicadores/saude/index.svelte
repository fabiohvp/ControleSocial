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
  import LimiteConstitucional from "../_components/AlertaLimiteConstitucionalSaudeEEducacao.svelte";

  const configLimiteConstitucional = {
    limite: 15
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
        run: "Municipio.Indicador.Saude",
        args: [ano]
      }
    ]);

    const data = res.data[0].value;
    totais = {
      aplicacao: data.reduce((a, b) => a + b.aplicacao, 0),
      quantidadeAlunos: data.reduce((a, b) => a + b.quantidadeAlunos, 0),
      aplicacaoPorAluno: data.reduce((a, b) => a + b.aplicacaoPorAluno, 0)
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
  <title>Saúde</title>
</svelte:head>

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Municípios
        <Sort key="municipio" on:sort={onSortString} />
      </th>
      <th>
        Aplicação total
        <Sort key="aplicacao" on:sort={onSortNumber} />
      </th>
      <th>
        Alunos
        <Sort key="quantidadeAlunos" on:sort={onSortNumber} />
      </th>
      <th>
        Por aluno
        <Sort key="aplicacaoPorAluno" on:sort={onSortNumber} />
      </th>
      <th>
        Limite constitucional
        <Sort key="limiteConstitucional" on:sort={onSortNumber} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index} on:click={() => onCellClick(row)}>
        <td data-label="Município" class="font-bold">{row.municipio}</td>
        <RealComBarra
          label="Aplicação total"
          value={row.aplicacao}
          total={totais.aplicacao} />
        <td data-label="Alunos" class="text-right" title={row.quantidadeAlunos}>
          {row.quantidadeAlunos}
          <Barra
            value={(row.quantidadeAlunos * 100) / totais.quantidadeAlunos} />
        </td>
        <RealComBarra
          label="Por aluno"
          value={row.aplicacaoPorAluno}
          total={totais.aplicacaoPorAluno} />
        <PercentualComBarra
          label="Limite constitucional"
          isPositivo={v => v >= configLimiteConstitucional.limite}
          value={row.limiteConstitucional}>
          <LimiteConstitucional
            config={configLimiteConstitucional}
            value={row.limiteConstitucional} />
        </PercentualComBarra>
      </Row>
    {/each}
    <Row>
      <td data-label="Total">Totais</td>
      <Total label="Aplicação total" total={totais.aplicacao} />
      <Total label="Alunos" total={totais.quantidadeAlunos} />
      <Total label="Por aluno" total={totais.aplicacaoPorAluno} />
    </Row>
  </tbody>

  <span slot="bottom" />
</Table>
