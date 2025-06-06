<template>
    <v-row dense>
      <v-col cols="12">
        <v-list>
          <v-list-item v-for="(direccion, index) in direcciones" :key="index">
            <v-list-item-title>{{ direccion }}</v-list-item-title>
            <v-btn icon @click="eliminar(index)" color="error" class="ml-2">
              <v-icon>mdi-delete</v-icon>
            </v-btn>
          </v-list-item>
        </v-list>
      </v-col>
  
      <v-col cols="12" md="8">
        <v-text-field label="Nueva dirección" v-model="nuevaDireccion" />
      </v-col>
      <v-col cols="12" md="4">
        <v-btn color="primary" @click="agregar">Añadir</v-btn>
      </v-col>
    </v-row>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const direcciones = ref<string[]>([])
  const nuevaDireccion = ref('')
  
  function agregar() {
    if (nuevaDireccion.value.trim()) {
      direcciones.value.push(nuevaDireccion.value)
      nuevaDireccion.value = ''
    }
  }
  
  function eliminar(index: number) {
    direcciones.value.splice(index, 1)
  }
  </script>
  