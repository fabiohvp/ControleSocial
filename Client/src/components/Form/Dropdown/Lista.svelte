<script context="module">
  import { writable } from "svelte/store";

  export const allowVisible = writable(true);

  export function closeAllDropdowns() {
    allowVisible.set(false);
    allowVisible.set(true);
  }
</script>

<script>
  import { tick } from "svelte";

  export let multiple = false;
  export let items = [];
  export let labels = {
    close: "Fechar"
  };

  let _selecteds;

  let filtered = [];
  let itemsContainerRef;
  let label = "";
  let text = "";
  let textRef;
  let visible = false;
  let lastScrollTop = 0;

  $: {
    _selecteds = items.filter(i => i.selected);

    if (_selecteds.length === 0) {
      onChange();
      if (items.length === 0) {
        filtered = [];
        label = "";
      } else {
        const _items = items.slice(0);
        _items[0].selected = true;
        filtered = _items;
        label = _items[0].label;
      }
    } else {
      onChange();
      filtered = items.slice(0);
      label = _selecteds.map(i => i.label).join(", ");
    }
  }

  $: if (text.length === 0) {
    filtered = items.slice(0);
  } else {
    const _text = text.toLocaleLowerCase();

    filtered = items.filter(
      i =>
        i.label.toLocaleLowerCase().indexOf(text) > -1 ||
        (i.value.toLocaleLowerCase().indexOf(text) > -1 && i.visible !== false)
    );
  }

  allowVisible.subscribe(a => {
    if (!a) {
      close();
    }
  });

  export function close() {
    if (itemsContainerRef) {
      lastScrollTop = itemsContainerRef.scrollTop;
    }
    visible = false;
    text = "";
  }

  async function onClickDropdown(e) {
    e.stopPropagation();

    if (!visible) {
      closeAllDropdowns();
      visible = true;
      await tick();
      textRef.focus();
      itemsContainerRef.scrollTo(0, lastScrollTop);
    } else {
      close();
    }
  }

  function onChange() {
    close();
  }

  export function select(item) {
    onChange();

    if (!multiple) {
      items = items.map(m => {
        m.selected = false;
        return m;
      });
    }

    item.selected = true;
  }

  function onClickWindow(e) {
    closeAllDropdowns();
  }

  function onKeyupWindow(e) {
    const esc = 27;

    if (e.which === esc) {
      closeAllDropdowns();
    }
  }
</script>

<style>
  .dropdown .label {
    width: 100%;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }

  .dropdown :global(li) {
    float: left;
    width: 100%;
  }

  .dropdown :global(li > a) {
    float: left;
    width: 100%;
    @apply p-2;
    @apply cursor-pointer;
  }

  .dropdown :global(li > a:hover) {
    @apply bg-blue-400;
    @apply text-white;
  }

  .dropdown :global(li.active > a) {
    @apply bg-blue-600;
    @apply text-white;
  }

  .dropdown :global(.container) {
    top: 0;
    @apply mt-10;
  }

  @media (max-width: 767px) {
    .dropdown :global(.container) {
      margin-top: 0;
    }
  }

  @media (min-width: 768px) {
    .dropdown :global(.container) {
      position: absolute;
      height: auto;
      padding: 0 0;
    }

    .dropdown :global(.list) {
      max-height: 50vh;
    }
  }
</style>

<svelte:window on:keyup={onKeyupWindow} on:click={onClickWindow} />

<div class="relative float-left w-full dropdown">
  <div
    class="appearance-none w-full bg-white border border-gray-200
    hover:border-gray-300 rounded shadow focus:outline-none focus:shadow-outline
    p-1 md:px-2 float-left cursor-pointer"
    on:click={onClickDropdown}>
    <span class="float-left label">{label}</span>
    <!-- <span
      class="pointer-events-none absolute inset-y-0 right-0 flex items-center
      px-2 text-gray-700">
      <svg
        class="fill-current h-4 w-4"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20">
        <path
          d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586
          4.343 8z" />
      </svg>
    </span> -->
  </div>
  {#if visible}
    <div
      class="container rounded shadow z-10 bg-white w-full h-full fixed left-0
      z-50">
      <div class="w-full p-2">
        <input
          bind:this={textRef}
          bind:value={text}
          class="border-2 rounded h-8 w-full px-2" />
      </div>

      <div bind:this={itemsContainerRef} class="list overflow-y-auto h-full">
        <ul class="list-reset pb-24 md:pb-0">
          <slot items={filtered} />
        </ul>
      </div>

      <div
        class="fixed bottom-0 md:hidden bg-white w-full text-center
        hover:bg-gray-200 h-12 cursor-pointer border-t border-gray-300"
        style="line-height:3rem;"
        on:click={close}>
        {labels.close}
      </div>
    </div>
  {/if}
</div>
