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
              @click="show_article(item.id)"
            >
              <v-card-title>{{ item.title }}</v-card-title>
              <v-card-subtitle>{{ item.author }}</v-card-subtitle>
              <v-card-text>{{ item.content }}</v-card-text>
            </v-card>
          </v-col>          
        </v-row>
      </v-col>
    </v-row>
    <v-btn
      bottom
      color="blue"
      dark
      fab
      fixed
      right
      @click="dialog = !dialog"
    >
      <v-icon>mdi-plus</v-icon>
    </v-btn>
    <v-dialog
      v-model="dialog"
      persistent
      max-width="600px"
    >
      <v-card class="form">
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="title" label="标题"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="author" label="作者"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-textarea
                  v-model="content"
                  auto-grow
                  filled
                  label="内容"
                  rows="4"
                ></v-textarea>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-divider></v-divider>
        <v-card-actions>
          <v-btn 
            text
            @click="close"
          >关闭</v-btn>
          <v-spacer></v-spacer>
          <v-btn
            color="blue"
            depressed
            @click="submit"
          >提交</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
  import axios from 'axios'

  export default {
    inject: ['reload'],
    data: () => ({
      items: null,
      dialog: false,

      id: null,
      title: null,
      author: null,
      content: null,
    }),
    mounted () {
      axios
        .get("http://127.0.0.1:5000/api/articles")
        .then(res => {
          this.items = res.data
        })
        .catch(function (err){
          console.log(err)
        });
    },
    methods: {
      show_article: function (id) {
        for (let item of this.items) {
          if (item.id === id) {
            this.id = item.id
            this.title = item.title
            this.author = item.author
            this.content = item.content
          }
        }
        this.dialog = true;
      },
      close: function () {
        this.dialog = false
        this.clear()
      },
      submit: function () {
        let data = {
          "title": this.title,
          "author": this.author,
          "content": this.content
        }
        if (this.id) {
          axios
            .put("http://127.0.0.1:5000/api/article/" + this.id, data)
            .then(res => {
              console.log(res.status)
              this.reload()
            })
            .catch(function (err){
              console.log(err)
            });
        } else {
          axios
            .post("http://127.0.0.1:5000/api/article", data)
            .then(res => {
              console.log(res.status)
              this.reload()
            })
            .catch(function (err){
              console.log(err)
            });
        }
        this.dialog = false
        this.clear()
      },
      clear: function () {
        this.id = null
        this.title = null
        this.author = null
        this.content = null
      }
    }
  }
</script>
