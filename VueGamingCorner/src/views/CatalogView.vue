<script setup>
import { ref, computed } from 'vue';
import CardComponent from '@/components/CardComponent.vue'


const showFilters = ref(false);
const search = ref('');
const selectedCategory = ref(null);
const selectedPlatform = ref(null);

const categories = ['Acción', 'Aventura', 'RPG', 'Deportes', 'Carreras'];
const platforms = ['PlayStation', 'Xbox', 'Nintendo', 'PC'];

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
    <v-row>
      <!-- Botón para mostrar filtros -->
      <v-col cols="1">
        <v-btn @click="showFilters = !showFilters" color="primary">
           Filtros
        </v-btn>
      </v-col>
      <v-col cols="9">
        <v-text-field v-model="search" label="Buscar..." prepend-inner-icon="mdi-magnify" clearable />
      </v-col>
      <v-col cols="2">
        <v-select v-model="selectedCategory" :items="categories" label="Categoría" clearable />
      </v-col>

    </v-row>
    <v-row v-if="showFilters">
      <v-col cols="4">
        <v-select v-model="selectedCategory" :items="categories" label="Categoría" clearable />
      </v-col>
      <v-col cols="4">
        <v-select v-model="selectedPlatform" :items="platforms" label="Plataforma" clearable />
      </v-col>
      <v-btn block @click="resetFilters" color="error">Limpiar Filtros</v-btn>
    </v-row>


    <!-- Grid de Productos -->
    <v-row>
      <v-col v-for="product in filteredProducts" :key="product.id" cols="6" xs="6" md="4">
        <CardComponent title="Resident Evil" :src="product.image" />
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
</style>