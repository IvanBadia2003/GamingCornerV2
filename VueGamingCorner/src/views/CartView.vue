<script setup lang="ts">
import AddressForm from '@/components/Auth/AddressForm.vue';
import { useUserStore } from '@/stores/UserStore';
import { useCartStore } from '@/stores/CartStore';
import { computed, onMounted, ref } from 'vue';

import { useRouter } from 'vue-router'
import { tr } from 'vuetify/locale';
import { PaymentMethodEnum, useOrderStore, type CreateOrder } from '@/stores/OrderStore';
const router = useRouter()

const quantity = ref(1);

/* STEPPED */
const step1completed = ref(false);
const step2completed = ref(false);
const step3completed = ref(false);
const currentStep = ref(1);

const addressPanel = ref<number>()
const paidMetodPanel = ref<number>()

const wishList = ref([])
const cartStore = useCartStore();
const userStore = useUserStore();
const orderStore = useOrderStore();

const codigoActivacion = 'ABCD-1234-EFGH-5678' // Ejemplo de código
const mostrarCodigo = ref(false)

onMounted(() => {
    // Cargar la lista de deseos desde el store
    cartStore.getCartProducts()
});

function eliminarDelCarrito(productId: number) {
    cartStore.removeFromCart(productId);
}

function pay() {
    debugger
    const createOrder: CreateOrder = {
        billingAddress: userStore.user.address as string,
        createdAt: new Date(),
        paymentMethod: paidMetodPanel.value as number,
        userId: userStore.user.userId
    };

    orderStore.addOrder(createOrder)
}

</script>

<template>
    <v-container class="content">
        <v-stepper :model-value="currentStep">
            <v-stepper-header>
                <v-stepper-item title="Cesta" :value="1" :complete="step1completed"></v-stepper-item>

                <v-divider></v-divider>

                <v-stepper-item title="Pago" :value="2" :complete="step2completed"></v-stepper-item>

                <v-divider></v-divider>

                <v-stepper-item title="Activación" :value="3" :complete="step3completed"></v-stepper-item>
            </v-stepper-header>
        </v-stepper>
        <v-row class="mt-15">
            <!-- Carrito principal -->
            <v-col>
                <v-stepper-window :model-value="currentStep" class="ma-0">
                    <v-stepper-window-item :value="1">
                        <v-row>
                            <v-col cols="12">
                                <h3>CESTA</h3>
                                <v-card class="cart-item pa-4 mb-5" elevation="2" v-if="cartStore.cartProducts.length > 0"
                                    v-for="(item, index) in cartStore.cartProducts" :key="index">
                                    <v-row align="center">
                                        <!-- Imagen del producto -->
                                        <v-col cols="4">
                                            <v-img :src="item.productImages.main || ''" class="product-image rounded-lg"
                                                cover></v-img>
                                        </v-col>

                                        <!-- Información del producto -->
                                        <v-col cols="5">
                                            <v-row class="align-center" no-gutters>
                                                <v-col cols="2">
                                                    <v-avatar size="24">
                                                        <v-img
                                                            src="data:image/jpeg;base64,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"></v-img>
                                                    </v-avatar>
                                                </v-col>
                                                <v-col cols="10">
                                                    <p>{{ item.name }} </p>
                                                </v-col>
                                                <v-col cols="12">
                                                    <p>steam</p>
                                                </v-col>
                                            </v-row>
                                        </v-col>

                                        <!-- Precio y selector de cantidad -->
                                        <v-col cols="3" class="text-right">
                                            <v-row class="align-center">
                                                <v-col cols="7" class="text-center">

                                                    <p>{{ ((item.price as number) - ((item.price as
                                                        number) * (item.discount as number) / 100)).toFixed(2) }}€</p>
                                                </v-col>
                                                <v-col cols="5" class="text-center">
                                                    <v-btn icon color="" @click="eliminarDelCarrito(item.id)">
                                                        <v-icon>mdi-delete</v-icon>
                                                    </v-btn>
                                                </v-col>

                                            </v-row>
                                        </v-col>
                                    </v-row>

                                </v-card>
                                <p v-else>No hay productos en el carrito</p>


                            </v-col>

                        </v-row>
                        <v-row>
                            <v-col cols="12">
                                <h3>LISTA DE DESEOS</h3>

                                <v-card class="cart-item pa-4 mb-5" elevation="2" v-if="wishList.length > 0"
                                    v-for="(item, index) in wishList" :key="index">
                                    <v-row align="center">
                                        <!-- Imagen del producto -->
                                        <v-col cols="4">
                                            <v-img src="https://i.ytimg.com/vi/rSDBMVDXDh4/maxresdefault.jpg"
                                                class="product-image rounded-lg" cover></v-img>
                                        </v-col>

                                        <!-- Información del producto -->
                                        <v-col cols="5">
                                            <v-row class="align-center" no-gutters>

                                                <v-col cols="12">
                                                    <p>Crash Bandicoot </p>
                                                </v-col>
                                                <v-col cols="12">
                                                    <p>steam</p>
                                                </v-col>
                                            </v-row>
                                        </v-col>

                                        <!-- Precio y selector de cantidad -->
                                        <v-col cols="3" class="text-right">
                                            <v-icon size="20">mdi-arrow-up</v-icon>
                                            <span class="ml-2 text-body-2">mover a la cesta</span>
                                        </v-col>
                                    </v-row>

                                    <!-- Botón "Mover a lista de deseos" -->
                                    <!-- <v-btn class="mt-2 text-secondary" variant="text" size="small">
                        <v-icon left>mdi-trash-can-outline</v-icon> Mover a la lista de deseos
                    </v-btn> -->
                                </v-card>

                                <p v-else>No hay productos en la lista de deseos</p>
                            </v-col>

                        </v-row>
                    </v-stepper-window-item>
                    <v-stepper-window-item :value="2">
                        <v-row>
                            <v-col cols="12">
                                <h3>DIRECCIÓN FACTURACIÓN/ENVÍO</h3>
                                <v-expansion-panels v-model="addressPanel">
                                    <v-expansion-panel class="my-2" v-if="userStore.user.address != null">
                                        <v-expansion-panel-title>Usar mi dirección</v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <AddressForm :newAddress="true"
                                                :direction="userStore.addressFormatted[0].valor"
                                                :city="userStore.addressFormatted[2].valor"
                                                :country="userStore.addressFormatted[1].valor"
                                                :zip="userStore.addressFormatted[3].valor" />
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>Escribir dirección nueva</v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <AddressForm :newAddress="true" direction="" city="" country="" zip="" />
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                </v-expansion-panels>


                            </v-col>

                        </v-row>
                        <v-row>
                            <v-col cols="12">
                                <h3>Método de pago</h3>
                                <v-expansion-panels v-model="paidMetodPanel">
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>
                                            <v-col cols="3">
                                                <v-img src="C" class="product-image rounded-lg" cover></v-img>
                                            </v-col>

                                            <v-col cols="8">
                                                <p>Tarjeta</p>
                                            </v-col>
                                        </v-expansion-panel-title>

                                        <v-expansion-panel-text>
                                            <v-card class="pa-5">
                                                <v-form>
                                                    <v-row>
                                                        <v-col cols="12" md="6">
                                                            <v-text-field label="Número de tarjeta" required />
                                                        </v-col>
                                                        <v-col cols="12" md="6">
                                                            <v-text-field label="Titular de la tarjeta" required />
                                                        </v-col>
                                                        <v-col cols="12" md="6">
                                                            <v-text-field label="Fecha de caducidad" required />
                                                        </v-col>
                                                        <v-col cols="12" md="6">
                                                            <v-text-field label="CVV" required />
                                                        </v-col>

                                                    </v-row>



                                                </v-form>
                                            </v-card>
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>
                                            <v-col cols="3">
                                                <v-img src="CC" class="product-image rounded-lg" cover></v-img>
                                            </v-col>

                                            <v-col cols="8">
                                                <p>Paypal</p>
                                            </v-col>
                                        </v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <v-card class="pa-5">
                                                <v-form>
                                                    <v-row>
                                                        <v-col cols="12">
                                                            <v-text-field label="Correo electronico" required />
                                                        </v-col>
                                                        <v-col cols="12">
                                                            <v-text-field label="Contraseña" required />
                                                        </v-col>
                                                    </v-row>
                                                </v-form>
                                            </v-card>
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>
                                            <v-col cols="3">
                                                <v-img src="k=" class="product-image rounded-lg" cover></v-img>
                                            </v-col>

                                            <v-col cols="8">
                                                <p>Bizum</p>
                                            </v-col>
                                        </v-expansion-panel-title>
                                    </v-expansion-panel>
                                </v-expansion-panels>


                            </v-col>

                        </v-row>

                    </v-stepper-window-item>
                    <v-stepper-window-item :value="3">
                        <v-row>
                            <v-col cols="12" class="text-center">
                                <h3>¡COMPRA REALIZADA CON ÉXITO!</h3>

                                <v-card class="pa-5 text-center">
                                    <v-card-title class="text-h5">Gracias por tu compra</v-card-title>
                                    <v-card-text>Puedes activar tu producto ahora o más tarde en tu perfil</v-card-text>

                                    <v-card v-for="(videogame, index) in orderStore.VideogamePurchases" :key="index" class="pa-3 my-4" elevation="2">
                                        <v-card-title class="text-subtitle-1">Código de Activación - {{ videogame.name }}</v-card-title>
                                        <v-card-text>
                                            <span :class="{ 'blur-text': !mostrarCodigo }">{{ videogame.digitalCode }}</span>
                                        </v-card-text>
                                        <v-btn color="secondary" variant="outlined"
                                            @click="mostrarCodigo = !mostrarCodigo">
                                            {{ mostrarCodigo ? 'Ocultar Código' : 'Ver Código' }}
                                        </v-btn>
                                    </v-card>

                                    <v-card-actions class="justify-center">
                                        <router-link to="/">
                                            <v-btn color="primary">Volver a la tienda</v-btn>
                                        </router-link>
                                    </v-card-actions>
                                </v-card>

                            </v-col>

                        </v-row>
                    </v-stepper-window-item>
                </v-stepper-window>
            </v-col>

            <!-- Resumen (se mantiene fijo) -->
            <v-col cols="12" md="4" class="summary-card" v-if="currentStep === 1 || currentStep === 2">
                <h3>RESUMEN</h3>

                <v-card class=" pa-5 bg-primary" elevation="2">
                    <!-- Precios -->
                    <v-row class="mb-3">
                        <v-col cols="6" class="text-body-1 text-primary-darken-1">Precio oficial</v-col>
                        <v-col cols="6" class="text-body-1 text-secondary text-right">{{
                            cartStore.totalCartOficialPriceRounded
                        }}€</v-col>

                        <v-col cols="6" class="text-body-1 text-secondary">Descuento</v-col>
                        <v-col cols="6" class="text-body-1 text-success text-right">-{{ cartStore.totalCartDiscountPrice
                        }}€</v-col>

                        <v-col cols="6" class="text-h6 font-weight-bold">Subtotal</v-col>
                        <v-col cols="6" class="text-h6 font-weight-bold text-right">{{ cartStore.totalCartPriceRounded
                        }}€</v-col>
                    </v-row>

                    <!-- Botón de pago -->
                    <v-btn block class="payment-btn" height="50" :to="{ name: 'login' }"
                        v-if="!userStore.isAuthenticated">
                        Inicia sesión para continuar <v-icon>mdi-login</v-icon>
                    </v-btn>
                    <v-btn block class="payment-btn" height="50" @click="currentStep = 2; step1completed = true"
                        v-if="currentStep === 1 && userStore.isAuthenticated">
                        Proceder con el pago <v-icon>mdi-chevron-right</v-icon>
                    </v-btn>
                    <v-btn v-else-if="currentStep === 2" block class="payment-btn" height="50"
                        @click="currentStep = 3; step2completed = true; pay()"
                        :disabled="addressPanel === undefined || paidMetodPanel === undefined">
                        Proceder con el pago <v-icon>mdi-chevron-right</v-icon>
                    </v-btn>


                    <!-- Separador -->
                    <v-divider class="my-4"></v-divider>

                    <!-- Botón "Continuar comprando" -->
                    <div class="d-flex justify-center align-center text-secondary" v-if="currentStep === 1"
                        @click="router.back()">
                        <v-icon size="20">mdi-arrow-left</v-icon>
                        <span class="ml-2 text-body-2">Continuar comprando</span>
                    </div>
                    <div class="d-flex justify-center align-center text-secondary"
                        @click="currentStep = 1; step1completed = false" v-else>
                        <v-icon size="20">mdi-arrow-left</v-icon>
                        <span class="ml-2 text-body-2">Volver a la cesta</span>
                    </div>
                </v-card>
            </v-col>
        </v-row>

    </v-container>
</template>

<style scoped>
.content {
    width: 60%;
    margin: auto;
}

/* Hace que el resumen sea sticky y siempre visible */
.summary-card {
    position: sticky;
    top: 100px;
    /* Ajusta la distancia desde la parte superior */
    max-height: 70vh;
    /* Evita que sea demasiado alto */
    overflow-y: auto;
    /* Permite scroll si el contenido es grande */
}

.blur-text {
    filter: blur(5px);
    user-select: none;
    transition: filter 0.3s ease-in-out;
}
</style>