<script>
  import { fade } from "svelte/transition";

  let visible = false;
  let hideTimer;
  let inverseX = false;

  export let width = 40;
  export let hideTimeout = 250;

  export function show(e) {
    clearTimeout(hideTimer);

    if (visible) {
      return;
    }

    const widthPx = (width / 100) * e.view.innerWidth;
    const diff = e.x + widthPx - e.view.innerWidth;

    if (diff > 0) {
      inverseX = true;
    }

    visible = true;
  }

  export function hide(e) {
    hideTimer = setTimeout(() => {
      inverseX = false;
      visible = false;
    }, hideTimeout);
  }
</script>

<style>
  .tooltip {
    position: absolute;
    top: 100%;
    left: 0;
    background: #f6f7d5;
    color: black;
    border-radius: 3px;
    box-shadow: 0 0 2px rgba(0, 0, 0, 0.5);
    padding: 10px 10px;
  }

  .inverse-x {
    left: unset;
    right: 0;
  }
</style>

<span class="relative w-full float-left">
  <span class="text-center w-full float-left">
    <slot name="icon">i</slot>
  </span>
  <span
    transition:fade|local={{ duration: 150 }}
    class:inverse-x={inverseX}
    class:hidden={!visible}
    class="tooltip z-40"
    style={`width:${width}vw;`}>
    <slot />
  </span>
</span>
