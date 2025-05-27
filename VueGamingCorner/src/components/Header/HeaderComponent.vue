<script setup lang="ts">
import { computed, ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import { useAuthStore } from '@/stores/AuthStore'
import { useProductStore } from '@/stores/ProductStore'
import IconLogo from '@/components/icons/IconLogo.vue'
const auth = useAuthStore()
const productStore = useProductStore()
const cartStore = useCartStore()

const theme = useTheme()

import { useDisplay } from 'vuetify'
import { useCartStore } from '@/stores/CartStore';
const { xs, sm, mdAndUp } = useDisplay()

// Para ordenadores
const showFullMenu = computed(() => mdAndUp.value )
// Para móviles y tablets
const showMobileMenu = computed(() => xs.value || sm.value)
const toggleMenuManual = ref(false)

const toggleMenu = computed(() => mdAndUp.value || toggleMenuManual.value)

const cartCount = computed(() => cartStore.updateCartCount())

const toggleTheme = () => {
    const current = theme.global.name.value
    const newTheme = current === 'light' ? 'dark' : 'light'

    theme.global.name.value = newTheme
    useThemeStore().setTheme(newTheme)
}

const platforms = [
    { name: 'Juegos', route: '/catalog', type: 'videogame' },
    { name: 'Consolas', route: '/catalog', type: 'console' },
    { name: 'Segunda Mano', route: '/catalog' }
];
</script>
<template>
    <header id="Header" class="bg-primary">
        <v-row align="center">
            <v-col cols="3" sm="3" md="3" class="d-flex ">
                <router-link :to="'/'">
                    <IconLogo />
                </router-link>
            </v-col>

            <v-col  cols="6" sm="6" md="6" class="d-flex flex-column flex-md-row justify-center align-center my-2">
                <div v-if="showMobileMenu && toggleMenu">
                    <v-btn icon :to="'/cart'" color="white" class="me-4">
                        <v-badge :content="cartCount" color="background" overlap>
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
                                <v-list-item-title>
                                </v-list-item-title>
                            </v-list-item>
                        </v-list>
                        <v-list v-else>
                            <v-list-item :to="'/login'">
                                <v-list-item-title>Iniciar Sesión</v-list-item-title>
                            </v-list-item>

                        </v-list>
                    </v-menu>
                </div>
                <v-btn v-if=" toggleMenu" v-for="platform in platforms" :key="platform.name" :to="platform.route" class="mx-0"
                    variant="text" color="white" @click="productStore.getProductsToCatalog(platform.type as string)">
                    {{ platform.name }}
                </v-btn>
            </v-col>

            <v-col v-if="showFullMenu" cols="3" sm="3" md="3" class="d-flex justify-end align-center px-10 ">
                <v-btn icon :to="'/cart'" color="white" class="me-4">
                    <v-badge :content="cartCount" color="background" overlap>
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
                            <v-list-item-title>
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
            <v-col v-if="showMobileMenu"  cols="3" sm="3" md="3" class="d-flex justify-end align-center px-10">
                <button @click="toggleMenuManual = !toggleMenuManual" :class="{ 'open': toggleMenu }" class="button">
                    <div></div>
                    <div></div>
                    <div></div>
                </button>
            </v-col>


        </v-row>
        <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
    </header>
</template>

<style scoped lang="scss">
#Header {
    width: 100%;
    height: auto;

    .logo {
        max-width: 70px;

        @media (min-width: 764px) {
            max-width: 150px;
        }
    }
}

.button {
    display: flex;
    flex-direction: column;
    width: 3rem;
    height: 2rem;
    border: 0;
    background: transparent;
    gap: .65rem;

    &.open>div:first-child {
        transform: rotate(45deg);
    }

    &.open>div:nth-child(2) {
        opacity: 0;
    }

    &.open>div:last-child {
        transform: rotate(-45deg);
    }

    >div {
        background-color: black;
        height: 2px;
        width: 100%;
        border-radius: 5px;
        transition: all .5s;
        transform-origin: left;
    }


}
</style>