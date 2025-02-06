<template>
<v-container style="width: 80%;">
  <h2>DESTACADOS Y RECOMENDADOS</h2>
  <DestacablesComponent />
 

  <GridComponent />
</v-container>

</template>

<script setup lang="ts">
import DestacablesComponent from '@/components/Home/DestacablesComponent.vue';
import GridComponent from '@/components/Home/GridComponent.vue';
import PrincipalImage from '@/components/Images/PrincipalImage.vue';

</script>


<style lang="scss" scoped></style>
