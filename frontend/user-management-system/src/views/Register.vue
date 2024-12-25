<template>
  <div class="register-container">
    <h2>Cadastrar Usuário</h2>
    <form @submit.prevent="register">
      <div>
        <label for="name">Nome</label>
        <input type="text" id="name" v-model="name" required />
      </div>
      <div>
        <label for="email">Email</label>
        <input type="email" id="email" v-model="email" required />
      </div>
      <div>
        <label for="password">Senha</label>
        <input type="password" id="password" v-model="password" required />
      </div>
      <div>
        <label for="phone">Telefone</label>
        <input type="text" id="phone" v-model="phone" />
      </div>
      <button type="submit">Cadastrar</button>
    </form>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'Register',
  data() {
    return {
      name: '',
      email: '',
      password: '',
      phone: '',
    };
  },
  methods: {
    ...mapActions(['registerUser']),
  },
};
</script>

<style scoped>
.register-container {
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
