<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-row>
          <v-col
            v-for="item in items"
            :key="item.id"
            md="3"
            cols="6"
          >
            <v-card
              @click="show_image(item.id)"
            >
              <v-img
                :src="item.imgUrl"
              >
              </v-img>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-dialog
      v-model="dialog"
    >
      <v-card>
        <v-img
          :src="showedImage ? showedImage.imgUrl : ''"
        >
        </v-img>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
  import axios from 'axios'
  
  export default {
    data: () => ({
      items: null,
      dialog: false,
      showedImage: null,
    }),
    mounted () {
      axios
        .get("https://api.gen.li/Blog/Image")
        .then(res => {
          this.items = res.data
        })
        .catch(function (err){
          console.log(err)
        });
    },
    methods: {
      show_image: function (id) {
        for (let item of this.items) {
          if (item.id === id) {
            this.showedImage = item
          }
        }
        this.dialog = true;
      }
    }
  }
</script>
