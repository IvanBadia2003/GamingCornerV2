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
                                <v-card class="cart-item pa-4 mb-5" elevation="2"
                                    v-if="cartStore.cartProducts.length > 0"
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
     
                                                <v-col cols="12">
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
                                                    <v-btn icon color="red" @click="eliminarDelCarrito(item.id)">
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
                                            <AddressForm :haveAddress="true"
                                                :direction="userStore.addressFormatted[0].valor"
                                                :city="userStore.addressFormatted[2].valor"
                                                :country="userStore.addressFormatted[1].valor"
                                                :zip="userStore.addressFormatted[3].valor" />
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>Escribir dirección nueva</v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <AddressForm :haveAddress="false" direction="" city="" country="" zip="" />
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

                                    <v-card v-for="(videogame, index) in orderStore.VideogamePurchases" :key="index"
                                        class="pa-3 my-4" elevation="2">
                                        <v-card-title class="text-subtitle-1">Código de Activación - {{ videogame.name
                                            }}</v-card-title>
                                        <v-card-text>
                                            <span :class="{ 'blur-text': !mostrarCodigo }">{{ videogame.digitalCode
                                                }}</span>
                                        </v-card-text>
                                        <v-btn variant="outlined"
                                            @click="mostrarCodigo = !mostrarCodigo">
                                            {{ mostrarCodigo ? 'Ocultar Código' : 'Ver Código' }}
                                        </v-btn>
                                    </v-card>

                                    <v-card-actions class="justify-center">
                                        <router-link to="/">
                                            <v-btn color="primary" border>Volver a la tienda</v-btn>
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
                        <v-col cols="6" class="text-body-1 ">Precio oficial</v-col>
                        <v-col cols="6" class="text-body-1  text-right">{{
                            cartStore.totalCartOficialPriceRounded
                            }}€</v-col>

                        <v-col cols="6" class="text-body-1 text-warning">Descuento</v-col>
                        <v-col cols="6" class="text-body-1 text-warning text-right">-{{ cartStore.totalCartDiscountPrice
                            }}€</v-col>

                        <v-col cols="6" class="text-h6 font-weight-bold text-success">Subtotal</v-col>
                        <v-col cols="6" class="text-h6 font-weight-bold text-success text-right">{{
                            cartStore.totalCartPriceRounded
                            }}€</v-col>
                    </v-row>

                    <!-- Botón de pago -->
                    <v-btn block class="payment-btn" height="50" :to="{ name: 'login' }"
                        v-if="!userStore.isAuthenticated" prepend-icon="mdi-login">
                        Inicia sesión para continuar
                    </v-btn>
                    <v-btn block class="payment-btn" height="50" @click="currentStep = 2; step1completed = true"
                        v-if="currentStep === 1 && userStore.isAuthenticated"
                        :disabled="cartStore.cartProducts.length === 0">
                        Proceder con el pago
                        <v-icon end>mdi-chevron-right</v-icon>
                    </v-btn>
                    <v-btn v-else-if="currentStep === 2" block class="payment-btn" height="50"
                        @click="currentStep = 3; step2completed = true; pay()"
                        :disabled="addressPanel === undefined || paidMetodPanel === undefined">
                        Proceder con el pago <v-icon>mdi-chevron-right</v-icon>
                    </v-btn>


                    <!-- Separador -->
                    <v-divider class="my-4"></v-divider>

                    <!-- Botón "Continuar comprando" -->
                    <div class="d-flex justify-center align-center text-on-background" v-if="currentStep === 1"
                        @click="router.back()">
                        <v-icon size="20">mdi-arrow-left</v-icon>
                        <span class="ml-2 text-body-2">Continuar comprando</span>
                    </div>
                    <div class="d-flex justify-center align-center"
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