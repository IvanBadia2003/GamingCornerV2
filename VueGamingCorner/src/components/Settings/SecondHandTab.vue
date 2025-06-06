<template>
    <v-row dense>
      <v-col cols="12" v-if="productos.length === 0">
        <p>No tienes productos en venta.</p>
      </v-col>
  
      <v-col
        v-for="(p, index) in productos"
        :key="index"
        cols="12"
        md="6"
      >
        <v-card>
          <v-card-title>{{ p.nombre }}</v-card-title>
          <v-card-subtitle>{{ p.precio }} €</v-card-subtitle>
          <v-card-actions>
            <v-btn color="primary" @click="editar(index)">Editar</v-btn>
            <v-btn color="error" @click="eliminar(index)">Eliminar</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  interface Producto {
    nombre: string
    precio: number
  }
  
  const productos = ref<Producto[]>([
    { nombre: 'The Last of Us - PS5', precio: 35 },
    { nombre: 'Nintendo Switch Lite', precio: 150 },
  ])
  
  function editar(index: number) {
    console.log('Editar producto:', productos.value[index])
  }
  
  function eliminar(index: number) {
    productos.value.splice(index, 1)
  }
  </script>
  