<script setup>
import { ref, computed, onMounted } from 'vue';
import { useDisplay } from 'vuetify'
import { useProductStore } from '@/stores/ProductStore';

import CardComponent from '@/components/CardComponent.vue'

const productStore = useProductStore();

onMounted(() => {
  productStore.getAllVideogames();
  productStore.getAllConsoles();

});

const { mdAndUp } = useDisplay() //será true si la pantalla está en md, lg o xl


const showFilters = ref(false);
const showStores = ref(false);
const search = ref('');
const selectedCategory = ref(null);
const selectedPlatform = ref(null);

const categories = ['Acción', 'Aventura', 'RPG', 'Deportes', 'Carreras'];
const platforms = [ 'PC', 'Xbox', 'Nintendo', 'PlayStation'];
const stores = ['Steam', 'Epic Games', 'Ubisoft'];


const products = ref([
  { id: 1, name: 'The Last of Us', category: 'Aventura', platform: 'PlayStation', price: 49.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 2, name: 'Halo Infinite', category: 'Acción', platform: 'Xbox', price: 59.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 3, name: 'Zelda: Breath of the Wild', category: 'Aventura', platform: 'Nintendo', price: 39.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 1, name: 'The Last of Us', category: 'Aventura', platform: 'PlayStation', price: 49.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 2, name: 'Halo Infinite', category: 'Acción', platform: 'Xbox', price: 59.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 3, name: 'Zelda: Breath of the Wild', category: 'Aventura', platform: 'Nintendo', price: 39.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 1, name: 'The Last of Us', category: 'Aventura', platform: 'PlayStation', price: 49.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 2, name: 'Halo Infinite', category: 'Acción', platform: 'Xbox', price: 59.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
  { id: 3, name: 'Zelda: Breath of the Wild', category: 'Aventura', platform: 'Nintendo', price: 39.99, image: 'https://www.nintendo.com/eu/media/images/10_share_images/games_15/nintendo_switch_download_software_1/H2x1_NSwitchDS_Tetris99_image1600w.jpg' },
]);

const filteredProducts = computed(() => {
  return products.value.filter(product =>
    (!search.value || product.name.toLowerCase().includes(search.value.toLowerCase())) &&
    (!selectedCategory.value || product.category === selectedCategory.value) &&
    (!selectedPlatform.value || product.platform === selectedPlatform.value)
  );
});

const resetFilters = () => {
  search.value = '';
  selectedCategory.value = null;
  selectedPlatform.value = null;
};



function onClick() {
  alert('Buscando')
}
</script>

<template>
  <!-- Sidebar de Filtros -->
  <!--   <div class="filters" :class="{ 'filters--hidden': !showFilters }">
    <v-card class="pa-4">
      <v-card-title>Filtros</v-card-title>
      <v-divider></v-divider>

      <v-text-field v-model="search" label="Buscar..." prepend-inner-icon="mdi-magnify" clearable />
      <v-select v-model="selectedCategory" :items="categories" label="Categoría" clearable />
      <v-select v-model="selectedPlatform" :items="platforms" label="Plataforma" clearable />
      <v-btn block @click="resetFilters" color="error">Limpiar Filtros</v-btn>
    </v-card>
  </div> -->
  <!-- Contenedor Principal -->
  <v-container style="width: 80%;">

    <v-row justify="center" class="mb-10 mt-5">
      <v-btn-toggle rounded="xl">
        <v-btn v-for="(store, index) in platforms" :key="index" :size="mdAndUp ? 'large' : 'default'"
          :min-width="mdAndUp ? 150 : undefined" @click="showStores = true">
          {{ store }}
        </v-btn>
      </v-btn-toggle>
    </v-row>
    <v-expand-transition>  
      <v-row justify="center" class="mb-10 mt-5" v-if="showStores">
        <v-btn-toggle rounded="xl">
          <v-btn v-for="(store, index) in stores" :key="index" :size="mdAndUp ? 'large' : 'default'"
          :min-width="mdAndUp ? 150 : undefined">
          {{ store }}
        </v-btn>
      </v-btn-toggle>
    </v-row>
  </v-expand-transition>

    <!-- Fila de búsqueda y acciones -->
    <v-row align="center" justify="space-between" class="mb-4">
      <!-- Búsqueda -->
      <v-col cols="12" md="6">
        <v-text-field v-model="search" append-inner-icon="mdi-magnify" variant="solo" hide-details single-line
          placeholder="Buscar..." clearable @click:append-inner="onClick"></v-text-field>
      </v-col>

      <!-- Filtros y Ordenar -->
      <v-col cols="12" md="4" class="d-flex justify-end ">
        <v-btn variant="flat" @click="showFilters = !showFilters" class="mr-2">Filtros</v-btn>

        <v-menu offset-y transition="slide-y-transition" :close-on-content-click="false">
          <template #activator="{ props }">
            <v-btn variant="flat" v-bind="props" @click="toggleSort">Ordenar</v-btn>
          </template>

          <v-list>
            <v-list-item>
              <v-list-item-title>Precio más bajo</v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>Precio más alto</v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>Más rebaja</v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>Menos rebaja</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-col>
    </v-row>

    <v-expand-transition>
      <div v-if="showFilters">
        <v-row dense>
          <v-col cols="12" md="3">
            <v-select v-model="selectedPlatform" :items="platforms" label="Plataforma" clearable variant="solo" />
          </v-col>
          <v-col cols="12" md="3">
            <v-select v-model="selectedCondition" :items="['Nuevo', 'Segunda mano']" label="Estado" clearable
              variant="solo" />
          </v-col>
          <v-col cols="12" md="3">
            <v-select v-model="selectedBrand" :items="brands" label="Marca" clearable variant="solo" />
          </v-col>
          <v-col cols="12" md="3" class="d-flex justify-end ">
            <v-btn variant="flat" color="primary" @click="resetFilters">Restablecer filtros</v-btn>
          </v-col>
        </v-row>
      </div>
    </v-expand-transition>


    <!-- Grid de Videojuegos -->
    <v-row>
      <v-col v-for="product in productStore.products" :key="product.id" cols="6" xs="6" md="4">
        <CardComponent :title="product.name" :src="product.principalImageURL" :discount="product.discount" :price="product.price" :productId="product.productId" />
      </v-col>
    </v-row>
  </v-container>
</template>



<style scoped>
.filters--hidden {
  transform: translateY(100%);
}



.filter-btn {
  position: fixed;
  top: 16px;
  left: 16px;
  z-index: 11;
}

@media only screen and (min-width: 768px) {
  .filters {
    position: fixed;
    left: 0;
    bottom: 0;
    width: 100%;
    height: auto;
    background: white;
    box-shadow: 2px 0 5px rgba(0, 0, 0, 0.2);
    padding: 16px;
    z-index: 10;
    transition: transform 0.3s ease-in-out;
  }

}

.store-button {

  &:hover {
    background-color: transparent;
    border: 1px solid #1976D2;
  }
}
</style>