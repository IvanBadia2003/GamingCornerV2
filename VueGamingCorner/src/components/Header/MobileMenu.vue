<script setup lang="ts">
import { computed, ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import { useUserStore } from '@/stores/UserStore'
import IconLogo from '@/components/icons/IconLogo.vue'

const user = useUserStore()
const toggleMenu = ref<boolean>(false);

defineProps<{
    platforms: { name: string, route: string }[]
}>()

</script>
<template>
    <v-col cols="12" sm="6" md="6" class="d-flex justify-center">
        <v-btn v-for="platform in platforms" :key="platform.name" :to="platform.route" class="mx-0" variant="text"
            color="white">
            {{ platform.name }}
        </v-btn>
    </v-col>

    <v-col cols="12" sm="3" md="3" class="d-flex justify-end align-center px-10">

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

            <v-list v-if="user.isAuthenticated">
                <v-list-item :to="'/perfil'">
                    <v-list-item-title>Mi perfil</v-list-item-title>
                </v-list-item>
                <v-list-item :to="'/orders'">
                    <v-list-item-title>Mis pedidos</v-list-item-title>
                </v-list-item>
                <v-list-item :to="'/admin'" v-if="user.user?.admin">
                    <v-list-item-title>Pantalla Admin</v-list-item-title>
                </v-list-item>
                <v-list-item>
                    <v-list-item-title @click="user.logout">Cerrar sesión</v-list-item-title>
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
    <v-col sm="6" md="6" class="d-flex justify-end align-center px-10">
        <button @click="toggleMenu = !toggleMenu" :class="{ 'open': toggleMenu }">
            <div></div>
            <div></div>
            <div></div>
        </button>
    </v-col>
</template>

<style scoped lang="scss">

</style>