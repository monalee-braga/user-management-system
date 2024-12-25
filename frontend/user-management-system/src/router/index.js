// src/router.js
import { createRouter, createWebHistory } from 'vue-router'; // Importa as funções do Vue Router para Vue 3
import LoginForm from '../views/LoginForm.vue';
import store from '../store'; // Para acessar o Vuex store

const routes = [
  {
    path: '/',
    name: 'login',
    component: LoginForm,
    meta: { requiresAuth: false }, // Página de login não requer autenticação
  },
  // Adicione outras rotas conforme necessário
];

const router = createRouter({
  history: createWebHistory(), // Usando o Web History para Vue 3
  routes,
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = store.state.auth.isAuthenticated;

  if (
    to.matched.some((record) => record.meta.requiresAuth) &&
    !isAuthenticated
  ) {
    next({ name: 'login' }); // Se não estiver autenticado, redireciona para login
  } else {
    next(); // Caso contrário, permite a navegação
  }
});

export default router;
