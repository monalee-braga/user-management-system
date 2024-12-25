<template>
  <nav>
    <ul>
      <li><router-link to="/login">Login</router-link></li>
      <li><router-link to="/register">Cadastrar</router-link></li>
      <li><router-link to="/users">Lista de Usuários</router-link></li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: 'Navbar',
};
</script>

<style scoped>
nav {
  background-color: #333;
  padding: 1rem;
}

ul {
  display: flex;
  list-style-type: none;
}

li {
  margin-right: 1rem;
}

a {
  color: white;
  text-decoration: none;
}
</style>
