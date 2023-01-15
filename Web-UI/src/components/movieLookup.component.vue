<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="lookupResult" class="content">
            
            <div class="row">
                <div class="col-md-12">
                    <pre>{{JSON.stringify(lookupResult)}}</pre>
                </div>
            </div>

        </div>
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