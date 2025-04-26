<template>
    <v-form @submit.prevent="login">
      <h2 class="mb-6">Iniciar sesión</h2>
  
      <v-text-field label="Correo electrónico" v-model="email" />
      <v-text-field label="Contraseña" type="password" v-model="password" />
  
      <v-btn type="submit" color="primary" block class="mt-4">Entrar</v-btn>
  
      <p class="text-center mt-6">
        ¿No tienes cuenta?
        <v-btn variant="text" @click="$emit('switch')">Regístrate</v-btn>
      </p>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  
  const email = ref('')
  const password = ref('')
  
  function login() {
    console.log('Iniciar sesión con:', email.value, password.value)
    // Aquí va tu llamada a la API
  }
  </script>
  