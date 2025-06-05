<script setup>
const icons = [
  'mdi-facebook',
  'mdi-twitter',
  'mdi-linkedin',
  'mdi-instagram',
]


</script>

<template>
  <v-footer class="text-center d-flex flex-column ga-2 py-4 bg-background">
    <div class="d-flex ga-3">
      <v-btn v-for="icon in icons" :key="icon" :icon="icon" density="comfortable" variant="text"></v-btn>
    </div>

    <v-divider class="my-2" thickness="2" width="50"></v-divider>

    <div class="text-caption font-weight-regular opacity-60 px-6">
      Gaming Corner es una tienda online especializada en videojuegos, consolas y productos gaming de segunda mano.
      Nuestro objetivo es ofrecer a los jugadores de todas las plataformas —PlayStation, Xbox, Nintendo y PC— un espacio
      donde puedan descubrir, comprar y vender artículos de forma segura y confiable. Cada producto es verificado y
      gestionado con cuidado para asegurar su calidad. <br /><br />
      Además, trabajamos constantemente para mantener precios competitivos, ampliar nuestro catálogo y brindar una
      atención al cliente cercana y resolutiva. Ya seas un coleccionista, un jugador casual o un fan de los títulos
      retro, aquí encontrarás lo que necesitas. <br /><br />
      Gracias por confiar en nosotros. Sigue conectado a Gaming Corner para descubrir ofertas exclusivas, nuevos
      lanzamientos y contenido pensado para la comunidad gamer. ¡Jugar nunca fue tan fácil!
    </div>

    <v-divider class="my-2" />


    <div>
      {{ new Date().getFullYear() }} — <strong>Gaming Corner</strong>
    </div>
  </v-footer>
</template>


<style scoped lang="scss"></style>