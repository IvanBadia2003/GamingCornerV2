<template>

  <v-container style="width: 80%;">

    <h2>DESTACADOS Y RECOMENDADOS</h2>

    <DestacablesComponent />
  </v-container>

  <v-parallax
    src="https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png"
    height="500" width="100%" class="tilted-bottom">
  </v-parallax>


  <v-container style="width: 80%;">

    <h2>top ventas - JUEGOS</h2>
    <GridComponentTopGames />


    <h2>top ventas - CONSOLAS</h2>
    <GridComponentTopConsoles />

  </v-container>
  <v-row class="bg-primary pa-5">
    <v-col cols="12" sm="12" md="6" lg="6" class="d-flex flex-column align-center justify-center text-center">
      <v-row justify="center">
        <v-col cols="12" class="d-flex flex-column align-center justify-center text-center">
          <h2>Vender tus productos nunca fue tan fácil</h2>
        </v-col>
      </v-row>

      <v-row justify="center">
        <v-col cols="12">
          <v-btn variant="outlined" @click="startSelling()">
            EMPEZAR A VENDER
          </v-btn>
        </v-col>
      </v-row>
    </v-col>

    <v-col cols="12" sm="12" md="6" lg="6">
      <v-row>
        <v-col cols="12" sm="12" md="6" lg="6">
          <v-img cover max-height="225"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-MKPpxx3kF5I2cyZp4cq6z-P2IlnREy9FBQ&s" />

        </v-col>
        <v-col cols="12" sm="12" md="6" lg="6">
          <v-img cover max-height="225"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIiVlxac-YiB71fnMIoifPJ3cJxAjILGFyyw&s" />

        </v-col>
      </v-row>
      
    </v-col>
  </v-row>



</template>

<script setup lang="ts">
import DestacablesComponent from '@/components/Home/DestacablesComponent.vue';
import GridComponentTopConsoles from '@/components/Home/GridComponentTopConsoles.vue';
import GridComponentTopGames from '@/components/Home/GridComponentTopGames.vue';
import PrincipalImage from '@/components/Images/PrincipalImage.vue';
import router from '@/router';
import { useProductStore } from '@/stores/ProductStore';
import { useUserStore } from '@/stores/UserStore';
import { onMounted } from 'vue';

const productStore = useProductStore();
const userStore = useUserStore();

onMounted(async () => {
  productStore.TopSellingVideogames();
  productStore.TopSellingConsoles();
});

function startSelling(){
    router.push('/profile')
 
}

</script>


<style lang="scss" scoped>
.tilted-bottom {
  clip-path: polygon(0% 0%, 100% 0%, 100% 100%, 0% 90%);
  background-size: cover;
  /* Ajusta la imagen sin distorsionarla */
  background-position: center;
  /* Centra la imagen */
}
</style>
