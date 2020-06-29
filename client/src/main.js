import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import vuetify from './plugins/vuetify'

import PageHome from './components/HelloWorld'
import PageArticle from './components/PageArticle'
import PageGame from './components/PageGame'
import PageImage from './components/PageImage'
import PageMusic from './components/PageMusic'

Vue.config.productionTip = false

Vue.use(VueRouter)

const routes = [
  { path: '/', component: PageHome},
  { path: '/article', component: PageArticle},
  { path: '/game', component: PageGame},
  { path: '/image', component: PageImage},
  { path: '/music', component: PageMusic}
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

new Vue({
  vuetify,
  render: h => h(App),
  router
}).$mount('#app')
