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
              @click="play_music(item)"
            >
              <v-img
                class="align-end"
                :src="item.cover_url"
              >
                <v-card-title>{{ item.name }}</v-card-title>
                <v-card-subtitle>{{ item.author }}</v-card-subtitle>
              </v-img>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import axios from 'axios'
  export default {
    data: () => ({
      items: null,
    }),
    mounted () {
      axios
        .get("http://127.0.0.1:5000/api/musics")
        .then(res => {
          this.items = res.data
        })
        .catch(function (err){
          console.log(err)
        });
    },
    methods: {
      play_music: function(music) {
        this.$store.commit('changeMusic', music)
        document.getElementsByTagName('audio')[0].play()
      }
    }
  }
</script>
