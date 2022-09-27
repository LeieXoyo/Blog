<template>
  <div id="aplayer" style="position: fixed">
    <aplayer autoplay :music="{
          title: this.$store.state.preparedMusic.name,
          artist: this.$store.state.preparedMusic.author,
          src: this.$store.state.preparedMusic.fileUrl,
          pic: this.$store.state.preparedMusic.coverUrl
        }">
    </aplayer>
  </div>
</template>

<script>
  import Aplayer from 'vue-aplayer';
  import axios from 'axios';
  
  export default {
    name: "APlayer",
    components: {
      Aplayer
    },
    mounted () {
      axios
        .get("/api/Music")
        .then(res => {
          this.$store.commit('changeMusic', res.data[0])
        })
        .catch(function (err){
          console.log(err)
        });
    }
  }
</script>

<style>
#aplayer {
  bottom: 0;
  width: 280px;
}
</style>>
