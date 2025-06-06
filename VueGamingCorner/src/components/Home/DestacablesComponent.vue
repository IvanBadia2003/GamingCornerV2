  <script setup lang="ts">
  import { useProductStore } from '@/stores/ProductStore';
import PrincipalImage from '../Images/PrincipalImage.vue';
import { onMounted } from 'vue';

  const productStore = useProductStore()

  onMounted(async () => {
    await productStore.GetTopRatedVideogames();

});


</script>
<template>
  <v-container style="height: auto;">
    <v-carousel
  v-if="productStore.bestVideogames.length > 0"
  hide-delimiters
  style="height: auto; position: relative;"
>      
      <!-- Botón Anterior -->
      <template v-slot:prev="{ props }">
        <v-btn variant="elevated" class="custom-prev" @click="props.onClick">
          ◀
        </v-btn>
      </template>

      <!-- Botón Siguiente -->
      <template v-slot:next="{ props }">
        <v-btn variant="elevated" class="custom-next" @click="props.onClick">
          ▶
        </v-btn>
      </template>

      <!-- Ítems del carrusel -->
      <v-carousel-item v-for="(item, i) in productStore.bestVideogames" :key="i">
        <v-row no-gutters align="center">
          
          <!-- Imagen principal -->
          <v-col cols="12" sm="12" md="8" lg="8">
            <PrincipalImage :src="item.productImages?.main || ''" />
          </v-col>

          <!-- Info y mini imágenes -->
          <v-col cols="12" sm="12" md="4" lg="4" class="bg-surface d-flex flex-column align-center">
            <h3>{{ item.name }}</h3>

            <!-- Imágenes secundarias -->
            <v-row class="secundaryImages">
              <v-col cols="6">
                <PrincipalImage :src="item.productImages?.content1 || ''" />
              </v-col>
              <v-col cols="6">
                <PrincipalImage :src="item.productImages?.content2 || ''" />
              </v-col>
            </v-row>

            <!-- Géneros (aún no llegan) -->
            <v-row class="mt-0">
              <v-chip-group>
                <v-col
                  v-if="item.genders && item.genders.length > 0"
                  v-for="(genre, i) in item.genders"
                  :key="i"
                  class="px-0"
                >
                  <v-chip class="bg-primary">{{ genre.name }}</v-chip>
                </v-col>
                <v-col v-else class="px-0">
                  <v-chip :to="'/description/' + item.productId" class="bg-primary">Ver más</v-chip>
                </v-col>
              </v-chip-group>
            </v-row>

          </v-col>
        </v-row>
      </v-carousel-item>
    </v-carousel>
  </v-container>
</template>

<style lang="scss" scoped>
.secundaryImages {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  @media screen and (max-width: 960px) {
    flex-direction: row;
    margin: 5px 0;
  }
}


.custom-prev {
  left: -40px;
}

.custom-next {
  right: -40px;
}

::v-deep(.v-btn) {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  z-index: 10;

  font-size: 20px;
  background-color: rgba(0, 0, 0, 0.7);
  height: 90px !important;

}
</style>