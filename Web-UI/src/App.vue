<template>
    
    <b-container fluid>
        <h1 class="main-title">OMDB API Web App</h1>
        <b-row>
            <b-col class="nav-menu" cols="2">
                <b-nav vertical class="w-75">
                    <b-nav-item active>
                        <router-link to="/">Home</router-link>
                    </b-nav-item>
                    <b-nav-item>
                        <router-link to="/movieLookup">Movie Lookup</router-link>
                    </b-nav-item>
                    <b-nav-item>
                        <router-link to="/movieSearch">Movie Search</router-link>
                    </b-nav-item>
                </b-nav>
            </b-col>
            <b-col cols="8">
                <router-view></router-view>
            </b-col>
        </b-row>
    </b-container>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    import MovieLookup from './components/movieLookup.component.vue';

    export default defineComponent({
        name: 'App',
        components: {
            MovieLookup
        }
    });
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        color: #2c3e50;
        padding-top: 60px;
        background-color: #e5e5e5;
    }

    .main-title {
        text-align: center;
    }

    .nav-menu a {
        color: #000000;
        text-decoration: none;
    }

    .nav-menu a:hover {
        color: #000000;
        text-decoration: underline;
    }
</style>
