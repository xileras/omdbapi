import { createRouter, createWebHashHistory } from "vue-router";

import Home from "./components/home.component.vue";
import movieLookupComponentVue from "./components/movieLookup.component.vue";
import movieSearchComponentVue from "./components/movieSearch.component.vue";
import notFoundComponent from "./components/404notFound.component.vue";

const routes = [
    { path: '/', component: Home },
    { path: '/movieLookup', component: movieLookupComponentVue },
    { path: '/movieLookup/:imdbID', name: 'lookup', component: movieLookupComponentVue },
    { path: '/movieSearch', component: movieSearchComponentVue },
    { path: '/:pathMatch(.*)*', name: "Not Found", component: notFoundComponent },
];

export const router = createRouter({
    history: createWebHashHistory(),
    routes
});