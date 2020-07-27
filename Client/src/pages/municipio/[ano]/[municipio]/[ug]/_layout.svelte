<script>
  import { route } from "@sveltech/routify";
  import settings from "../../../../../stores/settings.js";
  import Breadcrumb from "../../../../../components/Breadcrumb/Breadcrumb.svelte";
  import DropdownLista from "../../../../../components/Form/Dropdown/Lista.svelte";
  import Link from "../../../../../components/Navigation/Link.svelte";
  import Gear from "../../../../../components/Icons/Gear.svelte";
  import menu from "./menu.js";
  import menuStore, { updateMenu } from "../../../../../stores/menu.js";

  let ano;
  let municipio;
  let segments;
  let ug;

  $: refresh($route);

  function refresh({ params, path }) {
    const _segments = path
      .replace("/municipio/:ano/:municipio/:ug/", "")
      .split("/");

    ano = parseInt(params.ano);
    municipio = params.municipio;
    segments = (_segments[_segments.length - 1].toLowerCase() === "index"
      ? _segments.slice(0, _segments.length - 1)
      : _segments
    ).join("/");
    ug = params.ug;

    menuStore.set(updateMenu(menu, _segments));
    window.scrollTo(0, 0);
  }
</script>

<div class="breadcrumb fixed w-full h-12 pt-2 px-3 bg-white z-40">
  <Breadcrumb>
    <span class="w-1/2 mr-1">
      <DropdownLista items={settings.municipios.get(municipio)} let:items>
        {#each items as item}
          <li class:active={item.selected}>
            <Link
              href={`/municipio/${ano}/${item.value}/${ug}/${segments}`}
              title={item.label}>
              {@html item.label}
            </Link>
          </li>
        {/each}
      </DropdownLista>
    </span>
    {#each $menuStore as menu}
      <span class="w-1/2 mx-1">
        <DropdownLista items={menu} let:items>
          {#each items as item}
            <li class:active={item.selected}>
              <Link
                href={`/municipio/${ano}/${municipio}/${ug}/${item.path}`}
                title={item.title}>
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
            <Link
              href={`/municipio/${item.value}/${municipio}/${ug}/${segments}`}
              title={item.label}>
              {@html item.label}
            </Link>
          </li>
        {/each}
      </DropdownLista>
    </span>
    <!-- <span class="text-lg ml-1 self-center" style="width:40px;">
      <Gear />
    </span> -->
  </Breadcrumb>
</div>

<div class="w-full px-2 pt-12 pb-2">
  <slot />
</div>
