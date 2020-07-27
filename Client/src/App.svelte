<script>
  import { Router } from "@sveltech/routify";
  import { routes } from "@sveltech/routify/tmp/routes";

  import {
    setPaginationLabels,
    setTableLabels,
    setSearchLabels,
    setSortLabels
  } from "@fabiohvp/svelte-table";

  setPaginationLabels({
    first: "Primeira",
    last: "Última",
    next: "Próxima",
    previous: "Anterior"
  });
  setTableLabels({
    empty: "Não há registros disponíveis",
    loading: `<span class="spinning">.</span><span class="ml-4">Obtendo dados</span>`
  });
  setSearchLabels({
    placeholder: "Pesquisar"
  });
  setSortLabels({
    asc: { title: "Crescente", html: "&#8593;" },
    desc: { title: "Decrescente", html: "&#8595;" },
    unsorted: { title: "Ordenação inicial", html: "&#8645;" }
  });
</script>

<!-- src/App.svelte -->
<Router {routes} />
