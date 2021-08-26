import Vue from 'vue';
import Router from 'vue-router';
import Index from './components/Index';
import Clientes from './components/NewCliente';

Vue.use(Router);

export default new Router({
  routes:[
    {
      path: '/',
      nome: 'Index',
      component: Index
    },
    {
      path: '/index',
      nome: 'Indexbranch',
      component: Index
    },
    {
      path: '/clientes',
      nome: 'Clientes',
      component: Clientes
    },
  ]
})