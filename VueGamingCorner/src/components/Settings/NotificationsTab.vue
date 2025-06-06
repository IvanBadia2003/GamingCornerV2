<template>
    <v-row dense>
      <v-col cols="12" md="6">
        <v-switch
          label="Recibir notificaciones de pedidos"
          v-model="pedidos"
        />
      </v-col>
      <v-col cols="12" md="6">
        <v-switch
          label="Ofertas y promociones"
          v-model="promociones"
        />
      </v-col>
      <v-col cols="12">
        <v-btn color="primary" @click="guardar">Guardar preferencias</v-btn>
      </v-col>
    </v-row>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const pedidos = ref(true)
  const promociones = ref(false)
  
  function guardar() {
    console.log('Preferencias guardadas:', pedidos.value, promociones.value)
  }
  </script>
  