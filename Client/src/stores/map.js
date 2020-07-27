import { readable } from "svelte/store";

async function fetchES() {
  const res = await fetch("../../assets/maps/es.json");
  const geoJson = await res.json();
  return geoJson;
}

const es = readable({ features: [] }, async set => {
  const geoJson = await fetchES();
  set(geoJson);
});

export { es };
