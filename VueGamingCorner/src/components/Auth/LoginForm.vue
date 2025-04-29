<script setup lang="ts">
import { ref } from 'vue'
import { useAuthStore } from '@/stores/AuthStore'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')

const auth = useAuthStore()
const showPassword = ref(false)
</script>

<template>
  <v-form @submit.prevent="auth.login(email, password)">
    <h2 class="mb-6">Iniciar sesión</h2>

    <v-text-field
      label="Correo electrónico"
      v-model="email"
      :disabled="auth.loading"
      type="email"
      :rules="[v => !!v || 'El correo es obligatorio']"
      required
    />
    <v-text-field
      label="Contraseña"
      v-model="password"
      :type="showPassword ? 'text' : 'password'"
      :disabled="auth.loading"
      :rules="[v => !!v || 'La contraseña es obligatoria']"
      :append-icon="showPassword ? 'mdi-eye-off' : 'mdi-eye'"
      @click:append="showPassword = !showPassword"

      required
    />


    <v-btn
      type="submit"
      color="primary"
      block
      class="mt-4"
      :loading="auth.loading"
      :disabled="auth.loading"
    >
      Entrar
    </v-btn>

    <v-alert
      v-if="auth.error"
      type="error"
      class="mt-4"
      density="compact"
      border="start"
    >
      {{ auth.error }}
    </v-alert>

    <p class="text-center mt-6">
      ¿No tienes cuenta?
      <v-btn variant="text" @click="$emit('switch')">Regístrate</v-btn>
    </p>
  </v-form>
</template>
