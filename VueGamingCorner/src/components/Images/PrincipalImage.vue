<script setup lang="ts">
import { ref } from "vue";

const showModal = ref(false); // Estado del modal

const props = defineProps<{
  src: string
}>()


</script>

<template>
  <!--       src="https://media.revistagq.com/photos/61bc91a5fbb7175cba582df3/16:9/w_2654,h_1493,c_limit/god-of-war-ragnarok-hero-banner-desktop-01-en-07sep21.jpeg"
 -->
    <v-img
    :src="src"
    cover
      height="100%"
      width="100%"
       @click="showModal = true"
       class="img"
    />

    <v-dialog v-model="showModal" max-width="70%">
        <v-img
            :src="src"
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