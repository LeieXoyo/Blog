import Vue from 'vue'
import VueRouter from 'vue-router'
import Vuex from 'vuex'
import VueWechatTitle from 'vue-wechat-title'
import App from './App.vue'
import vuetify from './plugins/vuetify'

import PageHome from './components/HelloWorld'
import PageArticle from './components/PageArticle'
import PageGame from './components/PageGame'
import PageImage from './components/PageImage'
import PageMusic from './components/PageMusic'

Vue.config.productionTip = false

Vue.use(VueRouter)
Vue.use(Vuex)
Vue.use(VueWechatTitle)

const store = new Vuex.Store({
  state: {
    preparedMusic: {
      name: null,
      author: null,
      file_url: null,
      cover_url: null,
    },
  },
  mutations: {
    changeMusic (state, music) {
      state.preparedMusic = music
    }
  }
})

const routes = [
  { path: '/', component: PageHome, meta: {title: '主页'} },
  { path: '/article', component: PageArticle, meta: {title: '书墨'} },
  { path: '/game', component: PageGame, meta: {title: '星弈'} },
  { path: '/image', component: PageImage, meta: {title: '丹青'} },
  { path: '/music', component: PageMusic, meta: {title: '商羽'} }
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

new Vue({
  vuetify,
  render: h => h(App),
  router: router,
  store: store
}).$mount('#app')
