import { createRouter, createWebHashHistory } from "vue-router";

import Home from "./components/home.component.vue";
import movieLookupComponentVue from "./components/movieLookup.component.vue";
import movieSearchComponentVue from "./components/movieSearch.component.vue";

const routes = [
    { path: '/', component: Home },
    { path: '/movieLookup', component: movieLookupComponentVue },
    { path: '/movieSearch', component: movieSearchComponentVue }
];

export const router = createRouter({
    history: createWebHashHistory(),
    routes
});