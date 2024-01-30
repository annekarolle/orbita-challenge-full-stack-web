<style src='./styles.css'></style>

<script lang="ts">

import { GetStudentBYRA, EditStudent } from "../../services/StudentsService";
import { useRoute } from 'vue-router';
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

export default {
  data() {
    return {
      ra: "",
      student: {
        name: '',
        email: '',
        cpf: '',
        ra: ''
      },
      route: useRoute(),
    };
  },
  methods: {
    async handleSubmit() {
      const body = {
        ra: this.ra,
        name: this.student.name,
        email: this.student.email,     
      };
      try {
        await EditStudent(body).then(response => {

            toast.success(response.data)

        });

      } catch (error) {
        console.error('Erro ao salvar aluno:', error);
      }
    },
    async getStudent() {
      try {
        await GetStudentBYRA(this.ra).then(response => {

          this.student = {
            name: response.data.name,
            email: response.data.email,
            cpf: response.data.cpf,
            ra: response.data.ra
          };
        });

      } catch (error) {
        console.error('Erro ao obter aluno:', error);
      }
    }
  },
  mounted() {
    const raParam = this.route.params.ra;

    if (typeof raParam === 'string') {
      this.ra = raParam;
      this.getStudent();
    } else if (Array.isArray(raParam) && raParam.length > 0) {
      this.ra = raParam[0];
      this.getStudent();
    }
  },

}
</script>

<template>
  <section>
    <div class="container-header">
      <h3>Cadastro de aluno</h3>
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
          <input type="text" placeholder="Informe o registro acadêmico" v-model="student.ra" disabled >
        </div>
        <div class="container-input">
          <label for="">CPF</label>
          <input type="text" placeholder="Informe o número do documento" v-model="student.cpf" disabled>
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
