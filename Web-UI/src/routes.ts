import Home from "./components/home.component.vue";
import movieLookupComponentVue from "./components/movieLookup.component.vue";
import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
    { path: '/', component: Home },
    { path: '/movieLookup', component: movieLookupComponentVue}
];

export const router = createRouter({
    // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
    history: createWebHashHistory(),
    routes, // short for `routes: routes`
});