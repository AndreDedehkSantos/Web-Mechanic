<script>
  export default {
    name: "HeaderBar",
  };
</script>

<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark headerBar">
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/Index">
          <img src="../assets/logo.png" width="80px" height="auto" class="logo"/>
        </router-link>
        <b-button v-b-toggle.collapse-1 class="navbar-toggler">
          <span class="navbar-toggler-icon"></span>
        </b-button>
        <b-collapse class="collapse navbar-collapse" id="collapse-1">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="#">Produtos</a>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/Clientes">Clientes</router-link>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Vendas</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Estoque</a>
            </li>
          </ul>
          <ul class="navbar-nav ms-auto">
            <li class="nav-item">
              <a class="nav-link nav-link" href="#">usuario@webmechanic</a>
            </li>
          </ul>
        </b-collapse>
      </div>
    </nav>
  </div>
</template>


<style scoped>
  .headerBar {
    border: 1px solid rgba(10, 10, 10, 0.829);
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