<script setup lang="ts">
import { ref, computed, onMounted } from 'vue';
import { useDisplay } from 'vuetify'
import { OrderDirectionEnum, useProductStore, type Filters } from '@/stores/ProductStore';

import CardComponent from '@/components/CardComponent.vue'
import { usePlatformStore } from '@/stores/PlatformStore';
import { useGenderStore } from '@/stores/GenderStore';

const productStore = useProductStore();
const platformStore = usePlatformStore();
const genderStore = useGenderStore();


const { mdAndUp } = useDisplay() //será true si la pantalla está en md, lg o xl


const showFilters = ref(false);
const showStores = ref(false);

const sortOptions = [
  { label: 'Precio más bajo', orderBy: 'price', direction: OrderDirectionEnum.ASC },
  { label: 'Precio más alto', orderBy: 'price', direction: OrderDirectionEnum.DESC },
  { label: 'Más rebaja', orderBy: 'discount', direction: OrderDirectionEnum.DESC },
  { label: 'Menos rebaja', orderBy: 'discount', direction: OrderDirectionEnum.ASC }
]

onMounted(() => {
  productStore.getProductsToCatalog(productStore.productType);
  productStore.getAllVideogames();
  productStore.getAllConsoles();
  platformStore.getAllPlatforms();
  genderStore.getAllGenders();
  console.log(productStore.videogames);
});

const onSystemChange = (newSystem: number | null) => {
   
  if (newSystem === null) return;

  showStores.value = true;
  resetFiltersToUse();
  filters.value.system = newSystem; // Opcional, ya lo hace el v-model
  platformStore.getPlatformBySystem(newSystem);
  applyFilters();
};

const filters = ref<Filters>({
  platform: null,
  genre: null,
  minPrice: null,
  maxPrice: null,
  search: '',
  system: null,
  orderBy: null,
  orderDirection: 1,
  brand: null
})

const resetFiltersToUse = () => {
  filters.value.system = null;
  filters.value.platform = null;
  filters.value.genre = null;
  filters.value.minPrice = null;
  filters.value.maxPrice = null;
  filters.value.search = '';
  filters.value.orderBy = null;
  filters.value.orderDirection = 1;

};

const resetFilters = () => {
  productStore.getProductsToCatalog(productStore.productType as string);
}

const applyFilters = () => {
  console.log(filters);
  if (productStore.productType === 'videogame') {
    productStore.getFilteredVideogames(filters.value);

  } else if (productStore.productType === 'console') {
    productStore.getFilteredConsoles(filters.value);

  }
};

</script>

<template>

  <!-- Contenedor Principal -->
  <v-container style="width: 60%;">

    <!-- SISTEMAS -->
    <v-row v-if="productStore.productType != 'secondHand'" justify="center" class="mb-10 mt-5">
      <v-btn-toggle rounded="xl" v-model="filters.system" class="store-button" @update:modelValue="onSystemChange">
        <v-btn v-for="(store, index) in platformStore.systemOptions" :key="index" :value="store.value"
          :size="mdAndUp ? 'large' : 'default'" :min-width="mdAndUp ? 150 : undefined">
          {{ store.label }}
        </v-btn>
      </v-btn-toggle>
    </v-row>

    <!-- PLATAFORMAS -->
    <v-expand-transition>
      <v-row justify="center" class="mb-10 mt-5" v-if="showStores">
        <v-btn-toggle v-model="filters.platform" rounded="xl">
          <v-btn v-for="(platform, index) in platformStore.platforms" :key="index" :value="platform.platformId"
            :size="mdAndUp ? 'large' : 'default'" :min-width="mdAndUp ? 150 : undefined" @click="applyFilters()">
            {{ platform.name }}
          </v-btn>
        </v-btn-toggle>
      </v-row>
    </v-expand-transition>
    <!-- Fila de búsqueda y acciones -->
    <v-row align="center" justify="space-between" class="mb-4">
      <!-- Búsqueda -->
      <v-col cols="12" md="6">
        <v-text-field v-model="filters.search" append-inner-icon="mdi-magnify" variant="solo" hide-details single-line
          placeholder="Buscar..." clearable @click:append-inner="applyFilters" />
      </v-col>

      <!-- Filtros y Ordenar -->
      <v-col cols="12" md="4" class="d-flex justify-end ">
        <v-btn variant="flat" @click="showFilters = !showFilters" class="mr-2">Filtros</v-btn>
        <v-menu offset-y transition="slide-y-transition" :close-on-content-click="true">
          <template #activator="{ props }">
            <v-btn variant="flat" v-bind="props">Ordenar</v-btn>
          </template>

          <v-list>
            <v-list-item v-for="(option, index) in sortOptions" :key="index" @click="
              filters.orderBy = option.orderBy;
            filters.orderDirection = option.direction;
            applyFilters();
            ">
              <v-list-item-title>{{ option.label }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-col>
    </v-row>

    <v-expand-transition>
      <div v-if="showFilters">
        <v-row dense>
          <v-col cols="12" md="3">
            <v-text-field   v-if="productStore.productType === 'console'" v-model="filters.brand" append-inner-icon="mdi-magnify" variant="solo" hide-details single-line
          placeholder="Marca" clearable @click:append-inner="applyFilters" />
            <v-select v-if="productStore.productType === 'videogame'" v-model="filters.genre" :items="genderStore.genders" label="Géneros" clearable variant="solo"
              item-title="name" item-value="genderId" @update:modelValue="applyFilters" />
          </v-col>
          <!-- Precio mínimo -->
          <v-col cols="3">
            <v-text-field v-model.number="filters.minPrice" label="Precio mínimo" type="number" clearable variant="solo"
              @update:modelValue="applyFilters" />
          </v-col>
          <!-- Precio máximo -->
          <v-col cols="3">
            <v-text-field v-model.number="filters.maxPrice" label="Precio máximo" type="number" clearable variant="solo"
              @update:modelValue="applyFilters" />
          </v-col>
          <v-col cols="12" md="3" class="d-flex justify-end ">
            <v-btn variant="flat" color="primary" @click="resetFilters">Restablecer filtros</v-btn>
          </v-col>
        </v-row>
      </div>
    </v-expand-transition>


    <!-- Grid de productos -->
    <v-row>
      <v-col v-for="product in productStore.products" :key="product.id" cols="6" xs="6" md="4">
        <CardComponent :title="product.name" :src="product.productImages?.main || ''" :discount="product.discount"
          :price="product.price" :productId="product.productId" />
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