<template>
  <div class="user-edit-container">
    <h2>Editar Usuário</h2>
    <form @submit.prevent="updateUser">
      <div>
        <label for="name">Nome</label>
        <input type="text" id="name" v-model="user.name" required />
      </div>
      <div>
        <label for="email">Email</label>
        <input type="email" id="email" v-model="user.email" required />
      </div>
      <div>
        <label for="phone">Telefone</label>
        <input type="text" id="phone" v-model="user.phone" />
      </div>
      <button type="submit">Atualizar</button>
    </form>
  </div>
</template>

<script>
export default {
  name: 'UserEdit',
  data() {
    return {
      user: {
        name: '',
        email: '',
        phone: '',
      },
    };
  },
  methods: {
    updateUser() {
      // Chamada à API para atualizar os dados do usuário
    },
  },
  mounted() {
    // Carregar os dados do usuário ao montar o componente
  },
};
</script>

<style scoped>
.user-edit-container {
  max-width: 400px;
  margin: 0 auto;
  padding: 2rem;
  border: 1px solid #ccc;
}

form {
  display: flex;
  flex-direction: column;
}

label {
  margin-top: 1rem;
}

button {
  margin-top: 2rem;
  padding: 0.5rem;
  background-color: #4caf50;
  color: white;
  border: none;
}
</style>
