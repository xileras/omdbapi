<template>
    <h2>Home</h2>
    <p>Deary me, this UI isn't quite the best, is it?</p>
    <p>In my defense, this is my first attempt at Vue.js and it wasn't the easiest thing in the world to configure Bootstrap 5 to work with Vue 3, given that there hasn't actually been an offical update from Bootstrap that supports this version of Vue 3.</p>
    <p>Anyway, there are 3 main items to this little web-app. The first is the Movie Lookup, which by default will show some details about the Social Network.</p>
    <p>The second item lets you search for a movie title and when you click the button, will show you all matching results pertaining to your search term. You can click on the IMDB ID, which will show you more details about that particular movie.</p>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { MovieLookupResult } from './movieLookup.model'

    interface Data {
        loading: boolean,
        lookupResult: null | MovieLookupResult
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                lookupResult: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.lookupResult = null;
                this.loading = true;

                fetch('Movie')
                    .then(r => r.json())
                    .then(json => {
                        this.lookupResult = json as MovieLookupResult;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>