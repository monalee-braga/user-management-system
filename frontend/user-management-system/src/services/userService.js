import axios from 'axios';

const apiUrl = 'http://localhost:5000/api/users'; // Substitua pela URL da sua API

const userService = {
  async getUsers() {
    return await axios.get(apiUrl); // Retorna todos os usuários
  },

  async getUserById(id) {
    return await axios.get(`${apiUrl}/${id}`); // Retorna um usuário pelo ID
  },

  async createUser(user) {
    return await axios.post(apiUrl, user); // Cria um novo usuário
  },

  async updateUser(user) {
    return await axios.put(`${apiUrl}/${user.id}`, user); // Atualiza um usuário existente
  },

  async deleteUser(id) {
    return await axios.delete(`${apiUrl}/${id}`); // Exclui um usuário
  },
};

export default userService;
