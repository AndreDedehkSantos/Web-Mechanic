<script>

  export default {
    data(){
      return{
        resposta: [],
        exibeResposta: false,
        exbeRespostaErro: false,
        editCliente: {
          id: 0,
          nome: "",
          cpf: "",
          dataNascimento: "",
          genero: "Selecione",
          email: "",
          senha: "",
          telefone:{
            tipo: "Selecione",
            ddd: "",
            numero: ""
          },
          ranking: 0,
          status: "Ativo",
          enderecos: [],
          cartoes: [],
          transacoes: []
        },
        filtros: {
          filtroString: []
        }
      }
    },  
    methods: {
      editarCliente(cliente_id){
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
      concluirEditar(){
        this.$http.put('https://localhost:5001/api/Cliente/AlterarCliente', this.editCliente).then(res => res.json()).then(res => {
          this.editCliente = res;
          this.exibeResposta = true;
          this.$parent.concluirEditar();
        }, res => {
          console.log(res);
          this.resposta = res.body.retornoString;
          this.exbeRespostaErro = true;
        });
      },
      resultadoEdicao(resultado){
        if(resultado != null){
          this.resposta = resultado;
        }
      }
    }
  }
</script>

<template>
  <div>
    <div class="modal fade" id="editClienteModal" tabindex="-1" aria-labelledby="editClienteModalLabel" aria-hidden="true">
      <div class="modal-dialog  modal-lg">
        <div class="modal-content">
          <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
            <h5 class="modal-title" id="editClienteModalLabel">Editar Cliente</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div v-if="exibeResposta && resposta.length == 0" class="alert alert-primary alert-dismissible fade show" role="alert">
            <strong>Cliente Alterado com Sucesso!</strong>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
          </div>
          <div v-if="exbeRespostaErro" class="alert alert-danger" role="alert">
            <strong>Erro ao Alterar Cliente!</strong>
            <p v-for="resp in resposta" :key="resp">{{resp}}</p>
          </div>
          <div class="modal-body">
            <form>
              <div class="row pb-3">
                <div class="col-md-7">
                  <label class="form-label">Nome</label>
                  <input v-model="editCliente.nome" type="text" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                  <label class="form-label">Gênero</label>
                  <div class="dropdown">
                    <button style="width: 92.81px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editGenero${editCliente.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{editCliente.genero}}</button>
                    <ul class="dropdown-menu" :aria-labelledby="`editGenero${editCliente.id}`">
                      <li><a class="dropdown-item" href="#" @click="editCliente.genero = 'Masculino'">Masculino</a></li>
                      <li><a class="dropdown-item" href="#" @click="editCliente.genero = 'Feminino'">Feminino</a></li>
                      <li><a class="dropdown-item" href="#" @click="editCliente.genero = 'Outro'">Outro</a></li>
                    </ul>
                  </div>
                </div>
              </div>  
              <div class="row pb-3">
                <div class="col-md-7">
                  <label class="form-label">Data de Nascimento</label>
                  <b-form-datepicker v-model="editCliente.dataNascimento" :id="`datepicker${editCliente.id}`" class="form-control form-control-sm"></b-form-datepicker>
                </div>
                <div class="col-md-2">
                  <label class="form-label">Telefone</label>
                  <div class="dropdown">
                    <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editTelefoneTipo${editCliente.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{editCliente.telefone.tipo}}</button>
                    <ul class="dropdown-menu" :aria-labelledby="`editTelefoneTipo${editCliente.id}`">
                      <li><a class="dropdown-item" href="#" @click="editCliente.telefone.tipo = 'Residencial'">Residencial</a></li>
                      <li><a class="dropdown-item" href="#" @click="editCliente.telefone.tipo  = 'Celular'">Celular</a></li>
                      <li><a class="dropdown-item" href="#" @click="editCliente.telefone.tipo  = 'Comercial'">Comercial</a></li>
                    </ul>
                  </div>
                </div>
                <div class="col-md-1">
                  <label class="form-label">DDD</label>
                  <input v-model="editCliente.telefone.ddd" type="text" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                  <label class="form-label">Número</label>
                  <input v-model="editCliente.telefone.numero" type="text" class="form-control form-control-sm">
                </div>
              </div>
              <div class="row pb-3">
                <div class="col-md-4">
                  <label class="form-label">E-mail</label>
                  <input v-model="editCliente.email" type="text" class="form-control form-control-sm">
                </div>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
            <button class="btn btn-primary" @click="concluirEditar()">Concluir</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>