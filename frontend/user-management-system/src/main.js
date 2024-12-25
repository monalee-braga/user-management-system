// src/main.js
import { createApp } from 'vue'; // Importa o Vue 3
import App from './App.vue';
import router from './router'; // Importa o router
import store from './store'; // Importa o store Vuex

const app = createApp(App);
app.use(router); // Configura o Vue Router no Vue 3
app.use(store); // Configura o Vuex no Vue 3
app.mount('#app'); // Monta o app na div com id="app"

