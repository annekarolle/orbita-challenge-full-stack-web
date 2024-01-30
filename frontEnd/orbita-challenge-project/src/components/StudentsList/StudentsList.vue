<style src='./styles.css' ></style>

<script lang="ts">
 

export default {
  data() {
    return {
      showModal: false,
     
    };
    
  },
 
  methods: {
    
    editarAluno(id) {     
      
    }, 

    openModal() {
    console.log(this.showModal)
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
    },
  },
  
}
</script>

<template>
  <section>
    <div class="container-header">
        <h3>
           Consulta de alunos
        </h3>
    </div>
 <div>
    <div class="main-container-search-students">
        <div class="container-search-students">
            <input type="text">
            <button class="btn">Pesquisar</button>
        </div>
        <router-link to="/dashboard/cadastrar" class="link">
         <button class="btn btn-save" style="width: 150px">Cadastrar Aluno</button>
        </router-link>
    </div>
 </div>
 <table>
    <thead>
      <tr>
        <th>Registro Acadêmico</th>
        <th>Nome</th>
        <th>CPF</th>
        <th>Ações</th>
      </tr>
    </thead>
    <tbody>      
      <tr>
        <td>12345</td>
        <td>João Silva</td>
        <td>123.456.789-00</td>
        <td>
          <button @click="editarAluno" class="btn-action">Editar</button>
          <button @click="openModal"  class="btn-action">Excluir</button>
        </td>
      </tr>    
    </tbody>
  </table>
  </section>
  <div class="modal" v-if="showModal">
    <div class="modal-content">
      <span class="close" @click="closeModal">&times;</span>
       <h1>teste</h1>
      <slot></slot>
    </div>
  </div>
</template>
