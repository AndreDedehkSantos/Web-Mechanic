<script>
  export default {
    data() {
      return {
        logTipo: "Selecione",
        expanded: [],
        singleExpand: false,
        clientesHeaders: [
          { text: "Código", value: "id" },
          { text: "Nome", value: "nome" },
          { text: "CPF", value: "cpf" },
          { text: "Data de Nascimento", value: "dataNasc" },
          { text: "Gênero", value: "genero" },
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
          /*{
            id: 3,
            nome: "Marcos de Holanda Kristenssen",
            genero: "Masculino",
            dataNasc: "17/08/1992",
            cpf: "53089741236",
            telefone: "21 954123687 (celular)",
            email: "holanda.k.marcos@gmail.com",
            senha: "biapaulinho2010-2002",
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
          },*/
        ],
      };
    },
  };
</script>

<template>
  <div class="container-fluid">
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
                <div class="col-4">
                  <b>Senha: </b> {{item.senha}} 
                </div>
              </div>
              <div v-for="endereco in item.enderecos" :key="endereco.id">
                <hr>
                <div class="row  cliente-detalhe">
                  <div class="col-8">
                    <b>Endereço {{endereco.id}} - ({{endereco.tipo}})</b>
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
                    <b>Complemento: </b> {{endereco.complemento}}
                  </div>
                </div>
                <div class="row  cliente-detalhe">
                  <div class="col-4">
                    <b>Cidade: </b> {{endereco.cidade}}
                  </div>
                  <div class="col-4">
                    <b>UF: </b> {{endereco.estado}}
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
                  <button class="btn btn-edit">Editar Cliente</button>
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
    <div class="container-fluid edit-container" style="margin-top: 30px;">
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
        <div class="row">
          <div class="col-2"></div>
          <div class="col-4">
            <label class="form-label">Nome</label>
            <input type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">CPF</label>
            <input type="text" class="form-control">
          </div>
          <div class="col-2">
            <label class="form-label">Data de Nascimento</label>
            <input type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-2">
            <label class="form-label">Gênero</label>
            <input type="text" class="form-control">
          </div>
           <div class="col-2">
            <label class="form-label">Telefone</label>
            <input type="text" class="form-control">
          </div>
        </div>
        <br>
        <div class="row">
          <div class="col-2"></div>
          <div class="col-1">
            <label class="form-label">&nbsp;</label>
            <div class="dropdown">
              <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">{{this.logTipo}}</button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <li><a class="dropdown-item" href="#">Rua</a></li>
                <li><a class="dropdown-item" href="#">Avenida</a></li>
                <li><a class="dropdown-item" href="#">Travessa</a></li>
                <li><a class="dropdown-item" href="#">Rodovia</a></li>
                <li><a class="dropdown-item" href="#">Alameda</a></li>
                <li><a class="dropdown-item" href="#">Estrada</a></li>
                <li><a class="dropdown-item" href="#">Sítio</a></li>
                <li><a class="dropdown-item" href="#">Viela</a></li>
              </ul>
            </div>
          </div>
          <div class="col-6">
            <label class="form-label">Logradouro</label>
            <input type="text" class="form-control">
          </div>
          <div class="col-1">
            <label class="form-label">Número</label>
            <input type="text" class="form-control">
          </div>
        </div>
      </form>
    </div>
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