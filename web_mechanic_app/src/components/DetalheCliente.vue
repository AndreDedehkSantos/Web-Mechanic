<script>
export default {
  data() {
    return {
      classCardEndereco: "col-2 card-selector p-0",
      classCardCartao: "col-2 card-selector p-0",
      classCardTransaoes: "col-2 card-selector p-0",
      detalheEndereco: false,
      detalheCartao: false,
      detalheTransacoes: false,
      exibeCard: false,
      novoEndereco: {
        descricao: null,
        tipo: "Selecione",
        tipoLogradouro: "Selecione",
        logradouro: null,
        numero: null,
        complemento: null,
        bairro: null,
        cidade: null,
        estado: "Selecione",
        cobranca: false,
        entrega: false
      },
      editEndereco: {},
      novoCartao: {
        tipo: "Selecione",
        bandeira: "Selecione",
        numero: null,
        dataValidade: null,
        codigoVerificacao: null,
        nomeImpresso: null,
        preferencial: false
      },
      clienteDetalhe: {},
    };
  },
  methods: {
    detalhesCliente(cliente) {
      this.clienteDetalhe = cliente;
      this.exibeCard = true;
      this.detalheEndereco = true;
      this.detalheCartao = false;
      this.detalheTransacoes = false;
      this.classCardEndereco = "col-2 card-selector-active p-0";
      this.classCardCartao = "col-2 card-selector p-0";
      this.classCardTransaoes = "col-2 card-selector p-0";
    },
    ativarCard(campo) {
      if (campo == "endereco") {
        this.classCardCartao = "col-2 card-selector p-0";
        this.classCardTransaoes = "col-2 card-selector p-0";
        this.classCardEndereco = "col-2 card-selector-active p-0";
        this.detalheCartao = false;
        this.detalheTransacoes = false;
        this.detalheEndereco = true;
      }
      if (campo == "cartao") {
        this.classCardEndereco = "col-2 card-selector p-0";
        this.classCardTransaoes = "col-2 card-selector p-0";
        this.classCardCartao = "col-2 card-selector-active p-0";
        this.detalheEndereco = false;
        this.detalheTransacoes = false;
        this.detalheCartao = true;
      }
      if (campo == "transacoes") {
        this.classCardEndereco = "col-2 card-selector p-0";
        this.classCardCartao = "col-2 card-selector p-0";
        this.classCardTransaoes = "col-2 card-selector-active p-0";
        this.detalheEndereco = false;
        this.detalheCartao = false;
        this.detalheTransacoes = true;
       }
    },
    editandoEndereco(endereco){
      this.editEndereco = endereco;
    },
    cadastrarEndereco(cliente_id, endereco){
      this.$parent.cadastrarEndereco(cliente_id, endereco);
    },
    cadastrarCartao(cliente_id, cartao){
      this.$parent.cadastrarCartao(cliente_id, cartao);
    },
    removerEndereco(cliente_id, endereco){
      this.$parent.removerEndereco(cliente_id, endereco);
    },
    removerCartao(cliente_id, cartao){
      this.$parent.removerCartao(cliente_id, cartao);
    },
    formatarDataValidade(data){
        let dataFormat = new Date(data);
        let dataRetorno;
        let mes = (dataFormat.getMonth()+1).toString().padStart(2, '0');
        dataRetorno = mes + "/";
        let ano  = dataFormat.getFullYear().toString().substr(2,2);
        dataRetorno += ano
        return dataRetorno;
      },
    numeroCartao(cartaoNumero){
      var numero = []
      numero = cartaoNumero.split('');
      let numeroExibir = "Final ";
      for(let i = numero.length-1; i > (numero.length - 5); i--)
      {
        numeroExibir += numero[i];
      }
      return numeroExibir;
    }
  },
};
</script>

<template>
  <div v-if="exibeCard">
    <div class="card">
      <div class="card-header p-0">
        <div class="row pb-0 pl-6">
          <div :class="classCardEndereco" style="text-align: center; margin-left: 11px; vertical-align: middle;" @click="ativarCard('endereco')">
            <div style="padding-top: 10px; padding-bottom: 10px; border-right: 1px solid black">Endereços</div>
          </div>
          <div :class="classCardCartao" style="text-align: center; vertical-align: middle" @click="ativarCard('cartao')">
            <div style="padding-top: 10px; padding-bottom: 10px; border-right: 1px solid black">Cartões</div>
          </div>
            <div :class="classCardTransaoes" style="text-align: center; vertical-align: middle" @click="ativarCard('transacoes')">
            <div style="padding-top: 10px; padding-bottom: 10px">Transações</div>
          </div>
          <div class="col-5 d-flex flex-row-reverse" style="margin-left: 80px; margin-top: 10px;">
            <button class="btn btn-close btn-danger" @click="exibeCard = false"></button>
          </div>
        </div>
      </div>
      <div class="card-body">
        <div class="row pb-3 pt-1">
          <h4>{{clienteDetalhe.id}} - {{clienteDetalhe.nome}}</h4>
        </div>
        <div v-if="detalheEndereco">
          <div class="row">
            <div v-for="endereco in clienteDetalhe.enderecos" :key="endereco.id" class="col-sm-3">
              <div class="card" style="width: 18rem;">
                <div class="card-body">
                  <h5 class="card-title">{{endereco.descricao}}</h5>
                  <h6 class="card-subtitle mb-2 text-muted">{{endereco.tipo}}</h6>
                  <p class="card-text pt-3 pb-0 m-0">{{endereco.tipoLogradouro}} {{endereco.logradouro}}, {{endereco.numero}}</p>
                  <p v-if="endereco.complemento" class="card-text pb-0 m-0">{{endereco.complemento}}</p>
                  <p v-else class="card-text pb-0 m-0">&nbsp;</p>
                  <p class="card-text pb-0 m-0">{{endereco.bairro}}</p>
                  <p class="card-text pt-2 pb-0 m-0">{{endereco.cidade.descricao}}, {{endereco.estado.uf}}</p>
                  <p class="card-text pb-0 m-0">{{endereco.cep}}</p>
                  <p v-if="endereco.cobranca" class="card-text pt-2 pb-0 m-0"><b><u>Endereço de Cobrança</u></b></p>
                  <p v-else class="card-text pt-2 pb-0 m-0">&nbsp;</p>
                  <p v-if="endereco.entrega" class="card-text pb-0 m-0"><b><u>Endereço de Entrega</u></b></p>
                  <p v-else class="card-text pb-0 m-0">&nbsp;</p><br>
                  <button class="btn btn-primary btn-sm" style="margin-right: 5px;" data-bs-toggle="modal" data-bs-target="#editarEndereco" @click="editandoEndereco(endereco)">Editar</button>
                  <div class="modal fade" id="editarEndereco" tabindex="-1" aria-labelledby="editarEnderecoLabel" aria-hidden="true">
                    <div class="modal-dialog  modal-lg">
                      <div class="modal-content">
                        <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                          <h5 class="modal-title" id="editarEnderecoLabel">Editar Endereço</h5>
                          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                          <form>
                            <div class=" row pb-3">
                              <div class="col-md-2">
                                <label class="form-label">Tipo</label>
                                <div class="dropdown">
                                  <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editEnderecoTipo${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{editEndereco.tipo}}</button>
                                  <ul class="dropdown-menu" :aria-labelledby="`editEnderecoTipo${clienteDetalhe.id}`">
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipo = 'Casa'">Casa</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipo = 'Apartamento'">Apartamento</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipo = 'Comércio'">Comércio</a></li>
                                  </ul>
                                </div>
                              </div>
                              <div class="col-md-4">
                                <label class="form-label">Descrição</label>
                                <input v-model="editEndereco.descricao" type="text" class="form-control form-control-sm">
                              </div>
                            </div>
                            <div class="row pb-3">
                              <div class="col-md-2">
                                <label class="form-label">Logradouro</label>
                                <div class="dropdown">
                                  <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editEnderecoTipoLogra${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.tipoLogradouro}}</button>
                                  <ul class="dropdown-menu" :aria-labelledby="`editEnderecoTipoLogra${clienteDetalhe.id}`">
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Rua'">Rua</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Avenida'">Avenida</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Travessa'">Travessa</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Estrada'">Estrada</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Alameda'">Alameda</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Rodovia'">Rodovia</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.tipoLogradouro = 'Viela'">Viela</a></li>
                                  </ul>
                                </div>
                              </div>
                              <div class="col-md-5">
                                <label class="form-label">&nbsp;</label>
                                <input v-model="editEndereco.logradouro" type="text" class="form-control form-control-sm">
                              </div>
                              <div class="col-md-2">
                                <label class="form-label">Número</label>
                                <input v-model="editEndereco.numero" type="text" class="form-control form-control-sm">
                              </div>
                            </div>
                            <div class="row pb-3">
                              <div class="col-md-5">
                                <label class="form-label">Complemento</label>
                                <input v-model="editEndereco.complemento" type="text" class="form-control form-control-sm">
                              </div>
                              <div class="col-md-4">
                                <label class="form-label">Bairro</label>
                                <input v-model="editEndereco.bairro" type="text" class="form-control form-control-sm">
                              </div>
                            </div>
                            <div class="row pb-3">
                              <div class="col-md-4">
                                <label class="form-label">Cidade</label>
                                <input v-model="editEndereco.cidade" type="text" class="form-control form-control-sm">
                              </div>
                              <div class="col-md-2">
                                <label class="form-label">Estado</label>
                                <div class="dropdown">
                                  <button style="width: 85px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editEstado${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.estado}}</button>
                                  <ul class="dropdown-menu" :aria-labelledby="`editEstado${clienteDetalhe.id}`">
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'AC'">AC</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'AL'">AL</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'AP'">AP</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'AM'">AM</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'BA'">BA</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'CE'">CE</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'DF'">DF</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'ES'">ES</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'GO'">GO</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'MA'">MA</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'MT'">MT</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'MS'">MS</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'MG'">MG</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'PA'">PA</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'PB'">PB</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'PR'">PR</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'PE'">PE</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'PI'">PI</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'RJ'">RJ</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'RN'">RN</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'RS'">RS</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'RO'">RO</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'RR'">RR</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'SC'">SC</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'SP'">SP</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'SE'">SE</a></li>
                                    <li><a class="dropdown-item" href="#" @click="editEndereco.estado = 'TO'">TO</a></li>
                                  </ul>
                                </div>
                              </div>
                              <div class="col-md-3">
                                <label class="form-label">CEP</label>
                                <input v-model="editEndereco.cep" type="text" class="form-control form-control-sm">
                              </div>
                            </div>
                            <div class="row pb-3">
                              <div class="col-md-4">
                                <div class="form-check">
                                  <input v-model="editEndereco.cobranca" class="form-check-input" :id="`editCobranca${clienteDetalhe.id}`" type="checkbox" :disabled="clienteDetalhe.enderecos.length == 1">
                                  <label class="form-check-label"> 
                                    Endereço de Cobrança
                                  </label>
                                </div>
                                <div class="form-check">
                                  <input v-model="editEndereco.entrega" class="form-check-input" :id="`editCobranca${clienteDetalhe.id}`" type="checkbox" :disabled="clienteDetalhe.enderecos.length == 1">
                                  <label class="form-check-label">
                                    Endereço de Entrega
                                  </label>
                                </div>
                              </div>
                            </div>
                          </form>
                        </div>
                        <div class="modal-footer">
                          <button class="btn btn-secondary" data-bs-dismiss="modal" @click="cancelarCadastroCliente()">Cancelar</button>
                          <button class="btn btn-new" data-bs-dismiss="modal">Concluir</button>
                        </div>
                      </div>
                    </div>
                  </div>
                  <button v-if="clienteDetalhe.enderecos.length > 1" class="btn btn-danger btn-sm" @click="removerEndereco(clienteDetalhe.id, endereco)">Remover</button>
                </div>
              </div>
            </div>
            <div class="col-sm-1 align-middle" ><button class="btn btn-new" data-bs-toggle="modal" data-bs-target="#newEndereco">Novo Endereço</button></div>
            <div class="modal fade" id="newEndereco" tabindex="-1" aria-labelledby="newEnderecoModalLabel" aria-hidden="true">
              <div class="modal-dialog  modal-lg">
                <div class="modal-content">
                  <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                    <h5 class="modal-title" id="newEnderecoModalLabel">Novo Endereço</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                    <form>
                      <div class=" row pb-3">
                        <div class="col-md-2">
                          <label class="form-label">Tipo</label>
                          <div class="dropdown">
                            <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="novoEnderecoTipo" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.tipo}}</button>
                            <ul class="dropdown-menu" aria-labelledby="novoEnderecoTipo">
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
                            <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" id="novoEnderecoTipoLog" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.tipoLogradouro}}</button>
                            <ul class="dropdown-menu" aria-labelledby="novoEnderecoTipoLog">
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
                            <button style="width: 85px;" class="btn btn-secondary btn-sm dropdown-toggle" id="novoEnderecoEstado" data-bs-toggle="dropdown" aria-expanded="false">{{novoEndereco.estado}}</button>
                            <ul class="dropdown-menu" aria-labelledby="novoEnderecoEstado">
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
                      <div class="row pb-3">
                        <div class="col-md-4">
                          <div class="form-check">
                            <input v-model="novoEndereco.cobranca" class="form-check-input" type="checkbox" :id="`novoCobranca${clienteDetalhe.id}`">
                            <label class="form-check-label" for="flexCheckDefault">
                              Endereço de Cobrança
                            </label>
                          </div>
                          <div class="form-check">
                            <input v-model="novoEndereco.entrega" class="form-check-input" type="checkbox" :id="`novoEntrega${clienteDetalhe.id}`">
                            <label class="form-check-label" for="flexCheckChecked">
                              Endereço de Entrega
                            </label>
                          </div>
                        </div>
                      </div>
                    </form>
                  </div>
                  <div class="modal-footer">
                    <button class="btn btn-secondary" data-bs-dismiss="modal" @click="cancelarCadastroEndereco()">Cancelar</button>
                    <button class="btn btn-new" data-bs-dismiss="modal" @click="cadastrarEndereco(clienteDetalhe.id, novoEndereco)">Cadastrar</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div v-if="detalheCartao">
          <div class="row">
            <div v-for="cartao in clienteDetalhe.cartoes" :key="cartao.id" class="col-sm-3">
              <div class="card" style="width: 18rem;">
                <div class="card-body">
                  <h5 class="card-title">{{cartao.tipo}}</h5>
                  <h6 class="card-subtitle mb-2 text-muted">{{cartao.bandeira}}</h6>
                  <p class="card-text pb-0 m-0">{{numeroCartao(cartao.numero)}}</p>
                  <p class="card-text pb-0 m-0">{{formatarDataValidade(cartao.dataValidade)}}</p>
                  <p class="card-text pb-0 m-0">{{cartao.nomeImpresso}}</p>
                  <div class="row pb-3 pt-2">
                    <div class="col-md-12">
                      <div class="form-check">
                        <input v-model="cartao.preferencial" class="form-check-input" type="checkbox" :id="`preferencial${clienteDetalhe.id}`" :disabled="clienteDetalhe.cartoes.length < 2">
                        <label class="form-check-label">
                          Cartão Preferencial
                        </label>
                      </div>
                    </div>
                  </div>
                  <button class="btn btn-danger btn-sm" @click="removerCartao(clienteDetalhe.id, cartao)">Remover</button>
                </div>
              </div>
            </div>
            <div class="col-sm-1 align-middle"><button class="btn btn-new" data-bs-toggle="modal" data-bs-target="#newCartao">Novo Cartão</button></div>
            <div class="modal fade" id="newCartao" tabindex="-1" aria-labelledby="newCartaoModalLabel" aria-hidden="true">
              <div class="modal-dialog  modal-sm">
                <div class="modal-content">
                  <div class="modal-header" style="color: white; background-color: rgba(10, 10, 10, 0.699)">
                    <h5 class="modal-title" id="newCartaoModalLabel">Novo Cartão</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                    <form>
                      <div class="row pb-3">
                        <div class="col-md-6">
                          <label class="form-label">Tipo</label>
                          <div class="dropdown">
                            <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`novoTipoCartao${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{novoCartao.tipo}}</button>
                            <ul class="dropdown-menu" :aria-labelledby="`novoTipoCartao${clienteDetalhe.id}`">
                              <li><a class="dropdown-item" href="#" @click="novoCartao.tipo = 'Crédito'">Crédito</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.tipo = 'Débido'">Débido</a></li>
                            </ul>
                          </div>
                        </div>
                        <div class="col-md-6">
                          <label class="form-label">Bandeira</label>
                          <div class="dropdown">
                            <button style="width: 110px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`novoBandeiraCartao${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{novoCartao.bandeira}}</button>
                            <ul class="dropdown-menu" :aria-labelledby="`novoBandeiraCartao${clienteDetalhe.id}`">
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'Mastercard'">Mastercard</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'Visa'">Visa</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'AmericanEX'">Elo</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'AmericanEX'">Hipercard</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'AmericanEX'">Maestro</a></li>
                              <li><a class="dropdown-item" href="#" @click="novoCartao.bandeira = 'AmericanEX'">AmericanEX</a></li>
                            </ul>
                          </div>
                        </div>
                      </div>
                      <div class="row pb-3"> 
                        <div class="col-md-12">
                          <label class="form-label">Número</label>
                          <input v-model="novoCartao.numero" type="text" class="form-control form-control-sm">
                        </div>
                      </div>
                      <div class="row pb-3"> 
                        <div class="col-md-8">
                          <label class="form-label">Data de Validade</label>
                          <input v-model="novoCartao.dataValidade" type="text" class="form-control form-control-sm">
                        </div>
                        <div class="col-md-4">
                          <label class="form-label">Código</label>
                          <input v-model="novoCartao.codigoVerificacao" type="text" class="form-control form-control-sm">
                        </div>
                      </div>
                      <div class="row pb-3"> 
                        <div class="col-md-12">
                          <label class="form-label">Nome Impresso</label>
                          <input v-model="novoCartao.nomeImpresso" type="text" class="form-control form-control-sm">
                        </div>
                      </div>
                      <div class="row pb-3">
                        <div class="col-md-12">
                          <div class="form-check">
                            <input v-model="novoCartao.preferencial" class="form-check-input" type="checkbox" >
                            <label class="form-check-label">
                              Cartão Preferencial
                            </label>
                          </div>
                        </div>
                      </div>
                    </form>
                  </div>
                  <div class="modal-footer">
                    <button class="btn btn-secondary" data-bs-dismiss="modal" @click="cancelarCadastroCartao()">Cancelar</button>
                    <button class="btn btn-new" data-bs-dismiss="modal" @click="cadastrarCartao(clienteDetalhe.id, novoCartao)">Cadastrar</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
         <div v-if="detalheTransacoes">
          <div class="row">
            <div v-for="transacao in clienteDetalhe.transacoes" :key="transacao.codigo" class="col-sm-3">
              <div class="card" style="width: 18rem;">
                <div class="card-body">
                  <h5 class="card-title">{{transacao.codigo}}</h5>
                  <h6 class="card-subtitle mb-2 text-muted">{{transacao.valor}}</h6>
                  <p v-for="item in transacao.itens" :key="item" class="card-text pb-0 m-0"><ul><li>{{item}}</li></ul></p><br>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.card-selector {
  color: white;
  background-color: rgba(10, 10, 10, 0.699);
}
.card-selector:hover {
  cursor: pointer;
}
.card-selector-active {
  cursor: pointer;
  background-color: rgba(204, 204, 8, 0.712);
  color: white;
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
</style>