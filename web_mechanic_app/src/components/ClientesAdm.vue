<script>
  import Sidebar from "./Sidebar.vue";
  import ClienteDetalhe from "./DetalheCliente.vue";
  import EditarCliente from "./EditCliente.vue";
  import EditarSenha from "./EditSenha.vue";
  export default {
    components:{
      Sidebar,
      ClienteDetalhe,
      EditarCliente,
      EditarSenha
    },
    data(){
      return{
        novaSenha: null,
        confirmarSenha: null,
        fecharModal: false,
        exibeRespostaNovo: false,
        exibeRespostaNovoErro: false,
        resposta: [],
        exibindoCliente: {
          exibindo: false,
          id: null
        },
        clientes: [],
        novoEndereco: {
          id: 1,
          descricao: "",
          tipo: "Selecione",
          tipoLogradouro: "Selecione",
          logradouro: "",
          numero: "",
          complemento: "",
          bairro: "",
          cidade: {
            descricao: ""
          },
          estado: {
            uf: "Selecione"
          },
          cobranca: true,
          entrega: true,
          cliente_id : 0
        },
        novoCliente: {
          id: 0,
          nome: "",
          cpf: "",
          dataNascimento: "",
          genero: "Selecione",
          email: "",
          senhas: [],
          telefone:{
            tipo: "Selecione",
            ddd: "",
            numero: ""
          },
          ranking: 0,
          status: true,
          enderecos: [],
          cartoes: [],
          transacoes: []
        },
      }
    },
    mounted(){
      this.listarClientes();
    },
    methods: {
      listarClientes(){
        this.$http.get('https://localhost:5001/api/Cliente/Listar').then(res => res.json()).then(clientes => {
          this.clientes = clientes;
          this.clientes.forEach(element => {
            var aux = element.dataNascimento.replace(" 00:00:00", "");
            aux =  aux.replace("/", "");
            aux = aux.replace("/", "");
            var aux1 = aux.split('');
            var dataEdit = aux1[4] + aux1[5] + aux1[6] + aux1[7] + "-" + aux1[2] + aux1[3] + "-" + aux1[0] + aux1[1];
            element.dataNascimento = dataEdit;
          });
        }, res => {console.log(res)});
      },
      detalhesCliente(cliente){
        window.location.href = "#detalheDiv"
        this.$refs.detalheClienteView.detalhesCliente(cliente);
      },
      cadastrarCliente(){
        this.novoEndereco.cliente_id = 0;
        this.novoCliente.enderecos.push(this.novoEndereco);
        this.novoCliente.id = 0;
        if(this.novoCliente.dataNascimento != ""){
          var date = new Date(this.novoCliente.dataNascimento);
          var dateStr =
            date.getFullYear() + "-" +
            ("00" + (date.getMonth() + 1)).slice(-2) + "-" +
            ("00" + date.getDate()).slice(-2)
          this.novoCliente.dataNascimento = dateStr;
        }
        this.novoCliente.senhas.push(this.novaSenha);
        this.novoCliente.senhas.push(this.confirmarSenha);
        this.$http.post('https://localhost:5001/api/Cliente/NovoCliente', this.novoCliente).then(res => res.json()).then(res => {
          this.exibeRespostaNovo = true;
          this.clientes.push(res.cliente);
          this.detalhesCliente(res.cliente);
        }, res => {
          console.log(res);
          this.resposta = res.body.retornoString;
          this.exibeRespostaNovoErro = true;
        })
      },
      cadastrarCartao(cliente_id, cartao){
        this.clientes.forEach(element => {
          if(element.id == cliente_id){
            cartao.id = element.cartoes.length + 1;
            element.cartoes.push(cartao);
          }
        });
        window.alert("Cartão cadastrado com sucesso!");
      },
      editarCliente(cliente){
        this.$refs.editclienteview.editarCliente(cliente);
      },
      concluirEditar(){
        this.listarClientes();
      },
      cancelarCadastroEndereco(){
        this.novoEndereco.id = 1;
        this.novoEndereco.descricao = "";
        this.novoEndereco.tipo = "Selecione";
        this.novoEndereco.tipoLogradouro = "Selecione";
        this.novoEndereco.logradouro = "";
        this.novoEndereco.numero = "";
        this.novoEndereco.complemento = "";
        this.novoEndereco.bairro = "";
        this.novoEndereco.cidade.descricao = "";
        this.novoEndereco.estado.uf = "Selecione";
        this.novoEndereco.cobranca = true;
        this.novoEndereco.entrega = true;
      },
      cancelarCadastroCliente(){
        this.novoCliente.nome = "";
        this.novoCliente.cpf = ""
        this.novoCliente.dataNasc = "",
        this.novoCliente.genero = "Selecione",
        this.novoCliente.email = "",
        this.senha = "";
        this.telefone.tipo = "Selecione",
        this.telefone.ddd = "";
        this.telefone.numero = "";
        this.cancelarCadastroEndereco();
      },
      alterarSenha(cliente_id){
        this.$refs.editSenhaview.alterarSenha(cliente_id);
      },
      removerEndereco(cliente_id, endereco){
        this.clientes.forEach(element => {
          if(element.id == cliente_id){
            var index;
            index = element.enderecos.indexOf(endereco);
            element.enderecos.splice(index, 1);
          }
        });
        window.alert("Endereço removido com sucesso!");
      },
      removerCartao(cliente_id, cartao){
        this.clientes.forEach(element => {
          if(element.id == cliente_id){
            var index;
            index = element.cartoes.indexOf(cartao);
            element.cartoes.splice(index, 1);
          }
        });
        window.alert("Cartão removido com sucesso!");
      },
      inativarCliente(){
        window.alert("Cliente Inativado!");
      }
    },
  };
</script>

<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-2 p-0" style="background-color: rgba(10, 10, 10, 0.699); border: 1px solid rgba(10, 10, 10, 0.829);">
        <Sidebar/>
      </div>
      <div class="col-md-10 px-4 py-3">
        <button class="btn btn-new" data-bs-toggle="modal" data-bs-target="#newClienteModal">Novo Cliente</button><br><br>
        <div class="modal fade" id="newClienteModal" tabindex="-1" aria-labelledby="newClienteModalLabel" aria-hidden="true">
          <div class="modal-dialog modal-dialog-scrollable  modal-lg">
            <div class="modal-content">
              <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                <h5 class="modal-title" id="newClienteModalLabel">Novo Cliente</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div v-if="exibeRespostaNovo && resposta.length == 0" class="alert alert-success alert-dismissible fade show" role="alert">
                <strong>Cliente Inserido com Sucesso!</strong>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
              </div>
              <div v-if="exibeRespostaNovoErro" class="alert alert-danger" role="alert">
                <strong>Erro ao Cadastrar Cliente!</strong>
                <p v-for="resp in resposta" :key="resp">{{resp}}</p>
              </div>
              <div class="modal-body">
                <form>
                  <div class="row pb-3">
                    <div class="col-md-7">
                      <label class="form-label">Nome</label>
                      <input v-model="novoCliente.nome" type="text" class="form-control form-control-sm">
                    </div>
                    <div class="col-md-3">
                      <label class="form-label">CPF</label>
                      <input v-model="novoCliente.cpf" type="text" class="form-control form-control-sm">
                    </div>
                    <div class="col-md-2">
                      <label class="form-label">Gênero</label>
                      <div class="dropdown">
                        <button style="width: 92.81px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">{{novoCliente.genero}}</button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                          <li><a class="dropdown-item" href="#" @click="novoCliente.genero = 'Masculino'">Masculino</a></li>
                          <li><a class="dropdown-item" href="#" @click="novoCliente.genero = 'Feminino'">Feminino</a></li>
                          <li><a class="dropdown-item" href="#" @click="novoCliente.genero = 'Outro'">Outro</a></li>
                        </ul>
                      </div>
                    </div>
                  </div>  
                  <div class="row pb-3">
                    <div class="col-md-6">
                      <label class="form-label">Data de Nascimento</label>
                      <b-form-datepicker v-model="novoCliente.dataNascimento" id="example-datepickerNovo" class="mb-2"></b-form-datepicker>
                    </div>
                    <div class="col-md-2">
                      <label class="form-label">Telefone</label>
                      <div class="dropdown">
                        <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton2" data-bs-toggle="dropdown" aria-expanded="false">{{novoCliente.telefone.tipo}}</button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                          <li><a class="dropdown-item" href="#" @click="novoCliente.telefone.tipo = 'Residencial'">Residencial</a></li>
                          <li><a class="dropdown-item" href="#" @click="novoCliente.telefone.tipo  = 'Celular'">Celular</a></li>
                          <li><a class="dropdown-item" href="#" @click="novoCliente.telefone.tipo  = 'Comercial'">Comercial</a></li>
                        </ul>
                      </div>
                    </div>
                    <div class="col-md-1">
                      <label class="form-label">DDD</label>
                      <input v-model="novoCliente.telefone.ddd" type="text" class="form-control form-control-sm">
                    </div>
                     <div class="col-md-3">
                      <label class="form-label">Número</label>
                      <input v-model="novoCliente.telefone.numero" type="text" class="form-control form-control-sm">
                    </div>
                  </div>
                  <div class="row pb-3">
                    <div class="col-md-4">
                      <label class="form-label">E-mail</label>
                      <input v-model="novoCliente.email" type="text" class="form-control form-control-sm">
                    </div>
                    <div class="col-md-4">
                      <label class="form-label">Senha</label>
                      <input v-model="novaSenha" type="password" class="form-control form-control-sm">
                    </div>
                    <div class="col-md-4">
                      <label class="form-label">Confirmar Senha</label>
                      <input v-model="confirmarSenha" type="password" class="form-control form-control-sm">
                    </div>
                  </div>
                <hr>
                <div class="row pb-3">
                  <h5>Endereço</h5>
                </div>
                <div class=" row pb-3">
                  <div class="col-md-2">
                    <label class="form-label">Tipo</label>
                    <div class="dropdown">
                      <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton3" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.tipo}}</button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton3">
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipo = 'Casa'">Casa</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipo = 'Apartamento'">Apartamento</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipo = 'Comércio'">Comércio</a></li>
                      </ul>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <label class="form-label">Descrição</label>
                    <input v-model="novoEndereco.descricao" type="text" class="form-control form-control-sm">
                  </div>
                </div>
                <div class="row pb-3">
                  <div class="col-md-2">
                    <label class="form-label">Logradouro</label>
                    <div class="dropdown">
                      <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton4" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.tipoLogradouro}}</button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton4">
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Rua'">Rua</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Avenida'">Avenida</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Travessa'">Travessa</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Estrada'">Estrada</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Alameda'">Alameda</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Rodovia'">Rodovia</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.tipoLogradouro = 'Viela'">Viela</a></li>
                      </ul>
                    </div>
                  </div>
                  <div class="col-md-5">
                    <label class="form-label">&nbsp;</label>
                    <input v-model="novoEndereco.logradouro" type="text" class="form-control form-control-sm">
                  </div>
                  <div class="col-md-2">
                    <label class="form-label">Número</label>
                    <input v-model="novoEndereco.numero" type="text" class="form-control form-control-sm">
                  </div>
                 </div>
                 <div class="row pb-3">
                  <div class="col-md-5">
                    <label class="form-label">Complemento</label>
                    <input v-model="novoEndereco.complemento" type="text" class="form-control form-control-sm">
                  </div>
                  <div class="col-md-4">
                    <label class="form-label">Bairro</label>
                    <input v-model="novoEndereco.bairro" type="text" class="form-control form-control-sm">
                  </div>
                 </div>
                <div class="row pb-3">
                  <div class="col-md-4">
                    <label class="form-label">Cidade</label>
                    <input v-model="novoEndereco.cidade.descricao" type="text" class="form-control form-control-sm">
                  </div>
                  <div class="col-md-2">
                    <label class="form-label">Estado</label>
                    <div class="dropdown">
                      <button style="width: 85px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton5" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.estado.uf}}</button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton5">
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'AC'">AC</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'AL'">AL</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'AP'">AP</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'AM'">AM</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'BA'">BA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'CE'">CE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'DF'">DF</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'ES'">ES</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'GO'">GO</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'MA'">MA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'MT'">MT</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'MS'">MS</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'MG'">MG</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'PA'">PA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'PB'">PB</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'PR'">PR</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'PE'">PE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'PI'">PI</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'RJ'">RJ</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'RN'">RN</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'RS'">RS</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'RO'">RO</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'RR'">RR</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'SC'">SC</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'SP'">SP</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'SE'">SE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado.uf = 'TO'">TO</a></li>
                      </ul>
                    </div>
                  </div>
                  <div class="col-md-3">
                    <label class="form-label">CEP</label>
                    <input v-model="novoEndereco.cep" type="text" class="form-control form-control-sm">
                  </div>
                </div>
                </form>
              </div>
              <div class="modal-footer">
                <button class="btn btn-secondary" data-bs-dismiss="modal" @click="cancelarCadastroCliente()">Cancelar</button>
                <button class="btn btn-new" @click="cadastrarCliente()">Cadastrar</button>
              </div>
            </div>
          </div>
        </div>
        <table class="table-style table table-hover table-bordered">
          <thead class="table-header">
            <tr>
              <th scope="col"><small>Cód</small></th>
              <th scope="col"><small>Nome</small></th>
              <th scope="col"><small>CPF</small></th>
              <th scope="col"><small>Dt de Nascimento</small></th>
              <th scope="col"><small>Gênero</small></th>
              <th scope="col"><small>Email</small></th>
              <th scope="col"><small>Telefone</small></th>
              <th scope="col"><small>Rank</small></th>
              <th scope="col"><small>Status</small></th>
              <th scope="col"><small>Opções</small></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="cliente in this.clientes" :key="cliente.id">
              <th @click="detalhesCliente(cliente)"><small>{{cliente.id}}</small></th>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.nome}}</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.cpf}}</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.dataNascimento}}</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.genero}}</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.email}}</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.telefone.ddd}} {{cliente.telefone.numero}} ({{cliente.telefone.tipo}})</small></td>
              <td @click="detalhesCliente(cliente)"><small>{{cliente.ranking}}</small></td>
              <td v-if="cliente.status" @click="detalhesCliente(cliente)"><small>Ativo</small></td>
              <td v-else @click="detalhesCliente(cliente)"><small>Inativo</small></td>
              <td>
                <button class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#editClienteModal" @click="editarCliente(cliente.id)">Editar</button>&nbsp;
                <button class="btn btn-secondary btn-sm"  data-bs-toggle="modal" data-bs-target="#editSenhaModal" @click="alterarSenha(cliente.id)">Alterar Senha</button>
                <button class="btn btn-danger btn-sm" style="margin-left: 5px;" @click="cliente.status = 'Inativo'">Inativar</button>
              </td>
            </tr>
          </tbody>
        </table>
        <EditarCliente ref="editclienteview" />
        <EditarSenha ref="editSenhaview" />
        <div class="row" id="detalheDiv">
          <ClienteDetalhe ref="detalheClienteView"/>
        </div><!-- Button trigger modal -->
        <div class="row" style="margin-top: 20px;">&nbsp;</div>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .table-style{
    border: 1px solid black;
    background-color: white;
  }
  .table-header{
    color: white;
    background-color: rgba(10, 10, 10, 0.699);
  }
  .btn-new{
    background-color: rgba(204, 204, 8, 0.712);
    color: white;
    border: 1px solid rgba(204, 204, 8, 0.712);
    border-radius: 5px;
  }
  .btn-new:hover{
    background-color: rgba(199, 199, 10, 0.836);
  }
  .show-client{
    font: bold;
    background-color: rgba(255, 255, 255, 0);
  }
  td, .show-client:hover{
    cursor: pointer;
  }
</style>