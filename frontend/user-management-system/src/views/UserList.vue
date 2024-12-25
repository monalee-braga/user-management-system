<template>
  <div class="user-list-container">
    <h2>Lista de Usuários</h2>
    <input
      type="text"
      v-model="searchQuery"
      placeholder="Buscar por nome ou email"
      class="search-input"
    />
    <ul v-if="filteredUsers.length > 0">
      <li v-for="user in filteredUsers" :key="user.id" class="user-item">
        <UserCard
          :user="user"
          @edit="editUser(user)"
          @delete="deleteUser(user.id)"
        />
      </li>
    </ul>
    <p v-else>Nenhum usuário encontrado.</p>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex';
import UserCard from '@/components/UserCard.vue';

export default {
  name: 'UserList',
  components: {
    UserCard,
  },
  data() {
    return {
      searchQuery: '',
    };
  },
  computed: {
    ...mapState({
      users: (state) => state.users, // Pega a lista de usuários do Vuex
    }),
    filteredUsers() {
      // Filtra os usuários com base na pesquisa
      return this.users.filter(
        (user) =>
          user.name.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
          user.email.toLowerCase().includes(this.searchQuery.toLowerCase()),
      );
    },
  },
  methods: {
    ...mapActions(['fetchUsers', 'deleteUser']), // Ações Vuex para carregar e excluir usuários

    editUser(user) {
      // Redireciona para a página de edição de usuário
      this.$router.push({ name: 'userEdit', params: { id: user.id } });
    },
  },
  mounted() {
    // Carrega os usuários ao montar o componente
    this.fetchUsers();
  },
};
</script>

<style scoped>
.user-list-container {
  max-width: 800px;
  margin: 0 auto;
  padding: 2rem;
  border: 1px solid #ccc;
}

.search-input {
  width: 100%;
  padding: 0.5rem;
  margin-bottom: 1rem;
  border-radius: 4px;
  border: 1px solid #ccc;
}

ul {
  list-style-type: none;
  padding: 0;
}

.user-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  border-bottom: 1px solid #ccc;
}

p {
  text-align: center;
  color: gray;
}
</style>
