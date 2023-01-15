<template>
    <div class="post">
        <h2>Movie Lookup</h2>

        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="!!lookupResult && !!lookupResult.title" class="content">

            <b-row>
                <b-col>

                    <b-row>
                        <b-col cols="2">Title:</b-col> <b-col cols="8">{{lookupResult.title}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Year:</b-col> <b-col cols="8">{{lookupResult.year}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Rated:</b-col> <b-col cols="8">{{lookupResult.rated}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Released:</b-col> <b-col cols="8">{{lookupResult.released}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Runtime:</b-col> <b-col cols="8">{{lookupResult.runtime}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Genre:</b-col> <b-col cols="8">{{lookupResult.genre}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Director:</b-col> <b-col cols="8">{{lookupResult.director}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Writer:</b-col> <b-col cols="8">{{lookupResult.writer}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Actors:</b-col> <b-col cols="8">{{lookupResult.actors}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Plot:</b-col> <b-col cols="8">{{lookupResult.plot}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Language:</b-col> <b-col cols="8">{{lookupResult.language}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Country:</b-col> <b-col cols="8">{{lookupResult.country}}</b-col>
                    </b-row>

                    <b-row>
                        <b-col cols="2">Awards:</b-col> <b-col cols="8">{{lookupResult.awards}}</b-col>
                    </b-row>

                </b-col>

                <b-col cols="4">
                    <b-row>
                        <b-col cols="2"> <img :src="lookupResult.poster" /></b-col>
                    </b-row>
                </b-col>

            </b-row>

        </div>

        <!-- Show no results if there is no data -->
        <b-row v-if="!!lookupResult && lookupResult.title == null">
            <p>No data found</p>
        </b-row>

    </div>
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

                let url: string;

                if (!!this.$route.params.imdbID) {
                    url = `Movie/${this.$route.params.imdbID}`;
                }
                else {
                    url = "Movie/tt1285016";
                }

                fetch(url)
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