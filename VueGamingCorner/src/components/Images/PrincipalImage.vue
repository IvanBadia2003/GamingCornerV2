<script setup lang="ts">
import { ref } from "vue";

const showModal = ref(false); // Estado del modal
</script>

<template>
  <!--       src="https://media.revistagq.com/photos/61bc91a5fbb7175cba582df3/16:9/w_2654,h_1493,c_limit/god-of-war-ragnarok-hero-banner-desktop-01-en-07sep21.jpeg"
 -->
    <v-img
      src="https://preview.redd.it/zero-dawn-remastered-pre-load-v0-z4vhl1l56lwd1.jpeg?auto=webp&s=061dd572a460a5883ca3d6c86e95d6a0fefdffae"
      cover
      height="100%"
      width="100%"
       @click="showModal = true"
       class="img"
    />

    <v-dialog v-model="showModal" max-width="70%">
        <v-img
            src="https://preview.redd.it/zero-dawn-remastered-pre-load-v0-z4vhl1l56lwd1.jpeg?auto=webp&s=061dd572a460a5883ca3d6c86e95d6a0fefdffae"
            cover
            max-height="90vh"
          />
    </v-dialog>
  </template>
  

<style lang="scss" scoped>
::v-deep(.v-img__img) {
  position: relative !important;
}
</style>