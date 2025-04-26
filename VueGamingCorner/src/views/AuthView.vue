<template>
  <v-container class="auth-container">
    <v-row>
      <v-col cols="12" md="6" :class="imageDisplay">
        <v-img src="@/../src/assets/Auth/loginIMG.png" max-width="100%" aspect-ratio="1.5" />
      </v-col>

      <v-col cols="12" md="6" class="d-flex justify-center align-center">
        <div :class="['auth-card', isRegister ? 'flipped' : '']">
          <!-- Lado login -->
          <div class="auth-side front bg-primary">
            <LoginForm @switch="isRegister = true" />
          </div>
          <!-- Lado registro -->
          <div class="auth-side back bg-primary">
            <RegisterForm @switch="isRegister = false" />
          </div>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue'
import LoginForm from '@/components/Auth/LoginForm.vue'
import RegisterForm from '@/components/Auth/RegisterForm.vue'
import { useDisplay } from 'vuetify'
const { xs, sm, md, lg } = useDisplay()

const imageDisplay = computed(() => {
    if (xs.value) return 'd-none'
    if (sm.value) return 'd-none'
    if (md.value) return 'd-flex'
    if (lg.value) return 'd-flex'
    return 'd-flex'
})
const isRegister = ref(false)
</script>

<style scoped lang="scss">
.auth-container {
  perspective: 1000px;
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 80vh;
}

.auth-card {
  width: 400px;
  height: 600px;
  position: relative;
  transform-style: preserve-3d;
  transition: transform 0.8s;
}

.auth-card.flipped {
  transform: rotateY(180deg);
}

.auth-side {
  position: absolute;
  width: 100%;
  height: 100%;
  backface-visibility: hidden;
  background-color: white;
  border-radius: 16px;
  padding: 32px;
  box-shadow: 0 20px 30px rgba(0, 0, 0, 0.3);
}

.front {
  z-index: 2;
}

.back {
  transform: rotateY(180deg);
}
</style>