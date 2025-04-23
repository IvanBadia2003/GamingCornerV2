<template>
    <v-row dense>
      <v-col cols="12" v-if="tarjetas.length === 0">
        <p>No tienes tarjetas guardadas.</p>
      </v-col>
  
      <v-col v-for="(t, index) in tarjetas" :key="index" cols="12" md="6">
        <v-card>
          <v-card-title>{{ t }}</v-card-title>
          <v-card-actions>
            <v-btn color="error" @click="eliminar(index)">Eliminar</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
  
      <v-col cols="12" md="8">
        <v-text-field label="Nueva tarjeta (mock)" v-model="nuevaTarjeta" />
      </v-col>
      <v-col cols="12" md="4">
        <v-btn color="primary" @click="agregar">Añadir</v-btn>
      </v-col>
    </v-row>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const tarjetas = ref<string[]>([])
  const nuevaTarjeta = ref('')
  
  function agregar() {
    if (nuevaTarjeta.value.trim()) {
      tarjetas.value.push(nuevaTarjeta.value)
      nuevaTarjeta.value = ''
    }
  }
  
  function eliminar(index: number) {
    tarjetas.value.splice(index, 1)
  }
  </script>
  