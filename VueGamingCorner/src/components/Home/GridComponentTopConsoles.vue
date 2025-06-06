<template>
  <v-container>

    <!-- Fila 2: 3 tarjetas -->
    <v-row>
    <v-col
      v-for="(console, index) in productStore.topConsoles"
      :key="index"
      cols="4"
    >
      <CardComponent :title="console.name" :discount="console.discount"
          :price="console.price" :productId="console.productId"  :src="console.productImages.main || ''"/>
    </v-col>
  </v-row>
  </v-container>
</template>

<script setup lang="ts">
import CardComponent from '@/components/CardComponent.vue'
import { useProductStore } from '@/stores/ProductStore';

const productStore = useProductStore();
</script>

<style lang="scss" scoped></style>