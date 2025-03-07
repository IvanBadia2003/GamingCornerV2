  <script setup lang="ts">
  import PrincipalImage from '../Images/PrincipalImage.vue';


</script>
<template>
  <v-container style="height: auto; ">
    <v-carousel hide-delimiters style="height: auto; position: relative;">
      <!-- Botón Anterior -->
      <template v-slot:prev="{ props }">
        <v-btn variant="elevated" class="custom-prev" @click="props.onClick">
          ◀
        </v-btn>
      </template>

      <!-- Botón Siguiente -->
      <template v-slot:next="{ props }">
        <v-btn variant="elevated" class="custom-next" @click="props.onClick">
          ▶
        </v-btn>
      </template>
      <v-carousel-item v-for="(item, i) in 3" :key="i">
        <v-row no-gutters align="center">
          <v-col cols="12" sm="12" md="8" lg="8">
            <PrincipalImage />
          </v-col>

          <v-col cols="12" sm="12" md="4" lg="4" class="bg-surface d-flex flex-column align-center">
            <h3>GOD OF WAR</h3>
            <v-row class="secundaryImages">
              <v-col cols="6" xs="6" sm="6" md="6" lg="6">
                <PrincipalImage />
              </v-col>
              <v-col cols="6" xs="6" sm="6" md="6" lg="6">
                <PrincipalImage />
              </v-col>
            </v-row>
            <v-row class="mt-0">
              <v-chip-group>
                <v-col v-for="(item, i) in 3" :key="i"  :xs="12 / 3" :sm="12 / 3" :md="12 / 3" :lg="12 / 3" class="px-0">
                  <v-chip class="bg-primary">
                    Aventura
                  </v-chip>
                </v-col>
              </v-chip-group>
            </v-row>

          </v-col>
        </v-row>
      </v-carousel-item>
    </v-carousel>
  </v-container>





</template>


<style lang="scss" scoped>
.secundaryImages {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;

  @media screen and (max-width: 960px) {
    flex-direction: row;
    margin: 5px 0;
  }
}


.custom-prev {
  left: -40px;
}

.custom-next {
  right: -40px;
}

::v-deep(.v-btn) {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  z-index: 10;

  font-size: 20px;
  background-color: rgba(0, 0, 0, 0.7);
  height: 90px !important;

}
</style>