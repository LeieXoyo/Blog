<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-row
          :align="alignment"
          :justify="justify"
        >
          <v-col
            v-for="item in items"
            :key="item.id"
            cols="3"
          >
            <v-card
              @click="show_game(item.id)"
            >
              <v-img
                class="align-end"
                :src="item.img_url"
              >
                <v-card-title>{{ item.name }}</v-card-title>
              </v-img>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-dialog
      fullscreen
      v-model="dialog"
    >
      <v-toolbar dark color="primary">
        <v-btn icon dark @click="dialog = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <v-toolbar-title>{{ showedGame ? showedGame.name : '' }}</v-toolbar-title>
        <v-spacer></v-spacer>
      </v-toolbar>
      <iframe
        height="100%"
        width="100%"
        :src="showedGame ? showedGame.html_url : ''"
      >
      </iframe>
    </v-dialog>
  </v-container>
</template>
<script>
  import axios from 'axios'
  export default {
    data: () => ({
      items: null,
      dialog: false,
      showedGame: null,
    }),
    mounted () {
      axios
        .get("http://127.0.0.1:5000/api/games")
        .then(res => {
          this.items = res.data
        })
        .catch(function (err){
          console.log(err)
        });
    },
    methods: {
      show_game: function (id) {
        for (let item of this.items) {
          if (item.id === id) {
            this.showedGame = item
          }
        }
        this.dialog = true;
      }
    }
  }
</script>
