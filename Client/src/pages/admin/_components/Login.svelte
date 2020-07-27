<script>
  import { createEventDispatcher } from "svelte";
  import api, { token } from "../../../utils/api.js";
  import * as autenticacaoApi from "../../../stores/autenticacao/autenticacao.js";
  const dispatch = createEventDispatcher();

  let isAuthenticated;
  let email;
  let senha;
  let error;

  $: refreshUser($token);

  function refreshUser(_token) {
    isAuthenticated = token.isAuthenticated();
  }

  async function onSignIn() {
    error = undefined;
    const res = await api.post(
      api.getApiUrl("DWControleSocial/Authenticate"),
      autenticacaoApi.signIn(email.value, senha.value)
    );
    const data = res.data[0];

    if (data.error) {
      error = data.error;
      dispatch("error", data.error);
    } else {
      token.signIn(res.data[0].value);
      dispatch("login", res.data[0].value);
    }
  }

  async function onSignOut() {
    error = undefined;
    token.signOut();

    const res = await api.post(
      api.getApiUrl("DWControleSocial/Authenticate"),
      autenticacaoApi.signOut()
    );
    const data = res.data[0];

    if (data.error) {
      error = data.error;
      dispatch("error", data.error);
    } else {
      token.signOut();
      dispatch("logout", res.data[0].value);
    }
  }
</script>

{#if !isAuthenticated}
  <div class="container mx-auto">
    <div class="w-full">
      <div class="mb-4">
        <label class="block text-md font-light mb-2">Email</label>
        <input
          class="w-full border-gray-500 appearance-none border p-4 font-light
          leading-tight focus:outline-none focus:shadow-outline"
          type="text"
          placeholder="Email"
          bind:this={email} />
      </div>
      <div class="mb-4">
        <label class="block text-md font-light mb-2">Senha</label>
        <input
          class="w-full border-gray-500 appearance-none border p-4 font-light
          leading-tight focus:outline-none focus:shadow-outline"
          type="password"
          placeholder="Senha"
          bind:this={senha} />
      </div>
      {#if error}
        <p class="text-red-600 mb-2">{error.Message}</p>
      {/if}
      <div class="flex items-center justify-between mb-5">
        <button
          class="bg-indigo-600 hover:bg-blue-700 text-white font-light py-2 px-6
          rounded focus:outline-none focus:shadow-outline"
          type="button"
          on:click={onSignIn}>
          Autenticar
        </button>
      </div>
    </div>
  </div>
{/if}
