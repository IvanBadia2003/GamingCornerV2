<template>
    <v-row dense>
      <v-col cols="12" md="6">
        <v-switch
          label="Autenticación en dos pasos (2FA)"
          v-model="twoFactor"
        />
      </v-col>
      <v-col cols="12" md="6">
        <v-btn color="error" @click="cerrarSesion">Cerrar todas las sesiones</v-btn>
      </v-col>
    </v-row>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const twoFactor = ref(false)
  
  function cerrarSesion() {
    console.log('Sesiones cerradas')
  }
  </script>
  