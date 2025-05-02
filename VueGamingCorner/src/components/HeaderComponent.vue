<script setup lang="ts">
import { ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import { useAuthStore } from '@/stores/AuthStore'
import IconLogo from '@/components/icons/IconLogo.vue'

const theme = useTheme()
const auth = useAuthStore()

const toggleTheme = () => {
    const current = theme.global.name.value
    const newTheme = current === 'light' ? 'dark' : 'light'

    theme.global.name.value = newTheme
    useThemeStore().setTheme(newTheme)
}

const platforms = [
    { name: 'PC', route: '/catalog' },
    { name: 'PlayStation', route: '/catalog' },
    { name: 'Xbox', route: '/catalog' },
    { name: 'Nintendo', route: '/catalog' }
];
</script>
<template>
    <header id="Header" class="bg-primary">
        <v-row align="center">
            <v-col cols="12" md="3" class="d-flex ">
                <router-link :to="'/'">
                    <IconLogo />
                </router-link>
            </v-col>

            <v-col cols="12" md="6" class="d-flex justify-center">
                <v-btn v-for="platform in platforms" :key="platform.name" :to="platform.route" class="mx-2"
                    variant="text" color="white">
                    {{ platform.name }}
                </v-btn>
            </v-col>
            <v-col cols="12" md="3" class="d-flex justify-end align-center px-10">

                <v-btn icon :to="'/cart'" color="white" class="me-4">
                    <v-badge :content="71" color="background" overlap>
                        <v-icon icon="mdi-cart" size="x-large"></v-icon>
                    </v-badge> 
                </v-btn>
                <v-menu offset-y transition="slide-y-transition" :close-on-content-click="false">
                    <template #activator="{ props }">
                        <v-btn icon v-bind="props" color="white">
                            <v-icon>mdi-account</v-icon>
                        </v-btn>
                    </template>

                    <v-list v-if="auth.isAuthenticated">
                        <v-list-item :to="'/perfil'">
                            <v-list-item-title>Mi perfil</v-list-item-title>
                        </v-list-item>
                        <v-list-item :to="'/orders'">
                            <v-list-item-title>Mis pedidos</v-list-item-title>
                        </v-list-item>
                        <v-list-item :to="'/admin'" v-if="auth.user?.admin">
                            <v-list-item-title>Pantalla Admin</v-list-item-title>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-title @click="auth.logout">Cerrar sesión</v-list-item-title>
                        </v-list-item>
                        <v-list-item>
                            <v-list-item-title> <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
                            </v-list-item-title>
                        </v-list-item>
                    </v-list>
                    <v-list v-else>
                        <v-list-item :to="'/login'">
                            <v-list-item-title>Iniciar Sesión</v-list-item-title>
                        </v-list-item>
                        
                    </v-list>
                </v-menu>

            </v-col>


        </v-row>
    </header>
</template> -

<style scoped lang="scss">
#Header {
    width: 100%;
    height: 100px;

    .logo {
        max-width: 70px;

        @media (min-width: 764px) {
            max-width: 150px;
        }
    }
}
</style>