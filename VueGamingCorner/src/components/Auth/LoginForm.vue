<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/stores/UserStore'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')

const user = useUserStore()
const showPassword = ref(false)
</script>

<template>
  <v-form @submit.prevent="user.login(email, password)">
    <h2 class="mb-6">Iniciar sesión</h2>

    <v-text-field
  label="Correo electrónico"
  v-model="email"
  :disabled="user.loading"
  type="email"
  :rules="[v => !!v || 'El correo es obligatorio']"
  prepend-inner-icon="mdi-email"
  required
/>

    <v-text-field
  label="Contraseña"
  v-model="password"
  :type="showPassword ? 'text' : 'password'"
  :disabled="user.loading"
  :rules="[v => !!v || 'La contraseña es obligatoria']"
  prepend-inner-icon="mdi-lock" 
  :append-inner-icon="showPassword ? 'mdi-eye-off' : 'mdi-eye'"
  @click:append-inner="showPassword = !showPassword"
  required
/>



    <v-btn
      type="submit"
      color="surface"
      block
      class="mt-4"
      :loading="user.loading"
      :disabled="user.loading"
    >
      Entrar
    </v-btn>

    <v-alert
      v-if="user.error"
      type="error"
      class="mt-4"
      density="compact"
      border="start"
    >
      {{ user.error }}
    </v-alert>

    <h5 class="text-center mt-6">
      ¿No tienes cuenta?
      <v-btn variant="text" @click="$emit('switch')">Regístrate</v-btn>
    </h5>
  </v-form>
</template>
