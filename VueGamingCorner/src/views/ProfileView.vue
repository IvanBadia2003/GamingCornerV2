<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import { useDisplay } from 'vuetify'
import { useUserStore } from '@/stores/UserStore'

import CardComponent from '@/components/CardComponent.vue'
import PerfilTab from '@/components/Settings/PerfilTab.vue'
import AddressesTab from '@/components/Auth/AddressForm.vue'
import PayTab from '@/components/Settings/PayTab.vue'
import NotificationsTab from '@/components/Settings/NotificationsTab.vue'
import SecurityTab from '@/components/Settings/SecurityTab.vue'
import SecondHandTab from '@/components/Settings/SecondHandTab.vue'
import { useFavouriteStore } from '@/stores/FavouriteStore'
import { it } from 'vuetify/locale'
import { SystemEnum } from '@/stores/PlatformStore'
import { useOrderStore } from '@/stores/OrderStore'
import { useReviewStore } from '@/stores/ReviewStore'
import ReviewCard from '@/components/ReviewCard.vue'
import AddProductDialogComponent from '@/components/Admin/AddProductDialogComponent.vue'
import { useRoute } from 'vue-router'

const userStore = useUserStore()
const orderStore = useOrderStore()
const favouriteStore = useFavouriteStore()
const reviewStore = useReviewStore()
const { xs, sm, md, lg } = useDisplay()
const route = useRoute()

onMounted(async () => {
    await userStore.fetchCurrentUser(); // Espera a que el usuario esté disponible
    await favouriteStore.getFavouriteProducts()
    await orderStore.getOrderByUserId()
    await orderStore.GetPurchasedVideogamesByUser()
    await reviewStore.getReviewByUserId()
    await orderStore.GetUserStats()
    const queryTab = parseInt(route.query.tab as string)
  if (!isNaN(queryTab)) {
    tab.value = queryTab
  }
})

const avatarSize = computed(() => {
    if (xs.value) return 80
    if (sm.value) return 120
    if (md.value) return 150
    if (lg.value) return 200
    return 220
})

const tab = ref(0)
const mostrarProductos = ref(false)



const tabSettings = ref('perfil')

function getComponent(tabName: string) {
    switch (tabName) {
        case 'perfil': return PerfilTab
        case 'direcciones': return AddressesTab
        case 'pago': return PayTab
        case 'notificaciones': return NotificationsTab
        case 'seguridad': return SecurityTab
        case 'segundaMano': return SecondHandTab
        default: return PerfilTab
    }
}

// Props condicionales para cada componente
const propsDelComponente = computed(() => {
    if (tabSettings.value === 'direcciones') {
        return {
            newAddress: true,
            direction: userStore.addressFormatted[0].valor,
            country: userStore.addressFormatted[1].valor,
            city: userStore.addressFormatted[2].valor,
            zip: userStore.addressFormatted[3].valor
        }
    }

    return {} // Por defecto, sin props
})

const mostrarCodigos = ref<{ [key: number]: boolean }>({});

const toggleCodigo = (index: number) => {
    mostrarCodigos.value[index] = !mostrarCodigos.value[index];
};
</script>
<template>

    <v-container style="width: 80%;">
        <v-row class=" pa-5">
            <v-col cols="12" sm="12" md="12" lg="12" class="d-flex flex-column align-center justify-center text-center">
                <v-row justify="center">
                    <v-col cols="12" class="d-flex flex-column align-center justify-center text-center">
                        <v-avatar :size="avatarSize">
                            <v-img :alt="userStore.user.name" :src="userStore.user.avatar"></v-img>
                        </v-avatar>
                    </v-col>
                </v-row>

                <v-row justify="center">
                    <v-col cols="12">
                        <v-row justify="center">
                            <v-col cols="12">

                                <p>{{ userStore.user.name }}</p>
                                <p>Usuario desde {{ userStore.cratedDateFormated }}</p>
                            </v-col>
                        </v-row>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </v-container>

    <v-row class="bg-primary ">
        <v-col cols="12" class="pa-0 d-flex justify-center align-center">
            <v-tabs v-model="tab" bg-color="primary" style="width: 80%;">
                <v-row class="d-flex justify-space-between">
                    <v-col cols="12" md="7">
                        <v-row class="" no-gutters>

                            <v-col cols="2">
                                <v-tab value="one">General</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="two">Mis pedidos</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="three">favoritos</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="four">Biblioteca</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="five">Reviews</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="six">Vender Producto</v-tab>
                            </v-col>
                        </v-row>

                    </v-col>
                    <v-col cols="12" md="2">
                        <v-tab value="seven">Configuración</v-tab>
                    </v-col>
                </v-row>
            </v-tabs>

        </v-col>
    </v-row>

    <v-row class="bg-surface">
        <v-container style="width: 70%;">
            <v-row class="py-10">
                <v-col cols="12">
                    <v-tabs-window v-model="tab">
                        <v-tabs-window-item value="one">
                            <v-row>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary">
                                        <v-card-title class="pt-5">PRODUCTOS COMPRADOS</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Juegos</p>
                                                        <h3>{{ orderStore.userStats.totalVideogames }}</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Consolas</p>
                                                        <h3>{{ orderStore.userStats.totalConsoles }}</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Segunda Mano</p>
                                                        <h3>{{ orderStore.userStats.totalSecondHandProducts }}</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary h-100">
                                        <v-card-title class="pt-5">PRODUCTOS EN VENTA</v-card-title>
                                        <v-card-text class="py-10" v-if="orderStore.userStats.totalProductsOnSale > 0">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>En venta</p>
                                                        <h3>{{ orderStore.userStats.checkedProductsOnSale }}</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>Esperando Validación</p>
                                                        <h3>{{ orderStore.userStats.uncheckedProductsOnSale }}</h3>
                                                    </div>
                                                </v-col>

                                            </v-row>

                                        </v-card-text>
                                        <v-card-text class="py-10" v-else>
                                            <v-row class="d-flex justify-space-between">
                                                <v-col  cols="12">
                                                    <div >
                                                        <p>AÚN NO HAS PUESTO NADA A LA VENTA</p>
                                                        <v-btn @click="tab = 5" color="primary">PON ALGO
                                                            A LA VENTA</v-btn>
                                                    </div>
                                                </v-col>


                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary">
                                        <v-card-title class="pt-5">ÚLTIMOS PRODUCTOS EN FAVORITOS</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row  class="d-flex justify-center">
                                                <v-col v-if="favouriteStore.favouriteProducts.length > 0"
                                                    v-for="(favouriteProduct, index) in favouriteStore.favouriteProducts.slice(0, 3)"
                                                    :key="index" cols="12" sm="6" md="4">
                                                    <CardComponent :title="favouriteProduct.product.name"
                                                        :discount="favouriteProduct.product.discount"
                                                        :price="favouriteProduct.product.price"
                                                        :product-id="favouriteProduct.product.id"
                                                        :src="favouriteProduct.product.productImages?.main || ''" />
                                                </v-col>
                                                <p v-else>¡Aún no has añadido ningún juego a favoritos!</p>
                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary h-100 ">
                                        <v-card-title class="pt-5">TOTAL AHORRADO</v-card-title>
                                        <v-card-text class="py-5 ">
                                            <v-row class="d-flex justify-space-between ">
                                                <v-col cols="12" class="pa-0">
                                                    <div>
                                                        <p>En juegos</p>
                                                        <h3>{{ orderStore.userStats.totalSavedOnVideogames }}€</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>
                                            <v-row class="d-flex justify-space-between pa-0">
                                                <v-col cols="12" class="pa-0">
                                                    <div>
                                                        <p>En consolas</p>
                                                        <h3>{{ orderStore.userStats.totalSavedOnConsoles }}€</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>

                                        </v-card-text>

                                    </v-card>
                                </v-col>

                            </v-row>
                        </v-tabs-window-item>

                        <v-tabs-window-item value="two">
                            <v-row>
                                <v-col cols="6" v-for="(order, index) in orderStore.orders" :key="index">
                                    <v-card class="mb-4 elevation-2">
                                        <!-- Cabecera del pedido -->
                                        <v-card-title class="bg-primary text-white d-flex justify-space-between">
                                            <div>
                                                <div class="text-h6">Pedido #{{ order.orderNumber }}</div>
                                                <div class="text-caption">Realizado el {{ order.createdAt }}
                                                </div>
                                            </div>
                                            <div class="text-right">
                                                <div class="text-subtitle-2">Total: {{ order.totalPrice.toFixed(2) }}€
                                                </div>
                                            </div>
                                        </v-card-title>

                                        <!-- Líneas de pedido -->
                                        <v-card-text class="py-5">
                                            <v-row v-for="(line, i) in order.orderLines" :key="i" class="mb-3">
                                                <v-col cols="12" md="2">
                                                    <v-img
                                                        src="https://i.eurosport.com/2015/07/20/1644653-34890947-2560-1440.png"
                                                        height="80" contain></v-img>
                                                </v-col>

                                                <v-col cols="12" md="6">
                                                    <div class="text-subtitle-1">{{ line.productName }}</div>
                                                    <div class="text-caption">
                                                        Sistema: {{ line.productSystem }} | Plataforma: {{
                                                            line.productPlatform }}
                                                    </div>

                                                    <div v-if="line.digitalCode">
                                                        <span :class="{ 'blur-text': !mostrarCodigos[i] }">
                                                            {{ line.digitalCode }}
                                                        </span>
                                                        <v-btn size="small" color="secondary" variant="outlined"
                                                            class="ml-2 mt-2" @click="toggleCodigo(i)">
                                                            {{ mostrarCodigos[i] ? 'Ocultar Código' : 'Ver Código' }}
                                                        </v-btn>
                                                    </div>
                                                </v-col>

                                                <v-col cols="6" md="2" class="d-flex align-center justify-end">
                                                    <div><strong>{{ line.price.toFixed(2) }}€</strong></div>
                                                </v-col>
                                            </v-row>
                                        </v-card-text>

                                    </v-card>
                                </v-col>


                            </v-row>
                        </v-tabs-window-item>

                        <v-tabs-window-item value="three">
                            <v-row>
                                <v-col v-for="(videogame, index) in favouriteStore.favouriteProducts" :key="index"
                                    cols="12" sm="4" md="4">
                                    <CardComponent :title="videogame.product.name"
                                        :discount="videogame.product.discount" :price="videogame.product.price"
                                        :product-id="videogame.product.id"
                                        :src="videogame.product.productImages.main || ''" />
                                </v-col>
                            </v-row>
                        </v-tabs-window-item>
                        <v-tabs-window-item value="four">
                            <v-row>
                                <v-col v-for="(videogame, index) in orderStore.VideogameByUser" :key="index" cols="12"
                                    sm="4" md="4">
                                    <CardComponent :title="videogame.name" :discount="videogame.discount"
                                        :price="videogame.price" :product-id="videogame.productId"
                                        :src="videogame.productImages?.main || ''" />
                                </v-col>
                            </v-row>
                        </v-tabs-window-item>
                        <v-tabs-window-item value="five">

                            <v-row>
                                <ReviewCard v-for="(item, index) in reviewStore.reviews" :key="index" :review="item" />
                            </v-row>
                        </v-tabs-window-item>
                        <v-tabs-window-item value="six">
                            <v-row justify="center" >
                                <v-col cols="7">
                                    <AddProductDialogComponent type="segundamano"/>

                                </v-col>
                            </v-row>
                        </v-tabs-window-item>
                        <v-tabs-window-item value="seven">
                            <v-card>
                                <v-tabs v-model="tabSettings" background-color="primary" dark>
                                    <v-tab value="perfil">Perfil</v-tab>
                                    <v-tab value="direcciones">Direcciones</v-tab>
                                    <v-tab value="pago">Métodos de Pago</v-tab>
                                    <v-tab value="notificaciones">Notificaciones</v-tab>
                                    <v-tab value="seguridad">Seguridad</v-tab>
                                </v-tabs>

                                <v-divider></v-divider>

                                <v-card-text>
                                    <component :is="getComponent(tabSettings)" v-bind="propsDelComponente" />
                                </v-card-text>
                            </v-card>
                        </v-tabs-window-item>
                    </v-tabs-window>
                </v-col>
            </v-row>
        </v-container>
    </v-row>








</template>



<style lang="scss" scoped>
.tilted-bottom {
    clip-path: polygon(0% 0%, 100% 0%, 100% 100%, 0% 90%);
    background-size: cover;
    /* Ajusta la imagen sin distorsionarla */
    background-position: center;
    /* Centra la imagen */
}

.blur-text {
    filter: blur(5px);
    user-select: none;
    transition: filter 0.3s ease-in-out;
}
</style>