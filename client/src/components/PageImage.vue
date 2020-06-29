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
              @click="show_image(item.id)"
            >
              <v-img
                :src="item.src"
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
            :src="showedImage"
          >
          </v-img>
        </v-card>
    </v-dialog>
  </v-container>
</template>
<script>
  export default {
    data: () => ({
      items: [
        {id: 1, src: require('../assets/images/1.jpg')},
        {id: 2, src: require('../assets/images/2.jpg')},
        {id: 3, src: require('../assets/images/3.jpg')},
        {id: 4, src: require('../assets/images/4.jpg')},
        {id: 5, src: require('../assets/images/5.jpg')}
      ],
      dialog: false,
      showedImage: null,
    }),
    methods: {
      show_image: function (id) {
        for (let item of this.items) {
          if (item.id === id) {
            this.showedImage = item.src
          }
        }
        this.dialog = true;
      }
    }
  }
</script>
