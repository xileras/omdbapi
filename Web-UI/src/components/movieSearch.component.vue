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

            <b-row v-if="searchResults">
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
                            <tr v-for="result in searchResults.search" :key="searchResults.imdbID">
                                <td><img width="32" :src="result.poster" /></td>
                                <td>{{ result.title }}</td>
                                <td>{{ result.year }}</td>
                                <td>{{ result.imdbID }}</td>
                                <td>{{ result.type }}</td>
                            </tr>
                        </tbody>
                    </table>

                </b-col>
            </b-row>

        </b-container>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { MovieSearchResult } from './movieSearch.model'

    interface Data {
        filmTitle: string,
        loading: boolean,
        searchResults: null | MovieSearchResult
    }

    export default defineComponent({
        data(): Data {
            return {
                filmTitle: '',
                loading: false,
                searchResults: null
            };
        },
        methods: {
            searchFilm(): void {
                this.searchResults = null;
                this.loading = true;

                fetch(`Movie/GetMoviesByName/${this.filmTitle}`)
                    .then(r => r.json())
                    .then(json => {
                        this.searchResults = json as MovieSearchResult;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>