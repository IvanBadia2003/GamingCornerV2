<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import { RolEnum, useUserStore } from '@/stores/UserStore'
import { useProductStore } from '@/stores/ProductStore'
import { useDisplay } from 'vuetify'
import { useCartStore } from '@/stores/CartStore';

import IconLogo from '@/components/icons/IconLogo.vue'
import { storeToRefs } from 'pinia';
const user = useUserStore()
const productStore = useProductStore()

const cartStore = useCartStore()
const { cartCountCookies } = storeToRefs(cartStore) //Si no lo hago así, no sale el valor actualizado de cartCountCookies

onMounted(() => {
    cartStore.updateCartCount();
});

const theme = useTheme()

const { xs, sm, mdAndUp } = useDisplay()

const cartCountItems = computed(() => cartCountCookies.value)
// Para ordenadores
const showFullMenu = computed(() => mdAndUp.value)
// Para móviles y tablets
const showMobileMenu = computed(() => xs.value || sm.value)
const toggleMenuManual = ref(false)

const toggleMenu = computed(() => mdAndUp.value || toggleMenuManual.value)

const isDarkTheme = ref(theme.global.current.value.dark)

const toggleTheme = () => {
    const current = theme.global.name.value
    const newTheme = current === 'light' ? 'dark' : 'light'

    theme.global.name.value = newTheme
    useThemeStore().setTheme(newTheme)
}



const selectedProductType = ref('')

const Products = [
    { name: 'Juegos', route: '/catalog', type: 'videogame' as string },
    { name: 'Consolas', route: '/catalog', type: 'console' as string },
    { name: 'Segunda Mano', route: '/catalog', type: 'secondHand' as string }
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

            <v-col cols="6" sm="6" md="6" class="d-flex flex-column flex-md-row justify-center align-center my-2">
                <div v-if="showMobileMenu && toggleMenu">
                    <v-btn icon :to="'/cart'" color="white" class="me-4">
                        <v-badge :content="cartCountItems" color="background" overlap>
                            <v-icon icon="mdi-cart" size="x-large"></v-icon>
                        </v-badge>
                    </v-btn>
                    <v-menu offset-y transition="slide-y-transition" :close-on-content-click="false">
                        <template #activator="{ props }">
                            <v-btn icon v-bind="props" color="white">
                                <v-icon>mdi-account</v-icon>
                            </v-btn>
                        </template>

                        <v-list v-if="user.isAuthenticated" class="text-center">
                            <v-list-item :to="'/profile'" class="justify-center">
                                <v-list-item-title>Mi perfil</v-list-item-title>
                            </v-list-item>
                            <v-list-item :to="'/admin'" v-if="user.user.rol == RolEnum.Admin" class="justify-center">
                                <v-list-item-title>Pantalla Admin</v-list-item-title>
                            </v-list-item>
                            <v-list-item class="justify-center">
                                <v-list-item-title @click="user.logout">Cerrar sesión</v-list-item-title>
                            </v-list-item>
                            <v-list-item class="justify-center">
                                <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
                            </v-list-item>
                        </v-list>

                        <v-list v-else class="text-center">
                            <v-list-item :to="'/login'" class="justify-center">
                                <v-list-item-title>Iniciar Sesión</v-list-item-title>
                            </v-list-item>
                            <v-list-item class="justify-center">
                                <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
                            </v-list-item>
                        </v-list>
                    </v-menu>

                </div>
                <v-btn v-for="product in Products" :key="product.name" :value="product.type" :to="{ path: '/catalog' }"
                    variant="text" color="white" @click="
                        productStore.getProductsToCatalog(product.type || '');
                    productStore.productType = product.type || '';
                    ">
                    {{ product.name }}
                </v-btn>


            </v-col>

            <v-col v-if="showFullMenu" cols="3" sm="3" md="3" class="d-flex justify-end align-center px-10 ">
                <v-btn icon :to="'/cart'" color="white" class="me-4">
                    <v-badge :content="cartCountItems" color="background" overlap>
                        <v-icon icon="mdi-cart" size="x-large"></v-icon>
                    </v-badge>
                </v-btn>
                <v-menu offset-y transition="slide-y-transition" :close-on-content-click="false">
                    <template #activator="{ props }">
                        <v-btn icon v-bind="props" color="white">
                            <v-icon>mdi-account</v-icon>
                        </v-btn>
                    </template>

                    <v-list v-if="user.isAuthenticated" class="text-center">
                        <v-list-item :to="'/profile'" class="justify-center">
                            <v-list-item-title>Mi perfil</v-list-item-title>
                        </v-list-item>
                        <v-list-item :to="'/admin'" v-if="user.user.rol == RolEnum.Admin" class="justify-center">
                            <v-list-item-title>Pantalla Admin</v-list-item-title>
                        </v-list-item>
                        <v-list-item class="justify-center">
                            <v-list-item-title @click="user.logout">Cerrar sesión</v-list-item-title>
                        </v-list-item>
                        <v-list-item class="justify-center">
                            <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
                        </v-list-item>
                    </v-list>

                    <v-list v-else class="text-center">
                        <v-list-item :to="'/login'" class="justify-center">
                            <v-list-item-title>Iniciar Sesión</v-list-item-title>
                        </v-list-item>
                        <v-list-item class="justify-center">
                            <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
                        </v-list-item>
                    </v-list>
                </v-menu>

            </v-col>
            <v-col v-if="showMobileMenu" cols="3" sm="3" md="3" class="d-flex justify-end align-center px-10">
                <button @click="toggleMenuManual = !toggleMenuManual" :class="{ 'open': toggleMenu }" class="button">
                    <div></div>
                    <div></div>
                    <div></div>
                </button>
            </v-col>


        </v-row>
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