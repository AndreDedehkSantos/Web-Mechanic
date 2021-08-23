<script>
  import Sidebar from "./Sidebar.vue";
  import ClienteDetalhe from "./DetalheCliente.vue";
  export default {
    components:{
      Sidebar,
      ClienteDetalhe
    },
    data(){
      return{
        novaSenha: null,
        confirmarSenha: null,
        fecharModal: false,
        exibindoCliente: {
          exibindo: false,
          id: null
        },
        clientes: [
          {
            id: 1,
            nome: "José Carlos de Sampaio",
            genero: "Masculino",
            dataNasc: "1976-04-30",
            cpf: "23145312398",
            email: "jcarlossampaio@yahoo.com.br",
            senha: "********",
            ranking: 4,
            status: "Ativo",
            telefone: {
              tipo: "Celular",
              ddd: "11",
              numero: "964123267"
            },
            enderecos: [
              {
                id: 1,
                descricao: "Residência",
                tipo: "Casa",
                logradouro: "Ibiras Veles",
                tipoLogradouro: "Avenida",
                numero: "42",
                complemento: null,
                bairro: "Jardim Amaral",
                cidade: "Taboão da Serra",
                estado: "SP",
                cep: "03213876",
                cobranca: true,
                entrega: true
              }
            ],
            cartoes: [
              {
                id: 100,
                bandeira: "Mastercard",
                tipo: "Crédito",
                numero: "************5112",
                dataValidade: "07/29",
                codigoVerificacao: "***",
                nomeImpresso: "JOSE C SAMPAIO",
                preferencial: true
              }
            ],
            transacoes: [
              {
                codigo: 4821,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 1253,59",
              },
              {
                codigo: 5432,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 816,10",
              },
              {
                codigo: 5587,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 257,31",
              }
            ]
          },
          {
            id: 2,
            nome: "Marcos de Holanda Kristenssen",
            genero: "Masculino",
            dataNasc: "1992-08-17",
            cpf: "53089741236",
            email: "holanda.k.marcos@gmail.com",
            senha: "*************",
            ranking: 3,
            status: "Ativo",
            telefone: {
              tipo: "celular",
              ddd: "21",
              numero: "954123687"
            },
            enderecos: [
              {
                id: 1,
                tipo: "Apartamento",
                descricao: "Escritório",
                logradouro: "Savino Mesquita",
                tipoLogradouro: "Rua",
                numero: "452",
                complemento: "Bloco: B - Apto: 324",
                bairro: "Vila Maria",
                cidade: "Niteroi",
                estado: "RJ",
                cep: "25631478",
                cobranca: true,
                entrega: true
              }
            ],
            cartoes: [
              {
                id: 300,
                bandeira: "AmericanEX",
                tipo: "Crédito",
                numero: "************3006",
                dataValidade: "12/27",
                codigoVerificacao: "***",
                nomeImpresso: "MARCOS DE HOLANDA K",
                preferencial: true
              },
              {
                id: 400,
                bandeira: "Visa",
                tipo: "Crédito",
                numero: "************7419",
                dataValidade: "01/26",
                codigoVerificacao: "***",
                nomeImpresso: "MARCOS DE HOLANDA K",
                preferencial: false
              }
            ],
            transacoes: [
              {
                codigo: 4821,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 1253,59",
              },
              {
                codigo: 5432,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 816,10",
              },
              {
                codigo: 5587,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 257,31",
              }
            ]
          },
          {
            id: 3,
            nome: "Helena de Castro Paulino",
            genero: "Feminino",
            dataNasc: "1983-12-01",
            cpf: "31050046987",
            email: "helena.castro83@outlook.com",
            senha: "********",
            ranking: 8,
            status: "Ativo",
            telefone: {
              tipo: "celular",
              ddd: "58",
              numero: "954120369"
            },
            enderecos: [
              {
                id: 1,
                tipo: "Casa",
                descricao: "Minha Casa",
                logradouro: "João de Paulas",
                tipoLogradouro: "Travessa",
                numero: "51",
                complemento: null,
                bairro: "Vila Maria",
                cidade: "Anápolis",
                estado: "GO",
                cep: "09651470",
                cobranca: true,
                entrega: true
              },
              {
                id: 2,
                tipo: "Apartamento",
                descricao: "Casa da Mãe",
                logradouro: "Lourenço Baptista",
                tipoLogradouro: "Rua",
                numero: "137A",
                complemento: "Bloco Azul - Apto: 48",
                bairro: "Conjunto Floresta",
                cidade: "Ourinhos",
                estado: "MG",
                cep: "14012548",
                cobranca: false,
                entrega: false
              }
            ],
            cartoes: [
              {
                id: 200,
                bandeira: "Visa",
                tipo: "Crédito",
                numero: "************2235",
                dataValidade: "11/25",
                codigoVerificacao: "***",
                nomeImpresso: "HELENA DE C PAULINO",
                preferencial: true
              },
            ],
            transacoes: [
              {
                codigo: 4821,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 1253,59",
              },
              {
                codigo: 5432,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 816,10",
              },
              {
                codigo: 5587,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 257,31",
              }
            ]
          },
          {
            id: 4,
            nome: "Camila Yami Norumaka",
            genero: "Feminino",
            dataNasc: "1994-06-19",
            cpf: "47102306987",
            email: "cahzinha.yami@gmail.com",
            senha: "*****************",
            ranking: 6,
            status: "Ativo",
            telefone: {
              tipo: "celular",
              ddd: "31",
              numero: "948752023"
            },
            enderecos: [
              {
                id: 1,
                tipo: "Apartamento",
                descricao: "Residência",
                logradouro: "Pimentel",
                tipoLogradouro: "Avenida",
                numero: "89",
                complemento: "Torre: 3 - Apto: 190",
                bairro: "Vila Maria",
                cidade: "Joinville",
                estado: "SC",
                cep: "47123541",
                cobranca: true,
                entrega: true
              }
            ],
            cartoes: [
              {
                id: 500,
                bandeira: "Mastercard",
                tipo: "Crédito",
                numero: "************2235",
                dataValidade: "11/25",
                codigoVerificacao: "***",
                nomeImpresso: "HELENA DE C PAULINO",
                preferencial: true
              },
            ],
            transacoes: [
              {
                codigo: 4821,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 1253,59",
              },
              {
                codigo: 5432,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 816,10",
              },
              {
                codigo: 5587,
                itens: ["item 1", "item 2", "item 3"],
                valor: "R$ 257,31",
              }
            ]
          },
        ],
        novoEndereco: {
          id: 1,
          descricao: null,
          tipo: "Selecione",
          tipoLogradouro: "Selecione",
          logradouro: null,
          numero: null,
          complemento: null,
          bairro: null,
          cidade: null,
          estado: "Selecione",
          cobranca: true,
          entrega: true
        },
        novoCartao: {
          tipo: "Selecione",
          bandeira: "Selecione",
          numero: null,
          dataValidade: null,
          codigoVerificacao: null,
          nomeImpresso: null
        },
        novoCliente: {
          nome: null,
          cpf: null,
          dataNasc: null,
          genero: "Selecione",
          email: null,
          senha: null,
          telefone:{
            tipo: "Selecione",
            ddd: null,
            numero: null
          },
          ranking: 0,
          status: "Ativo",
          enderecos: [],
          cartoes: [],
          transacoes: []
        }
      }
    },
    methods: {
      detalhesCliente(cliente){
        window.location.href = "#detalheDiv"
        this.$refs.detalheClienteView.detalhesCliente(cliente);
      },
      validarEndereco(endereco){
        let retornoErro = [];
        if(endereco.tipo == "Selecione"){
          retornoErro.push("Campo Tipo - Endereço é obrigatório" + "\n");
        }
        if(endereco.descricao == null){
          retornoErro.push("Campo Descrição - Endereço é obrigatório" + "\n");
        }
        if(endereco.tipoLogradouro == "Selecione"){
          retornoErro.push("Campo Tipo do Logradouro - Endereço é obrigatório" + "\n");
        }
        if(endereco.logradouro == null){
          retornoErro.push("Campo Logradouro - Endereço é obrigatório" + "\n");
        }
        if(endereco.numero == null){
          retornoErro.push("Campo Número - Endereço é obrigatório" + "\n");
        }
        if(endereco.bairro == null){
          retornoErro.push("Campo Bairro - Endereço é obrigatório" + "\n");
        }
        if(endereco.cidade == "Selecione"){
          retornoErro.push("Campo Cidade - Endereço é obrigatório" + "\n");
        }
        if(endereco.estado == "Selecione"){
          retornoErro.push("Campo Estado - Endereço é obrigatório" + "\n");
        }
        if(endereco.cep == null){
          retornoErro.push("Campo CEP - Endereço é obrigatório" + "\n");
        }
        return retornoErro;
      },
      validarCliente(cliente){
        let retornoErro = [];
        if(cliente.nome == null){
          retornoErro.push("Campo Nome é obrigatório!" + "\n");
        }
        if(cliente.cpf == null){
          retornoErro.push("Campo CPF é obrigatório!" + "\n");
        }
        if(cliente.dataNasc == null){
         retornoErro.push("Campo Data de Nascimento é obrigatório!" + "\n");
        }
        if(cliente.genero == "Selecione"){
         retornoErro.push("Campo Gênero é obrigatório!" + "\n");
        }
        if(cliente.email == null){
          retornoErro.push("Campo E-mail é obrigatório!" + "\n");
        }
        if(cliente.senha == null){
          retornoErro.push("Campo Senha é obrigatório!" + "\n");
        }
        if(cliente.senha != this.confirmarSenha){
          retornoErro.push("Senhas Diferentes!" + "\n");
        }
        if(cliente.telefone.tipo == "Selecione"){
          retornoErro.push("Campo Tipo - Telefone é obrigatório!" + "\n");
        }
        if(cliente.telefone.ddd == null){
          retornoErro.push("Campo DDD - Telefone é obrigatório!" + "\n");
        }
        if(cliente.telefone.numero == null){
          retornoErro.push("Campo Número - Telefone é obrigatório!" + "\n");
        }
        let erroEndereco = [];
        erroEndereco = this.validarEndereco(this.novoEndereco);
        if(erroEndereco != null){
          erroEndereco.forEach(element => {
            retornoErro.push(element);
          })
        }
        return retornoErro;
      },
      cadastrarCliente(){
        this.novoEndereco.cobranca = true;
        this.novoEndereco.entrega = true;
        this.novoCliente.enderecos.push(this.novoEndereco);
        this.novoCliente.id = this.clientes.length + 1;
        this.clientes.push(this.novoCliente);
        this.fecharModal = true;
        window.alert("Cliente Cadastrado com Sucesso!");
        this.detalhesCliente(this.novoCliente);
        this.cancelarCadastroCliente();
        this.cancelarCadastroEndereco();
       
      },
      cadastrarEndereco(cliente_id, endereco){
        this.clientes.forEach(element => {
          if(element.id == cliente_id){
            endereco.id = element.enderecos.length + 1;
            element.enderecos.push(endereco);
          }
        });
        window.alert("Endereço cadastrado com sucesso!");
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
      cancelarCadastroEndereco(){
        this.novoEndereco.descricao = null;
        this.novoEnderecotipo = "Selecione";
        this.novoEndereco.tipoLogradouro = "Selecione";
        this.novoEndereco.logradouro = null;
        this.novoEndereco.numero = null;
        this.novoEndereco.complemento = null;
        this.novoEndereco.bairro = null;
        this.novoEndereco.cidade = null;
        this.novoEndereco.estado = "Selecione";
      },
      cancelarCadastroCliente(){
        this.novoCliente.nome = null;
        this.cpf = null
        this.novoCliente.dataNasc = null,
        this.novoCliente.genero = "Selecione",
        this.novoCliente.email = null,
        this.senha = null;
        this.telefone.tipo = "Selecione",
        this.telefone.ddd = null;
        this.telefone.numero = null;
        this.cancelarCadastroEndereco();
      },
      alterarSenha(cliente_id){
        this.clientes.forEach(element => {
          if(element.id == cliente_id){
            element.senha = this.novaSenha;
          }
        });
        window.alert("Senha alterada com sucesso!");
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
          <div class="modal-dialog  modal-lg">
            <div class="modal-content">
              <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                <h5 class="modal-title" id="newClienteModalLabel">Novo Cliente</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
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
                    <div class="col-md-7">
                      <label class="form-label">Data de Nascimento</label>
                      <div>
                        <b-form-datepicker id="example-datepicker" v-model="novoCliente.dataNasc" class="mb-2"></b-form-datepicker>
                      </div>
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
                     <div class="col-md-2">
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
                      <input v-model="novoCliente.senha" type="password" class="form-control form-control-sm">
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
                    <input v-model="novoEndereco.cidade" type="text" class="form-control form-control-sm">
                  </div>
                  <div class="col-md-2">
                    <label class="form-label">Estado</label>
                    <div class="dropdown">
                      <button style="width: 85px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton5" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.estado}}</button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton5">
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'AC'">AC</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'AL'">AL</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'AP'">AP</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'AM'">AM</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'BA'">BA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'CE'">CE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'DF'">DF</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'ES'">ES</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'GO'">GO</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'MA'">MA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'MT'">MT</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'MS'">MS</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'MG'">MG</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'PA'">PA</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'PB'">PB</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'PR'">PR</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'PE'">PE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'PI'">PI</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'RJ'">RJ</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'RN'">RN</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'RS'">RS</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'RO'">RO</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'RR'">RR</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'SC'">SC</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'SP'">SP</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'SE'">SE</a></li>
                        <li><a class="dropdown-item" href="#" @click="novoEndereco.estado = 'TO'">TO</a></li>
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
                <button class="btn btn-new" data-bs-dismiss="modal" @click="cadastrarCliente()">Cadastrar</button>
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
            <tr @click="detalhesCliente(cliente)" v-for="cliente in clientes" :key="cliente.id">
              <th><small>{{cliente.id}}</small></th>
              <td><small>{{cliente.nome}}</small></td>
              <td><small>{{cliente.cpf}}</small></td>
              <td><small>{{cliente.dataNasc}}</small></td>
              <td><small>{{cliente.genero}}</small></td>
              <td><small>{{cliente.email}}</small></td>
              <td><small>{{cliente.telefone.ddd}} {{cliente.telefone.numero}} ({{cliente.telefone.tipo}})</small></td>
              <td><small>{{cliente.ranking}}</small></td>
              <td><small>{{cliente.status}}</small></td>
              <td>
                <button class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#editClienteModal">Editar</button>&nbsp;
                <div class="modal fade" id="editClienteModal" tabindex="-1" aria-labelledby="editClienteModalLabel" aria-hidden="true">
                  <div class="modal-dialog  modal-lg">
                    <div class="modal-content">
                      <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                        <h5 class="modal-title" id="editClienteModalLabel">Editar Cliente</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div class="modal-body">
                        <form>
                          <div class="row pb-3">
                            <div class="col-md-7">
                              <label class="form-label">Nome</label>
                              <input v-model="cliente.nome" type="text" class="form-control form-control-sm">
                            </div>
                            <div class="col-md-3">
                              <label class="form-label">CPF</label>
                              <input v-model="cliente.cpf" type="text" class="form-control form-control-sm">
                            </div>
                            <div class="col-md-2">
                              <label class="form-label">Gênero</label>
                              <div class="dropdown">
                                <button style="width: 92.81px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton6" data-bs-toggle="dropdown" aria-expanded="false">{{cliente.genero}}</button>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton6">
                                  <li><a class="dropdown-item" href="#" @click="cliente.genero = 'Masculino'">Masculino</a></li>
                                  <li><a class="dropdown-item" href="#" @click="cliente.genero = 'Feminino'">Feminino</a></li>
                                  <li><a class="dropdown-item" href="#" @click="cliente.genero = 'Outro'">Outro</a></li>
                                </ul>
                              </div>
                            </div>
                          </div>  
                          <div class="row pb-3">
                            <div class="col-md-7">
                              <label class="form-label">Data de Nascimento</label>
                              <div>
                                <b-form-datepicker id="example-datepicker" v-model="cliente.dataNasc" class="mb-2"></b-form-datepicker>
                              </div>
                            </div>
                            <div class="col-md-2">
                              <label class="form-label">Telefone</label>
                              <div class="dropdown">
                                <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="dropdownMenuButton7" data-bs-toggle="dropdown" aria-expanded="false">{{cliente.telefone.tipo}}</button>
                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton7">
                                  <li><a class="dropdown-item" href="#" @click="cliente.telefone.tipo = 'Residencial'">Residencial</a></li>
                                  <li><a class="dropdown-item" href="#" @click="cliente.telefone.tipo  = 'Celular'">Celular</a></li>
                                  <li><a class="dropdown-item" href="#" @click="cliente.telefone.tipo  = 'Comercial'">Comercial</a></li>
                                </ul>
                              </div>
                            </div>
                            <div class="col-md-1">
                              <label class="form-label">DDD</label>
                              <input v-model="cliente.telefone.ddd" type="text" class="form-control form-control-sm">
                            </div>
                            <div class="col-md-2">
                              <label class="form-label">Número</label>
                              <input v-model="cliente.telefone.numero" type="text" class="form-control form-control-sm">
                            </div>
                          </div>
                          <div class="row pb-3">
                            <div class="col-md-4">
                              <label class="form-label">E-mail</label>
                              <input v-model="cliente.email" type="text" class="form-control form-control-sm">
                            </div>
                          </div>
                        </form>
                      </div>
                      <div class="modal-footer">
                        <button class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button class="btn btn-new" data-bs-dismiss="modal" @click="validarDados()">Concluir</button>
                      </div>
                    </div>
                  </div>
                </div>
                <button class="btn btn-secondary btn-sm"  data-bs-toggle="modal" data-bs-target="#editSenhaModal">Alterar Senha</button>
                <div class="modal fade" id="editSenhaModal" tabindex="-1" aria-labelledby="newCartaoModalLabel" aria-hidden="true">
                  <div class="modal-dialog  modal-sm">
                    <div class="modal-content">
                      <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                        <h5 class="modal-title" id="newCartaoModalLabel">Alterar Senha</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
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
                        <button class="btn btn-new" data-bs-dismiss="modal" @click="alterarSenha(cliente.id)">Concluir</button>
                      </div>
                    </div>
                  </div>
                </div>
                <button class="btn btn-danger btn-sm" style="margin-left: 5px;" @click="cliente.status = 'Inativo'">Inativar</button>
              </td>
            </tr>
          </tbody>
        </table>
        <div class="row" id="detalheDiv">
          <ClienteDetalhe ref="detalheClienteView"/>
        </div>
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
    background-color: white;
    color: rgba(204, 204, 8, 0.712);
  }
  .show-client{
    font: bold;
    background-color: rgba(255, 255, 255, 0);
  }
  td, .show-client:hover{
    cursor: pointer;
  }
</style>