<script>
  export default {
    name: "HeaderBar",
  };
</script>

<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark headerBar">
      <div class="container-fluid">
        <a class="navbar-brand" herf="#">
          <img
            src="../assets/logo.png"
            width="80px"
            height="auto"
            class="logo"
          />
        </a>
        <b-button v-b-toggle.collapse-1 class="navbar-toggler">
          <span class="navbar-toggler-icon"></span>
        </b-button>
        <b-collapse class="collapse navbar-collapse" id="collapse-1">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item">
              <a class="nav-link" href="#">Produtos</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Clientes</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Vendas</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Estoque</a>
            </li>
          </ul>
          <ul class="nav navbar-nav navbar-right" style="margin-right: 10px">
            <li class="nav-item">
              <a class="nav-link" href="#">Usuários</a>
            </li>
          </ul>
        </b-collapse>
      </div>
    </nav>
  </div>
</template>


<style scoped>
  .headerBar {
    background-color: rgba(10, 10, 10, 0.699);
  }
  .headerItems {
    color: white;
  }
  .logo {
    border-radius: 4px;
  }
  .userLink {
    align-items: right;
  }
</style>