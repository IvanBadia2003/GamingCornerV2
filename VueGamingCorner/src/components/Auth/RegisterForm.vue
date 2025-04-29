<template>
    <v-form @submit.prevent="registrar" ref="formRef">
      <v-card-title class="text-center mb-6">
        <h2>Crear cuenta</h2>
      </v-card-title>
  
      <v-card-text>
        <v-text-field
          v-model="nombre"
          label="Nombre de usuario"
          :rules="[v => !!v || 'El nombre es obligatorio', v => v.length >= 3 || 'Debe tener al menos 3 caracteres']"
          required
        />
        <v-text-field
          v-model="email"
          label="Correo electrónico"
          :rules="[v => !!v || 'El email es obligatorio', v => /.+@.+\..+/.test(v) || 'Email inválido']"
          required
        />
        <v-text-field
          v-model="password"
          type="password"
          label="Contraseña"
          :rules="[v => !!v || 'La contraseña es obligatoria', v => v.length >= 6 || 'Mínimo 6 caracteres']"
          required
        />
        <v-text-field
          v-model="confirmPassword"
          type="password"
          label="Contraseña"
          :rules="[v => !!v || 'La confirmación de contraseña es obligatoria' || v === password || 'Las contraseñas no coinciden']"
          required
        />
  
        <v-btn
          :loading="auth.loading"
          :disabled="auth.loading"
          type="submit"
          color="primary"
          block
          class="mt-4"
        >
          Registrarse
        </v-btn>
  
        <p class="text-center mt-6">
          ¿Ya tienes cuenta?
          <v-btn variant="text" @click="$emit('switch')">Iniciar sesión</v-btn>
        </p>
  
        <v-alert
          v-if="auth.error"
          type="error"
          class="mt-4"
          border="start"
          variant="tonal"
        >
          {{ auth.error }}
        </v-alert>
      </v-card-text>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import { useAuthStore } from '@/stores/AuthStore'
  
  const auth = useAuthStore()
  
  const nombre = ref('')
  const email = ref('')
  const password = ref('')
  const confirmPassword = ref('')

  const formRef = ref()
  
  async function registrar() {

    const valid = await formRef.value?.validate()
    if (!valid) return
    await auth.register(nombre.value, email.value, password.value)
  }
  </script>
  