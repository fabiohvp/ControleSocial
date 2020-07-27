<script>
  import { onMount } from "svelte";
  import { route } from "@sveltech/routify";

  //import tailwindConfig from "../../tailwind.config.js";
  import progressStore from "../stores/progress.js";

  import Drawer from "../components/Drawer/Drawer.svelte";
  import Header from "../components/Header/Header.svelte";
  import Link from "../components/Navigation/Link.svelte";
  import { token } from "../utils/api.js";
  import notify from "../utils/notification.js";

  let isAuthenticated;
  let ano = 2020;
  let municipio = "001";
  let ug = "consolidado";

  $: refresh($route);
  $: $token, (isAuthenticated = token.isAuthenticated());

  function refresh(route) {
    progressStore.set(false);
  }

  onMount(async () => {
    // if (process.env.NODE_ENV !== "development") {
    //   notify(
    //     "Notificação",
    //     "Houve uma atualização nos dados de 2019 do município 001",
    //     "https://cidades.tce.es.gov.br"
    //   );
    // }
  });

  function signOut() {
    token.signOut();
  }
</script>

<style>
  .Main {
    @apply pt-16;
  }
  .header :global(.header-link) {
    @apply mr-4;
    @apply text-gray-700;
    @apply font-bold;
  }

  .drawer :global(.navbar-link > a) {
    @apply cursor-pointer;
    @apply p-2;
    @apply w-full;
    @apply float-left;
  }

  @media print {
    :global(.Drawer, .Header, .breadcrumb) {
      display: none;
    }

    .Main {
      padding: 0 0;
    }
  }
</style>

<Header>
  <ul class="header list-none" slot="left">
    <!-- <li class="float-left">
      <Link
        href={`/municipio/${ano}/${municipio}/${ug}/receitas`}
        class="header-link">
        Municípios
      </Link>
    </li> -->
    <!-- <Link href={`/estado/${ano}`} class="header-link">Estado</Link>
    <Link
      href={`/municipio/${ano}/indicadores/composicao-receita-arrecadada`}
      class="header-link">
      Indicadores
    </Link> -->
    <!-- <Link href="/municipio/visao-geral" class="header-link">Municípios</Link> -->
    <!-- <Link href="/estado" class="header-link" >Estado</Link>
    <Link href="/obrigacaoEnvio" class="header-link">Obrigações</Link>
    <Link href="/fiscalizacao" class="header-link">Fiscalizações</Link>
    <Link href="/prestacaoConta" class="header-link">Prestações de contas</Link>
    <Link href="/folhaPagamento" class="header-link">Folha de pagamento</Link>
    <Link href="/dadosAbertos" class="header-link">Dados abertos</Link> -->
    <li class="float-right">
      {#if isAuthenticated}
        <button class="header-link" on:click={signOut}>Sair</button>
      {:else}
        <Link href={`/admin`} class="header-link">Admin</Link>
      {/if}
    </li>
  </ul>
</Header>
<Drawer>
  <ul class="drawer list-none text-white">
    <!-- <li class="navbar-link">
      <Link
        href={`/municipio/${ano}/${municipio}/${ug}/visao-geral`}
        rel="prefetch">
        Visão geral
      </Link>
    </li> -->
    <li class="navbar-link">
      <Link href={`/municipio/${ano}/${municipio}/${ug}/receitas`}>
        Receitas
      </Link>
    </li>
    <li class="navbar-link">
      <Link href={`/municipio/${ano}/${municipio}/${ug}/despesas`}>
        Despesas
      </Link>
    </li>
    <!-- <li class="navbar-link">
      <Link href={`/municipio/${ano}/${municipio}/${ug}/previdencia`}>
        Previdência
      </Link>
    </li>
    <li class="navbar-link">
      <Link href={`/municipio/${ano}/indicadores`}>Indicadores</Link>
    </li> -->
  </ul>
</Drawer>
<main class="Main">
  <slot />
</main>
