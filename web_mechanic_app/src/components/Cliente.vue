<script>
  export default {
    data() {
      return {
        expanded: [],
        singleExpand: false,
        clientesHeaders: [
          { text: "Código", value: "id" },
          { text: "Nome", value: "nome" },
          { text: "Gênero", value: "genero" },
          { text: "Data de Nascimento", value: "dataNasc" },
          { text: "CPF", value: "cpf" },
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
            endereco: {
              logradouro: "Av Ibiras Veles",
              numero: "42",
              complemento: null,
              bairro: "Jardim Amaral",
              cidade: "Taboão da Serra",
              estado: "SP",
              cep: "03213876"
            }
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
            endereco: {
              logradouro: "Tv João de Paulas",
              numero: "51",
              complemento: null,
              bairro: "Vila Maria",
              cidade: "Anápolis",
              estado: "GO",
              cep: "09651470"
            }
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
            endereco: {
              logradouro: "Rua Savino Mesquita",
              numero: "452",
              complemento: "Bloco: B - Apto: 324",
              bairro: "Vila Maria",
              cidade: "Niteroi",
              estado: "RJ",
              cep: "25631478"
            }
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
            endereco: {
              logradouro: "Av Pimentel",
              numero: "89",
              complemento: "Torre: 3 - Apto: 190",
              bairro: "Vila Maria",
              cidade: "Joinville",
              estado: "SC",
              cep: "47123541"
            }
          },
        ],
      };
    },
  };
</script>

<template>
  <div class="container-fluid">
    <div class="row" style="margin-top: 10px;">
      <div class="col-1"></div>
      <div class="col-9">
        <h3><b>Gestão de Clientes</b></h3>
        <br><br>
      </div>
    </div>
    <div class="row">
      <div class="col-1"></div>
      <div class="col-9">
        <button class="btn btn-new">Novo Cliente</button>
      </div>
    </div>
    <br>
    <div class="row" style=" margin-bottom: 20px">
      <div class="col-1"></div>
      <div class="col-9">
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
              <hr>
              <div class="row  cliente-detalhe">
                <div class="col-8">
                  <b>Endereço</b>
                </div>
              </div>
              <div class="row  cliente-detalhe">
                <div class="col-4">
                  <b>Logradouro: </b> {{item.endereco.logradouro}}
                </div>
                <div class="col-4">
                  <b>Número: </b> {{item.endereco.numero}}
                </div>
              </div>
              <div v-if="item.endereco.complemento" class="row  cliente-detalhe">
                <div class="col-8">
                  <b>Complemento: </b> {{item.endereco.complemento}}
                </div>
              </div>
              <div class="row  cliente-detalhe">
                <div class="col-4">
                  <b>Cidade: </b> {{item.endereco.cidade}}
                </div>
                <div class="col-4">
                  <b>UF: </b> {{item.endereco.estado}}
                </div>
              </div>
              <div class="row  cliente-detalhe" style="margin-bottom: 8px;">
                <div class="col-4">
                  <b>CEP: </b> {{item.endereco.cep}}
                </div>
                 <div class="col-4"></div>
                <div class="col-2">
                  <button class="btn btn-edit">Editar Cliente</button>
                </div>
                <div class="col-2">
                  <button class="btn btn-delete">Exluir Cliente</button>
                </div>
              </div>
            </td>
          </template>
        </v-data-table>
      </div>
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