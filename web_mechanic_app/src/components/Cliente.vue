<script>
  import FooterBar from "../components/FooterBar.vue"
  export default {
    components: {
      FooterBar
    },
    data() {
      return {
        search: '',
        expanded: [],
        singleExpand: false,
        clienteEdit: null,
        editando: false,
        inserindo: false,
        confirmSenha: null,
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
            nome: "Helena de Castro Paulino",
            genero: "Feminino",
            dataNasc: "01/12/1983",
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
            id: 3,
            nome: "Marcos de Holanda Kristenssen",
            genero: "Masculino",
            dataNasc: "17/08/1992",
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
            id: 4,
            nome: "Camila Yami Norumaka",
            genero: "Feminino",
            dataNasc: "19/06/1994",
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
        novoCliente: {
          nome: null,
          genero: "Selecione",
          dataNasc: null,
          cpf: null,
          email: null,
          senha: null,
          ranking: 0,
          status: "Ativo",
          telefone: {
            tipo: "Selecione",
            ddd: null,
            numero: null
          },
          enderecos: [
            {
              id: 1,
              tipo: "Selecione",
              descricao: null,
              logradouro: null,
              tipoLogradouro: "Selecione",
              numero: null,
              complemento: null,
              bairro: null,
              cidade: null,
              estado: "Selecione",
              cep: null,
              cobranca: false,
            }
          ],
          cartoes: [
            {
              id: 1000,
              bandeira: "Selecione",
              tipo: "Selecione",
              numero: null,
              dataValidade: null,
              codigoVerificacao: null,
              nomeImpresso: null,
              preferencial: true
            }
          ]
        },
        filtrosSelecionados: []
      };
    },
    methods: {
      editarCliente(item){
        this.clienteEdit = item;  
        this.editando = true;
        this.inserindo = false;
        this.quantidadeEndereco = item.enderecos.length;
      },
      inserirCliente(){
        this.editando = false;
        this.inserindo = true;
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
      },
      alterarCartaoPreferencial(cartao_id){
        this.clienteEdit.cartoes.forEach(element => {
          if(element.preferencial){
            element.preferencial = false;
          }
        });
        this.clienteEdit.cartoes.forEach(element => {
          if(element.id == cartao_id){
              element.preferencial = true;
            }
        });
      },
      adicionarFiltro(filtro){
        let existe = false;
        if(this.filtrosSelecionados.length != 0){
          this.filtrosSelecionados.forEach(element => {
            if(element.label == filtro){
              existe = true;
            }
          });
        }
        if(!existe){
          this.filtrosSelecionados.push(
            {
              label: filtro,
              texto: null
            }
          )
        }
      },
      removerFiltro(filtro){
        var index;
        this.filtrosSelecionados.forEach(element => {
          if(element.label == filtro){
            index = this.filtrosSelecionados.indexOf(element);
          }
        });
        this.filtrosSelecionados.splice(index, 1);
      },
      inativarCliente(){
        window.alert("Cliente Inativado!");
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
        <a href="#newForm" @click="inserirCliente()" class="btn btn-new">Novo Cliente</a>
      </div>
    </div>
    <br>
    <br>
    <div class="row">
      <div class="col-2"></div>
      <div class="col-1">
        <b-dropdown text="Filtros">
          <b-dropdown-item @click="adicionarFiltro('Código')">Código</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Nome')">Nome</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('CPF')">CPF</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Data de Nascimento')">Data de Nascimento</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Gênero')">Gênero</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Ranking')">Ranking</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Status')">Status</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('E-mail')">Email</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Telefone')">Telefone</b-dropdown-item>
          <b-dropdown-item @click="adicionarFiltro('Endereço')">Endereço</b-dropdown-item>
        </b-dropdown>
      </div>
      <div v-if="filtrosSelecionados.length > 0" class="col-1">
          <button class="btn btn-primary">Buscar</button>
        </div>
    </div>
    <br>
    <form>
      <div v-for="filtro in filtrosSelecionados" :key="filtro" style="margin-bottom: 30px;">
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label"><button @click="removerFiltro(filtro.label)" class="btn btn-danger">{{filtro.label}}</button></label>
            <input v-model="filtro.texto" type="text" class="form-control">
          </div>
          <br>
        </div>
      </div>
    </form>
    <div class="row" style=" margin-bottom: 20px">
      <div class="col-2"></div>
      <div class="col-8">
        <v-card>
          <v-card-title>
            <v-text-field v-model="search" append-icon="mdi-magnify" label="Procurar" single-line hide-details></v-text-field>
          </v-card-title>
          <v-data-table :headers="clientesHeaders" :items="clientes" :single-expand="singleExpand" :expanded.sync="expanded" item-key="id" :search="search" show-expand class="elevation-1">
            <template v-slot:expanded-item="{ headers, item }">
              <td :colspan="headers.length">
                <div class="row cliente-detalhe" style="margin-top: 15px;">
                  <div class="col-4">
                    <b>Telefone:</b> {{item.telefone.ddd}} {{item.telefone.numero}} ({{item.telefone.tipo}})
                  </div>
                </div>
                <div class="row  cliente-detalhe">
                  <div class="col-4">
                    <b>E-mail:</b> {{item.email}} 
                  </div>
                  <div class="col-3">
                    <b>Senha:</b> {{item.senha}} 
                  </div>
                  <div class="col-4">
                    <div>
                      <b-button v-b-modal.modal-1><small>Alterar Senha</small></b-button>
                      <b-modal id="modal-1" title="Alterar Senha">
                        <label class="form-label">Nova Senha</label>
                        <input v-model="item.senha" type="password" class="form-control">
                        <label class="form-label">Confirmar Senha</label>
                        <input v-model="confirmSenha" type="password" class="form-control">
                      </b-modal>
                    </div>
                  </div>
                </div>
                <hr>
                <div class="row cliente-detalhe">
                  <div class="col-4">
                    <b>Endereços</b>
                  </div>
                </div>
                <br>
                <div v-for="endereco in item.enderecos" :key="endereco.id">
                  <div class="row cliente-detalhe">
                    <div class="col-8">
                      <b>{{endereco.descricao}} ({{(endereco.tipo)}})</b>
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Logradouro: </b>{{endereco.tipoLogradouro}} {{endereco.logradouro}}
                    </div>
                    <div class="col-4">
                      <b>Número: </b>{{endereco.numero}}
                    </div>
                  </div>
                  <div v-if="endereco.complemento" class="row cliente-detalhe">
                    <div class="col-8">
                      <b>Complemento:</b> {{endereco.complemento}}
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Cidade: </b> {{endereco.cidade}}
                    </div>
                    <div class="col-4">
                      <b>Estado: </b> {{endereco.estado}}
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>CEP: </b> {{endereco.cep}}
                    </div>
                  </div>
                  <div v-if="endereco.cobranca" class="row cliente-detalhe">
                    <div class="col-4">
                      <b><u>ENDEREÇO DE COBRANÇA</u></b>
                    </div>
                  </div>
                  <br>
                </div>
                <hr>
                <div class="row cliente-detalhe">
                  <div class="col-4">
                    <b>Cartões</b>
                  </div>
                </div>
                <br>
                <div v-for="cartao in item.cartoes" :key="cartao.id">
                  <div class="row cliente-detalhe">
                    <div class="col-8">
                      <b>{{cartao.tipo}}</b>
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Bandeira: </b> {{cartao.bandeira}}
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Número: </b> {{cartao.numero}}
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Validade: </b> {{cartao.dataValidade}}
                    </div>
                    <div class="col-4">
                      <b>CV: </b> {{cartao.codigoVerificacao}}
                    </div>
                  </div>
                  <div class="row cliente-detalhe">
                    <div class="col-4">
                      <b>Nome: </b> {{cartao.nomeImpresso}}
                    </div>
                  </div>
                  <div v-if="cartao.preferencial" class="row  cliente-detalhe">
                    <div class="col-4">
                      <b><u>CARTÃO PREFERENCIAL</u></b>
                    </div>
                  </div>
                  <br>
                </div>
                <br>
                <br>
                <div class="row  cliente-detalhe" style="margin-bottom: 30px;">
                  <div class="col-4">
                    <div>
                      <b-button v-b-modal.modal-2><small>Consultar Transações</small></b-button>
                      <b-modal id="modal-2" title="Transações">
                        <div v-for="transacao in item.transacoes" :key="transacao.codigo">
                          <div class="row">
                            <div class="col-4">
                              <b>Código: </b>{{transacao.codigo}}
                            </div>
                            <div class="col-4">
                              <b>Valor: </b>{{transacao.valor}}
                            </div>
                          </div>
                          <br>
                          <div v-for="item in transacao.itens" :key="item" class="row">
                            <div class="col-2" style="margin-left: 20px;">
                              <ul>
                                <li>{{item}}</li>
                              </ul>
                            </div>
                          </div>
                          <hr>
                        </div>
                      </b-modal>
                    </div>
                  </div>
                  <div class="col-4"></div>
                  <div class="col-2">
                    <a href="#editForm" class="btn btn-edit" @click="editarCliente(item)"><small>Editar Cliente</small></a>
                  </div>
                  <div class="col-2">
                    <button class="btn btn-delete" @click="inativarCliente()"><small>Inativar Cliente</small></button>
                  </div>
                </div>
              </td>
            </template>
          </v-data-table>
        </v-card>
      </div>
    </div>
    <div v-if="inserindo" class="container-fluid edit-container" id="newForm" style="margin-top: 30px;">
      <form>
         <div class="row">
          <div class="col-2"></div>
          <div class="col-8"><hr></div>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <h4>Novo Cliente</h4>
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label">Nome</label>
            <input v-model="novoCliente.nome" type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">CPF</label>
            <input v-model="novoCliente.cpf" type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">Data de Nascimento</label>
            <input v-model="novoCliente.dataNasc" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-1">
            <label class="form-label">Gênero</label>
            <b-dropdown :text="novoCliente.genero">
              <b-dropdown-item @click="novoCliente.genero = 'Masculino'">Masculino</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.genero = 'Feminino'">Masculino</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.genero = 'Outro'">Masculino</b-dropdown-item>
            </b-dropdown>
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label">Email</label>
            <input v-model="novoCliente.email" type="text" class="form-control">
          </div>
          <div class="col-1">
            <label class="form-label">Telefone</label>
            <b-dropdown :text="novoCliente.telefone.tipo">
              <b-dropdown-item @click="novoCliente.telefone.tipo = 'Residencial'">Residencial</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.telefone.tipo = 'Comercial'">Comercial</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.telefone.tipo = 'Celular'">Celular</b-dropdown-item>
             </b-dropdown>
          </div>
          <div class="col-1">
            <label class="form-label">&nbsp;</label>
            <input v-model="novoCliente.telefone.ddd" type="text" class="form-control"  style="width: 50%;">
          </div>
           <div class="col-2">
            <label class="form-label">&nbsp;</label>
            <input v-model="novoCliente.telefone.numero" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-3">
            <label class="form-label">Senha</label>
            <input v-model="novoCliente.senha" type="text" class="form-control">
          </div>
          <div class="col-3">
            <label class="form-label">Confirmar Senha</label>
            <input v-model="novoCliente.senha" type="text" class="form-control">
          </div>
        </div>
        <br>
        <br>
        <div class="row">
          <div class="col-2"></div>
           <div class="col-2"><h5>Endereço</h5></div>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-1" style="margin-right: 10px;">
            <label class="form-label">Tipo</label>
            <b-dropdown :text="novoCliente.enderecos[0].tipo">
              <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Casa'">Casa</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Apartamento'">Apartamento</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Comércio'">Comércio</b-dropdown-item>
            </b-dropdown>
          </div>
          <div class="col-4">
            <label class="form-label">Descrição</label>
            <input v-model="novoCliente.enderecos[0].descricao" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-1">
            <label class="form-label">Logradouro</label>
            <b-dropdown :text="novoCliente.enderecos[0].tipoLogradouro">
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Rua'">Rua</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Avenida'">Avenida</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Travessa'">Travessa</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Estrada'">Estrada</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Alameda'">Alameda</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Rodovia'">Rodovia</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Viela'">Viela</b-dropdown-item>
            </b-dropdown>
          </div>
          <div class="col-6">
            <label class="form-label">&nbsp;</label>
            <input v-model="novoCliente.enderecos[0].logradouro" type="text" class="form-control">
          </div>
          <div class="col-1">
            <label class="form-label">Número</label>
            <input v-model="novoCliente.enderecos[0].numero" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label">Complemento</label>
            <input v-model="novoCliente.enderecos[0].complemento" type="text" class="form-control">
          </div>
          <div class="col-3">
            <label class="form-label">Cidade</label>
            <input v-model="novoCliente.enderecos[0].cidade" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row" style="margin-bottom: 50px;">
          <div class="col-2"></div>
          <div class="col-1">
            <label class="form-label">Estado</label>
            <b-dropdown :text="novoCliente.enderecos[0].estado">
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AC'">AC</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AL'">AL</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AP'">AP</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AM'">AM</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'BA'">BA</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'CE'">CE</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'DF'">DF</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'ES'">ES</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'GO'">GO</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MA'">MA</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MT'">MT</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MS'">MS</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MG'">MG</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PA'">PA</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PB'">PB</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PR'">PR</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PE'">PE</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PI'">PI</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RJ'">RJ</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RN'">RN</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RS'">RS</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RO'">RO</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RR'">RR</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SC'">SC</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SP'">SP</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SE'">SE</b-dropdown-item>
              <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'TO'">TO</b-dropdown-item>
            </b-dropdown>
          </div>
          <div class="col-2">
            <label class="form-label">CEP</label>
            <input v-model="novoCliente.enderecos[0].cep" type="text" class="form-control">
          </div>
        </div>
      </form>
      <div class="row">
        <div class="col-2"></div>
        <div class="col-8"><hr></div>
      </div>
      <br>
      <br>
      <div class="row">
        <div class="col-2"></div>
        <div class="col-6"></div>
        <div class="col-1">
          <button class="btn btn-secondary"><small>Cancelar</small></button>
        </div>
        <div class="col-2">
          <button class="btn btn-primary"><small>Cadastrar Cliente</small></button>
        </div>
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
          <div class="col-4">
            <label class="form-label">Email</label>
            <input v-model="clienteEdit.email" type="text" class="form-control">
          </div>
          <div class="col-1">
            <label class="form-label">Telefone</label>
            <b-dropdown :text="clienteEdit.telefone.tipo">
              <b-dropdown-item @click="clienteEdit.telefone.tipo = 'Residencial'">Residencial</b-dropdown-item>
              <b-dropdown-item @click="clienteEdit.telefone.tipo = 'Comercial'">Comercial</b-dropdown-item>
              <b-dropdown-item @click="clienteEdit.telefone.tipo = 'Celular'">Celular</b-dropdown-item>
             </b-dropdown>
          </div>
          <div class="col-1">
            <label class="form-label">&nbsp;</label>
            <input v-model="clienteEdit.telefone.ddd" type="text" class="form-control" style="width: 50%;">
          </div>
           <div class="col-2">
            <label class="form-label">&nbsp;</label>
            <input v-model="clienteEdit.telefone.numero" type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-1">
            <label class="form-label">Gênero</label>
            <b-dropdown :text="clienteEdit.genero">
              <b-dropdown-item @click="clienteEdit.genero = 'Masculino'">Masculino</b-dropdown-item>
              <b-dropdown-item @click="clienteEdit.genero = 'Feminino'">Masculino</b-dropdown-item>
              <b-dropdown-item @click="clienteEdit.genero = 'Outro'">Masculino</b-dropdown-item>
            </b-dropdown>
          </div>
        </div>
        <br>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-8"><hr></div>
        </div>
        <div class="row">
          <div class="col-2"></div>
           <div class="col-2"><h5>Endereços</h5></div>
        </div>
        <br>
        <div v-for="endereco in clienteEdit.enderecos" :key="endereco.id">
          <div class="row">
            <div class="col-2"></div>
            <div class="col-7">
              <b>{{endereco.descricao}}</b>
            </div>
            <div v-if="quantidadeEndereco > 1" class="col-1">
              <button class="btn btn-danger"><small>Remover</small></button>
            </div>
          </div>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-1" style="margin-right: 10px;">
              <label class="form-label">Tipo</label>
              <b-dropdown :text="endereco.tipo">
                <b-dropdown-item @click="endereco.tipo = 'Casa'">Casa</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipo = 'Apartamento'">Apartamento</b-dropdown-item>
                <b-dropdown-item @click="endereco.tipo = 'Comércio'">Comércio</b-dropdown-item>
              </b-dropdown>
            </div>
            <div class="col-4">
              <label class="form-label">Descrição</label>
              <input v-model="endereco.descricao" type="text" class="form-control">
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
          <div class="row">
            <div class="col-2"></div>
            <div class="form-check" @click="alterarEnderecoCobranca(endereco.id)" style="margin-left: 10px;">
              <input v-model="endereco.cobranca" class="form-check-input" type="checkbox" :id="endereco.id" :disabled="clienteEdit.enderecos.length < 2">
              <label class="form-check-label">
                Endereço de Cobrança
              </label>
            </div>
          </div>
          <br>
          <br>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-7"></div>
          <div class="col-2">
            <div class="container-fluid">
              <b-button v-b-modal.modal-3 class="btn btn-edit"><small>Novo Endereço</small></b-button>
              <b-modal id="modal-3" title="Novo Endereço">
                <form>
                  <div class="row">
                    <div class="col-2" style="margin-right: 80px;">
                      <label class="form-label">Tipo</label>
                      <b-dropdown :text="novoCliente.enderecos[0].tipo">
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Casa'">Casa</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Apartamento'">Apartamento</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipo = 'Comércio'">Comércio</b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-12">
                      <label class="form-label">Descrição</label>
                      <input v-model="novoCliente.enderecos[0].descricao" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-1" style="margin-right: 80px;">
                      <label class="form-label">Logradouro</label>
                      <b-dropdown :text="novoCliente.enderecos[0].tipoLogradouro">
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Rua'">Rua</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Avenida'">Avenida</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Travessa'">Travessa</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Estrada'">Estrada</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Alameda'">Alameda</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Rodovia'">Rodovia</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].tipoLogradouro = 'Viela'">Viela</b-dropdown-item>
                      </b-dropdown>
                    </div>
                    <div class="col-9">
                      <label class="form-label">&nbsp;</label>
                      <input v-model="novoCliente.enderecos[0].logradouro" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-3">
                      <label class="form-label">Número</label>
                      <input v-model="novoCliente.enderecos[0].numero" type="text" class="form-control">
                    </div>
                    <div class="col-9">
                      <label class="form-label">Complemento</label>
                      <input v-model="novoCliente.enderecos[0].complemento" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-3">
                      <label class="form-label">Cidade</label>
                      <input v-model="novoCliente.enderecos[0].cidade" type="text" class="form-control">
                    </div>
                    <div class="col-1">
                      <label class="form-label">Estado</label>
                      <b-dropdown :text="novoCliente.enderecos[0].estado">
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AC'">AC</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AL'">AL</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AP'">AP</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'AM'">AM</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'BA'">BA</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'CE'">CE</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'DF'">DF</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'ES'">ES</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'GO'">GO</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MA'">MA</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MT'">MT</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MS'">MS</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'MG'">MG</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PA'">PA</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PB'">PB</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PR'">PR</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PE'">PE</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'PI'">PI</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RJ'">RJ</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RN'">RN</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RS'">RS</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RO'">RO</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'RR'">RR</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SC'">SC</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SP'">SP</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'SE'">SE</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.enderecos[0].estado = 'TO'">TO</b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                  <br>
                  <div class="row" style="margin-bottom: 50px;">
                    <div class="col-6">
                      <label class="form-label">CEP</label>
                      <input v-model="novoCliente.enderecos[0].cep" type="text" class="form-control">
                    </div>
                  </div>
                </form>
              </b-modal>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-8"><hr></div>
        </div>
        <br>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-2"><h5>Cartões</h5></div>
        </div>
        <br>
        <div v-for="cartao in clienteEdit.cartoes" :key="cartao.id">
          <div class="row">
            <div class="col-2"></div>
            <div class="col-4"><b>Tipo: </b>{{cartao.tipo}}</div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-3"><b>Bandeira: </b>{{cartao.bandeira}}</div>
            <div class="col-2"><b>Número: </b>{{cartao.numero}}</div>
            <div class="col-1">
              <button class="btn btn-danger"><small>Remover</small></button>
            </div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-3"><b>Data de validade: </b>{{cartao.dataValidade}}</div>
            <div class="col-3"><b>Código: </b>{{cartao.codigoVerificacao}}</div>
          </div>
          <br>
          <div class="row">
            <div class="col-2"></div>
            <div class="col-3"><b>Nome: </b>{{cartao.nomeImpresso}}</div>
          </div>
        </div>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-7"></div>
          <div class="col-2">
            <div class="container-fluid">
              <b-button v-b-modal.modal-4 class="btn btn-edit"><small>Novo Cartão</small></b-button>
              <b-modal id="modal-4" title="Novo Cartão">
                <form>
                  <div class="row">
                    <div class="col-3">
                      <label class="form-label">Tipo</label>
                      <b-dropdown :text="novoCliente.cartoes[0].tipo">
                        <b-dropdown-item @click="novoCliente.cartoes[0].tipo = 'Crédito'">Crédito</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].tipo = 'Débito'">Débito</b-dropdown-item>
                      </b-dropdown>
                    </div>
                    <div class="col-3">
                      <label class="form-label">Bandeira</label>
                      <b-dropdown :text="novoCliente.cartoes[0].bandeira">
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'Mastercard'">Mastercard</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'Maestro'">Maestro</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'Visa'">Visa</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'Hipercard'">Hipercard</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'AmericanEX'">AmericanEX</b-dropdown-item>
                        <b-dropdown-item @click="novoCliente.cartoes[0].bandeira = 'Elo'">Elo</b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-8">
                      <label class="form-label">Número</label>
                      <input v-model="novoCliente.cartoes[0].numero" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-8">
                      <label class="form-label">Nome Impresso</label>
                      <input v-model="novoCliente.cartoes[0].nomeImpresso" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                  <div class="row">
                    <div class="col-4">
                      <label class="form-label">Data de Validade</label>
                      <input v-model="novoCliente.cartoes[0].dataValidade" type="text" class="form-control">
                    </div>
                    <div class="col-3">
                      <label class="form-label">CV</label>
                      <input v-model="novoCliente.cartoes[0].codigoVerificacao" type="text" class="form-control">
                    </div>
                  </div>
                  <br>
                </form>
              </b-modal>
            </div>
          </div>
        </div>
      </form>
      <div class="row">
        <div class="col-2"></div>
        <div class="col-8"><hr></div>
      </div>
      <br>
      <br>
      <div class="row">
        <div class="col-2"></div>
        <div class="col-6"></div>
        <div class="col-1">
          <button class="btn btn-secondary"><small>Cancelar</small></button>
        </div>
        <div class="col-2">
          <button class="btn btn-primary"><small>Salvar Alterações</small></button>
        </div>
      </div>
    </div>
    <div v-else></div>
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