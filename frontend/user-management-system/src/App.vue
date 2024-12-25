<template>
  <div id="app">
    <!-- Cabeçalho do sistema -->
    <header v-if="isAuthenticated">
      <nav>
        <ul>
          <li><router-link to="/">Home</router-link></li>
          <li></li>
        </ul>
      </nav>
    </header>

    <!-- Corpo da página -->
    <main>
      <!-- Renderiza a tela de login se não estiver autenticado -->
      <router-view v-if="!isAuthenticated"></router-view>

      <!-- Caso esteja autenticado, renderiza as demais rotas -->
      <div v-if="isAuthenticated">
        <router-view></router-view>
      </div>
    </main>

    <!-- Rodapé -->
    <footer v-if="isAuthenticated">
      <p>&copy; 2024 User Management System. Todos os direitos reservados.</p>
    </footer>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: 'App',
  computed: {
    ...mapState({
      isAuthenticated: (state) => state.auth.isAuthenticated,
    }),
  },
};
</script>

<style scoped>
/* Estilos gerais para a aplicação */
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

header {
  background-color: #333;
  padding: 10px;
  color: white;
}

nav ul {
  list-style: none;
  padding: 0;
}

nav ul li {
  display: inline;
  margin-right: 10px;
}

nav ul li a {
  color: white;
  text-decoration: none;
}

footer {
  background-color: #333;
  color: white;
  padding: 10px;
  position: fixed;
  bottom: 0;
  width: 100%;
}

footer p {
  margin: 0;
}
</style>

