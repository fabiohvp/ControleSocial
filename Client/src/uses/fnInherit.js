export default ($$props, extra = { attrs: {}, directives: {} }) => {
  const { $$slots: _slots, $$scope: _scope, ...props } = $$props;
  const attrs = { ...props, ...extra.attrs };
  const events = {};

  Object.keys(attrs).forEach(function(key) {
    if (key.indexOf("on$") === 0) {
      events[key.substring(3)] = attrs[key];
      delete attrs[key];
    }
  });

  Object.keys(extra.directives || {}).forEach(function(key) {
    if (key.indexOf("on$") === 0) {
      const newKey = key.substring(3);

      if (!events[newKey]) {
        events[newKey] = extra.directives[key];
        events[newKey].override = true;
      }
    }
  });

  return {
    directive: node => {
      const r = {};

      for (let key in events) {
        if (events[key].override) {
          events[key](node);
        } else {
          node.addEventListener(key, events[key]);

          r.destroy = () => {
            node.removeEventListener(key, events[key]);
          };
        }
      }

      return r;
    },
    attrs
  };
};
