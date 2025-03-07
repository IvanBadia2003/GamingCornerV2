<script setup lang="ts">
import PrincipalImage from './Images/PrincipalImage.vue';

defineProps({
  title: String,
  text: String,
  src: String
});
</script>
<template>
  <v-card tile style="height: 100%; width: 100%; display: flex; flex-direction: column; justify-content: space-between; position: relative;">
    <div class="discount bg-primary"><h5>50%</h5></div>
    <div style="height: 85%;">
      <v-img :src="src" cover height="100%" width="100%" />
    </div>
    <div style="display: flex; justify-content: space-between; align-items: center; height: 15%;" class="px-2">
      <h5>{{ title }}</h5>
      <h5>43€</h5>
    </div>
  </v-card>
</template>

<style lang="scss" scoped>

.discount{
  position: absolute;
  width: 20%;
  height: 15%;
  top: 0;
  right: 0;
  z-index: 10;
  display: flex;
  align-items: center;
  justify-content: center;
}

</style>