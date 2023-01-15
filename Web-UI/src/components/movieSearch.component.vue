<template>
    <div class="post">
        <b-container>
            <h2>Movie Search</h2>

            <b-row>
                <b-col cols="2">
                    <label name="film-title" class="form-label">Film Title:</label>
                </b-col>
                <b-col col="4">
                    <input for="film-title" v-model="filmTitle" />
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="1">
                    <button class="btn btn-primary" @click="searchFilm">Search</button>
                </b-col>
            </b-row>

            <!-- Show a grid if there is data -->
            <b-row v-if="results && results.search && dataLoaded">
                <b-col>

                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Title</th>
                                <th>Year</th>
                                <th>IMDB ID</th>
                                <th>Type</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="result in results.search" :key="results.imdbID">
                                <td><img width="32" :src="result.poster" /></td>
                                <td>{{ result.title }}</td>
                                <td>{{ result.year }}</td>
                                <td><router-link :to="{ name: 'lookup', params: { imdbID: result.imdbID }}">{{ result.imdbID }}</router-link></td>
                                <td>{{ result.type }}</td>
                            </tr>
                        </tbody>
                    </table>

                </b-col>
            </b-row>
            
            <!-- Show no results if there is no data -->
            <b-row v-if="results && !results.search && dataLoaded">
                <p>No data found</p>
            </b-row>

        </b-container>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { MovieSearchResult } from './movieSearch.model'

    interface Data {
        filmTitle: string,
        dataLoaded: boolean,
        results: null | MovieSearchResult
    }

    export default defineComponent({
        data(): Data {
            return {
                filmTitle: '',
                dataLoaded: false,
                results: null
            };
        },
        methods: {
            searchFilm(): void {
                this.results = null;
                this.dataLoaded = false;

                fetch(`Movie/GetMoviesByName/${this.filmTitle}`)
                    .then(r => r.json())
                    .then(json => {
                        this.results = json as MovieSearchResult;
                        this.dataLoaded = true;
                        return;
                    });
            }
        },
    });
</script>