<script>
  import Headerbar from "./components/HeaderBar.vue";
  import Cliente from "./components/Cliente.vue";

export default {
  name: "App",
  components: {
    Headerbar,
    Cliente,
  },
};
</script>

<template>
  <div id="app">
    <Headerbar />
    <Cliente />
    <footer class="border-top fixed-bottom text-muted headerBar">
      <div class="container">
        <div class="row py-2">
          <div class="col-12 text-center">
            &copy; 2021 - Web Mechanic.
          </div>
        </div>
      </div>
    </footer>
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