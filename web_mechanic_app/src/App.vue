<script>
  import Headerbar from './components/HeaderBar.vue'

  export default {
  name: 'App',
  components: {
    Headerbar
  }
}
</script>

<template>
  <div id="app">
    <Headerbar/>
  </div>
</template>


<style>
  .app-bg{
    background-color: rgba(145, 145, 145, 0.411);
  }
</style>
