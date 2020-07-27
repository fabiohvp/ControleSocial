<script>
  import { url } from "@sveltech/routify";
  export let segment = undefined;
  export let href = ".";
  export let exact = true;
  export let title = "";
  export let target = undefined;
  export let props = undefined;
  export let selected = false;
  export let rel = undefined;

  $: selected = exact ? segment === href : href.indexOf(segment);
</script>

<style>
  a {
    width: 100%;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }
</style>

<a
  href={$url(href)}
  {title}
  {rel}
  {target}
  class={$$props.class}
  class:selected
  {...props}>
  <slot />
</a>
