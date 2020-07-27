<script context="module">
  import { writable } from "svelte/store";

  export const visible = writable(false);

  export function toggleDrawer() {
    visible.update(d => !d);
  }

  export function showDrawer() {
    visible.update(d => true);
  }

  export function hideDrawer() {
    visible.update(d => false);
  }
</script>

<script>
  import Link from "../Navigation/Link.svelte";

  function onClickWindow(e) {
    hideDrawer();
  }

  function onKeyupWindow(e) {
    const esc = 27;

    if (e.which === esc) {
      hideDrawer();
    }
  }
</script>

<style>
  .navbar {
    height: calc(100vh - 4rem);
  }

  .navbar-open {
    display: block;
    z-index: 60;
  }
  .navbar-close {
    display: none;
  }
  .navbar :global(.navbar-link a):hover {
    @apply bg-blue-700;
  }
</style>

<svelte:window on:keyup={onKeyupWindow} on:click={onClickWindow} />

<div
  class="Drawer navbar w-full lg:w-1/6 mt-16 fixed overflow-x-auto bg-gray-700
  top-0 pb-5"
  class:navbar-open={$visible}
  class:navbar-close={!$visible}>
  <slot />
</div>
