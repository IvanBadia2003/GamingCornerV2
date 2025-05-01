<script setup lang="ts">
import { ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import IconLogo from '@/components/icons/IconLogo.vue'

const theme = useTheme()

const toggleTheme = () => {
  const current = theme.global.name.value
  const newTheme = current === 'light' ? 'dark' : 'light'

  theme.global.name.value = newTheme
  useThemeStore().setTheme(newTheme)
}
const toggleMenu = ref<boolean>(false);
</script>

<template>
    <header id="Header" class="bg-primary">
        <router-link  :to="'/'">

            <IconLogo  />
        </router-link>

        <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
        <button @click="toggleMenu = !toggleMenu" :class="{ 'open': toggleMenu }">
            <div></div>
            <div></div>
            <div></div>
        </button>

        <ul class="menu" :class="{ 'open': toggleMenu }">
            <router-link class="item" :to="'/'">Inicio</router-link>
            <router-link class="item" :to="'/catalog'">Productos</router-link>
           <router-link class="item" :to="'/perfil'">Perfil</router-link>
    

        </ul>
    </header>
</template>

<style scoped lang="scss">

#Header {
    width: 100%;

    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 5%;
    height: 100px;

    .logo {
        max-width: 70px;

        @media (min-width: 764px) {
            max-width: 150px;
        }
    }
}

  
</style>