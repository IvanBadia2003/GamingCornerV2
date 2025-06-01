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
          :loading="user.loading"
          :disabled="user.loading"
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
          v-if="user.error"
          type="error"
          class="mt-4"
          border="start"
          variant="tonal"
        >
          {{ user.error }}
        </v-alert>
      </v-card-text>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import { useUserStore } from '@/stores/UserStore'
  
  const user = useUserStore()
  
  const nombre = ref('')
  const email = ref('')
  const password = ref('')
  const confirmPassword = ref('')

  const formRef = ref()
  
  async function registrar() {

    const valid = await formRef.value?.validate()
    if (!valid) return
    await user.register(nombre.value, email.value, password.value)
  }
  </script>
  