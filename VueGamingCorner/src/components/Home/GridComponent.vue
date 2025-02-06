<template>
<v-container>
      <!-- Fila 1: 2 tarjetas -->
      <v-row>
        <v-col cols="12" md="6">
          <CardComponent title="Tarjeta 1" text="Contenido de la tarjeta 1" />
        </v-col>
        <v-col cols="12" md="6">
          <CardComponent title="Tarjeta 2" text="Contenido de la tarjeta 2" />
        </v-col>
      </v-row>
  
      <!-- Fila 2: 3 tarjetas -->
      <v-row>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 3" text="Contenido de la tarjeta 3" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 4" text="Contenido de la tarjeta 4" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 5" text="Contenido de la tarjeta 5" />
        </v-col>
      </v-row>
  
      <!-- Fila 3: 4 tarjetas -->
      <v-row>
        <v-col cols="12" sm="6" md="3">
          <CardComponent title="Tarjeta 6" text="Contenido de la tarjeta 6" />
        </v-col>
        <v-col cols="12" sm="6" md="3">
          <CardComponent title="Tarjeta 7" text="Contenido de la tarjeta 7" />
        </v-col>
        <v-col cols="12" sm="6" md="3">
          <CardComponent title="Tarjeta 8" text="Contenido de la tarjeta 8" />
        </v-col>
        <v-col cols="12" sm="6" md="3">
          <CardComponent title="Tarjeta 9" text="Contenido de la tarjeta 9" />
        </v-col>
      </v-row>
  
      <!-- Fila 4: 3 tarjetas -->
      <v-row>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 10" text="Contenido de la tarjeta 10" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 11" text="Contenido de la tarjeta 11" />
        </v-col>
        <v-col cols="12" sm="6" md="4">
          <CardComponent title="Tarjeta 12" text="Contenido de la tarjeta 12" />
        </v-col>
      </v-row>
    </v-container>
</template>

<script setup lang="ts">
import CardComponent from '@/components/CardComponent.vue'

</script>

<style lang="scss" scoped>
</style>