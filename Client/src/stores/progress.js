import { writable } from "svelte/store";

const progress = writable(false);
export default progress;