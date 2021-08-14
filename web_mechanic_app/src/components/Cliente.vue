<script>
  import FooterBar from "../components/FooterBar.vue"
  export default {
    components: {
      FooterBar
    },
    data() {
      return {
        logTipo: "Selecione",
        expanded: [],
        singleExpand: false,
        clienteEdit: null,
        editando: false,
        confrimSenha: null,
        quantidadeEndereco: 0,
        clientesHeaders: [
          { text: "Código", value: "id" },
          { text: "Nome", value: "nome" },
          { text: "CPF", value: "cpf" },
          { text: "Data de Nascimento", value: "dataNasc" },
          { text: "Gênero", value: "genero" },
          { text: "Ranking", value: "ranking"},
          { text: "Status", value: "status"}
        ],
        clientes: [
          {
            id: 1,
            nome: "José Carlos de Sampaio",
            genero: "Masculino",
            dataNasc: "30/04/1976",
            cpf: "23145312398",
            telefone: "11 964123267 (celular)",
            email: "jcarlossampaio@yahoo.com.br",
            senha: "admin123",
            ranking: 4,
            status: "Ativo",
            enderecos: [
              {
                id: 1,
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
              }
            ]
          },
          {
            id: 2,
            nome: "Helena de Castro Paulino",
            genero: "Feminino",
            dataNasc: "01/12/1983",
            cpf: "31050046987",
            telefone: "58 954120369 (celular)",
            email: "helena.castro83@outlook.com",
            senha: "helecas76@83",
            ranking: 8,
            status: "Ativo",
            enderecos: [
              {
                id: 1,
                tipo: "Casa",
                logradouro: "João de Paulas",
                tipoLogradouro: "Travessa",
                numero: "51",
                complemento: null,
                bairro: "Vila Maria",
                cidade: "Anápolis",
                estado: "GO",
                cep: "09651470",
                cobranca: true,
              },
              {
                id: 2,
                tipo: "Apartamento",
                logradouro: "Lourenço Baptista",
                tipoLogradouro: "Rua",
                numero: "137A",
                complemento: "Bloco Azul - Apto: 48",
                bairro: "Conjunto Floresta",
                cidade: "Ourinhos",
                estado: "MG",
                cep: "14012548",
                cobranca: false,
              }
            ]
          },
          {
            id: 3,
            nome: "Marcos de Holanda Kristenssen",
            genero: "Masculino",
            dataNasc: "17/08/1992",
            cpf: "53089741236",
            telefone: "21 954123687 (celular)",
            email: "holanda.k.marcos@gmail.com",
            senha: "biapaulinho2010-2002",
            ranking: 3,
            status: "Ativo",
            enderecos: [
              {
                id: 1,
                tipo: "Apartamento",
                logradouro: "Savino Mesquita",
                tipoLogradouro: "Rua",
                numero: "452",
                complemento: "Bloco: B - Apto: 324",
                bairro: "Vila Maria",
                cidade: "Niteroi",
                estado: "RJ",
                cep: "25631478",
                cobranca: true,
              }
            ]
          },
          {
            id: 4,
            nome: "Camila Yami Norumaka",
            genero: "Feminino",
            dataNasc: "19/06/1994",
            cpf: "47102306987",
            telefone: "31 948752023 (celular)",
            email: "cahzinha.yami@gmail.com",
            senha: "yaCahzinha8765@norumaka",
            ranking: 6,
            status: "Ativo",
            enderecos: [
              {
                id: 1,
                tipo: "Apartamento",
                logradouro: "Pimentel",
                tipoLogradouro: "Avenida",
                numero: "89",
                complemento: "Torre: 3 - Apto: 190",
                bairro: "Vila Maria",
                cidade: "Joinville",
                estado: "SC",
                cep: "47123541",
                cobranca: true,
              }
            ]
          },
        ],
      };
    },
    methods: {
      editarCliente(item){
        this.clienteEdit = item;  
        this.editando = true;
        this.confrimSenha = item.senha;
        this.quantidadeEndereco = item.enderecos.length;
      },
      alterarEnderecoCobranca(endereco_id){
        this.clienteEdit.enderecos.forEach(element => {
          if(element.cobranca){
            element.cobranca = false;
          }
        });
        this.clienteEdit.enderecos.forEach(element => {
          if(element.id == endereco_id){
              element.cobranca = true;
            }
        });
      }
    },
  };
</script>

<template>
  <div class="container-fluid" style="padding-bottom: 50px;">
    <div class="row" style="margin-top: 10px;">
      <div class="col-2"></div>
      <div class="col-8">
        <h3><b>Gestão de Clientes</b></h3>
        <br><br>
      </div>
    </div>
    <div class="row">
      <div class="col-2"></div>
      <div class="col-8">
        <button class="btn btn-new">Novo Cliente</button>
      </div>
    </div>
    <br>
    <div class="row" style=" margin-bottom: 20px">
      <div class="col-2"></div>
      <div class="col-8">
        <v-data-table :headers="clientesHeaders" :items="clientes" :single-expand="singleExpand" :expanded.sync="expanded" item-key="id" show-expand class="elevation-1">
          <template v-slot:expanded-item="{ headers, item }">
            <td :colspan="headers.length">
              <div class="row cliente-detalhe" style="margin-top: 5px;">
                <div class="col-4">
                  <b>Telefone:</b> {{item.telefone}}
                </div>
              </div>
              <div class="row  cliente-detalhe">
                <div class="col-4">
                  <b>E-mail:</b> {{item.email}} 
                </div>
                <div class="col-3">
                  <b>Senha: </b> {{item.senha}} 
                </div>
                <div class="col-4">
                  <div>
                    <b-button v-b-modal.modal-1><small>Alterar Senha</small></b-button>
                    <b-modal id="modal-1" title="Alterar Senha">
                      <label class="form-label">Nova Senha</label>
                      <input v-model="item.senha" type="password" class="form-control">
                      <label class="form-label">Confirmar Senha</label>
                      <input v-model="confrimSenha" type="password" class="form-control">
                    </b-modal>
                  </div>
                </div>
              </div>
              <div v-for="endereco in item.enderecos" :key="endereco.id">
                <hr>
                <div class="row  cliente-detalhe">
                  <div class="col-8">
                    <b>Endereço {{endereco.id}} - {{(endereco.tipo)}}</b>
                  </div>
                </div>
                <div class="row  cliente-detalhe">
                  <div class="col-4">
                    <b>Logradouro: </b>{{endereco.tipoLogradouro}} {{endereco.logradouro}}
                  </div>
                  <div class="col-4">
                    <b>Número: </b> {{endereco.numero}}
                  </div>
                </div>
                <div v-if="endereco.complemento" class="row  cliente-detalhe">
                  <div class="col-8">
                    <b>Complemento:</b> {{endereco.complemento}}
                  </div>
                </div>
                <div class="row  cliente-detalhe">
                  <div class="col-4">
                    <b>Cidade: </b> {{endereco.cidade}}
                  </div>
                  <div class="col-4">
                    <b>Estado: </b> {{endereco.estado}}
                  </div>
                </div>
                <div class="row  cliente-detalhe">
                  <div class="col-4">
                    <b>CEP: </b> {{endereco.cep}}
                  </div>
                </div>
                <div v-if="endereco.cobranca" class="row  cliente-detalhe">
                  <div class="col-4">
                    <b><u>ENDEREÇO DE COBRANÇA</u></b>
                  </div>
                </div>
              </div>
              <div class="row  cliente-detalhe" style="margin-bottom: 8px;">
                <div class="col-8"></div>
                <div class="col-2">
                  <a href="#editForm" class="btn btn-edit" @click="editarCliente(item)">Editar Cliente</a>
                </div>
                <div class="col-2">
                  <button class="btn btn-delete">Inativar Cliente</button>
                </div>
              </div>
            </td>
          </template>
        </v-data-table>
      </div>
    </div>
    <div v-if="editando" class="container-fluid edit-container" id="editForm" style="margin-top: 30px;">
      <form>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-8"><hr></div>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <h4>Editar Cliente</h4>
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label">Nome</label>
            <input v-model="clienteEdit.nome" type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">CPF</label>
            <input v-model="clienteEdit.cpf" type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">Data de Nascimento</label>
            <input v-model="clienteEdit.dataNasc" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-5">
            <label class="form-label">Email</label>
            <input v-model="clienteEdit.email" type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">Telefone</label>
            <input v-model="clienteEdit.telefone" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-2">
            <label class="form-label">Gênero</label>
            <input v-model="clienteEdit.genero" type="text" class="form-control">
          </div>
        </div>
        <br>
        <br>
        <div v-for="endereco in clienteEdit.enderecos" :key="endereco.id">
          <div class="row">
            <div class="col-2"></div>
            <div class="col-8"><hr></div>
          </div>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-7">
              <b>Endereço {{endereco.id}}</b>
            </div>
            <div v-if="quantidadeEndereco > 1" class="col-1">
              <button class="btn btn-danger"><small>Remover</small></button>
            </div>
          </div>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-1">
              <label class="form-label">Tipo</label>
              <b-dropdown :text="endereco.tipo">
                <b-dropdown-item @click="endereco.tipo = 'Casa'">Casa</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipo = 'Apartamento'">Apartamento</b-dropdown-item>
              </b-dropdown>
            </div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-1">
              <label class="form-label">Logradouro</label>
              <b-dropdown v-model="endereco.tipoLogradouro" :text="endereco.tipoLogradouro">
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Rua'">Rua</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Avenida'">Avenida</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Travessa'">Travessa</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Estrada'">Estrada</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Alameda'">Alameda</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Rodovia'">Rodovia</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipoLogradouro = 'Viela'">Viela</b-dropdown-item>
              </b-dropdown>
            </div>
            <div class="col-6">
              <label class="form-label">&nbsp;</label>
              <input v-model="endereco.logradouro" type="text" class="form-control">
            </div>
            <div class="col-1">
              <label class="form-label">Número</label>
              <input v-model="endereco.numero" type="text" class="form-control">
            </div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-4">
              <label class="form-label">Complemento</label>
              <input v-model="endereco.complemento" type="text" class="form-control">
            </div>
            <div class="col-3">
              <label class="form-label">Cidade</label>
              <input v-model="endereco.cidade" type="text" class="form-control">
            </div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-1">
              <label class="form-label">Estado</label>
              <b-dropdown :text="endereco.estado">
                <b-dropdown-item @click="endereco.estado = 'AC'">AC</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'AL'">AL</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'AP'">AP</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'AM'">AM</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'BA'">BA</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'CE'">CE</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'DF'">DF</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'ES'">ES</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'GO'">GO</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'MA'">MA</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'MT'">MT</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'MS'">MS</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'MG'">MG</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'PA'">PA</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'PB'">PB</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'PR'">PR</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'PE'">PE</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'PI'">PI</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'RJ'">RJ</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'RN'">RN</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'RS'">RS</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'RO'">RO</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'RR'">RR</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'SC'">SC</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'SP'">SP</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'SE'">SE</b-dropdown-item>
                <b-dropdown-item @click="endereco.estado = 'TO'">TO</b-dropdown-item>
              </b-dropdown>
            </div>
            <div class="col-2">
              <label class="form-label">CEP</label>
              <input v-model="endereco.cep" type="text" class="form-control">
            </div>
          </div>
          <br>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="form-check" @click="alterarEnderecoCobranca(endereco.id)" style="margin-left: 10px;">
              <input v-model="endereco.cobranca" class="form-check-input" type="checkbox" :id="endereco.id">
              <label class="form-check-label">
                Endereço de Cobrança
              </label>
            </div>
          </div>
          <br>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-7"></div>
          <div class="col-2">
            <button class="btn btn-edit"><small>Novo Endereço</small></button>
          </div>
        </div>
      </form>
    </div>
    <FooterBar/>
  </div>
</template>

<style scoped>
  .cliente-detalhe{
    margin-left: 40px
  }
  .btn-edit{
    color: white;
    background-color: rgba(204, 204, 8, 0.712);
    border: 1px solid rgba(204, 204, 8, 0.712);
    height: 33;
  }
  .btn-edit:hover{
    color: rgba(204, 204, 8, 0.712);
    background-color: white;
  }
  .btn-new{
    color: white;
    background-color: rgba(10, 10, 10, 0.699);
    border: 1px solid rgba(10, 10, 10, 0.699);
    height: 33;
  }
  .btn-new:hover{
    color: rgba(10, 10, 10, 0.699);
    background-color: white;
  }
  .btn-delete{
    color: white;
    background-color: rgba(141, 138, 138, 0.699);
    border: 1px solid rgba(141, 138, 138, 0.699);
    height: 33;
  }
  .btn-delete:hover{
    color: rgba(141, 138, 138, 0.699);
    background-color: white;
  }
</style>