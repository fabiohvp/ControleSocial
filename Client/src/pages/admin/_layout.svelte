<script>
  import { route } from "@sveltech/routify";
  import Login from "./_components/Login.svelte";
  import { token } from "../../utils/api.js";

  let isAuthenticated;
  let hasRoles;
  $: refreshUser($token);

  function refreshUser(_token) {
    isAuthenticated = token.isAuthenticated();
    hasRoles = token.hasRoles($route.meta.roles);
  }
</script>

<svelte:head>
  <title>CIDADES - PLATAFORMA PARA TRANSPARÊNCIA PÚBLICA</title>
</svelte:head>

<div class="p-4">
  {#if isAuthenticated}
    {#if hasRoles}
      <slot />
    {:else}teste{/if}
  {:else}
    <Login />
  {/if}
</div>
