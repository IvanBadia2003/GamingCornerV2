<template>
    <v-container class="auth-container">
      <div :class="['auth-card', isRegister ? 'flipped' : '']">
        <!-- Lado login -->
        <div class="auth-side front">
          <LoginForm @switch="isRegister = true" />
        </div>
        <!-- Lado registro -->
        <div class="auth-side back">
          <RegisterForm @switch="isRegister = false" />
        </div>
      </div>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import LoginForm from '@/components/Auth/LoginForm.vue'
  import RegisterForm from '@/components/Auth/RegisterForm.vue'
  
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
    height: 500px;
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
  