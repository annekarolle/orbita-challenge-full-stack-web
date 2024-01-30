<style src='./styles.css' ></style>

<script lang="ts">
export default {
  data() {
    return {
      students: [1, 2, 3, 4, 5, 6, 7, 8]
    };
  },
  methods: {
   
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
    <form>

      <div class="container-input">
        <label for="">Nome</label>
        <input type="text" placeholder="Informe o nome completo">
      </div>
      <div class="container-input">
        <label for="">E-mail</label>
        <input type="text" placeholder="Informe apenas um e-mail">
      </div>
      <div class="container-input">
        <label for="">RA</label>
        <input type="text" placeholder="Informe o registro acadêmico">
      </div>
      <div class="container-input">
        <label for="">CPF</label>
        <input type="text" placeholder="Informe o número do documento">
      </div>
        <div class="btn-container">
          <router-link to="/dashboard/listar" class="link">
          <button class="btn btn-cancel">Cancelar</button>
        </router-link>
          <button class="btn btn-save">Salvar</button>
        </div>
    </form>
   </div>
  </section>
</template>
