<template>
  <v-container>
    <!-- Fila 1: 2 tarjetas -->
    <v-row>
      <v-col cols="12" md="6">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" md="6">
        <PrincipalImage />
      </v-col>
    </v-row>

    <!-- Fila 2: 3 tarjetas -->
    <v-row>
      <v-col cols="12" sm="6" md="4">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="4">
          <PrincipalImage />

      </v-col>
    </v-row>

    <!-- Fila 3: 4 tarjetas -->
    <v-row>
      <v-col cols="12" sm="6" md="3">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="3">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="3">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="3">
        <PrincipalImage />
      </v-col>
    </v-row>

    <!-- Fila 4: 3 tarjetas -->
    <v-row>
      <v-col cols="12" sm="6" md="4">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <PrincipalImage />
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <PrincipalImage />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import CardComponent from '@/components/CardComponent.vue'
import PrincipalImage from '../Images/PrincipalImage.vue';

</script>

<style lang="scss" scoped></style>