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
          <v-btn variant="outlined">
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
      <v-row>
        <v-col cols="12" sm="12" md="6" lg="6">
          <v-img cover max-height="225"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_ICxKj5kX7sTFIlxJ6Nq_B7Xz0LdDqIYUYw&s" />

        </v-col>
        <v-col cols="12" sm="12" md="6" lg="6">
          <v-img cover max-height="225"
            src="data:image/jpeg;base64,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" />

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
