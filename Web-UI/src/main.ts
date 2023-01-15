import { createApp } from 'vue';
import App from './App.vue';
import { router } from './routes';

import BootstrapVueNext from 'bootstrap-vue-next';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

createApp(App)
    .use(BootstrapVueNext)
    .use(router)
    .mount('#app');
