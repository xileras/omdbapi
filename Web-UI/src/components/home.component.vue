<template>
The Home Component
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