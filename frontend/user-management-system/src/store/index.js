import { createStore } from 'vuex';

const store = createStore({
  state() {
    return {
      auth: {
        isAuthenticated: false,
        token: '',
      },
    };
  },
  mutations: {
    login(state, token) {
      state.auth.isAuthenticated = true;
      state.auth.token = token;
    },
    logout(state) {
      state.auth.isAuthenticated = false;
      state.auth.token = '';
    },
  },
  actions: {
    login({ commit }, token) {
      commit('login', token);
    },
    logout({ commit }) {
      commit('logout');
    },
  },
  getters: {
    isAuthenticated: (state) => state.auth.isAuthenticated,
  },
});

export default store;
