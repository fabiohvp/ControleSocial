<script>
  import Link from "../Navigation/Link.svelte";
  import { toggleDrawer } from "../Drawer/Drawer.svelte";
  import { closeAllDropdowns } from "../Form/Dropdown/Lista.svelte";

  function onClickHeader(e) {
    e.stopPropagation();
    closeAllDropdowns();
    toggleDrawer();
  }
</script>

<style>
  .Header {
    background-color: #f8f8f8;
    border-color: #e7e7e7;
    width: 100%;
    position: fixed;
  }
</style>

<nav class="flex items-center flex-wrap px-3 z-30 Header h-16">
  <div on:click={onClickHeader} class="sm:block mt-1">
    <button
      class="items-center px-3 py-2 border rounded border-teal-400
      hover:border-white">
      <svg
        class="fill-current h-3 w-3"
        viewBox="0 0 20 20"
        xmlns="http://www.w3.org/2000/svg">
        <title>Menu</title>
        <path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z" />
      </svg>
    </button>
  </div>
  <div class="m-auto md:mx-2">
    <Link href="/">
      <img
        src="/assets/images/logo-cidades.png"
        alt="Logo CidadES"
        class="fill-current"
        width="121" />
    </Link>
  </div>
  <div class="flex-grow lg:flex lg:items-center lg:w-auto sm:block hidden">
    <div class="text-sm lg:flex-grow">
      <slot name="left" />
      <slot name="right" />
    </div>
  </div>
</nav>
