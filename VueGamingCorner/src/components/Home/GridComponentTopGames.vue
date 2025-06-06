<template>
  <v-container>
    <v-row v-for="(row, rowIndex) in groupedGames" :key="rowIndex">
    <v-col
      v-for="(game, index) in row"
      :key="index"
      cols="12"
      :sm="12 / row.length"
      :md="12 / row.length"
    >
      <CardComponent :title="game.name" :discount="game.discount"
          :price="game.price" :productId="game.productId"  :src="game.principalImageURL as string"/>
    </v-col>
  </v-row>
  </v-container>
</template>

<script setup lang="ts">
import CardComponent from '@/components/CardComponent.vue'
import { useProductStore } from '@/stores/ProductStore';
import { computed } from 'vue';

const productStore = useProductStore();

const groupedGames = computed(() => {
  const grupos = [[0, 2], [2, 5], [5, 9], [9, 12]]; // índices por fila
  return grupos.map(([start, end]) => productStore.topVideogames.slice(start, end));
});

</script>

<style lang="scss" scoped></style>