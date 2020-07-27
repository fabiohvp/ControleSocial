import { writable } from "svelte/store";

const menus = writable([]);

export function updateMenu(items, segments, count = 1) {
  let _menus = [];
  const _segment = segments.slice(0, count).join("/");

  const _menu = items.map(m => {
    m.selected = m.path === _segment;

    if (m.selected && m.children) {
      let _children = updateMenu(m.children, segments, count + 1);
      _menus = _menus.concat(_children);
    }

    return m;
  });

  _menus = [_menu].concat(_menus);
  return _menus;
}

export default menus;
