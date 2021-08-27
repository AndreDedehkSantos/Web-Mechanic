<script>
  export default {
    data(){
      return{
        filtroRanking: -1
      }
    }
  };
</script>

<template>
  <div class="container px-0" style="max-heigth: 100px">
    <nav class="navbar navbar-expand d-flex flex-column align-item-start" id="sidebar">
      <div class="row pt-4 pb-5 px-3">
        <h5>Filtros</h5>
      </div>
       <form>
         <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label">Código</label>
            <input type="text" class="form-control form-control-sm">
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label">Nome</label>
            <input type="text" class="form-control form-control-sm">
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label">CPF</label>
            <input type="text" class="form-control form-control-sm">
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label">E-mail</label>
            <input type="text" class="form-control form-control-sm">
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label pb-4">Gênero</label><br>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox1">
              <label class="form-check-label">M</label>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox2">
              <label class="form-check-label">F</label>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox3">
              <label class="form-check-label">Outros</label>
            </div>
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label pb-4">Ranking</label>
            <br>
            <div class="row">
              <div class="col-md-12">
                <div class="range">
                <input v-model="filtroRanking" type="range" class="form-range" min="-1" max="10" id="customRange2" />
                <label v-if="filtroRanking >= 0" class="form-label">{{filtroRanking}}</label>
              </div>
            </div>
          </div>
          </div>
        </div>
        <div class="row px-3">
          <div class="col-12 filter-box">
            <label class="form-label pb-4">Status</label><br>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox4">
              <label class="form-check-label">Ativo</label>
            </div>
            <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox" id="inlineCheckbox5">
              <label class="form-check-label">Inativo</label>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-4">
          <button class="btn btn-filter">Filtrar</button>
          </div>
        </div>
      </form>
    </nav>
     <div style="margin-bottom: 50px"></div>
  </div>
</template>

<style scoped>
  .navbar {
    width: 100%;
    height: 100%;
    display: flex;
    flex-flow: column;
    align-items: right;
    color: white;
  }
  .filter-box {
    border: 1px solid rgba(204, 204, 8, 0.712);
    border-radius: 5px;
    padding: 10px;
    margin-bottom: 15px;
  }
  .btn-filter{
    background-color: transparent;
    color: rgba(204, 204, 8, 0.712);
    border: 1px solid rgba(204, 204, 8, 0.712);
    border-radius: 5px;
  }
  .btn-filter:hover{
    background-color: rgba(204, 204, 8, 0.712);
    color: rgba(10, 10, 10, 0.829);
  }
</style>