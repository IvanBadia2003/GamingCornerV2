<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from '@/components/HeaderComponent.vue'
</script>

<template>
  <HeaderComponent id="Header" />
  <div class="bg-background" id="App">
    <RouterView />
  </div>
</template>

<style lang="scss">
$HeaderHeight: 80px;

#App {
  min-height: calc(100vh - $HeaderHeight);
}

#Header {
  height: $HeaderHeight;
}

h2 {
  font: {
    family: "Bebas Neue", serif;
    weight: 400;
    size: clamp(24px, 7vw, 48px);
  }
}
h3 {
  font: {
    family: "Bebas Neue", serif;
    weight: 400;
    size: 4vw;
  }
}
</style>