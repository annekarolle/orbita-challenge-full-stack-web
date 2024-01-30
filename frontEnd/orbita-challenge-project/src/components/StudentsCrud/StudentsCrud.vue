<style src='./styles.css' ></style>

<script lang="ts">

import {CreateStudent,GetStudentBYRA } from "@/services/StudentsService"
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import app from "@/App.vue";
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';



 

export default {
  data() {
    return {
      ra: "",

      student: {
        name: '',
        email: '',
        ra: '',
        cpf: '',
      },
      route : useRoute(),
    };
  },
  methods: {
    async handleSubmit() {


      try {        
        await CreateStudent(this.student).then(response => {
          toast.success(response)
         this.student = {
                      name: '',
                      email: '',
                      ra: '',
                      cpf: '',
                    };
        });   

      } catch (error) {
        console.error('Erro ao salvar aluno:', error);
      }
    },
  },
  
}
</script>

<template>
  <section>
    <div class="container-header">
        <h3>
           Cadastro de aluno 
        </h3>
    </div>
 
   <div class="container-crud">
    <form @submit.prevent="handleSubmit">

      <div class="container-input">
        <label for="">Nome</label>
        <input type="text" placeholder="Informe o nome completo" v-model="student.name">
      </div>
      <div class="container-input">
        <label for="">E-mail</label>
        <input type="text" placeholder="Informe apenas um e-mail" v-model="student.email">
      </div>
      <div class="container-input">
        <label for="">RA</label>
        <input type="text" placeholder="Informe o registro acadêmico" v-model="student.ra">
      </div>
      <div class="container-input">
        <label for="">CPF</label>
        <input type="text" placeholder="Informe o número do documento" v-model="student.cpf">
      </div>
        <div class="btn-container">
          <router-link to="/dashboard/listar" class="link">
          <button class="btn btn-cancel">Cancelar</button>
        </router-link>
          <button class="btn btn-save" type="submit">Salvar</button>
        </div>
    </form>
   </div>
  </section>
</template>
