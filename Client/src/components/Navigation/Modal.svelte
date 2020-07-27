<script>
  import { createEventDispatcher, tick } from "svelte";
  import Icon from "fa-svelte";
  import { faTimesCircle } from "@fortawesome/free-solid-svg-icons/faTimesCircle";

  const dispatch = createEventDispatcher();
  const esc = 27;

  let visible = false;
  let modalRef = null;

  $: if (modalRef) {
    modalRef.focus();
  }

  function handleKeydown(event) {
    if (event.target === modalRef && event.which === esc) {
      close();
    }
  }

  export async function show() {
    visible = true;
  }

  export async function close() {
    dispatch("close");
    await tick();
    visible = false;
  }
</script>

<style>
  .modal-background {
    position: fixed;
    z-index: 998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.3);
  }

  .modal {
    z-index: 999;
    position: fixed;
    border-radius: 0.2em;
    background: white;
    top: 4rem;
    left: 0;
    width: 100%;
    min-height: calc(100% - 4rem);
  }

  @media (min-width: 640px) {
    .modal {
      left: 50%;
      top: 50%;
      width: 70vw;
      min-height: 70vh;
      transform: translate(-50%, -50%);
    }
  }

  .modal:focus {
    outline: inherit;
  }

  .header {
    height: 3em;
    line-height: 3em;
    @apply px-5;
  }

  .body {
    height: calc(100vh - 5em);
    overflow-y: auto;
    padding-bottom: 1em;
  }
</style>

<svelte:window on:keydown={handleKeydown} />

{#if visible}
  <div class="modal-background" />

  <div
    class={$$props.class}
    class:modal={true}
    tabindex="0"
    bind:this={modalRef}>
    <div class="relative">
      <div class="header">
        <span
          class="absolute cursor-pointer text-red-700 text-xl"
          style="top:-.50em;right:.25em;"
          on:click={close}>
          <Icon icon={faTimesCircle} />
        </span>
        <slot name="header" />
      </div>

      <div class="body">
        <div class="px-5">
          <slot />
        </div>
      </div>
    </div>
  </div>
{/if}
