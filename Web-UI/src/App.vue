<template>
    <h1>OMDB API Web App</h1>

    <div>

    </div>

    <b-container>
        <b-row>
            <b-col cols="2">
                <b-nav vertical class="w-75">
                    <b-nav-item active>
                        <router-link to="/">Home</router-link>
                    </b-nav-item>
                    <b-nav-item>
                        <router-link to="/movieLookup">Movie Lookup</router-link>
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
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
