<script setup lang="ts">
import { RouterLink, RouterView, useRoute } from 'vue-router'
import FooterComponent from '@/components/Footer/FooterComponent.vue'
import HeaderComponent from '@/components/Header/HeaderComponent.vue'


const route = useRoute()

// Lista de rutas donde NO se quiere mostrar el footer
const hideFooterOnRoutes = ['/login','/admin']
const shouldHideFooter = hideFooterOnRoutes.some(prefix => route.path.startsWith(prefix));

// Lista de rutas donde NO se quiere mostrar el header
const hideHeaderOnRoutes = ['/login', '/register', '/admin']
</script>

<template >
<div id="App1">

  <HeaderComponent id="Header" />
  <div class="bg-background" id="App">
    <RouterView />
  </div>
  <FooterComponent v-if="!shouldHideFooter" class=""/>
</div>
</template>

<style lang="scss">
$HeaderHeight: 90px;
html, body {
  height: 100%;
  margin: 0;
}

#App1 {
  display: grid;
  min-height: 100vh; // Esto asegura que al menos ocupe toda la pantalla
  grid-template-rows: auto 1fr auto;
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
    family: "Montserrat", serif;
    weight: 400;
    size: clamp(10px, 1vw, 19px);
  }
}

p {
  font: {
    family: "Montserrat", serif;
    size: clamp(1rem, 1vw, 2rem);
  }
}
</style>