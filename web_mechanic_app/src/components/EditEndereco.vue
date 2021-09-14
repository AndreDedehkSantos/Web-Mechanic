<script>
  export default {

  }
</script>

<template>
  <div>
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
                  <input v-model="editEndereco.cidade.descricao" type="text" class="form-control form-control-sm">
                </div>
                <div class="col-md-2">
                  <label class="form-label">Estado</label>
                  <div class="dropdown">
                    <button style="width: 85px;" class="btn btn-secondary btn-sm dropdown-toggle" :id="`editEstado${clienteDetalhe.id}`" data-bs-toggle="dropdown" aria-expanded="false">{{editEndereco.estado.uf}}</button>
                    <ul class="dropdown-menu" :aria-labelledby="`editEstado${clienteDetalhe.id}`">
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'AC'">AC</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'AL'">AL</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'AP'">AP</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'AM'">AM</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'BA'">BA</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'CE'">CE</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'DF'">DF</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'ES'">ES</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'GO'">GO</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'MA'">MA</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'MT'">MT</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'MS'">MS</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'MG'">MG</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'PA'">PA</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'PB'">PB</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'PR'">PR</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'PE'">PE</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'PI'">PI</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'RJ'">RJ</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'RN'">RN</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'RS'">RS</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'RO'">RO</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'RR'">RR</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'SC'">SC</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'SP'">SP</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'SE'">SE</a></li>
                      <li><a class="dropdown-item" href="#" @click="editEndereco.estado.uf = 'TO'">TO</a></li>
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
  </div>
</template>

<style scoped>
</style>