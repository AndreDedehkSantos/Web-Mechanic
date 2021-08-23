<script>
  import Headerbar from "./components/HeaderBar";
  import Cliente from "./components/NewCliente";
  import FooterBar from "./components/FooterBar";

export default {
  name: "App",
  components: {
    Headerbar,
    Cliente,
    FooterBar
  },
};
</script>

<template>
  <div id="app">
    <Headerbar />
    <Cliente />
    <FooterBar />
  </div>
</template>


<style>
  #app {
    height: 100%;
    min-height: 788px;
    margin: 0 auto;
    background-color: rgba(145, 145, 145, 0.411);
  }
   .headerBar {
    background-color: rgba(10, 10, 10, 0.699);
  }
</style>