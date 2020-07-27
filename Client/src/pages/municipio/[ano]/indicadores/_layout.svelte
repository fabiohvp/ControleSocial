<script>
  import { route } from "@sveltech/routify";
  import settings from "../../../../stores/settings.js";
  import Breadcrumb from "../../../../components/Breadcrumb/Breadcrumb.svelte";
  import DropdownLista from "../../../../components/Form/Dropdown/Lista.svelte";
  import Link from "../../../../components/Navigation/Link.svelte";
  import Gear from "../../../../components/Icons/Gear.svelte";
  import menu from "./menu.js";
  import menuStore, { updateMenu } from "../../../../stores/menu.js";

  let ano;
  let segments;

  $: refresh($route);

  function refresh({ params, path }) {
    const _segments = path
      .replace("/municipio/:ano/indicadores/", "")
      .split("/");

    ano = parseInt(params.ano);
    segments = (_segments[_segments.length - 1].toLowerCase() === "index"
      ? _segments.slice(0, _segments.length - 1)
      : _segments
    ).join("/");

    menuStore.set(updateMenu(menu, _segments));
    window.scrollTo(0, 0);
  }
</script>

<style>
  .container {
    @apply float-left;
    @apply pt-12;
    @apply pb-2;
    @apply px-3;
  }

  .header {
    @apply w-full;
    @apply text-center;
    @apply mt-5;
    background-image: url(/assets/images/fundo-comparacao-municipios.png);
    background-repeat: repeat-x;
    height: 53px;
    line-height: 53px;
  }

  @media (min-width: 768px) {
    .container {
      margin-left: 12.5%;
      min-width: 75%;
      max-width: 75%;
    }
  }
</style>

<div class="breadcrumb fixed w-full h-12 pt-2 px-2 bg-white z-40">
  <Breadcrumb>
    {#each $menuStore as menu}
      <span class="w-1/2 mx-1">
        <DropdownLista items={menu} let:items>
          {#each items as item}
            <li class:active={item.selected}>
              <Link href={`/municipio/${ano}/indicadores/${item.path}`}>
                {@html item.label}
              </Link>
            </li>
          {/each}
        </DropdownLista>
      </span>
    {/each}
    <span class="w-1/2 mx-1">
      <DropdownLista items={settings.anos.get(ano, segments)} let:items>
        {#each items as item}
          <li class:active={item.selected}>
            <Link href={`/municipio/${item.value}/indicadores/${segments}`}>
              {@html item.label}
            </Link>
          </li>
        {/each}
      </DropdownLista>
    </span>
    <span class="text-lg ml-1 self-center" style="width:40px;">
      <Gear />
    </span>
  </Breadcrumb>
</div>

<div class="container">
  <!-- <p>
    A ferramenta de Indicadores Consolidados permite que você tenha uma visão
    geral da situação de todos os municípios capixabas. Os indicadores são
    apresentados por agrupamentos temáticos, como receitas, despesas, saúde,
    educação, pessoal, etc. É muito simples: basta selecionar o agrupamento
    temático desejado. Ah, e você pode ordenar as colunas clicando sobre os
    títulos.
  </p>

  <div class="header">teste</div> -->

  <slot />
</div>
