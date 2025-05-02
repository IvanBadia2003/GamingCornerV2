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
$HeaderHeight: 90px;

#App {
  min-height: calc(100vh - $HeaderHeight);
  //min-height: calc(100vh - $HeaderHeight);
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
    size: clamp(20px, 5vw, 40px);
  }
}

h4 {
  font: {
    family: "Bebas Neue", serif;
    weight: 400;
    size: clamp(15px, 2.5vw, 30px);
  }
}

h5 {
  font: {
    family: "Bebas Neue", serif;
    weight: 400;
    size: clamp(12px, 1.5vw, 24px);
  }
}

p {
  font: {
    family: "Montserrat", serif;
    size: clamp(1rem, 1vw, 2rem);
  }
}
</style>