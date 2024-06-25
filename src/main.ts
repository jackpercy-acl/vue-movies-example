import './assets/main.css';

import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { OpenAPI } from '@/client';

const app = createApp(App);

app.use(router);

app.mount('#app');

OpenAPI.BASE = 'https://localhost:7011';
