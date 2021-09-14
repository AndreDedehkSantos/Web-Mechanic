<script>
  export default {
    data(){
      return {
        exibeResposta: false,
        exibeRespostaErro: false,
        resposta: [],
        editCliente: {},
        novaSenha: "",
        confirmarSenha: "",
        filtros: {
          filtroString: []
        }
      }
    },
    methods: {
      alterarSenha(cliente_id){
        this.novaSenha = "";
        this.confirmarSenha = "";
        this.exibeResposta = false;
        this.exibeRespostaErro = false;
        this.respota = [];
        let filtro = [`id = ${cliente_id}`];
        this.filtros.filtroString = filtro;
        this.$http.post(`https://localhost:5001/api/Cliente/Pesquisar`, this.filtros).then(res => res.json()).then(cliente => {
          this.editCliente = cliente[0];
          var aux = this.editCliente.dataNascimento.replace(" 00:00:00", "");
          aux =  aux.replace("/", "");
          aux = aux.replace("/", "");
          var aux1 = aux.split('');
          var dataEdit = aux1[4] + aux1[5] + aux1[6] + aux1[7] + "-" + aux1[2] + aux1[3] + "-" + aux1[0] + aux1[1];
          this.editCliente.dataNascimento = dataEdit;
        });
      },
      concluirAlteracao(){
        this.editCliente.senhas = [];
        this.editCliente.senhas.push(this.novaSenha);
        this.editCliente.senhas.push(this.confirmarSenha);
        this.$http.put('https://localhost:5001/api/Cliente/AlterarSenhaCliente', this.editCliente).then(res => res.json()).then(res => {
          this.editCliente = res;
          this.exibeResposta = true;
          this.$parent.concluirEditar();
        }, res => {
          this.resposta = res.body.retornoString;
          this.exibeRespostaErro = true;
        });
      }
    }
  }
</script>

<template>
  <div>
    <div class="modal fade" id="editSenhaModal" tabindex="-1" aria-labelledby="newCartaoModalLabel" aria-hidden="true">
      <div class="modal-dialog  modal-sm">
        <div class="modal-content">
          <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
            <h5 class="modal-title" id="newCartaoModalLabel">Alterar Senha</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div v-if="exibeResposta" class="alert alert-primary alert-dismissible fade show" role="alert">
            <strong>Senha Alterada com Sucesso!</strong>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
          </div>
          <div v-if="exibeRespostaErro" class="alert alert-danger" role="alert">
            <strong>Erro ao Alterar senha!</strong>
            <p v-for="resp in resposta" :key="resp">{{resp}}</p>
          </div>
          <div class="modal-body">
            <form>
              <div class="row pb-3">
                  <div class="col-md-12">
                  <label class="form-label">Nova Senha</label>
                  <input v-model="novaSenha" type="password" class="form-control form-control-sm">
                </div>
              </div> 
              <div class="row pb-3">
                  <div class="col-md-12">
                  <label class="form-label">Confirmar Senha</label>
                  <input v-model="confirmarSenha" type="password" class="form-control form-control-sm">
                </div>
              </div>
            </form>
          </div>
          <div class="modal-footer"> 
            <button class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
            <button class="btn btn-primary" @click="concluirAlteracao()">Concluir</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>