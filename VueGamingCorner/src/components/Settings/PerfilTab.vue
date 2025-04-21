<template>
    <v-form @submit.prevent="guardar">
      <v-row dense>
        <v-col cols="12" md="6">
          <v-text-field label="Nombre de usuario" v-model="nombre" />
        </v-col>
  
        <v-col cols="12" md="6">
          <v-text-field label="Correo electrónico" v-model="email" type="email" />
        </v-col>
  
        <v-col cols="12" md="6">
          <v-text-field label="Nueva contraseña" type="password" v-model="password" />
        </v-col>
  
        <v-col cols="12" md="6">
          <v-select
            label="Idioma preferido"
            :items="['Español', 'Inglés']"
            v-model="idioma"
          />
        </v-col>
  
        <v-col cols="12">
          <v-btn color="primary" type="submit">Guardar</v-btn>
        </v-col>
      </v-row>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const nombre = ref('')
  const email = ref('')
  const password = ref('')
  const idioma = ref('Español')
  
  function guardar() {
    console.log('Datos guardados:', nombre.value, email.value, idioma.value)
    // Aquí haces la llamada a la API
  }
  </script>
  