<style lang="css" src="./styles.css"></style>
  
<script>
import { Login } from '@/services/AuthService';
import {toast} from "vue3-toastify";
import 'vue3-toastify/dist/index.css';
export default {
  components: {

  },
  data() {
    return {
      email: '',
      password: '',
    };
  }, 
  methods: {
    login() {   
      const data = {
        email: this.email,
        password: this.password
      }

      Login(data).then((response) => {
        console.log(response)
        toast.success('Login Efetuado com Sucesso')
        this.$router.push('/dashboard/welcome');
      }).catch((error) => {
        toast.error('Oops! Usuário ou senha incorretos!')
        console.error('Erro durante o login:', error);
      });
      
    },
  },
};
</script>

<template>

<div class="container-home-page">
  <div class="container-imagem">
    <img src="./../../assets/home.png">
  </div>
  <div class="container-form">
    <h2 style="color: var(--brand-color3)">Login</h2>
    <form @submit.prevent="login">
      <label for="email">Email:</label>
      <input type="text" id="email" v-model="email" required>
      <label for="password">Password:</label>

      <input type="password" id="password" v-model="password" required>
      <button class="btn btn-save" type="submit">Login</button>
    </form>
  </div>
</div>
</template>
  
