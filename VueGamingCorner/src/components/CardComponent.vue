<script setup lang="ts">
import { id } from 'vuetify/locale';
import PrincipalImage from './Images/PrincipalImage.vue';
import { useProductStore } from '@/stores/ProductStore';

defineProps<{
  title: string
  src: string
  discount: number
  price: number
  productId: number
}>()

const productStore = useProductStore(); 

</script>
<template>
  <v-card tile elevation="0" class="bg-transparent" :to="'/description/' + productId" @click="productStore.getProductById(productId)"
    style="height: 100%; width: 100%; display: flex; flex-direction: column; justify-content: space-between; position: relative; overflow: visible;">
    <div class="discount bg-primary">
      <h5>-{{ discount }}%</h5>
    </div>
    <div style="height: 85%;">
      <v-img :src="src" cover height="100%" width="100%" />
    </div>
    <div style="display: flex; justify-content: space-between; align-items: center; height: 15%;" class="px-2">
      <p>{{ title }}</p>
      <p>{{ (price - (price * discount / 100)).toFixed(2) }}€</p>
    </div>
  </v-card>


</template>

<style lang="scss" scoped>
.discount {
  position: absolute;
  min-width: 60px;
  min-height: 35px;
  width: 10%;
  height: 10%;
  right: -10px;
  top: -10px;
  z-index: 10;
  border-radius: 10px;
  border: rgb(46, 46, 46) 2px solid;

  display: flex;
  align-items: center;
  justify-content: center;


}
</style>