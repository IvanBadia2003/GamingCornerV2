<template>

<v-container  style="height: auto;">
  <v-row no-gutters  align="center">
    <v-col cols="12" sm="12" md="8" lg="8"  >
      <PrincipalImage />
    </v-col>

    <v-col cols="12" sm="12" md="4" lg="4" class="bg-surface"
      >
      <v-row class="d">
      <h3>GOD OF WAR</h3>
            <v-col cols="6" sm="6" md="6" lg="6" >
                <SecondaryImage/>
            </v-col>
            <v-col cols="6" sm="6" md="6" lg="6" >
                <SecondaryImage/>
            </v-col>
        </v-row>    

    </v-col>
  </v-row>
</v-container>




</template>

<script setup lang="ts">
import PrincipalImage from '../Images/PrincipalImage.vue';
import SecondaryImage from '../Images/SecondaryImage.vue';


</script>

<style lang="scss" scoped>
.d{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

</style>