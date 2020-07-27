<script>
  import { route } from "@sveltech/routify";
  import Table, { Pagination, Row, Search, Sort } from "@fabiohvp/svelte-table";
  import api from "../../utils/api.js";
  import * as seedApi from "../../stores/seed/seed.js";
  import { sortDate, sortNumber, sortString } from "../../utils/sorting.js";

  const dateFormatter = new Intl.DateTimeFormat("pt-BR", {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit"
  });
  const store = api.createStore();
  let files = [];
  let percent = 0;
  let uploading = false;

  let loading = true;
  let rows = [];
  let page = 0; //first page
  let pageSize = 20;

  $: refresh($route);
  $: uploadDisabled = uploading;

  async function refresh({ params }) {
    rows = await api.post(api.getApiUrl("DWControleSocial"), seedApi.list());
    rows = rows.data[0].value.map(r => {
      r.dataCriacao = new Date(r.dataCriacao);
      return r;
    });
    loading = false;
  }

  async function onChange(event) {
    files = event.target.files;
    uploading = false;
  }

  async function onSubmit() {
    uploading = true;
    percent = 0;
    const formData = seedApi.seed(files);
    await api.post(api.getApiUrl("DWControleSocial/Upload"), formData, {
      store,
      onUploadProgress: function(progressEvent) {
        percent = Math.round(
          (progressEvent.loaded * 100) / progressEvent.total
        );
      }
    });
  }

  function onSortNumber({ detail: { dir, key } }) {
    rows = sortNumber(rows, dir, key);
  }

  function onSortDate({ detail: { dir, key } }) {
    rows = sortDate(rows, dir, key);
  }

  function onSortString({ detail: { dir, key } }) {
    rows = sortString(rows, dir, key);
  }
</script>

<!-- routify:options roles="Admin" -->
<div class="border border-dashed border-gray-500 relative">
  <input
    type="file"
    on:change={onChange}
    multiple
    class="cursor-pointer relative block opacity-0 w-full h-full p-20 z-50" />
  <div class="text-center p-10 absolute top-0 right-0 left-0 m-auto">
    <h4>
      Arraste seus arquivos aqui
      <br />
      ou
    </h4>
    <p class="">Clique aqui para selecionar os arquivos</p>
  </div>
</div>

<button
  on:click={onSubmit}
  disabled={uploadDisabled}
  class:opacity-50={uploadDisabled}
  class:cursor-not-allowed={uploadDisabled}
  class="bg-green-400 hover:bg-blue-light text-white font-bold py-2 px-4 w-full
  flex items-center justify-center mt-2">
  <svg
    fill="#FFF"
    height="18"
    viewBox="0 0 24 24"
    width="18"
    xmlns="http://www.w3.org/2000/svg">
    <path d="M0 0h24v24H0z" fill="none" />
    <path d="M9 16h6v-6h4l-7-7-7 7h4zm-4 2h14v2H5z" />
  </svg>
  <span>Enviar</span>
</button>

{#if files.length > 0}
  <div>
    <h3 class="font-semibold text-xl">Files</h3>
    {#each files as file}
      <p>
        <span>{file.name}</span>
      </p>
    {/each}
  </div>
{/if}

{#if uploading}
  <div class="w-full">
    <div class="shadow w-full bg-gray-300 mt-2 relative">
      <div class="bg-blue-400 py-3 h-full" style="width: {percent}%" />
      <span class="absolute w-full text-center text-white top-0">
        {percent}%
      </span>
    </div>
  </div>
{/if}

<Table {loading} {page} {pageSize} {rows} let:rows={rows2}>
  <thead slot="head">
    <tr>
      <th>
        Id
        <Sort key="id" on:sort={onSortNumber} />
      </th>
      <th>
        Arquivo
        <Sort key="arquivo" on:sort={onSortString} />
      </th>
      <th>
        Data de criação
        <Sort key="dataCriacao" on:sort={onSortDate} />
      </th>
    </tr>
  </thead>
  <tbody>
    {#each rows2 as row, index (row)}
      <Row {index}>
        <td data-label="Id" class="font-bold">{row.id}</td>
        <td label="Arquivo">{row.arquivo}</td>
        <td label="Data de criação">{dateFormatter.format(row.dataCriacao)}</td>
      </Row>
    {/each}
  </tbody>
</Table>
