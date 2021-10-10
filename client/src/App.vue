<template>
  <v-app id="app">
    <v-navigation-drawer
      v-model="drawer"
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
    >
      <v-list dense>
        <template v-for="item in items">
          <router-link :key="item.text" :to="item.path">
            <v-list-item link>
              <v-list-item-action>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-action>
              <v-list-item-content>
                <v-list-item-title>{{ item.text }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </router-link>
        </template>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="blue darken-3"
      dark
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title
        style="width: 300px"
        class="ml-0 pl-4"
      >
        <span>玈馥Blog</span>
      </v-toolbar-title>
      <v-text-field
        flat
        solo-inverted
        hide-details
        prepend-inner-icon="mdi-magnify"
        label="搜索"
        class="hidden-sm-and-down"
      ></v-text-field>
      <v-spacer></v-spacer>
      <v-btn
        icon
        href="https://files.gen.li/"
        target="_blank"
      ><v-icon>mdi-file-cabinet</v-icon>
      </v-btn>
      <v-btn
        icon
        href="https://mail.gen.li/"
        target="_blank"
      ><v-icon>mdi-email-variant</v-icon>
      </v-btn>
      <v-btn
        icon
        @click="info_dialog = true"
      ><v-icon>mdi-google-assistant</v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <router-view
        v-if="isRouterAlive"
        v-wechat-title='$route.meta.title'
      ></router-view>
      <aplayer></aplayer>
      <v-dialog
        v-model="info_dialog"
        persistent
        max-width="600px"
      >
        <v-card class="mx-auto">
          <v-list-item>
            <v-list-item-avatar>
              <img src="/static/images/avatar.jpg">
            </v-list-item-avatar>
            <v-list-item-content>
              <v-list-item-title class="headline">玈馥</v-list-item-title>
              <v-list-item-subtitle>LeieXoyo</v-list-item-subtitle>
            </v-list-item-content>
            <v-spacer></v-spacer>
            <v-btn
              icon
              color="red"
              @click="info_dialog = false"
            ><v-icon>mdi-close-circle</v-icon>
            </v-btn>
          </v-list-item>

          <v-img
            src="/static/images/info_dialog.jpg"
          ></v-img>

          <v-card-text>
            <!-- <p>没想好写啥在这里</p> -->
          </v-card-text>

          <v-card-actions>
            <v-btn
              icon
              href="mailto:gen@gen.li"
            ><v-icon>mdi-email</v-icon>
            </v-btn>
            <v-spacer></v-spacer>
            <v-btn
              icon
              href="https://github.com/LeieXoyo/Blog"
            ><v-icon>mdi-github</v-icon>
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-main>
  </v-app>
</template>

<script>
  import aplayer from './components/APlayer'

  export default {
    provide () {
      return {
        reload: this.reload
      }
    },
    props: {
      source: String,
    },
    data: () => ({
      drawer: null,
      items: [
        { path: '/music', icon: 'mdi-music', text: '商羽' },
        { path: '/game', icon: 'mdi-gamepad', text: '星弈' },
        { path: '/article', icon: 'mdi-book', text: '书墨' },
        { path: '/image', icon: 'mdi-image', text: '丹青' },
      ],
      info_dialog: false,
      isRouterAlive: true
    }),
    components: {
      'aplayer': aplayer
    },
    methods: {
      reload() {
        this.isRouterAlive = false
        this.$nextTick(function(){
          this.isRouterAlive = true
        })
      }
    }
  }
</script>

<style>
a {
  text-decoration: none;
}
</style>>
