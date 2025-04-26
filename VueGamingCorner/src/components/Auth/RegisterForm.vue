<template>
    <v-form @submit.prevent="registrar">
      <h2 class="mb-6">Crear cuenta</h2>
  
      <v-text-field label="Nombre de usuario" v-model="nombre" />
      <v-text-field label="Correo electrónico" v-model="email" />
      <v-text-field label="Contraseña" type="password" v-model="password" />
  
      <v-btn type="submit" color="primary" block class="mt-4">Registrarse</v-btn>
  
      <p class="text-center mt-6">
        ¿Ya tienes cuenta?
        <v-btn variant="text" @click="$emit('switch')">Iniciar sesión</v-btn>
      </p>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const nombre = ref('')
  const email = ref('')
  const password = ref('')
  
  function registrar() {
    console.log('Registrando a:', nombre.value, email.value)
    // Aquí va tu llamada a la API
  }
  </script>
  