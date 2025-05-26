<script setup lang="ts">
import { computed, ref } from 'vue';

const quantity = ref(1);

/* STEPPED */
const step1completed = ref(false);
const step2completed = ref(false);
const step3completed = ref(false);
const currentStep = ref(1);

const panel = ref([])
const panel2 = ref([0])

const useSameAddress = ref(true)

const wishList = ref([])

const codigoActivacion = 'ABCD-1234-EFGH-5678' // Ejemplo de código
const mostrarCodigo = ref(false)
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
                                <v-card class="cart-item pa-4 mb-5" elevation="2" v-for="(item, index) in 1"
                                    :key="index">
                                    <v-row align="center">
                                        <!-- Imagen del producto -->
                                        <v-col cols="4">
                                            <v-img
                                                src="https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/aqZdSwWyy9JcQ66BxHDKrky6.jpg"
                                                class="product-image rounded-lg" cover></v-img>
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
                                                    <p>Crash Bandicoot </p>
                                                </v-col>
                                                <v-col cols="12">
                                                    <p>steam</p>
                                                </v-col>
                                            </v-row>
                                        </v-col>

                                        <!-- Precio y selector de cantidad -->
                                        <v-col cols="3" class="text-right">
                                            <v-row class="align-center">
                                                <v-col cols="5" class="text-center">

                                                    <p>36€</p>
                                                </v-col>
                                                <v-col cols="7" class="text-center">
                                                    <v-select v-model="quantity" :items="[1, 2, 3, 4, 5]"
                                                        class="quantity-selector" density="compact" variant="outlined"
                                                        hide-details></v-select>
                                                </v-col>
                                            </v-row>
                                        </v-col>
                                    </v-row>

                                </v-card>


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
                                <v-expansion-panels v-model="panel">
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>Usar mi dirección</v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <v-card class="pa-5">
                                                <v-card-title>Dirección de Facturación</v-card-title>
                                                <v-form>
                                                    <v-row>
                                                        <v-col cols="12" md="12">
                                                            <v-text-field label="Dirección" required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-select label="País"
                                                                :items="['España', 'México', 'Argentina', 'Chile', 'Colombia']"
                                                                required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-text-field label="Ciudad" required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-text-field label="Código Postal" required />
                                                        </v-col>
                                                    </v-row>

                                                    <v-checkbox v-model="useSameAddress"
                                                        label="Usar la misma dirección para el envío" />

                                                    <v-expand-transition>
                                                        <div v-if="!useSameAddress">
                                                            <v-card-title>Dirección de Envío</v-card-title>
                                                            <v-row>
                                                                <v-col cols="12" md="6">
                                                                    <v-text-field label="Nombre Completo" required />
                                                                </v-col>
                                                                <v-col cols="12" md="6">
                                                                    <v-text-field label="Dirección" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-text-field label="Ciudad" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-text-field label="Código Postal" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-select label="País"
                                                                        :items="['España', 'México', 'Argentina', 'Chile', 'Colombia']"
                                                                        required />
                                                                </v-col>
                                                            </v-row>
                                                        </div>
                                                    </v-expand-transition>


                                                </v-form>
                                            </v-card>
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>Escribir dirección</v-expansion-panel-title>
                                        <v-expansion-panel-text>
                                            <v-card class="pa-5">
                                                <v-card-title>Dirección de Facturación</v-card-title>
                                                <v-form>
                                                    <v-row>
                                                        <v-col cols="12" md="12">
                                                            <v-text-field label="Dirección" required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-select label="País"
                                                                :items="['España', 'México', 'Argentina', 'Chile', 'Colombia']"
                                                                required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-text-field label="Ciudad" required />
                                                        </v-col>
                                                        <v-col cols="12" md="4">
                                                            <v-text-field label="Código Postal" required />
                                                        </v-col>
                                                    </v-row>

                                                    <v-checkbox v-model="useSameAddress"
                                                        label="Usar la misma dirección para el envío" />

                                                    <v-expand-transition>
                                                        <div v-if="!useSameAddress">
                                                            <v-card-title>Dirección de Envío</v-card-title>
                                                            <v-row>
                                                                <v-col cols="12" md="6">
                                                                    <v-text-field label="Nombre Completo" required />
                                                                </v-col>
                                                                <v-col cols="12" md="6">
                                                                    <v-text-field label="Dirección" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-text-field label="Ciudad" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-text-field label="Código Postal" required />
                                                                </v-col>
                                                                <v-col cols="12" md="4">
                                                                    <v-select label="País"
                                                                        :items="['España', 'México', 'Argentina', 'Chile', 'Colombia']"
                                                                        required />
                                                                </v-col>
                                                            </v-row>
                                                        </div>
                                                    </v-expand-transition>


                                                </v-form>
                                            </v-card>
                                        </v-expansion-panel-text>
                                    </v-expansion-panel>
                                </v-expansion-panels>


                            </v-col>

                        </v-row>
                        <v-row>
                            <v-col cols="12">
                                <h3>Método de pago</h3>
                                <v-expansion-panels v-model="panel2">
                                    <v-expansion-panel class="my-2">
                                        <v-expansion-panel-title>
                                            <v-col cols="3">
                                                <v-img
                                                    src="data:image/png;base64,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"
                                                    class="product-image rounded-lg" cover></v-img>
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
                                                <v-img
                                                    src="data:image/png;base64,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"
                                                    class="product-image rounded-lg" cover></v-img>
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
                                                <v-img
                                                    src="data:image/jpeg;base64,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"
                                                    class="product-image rounded-lg" cover></v-img>
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

                                    <v-card class="pa-3 my-4" elevation="2">
                                        <v-card-title class="text-subtitle-1">Código de Activación</v-card-title>
                                        <v-card-text>
                                            <span :class="{ 'blur-text': !mostrarCodigo }">{{ codigoActivacion }}</span>
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
            <v-col cols="12" md="5" class="summary-card" v-if="currentStep === 1 || currentStep === 2">
                <h3>RESUMEN</h3>

                <v-card class=" pa-5 bg-primary" elevation="2">
                    <!-- Precios -->
                    <v-row class="mb-3">
                        <v-col cols="6" class="text-body-1 text-primary-darken-1">Precio oficial</v-col>
                        <v-col cols="6" class="text-body-1 text-secondary text-right">70e</v-col>

                        <v-col cols="6" class="text-body-1 text-secondary">Descuento</v-col>
                        <v-col cols="6" class="text-body-1 text-success text-right">-35€</v-col>

                        <v-col cols="6" class="text-h6 font-weight-bold">Subtotal</v-col>
                        <v-col cols="6" class="text-h6 font-weight-bold text-right">35€</v-col>
                    </v-row>

                    <!-- Botón de pago -->
                    <v-btn block class="payment-btn" height="50" @click="currentStep = 2; step1completed = true"
                        v-if="currentStep === 1">
                        Proceder con el pago <v-icon>mdi-chevron-right</v-icon>
                    </v-btn>
                    <v-btn block class="payment-btn" height="50" @click="currentStep = 3; step2completed = true" v-else>
                        Proceder con el pago <v-icon>mdi-chevron-right</v-icon>
                    </v-btn>

                    <!-- Separador -->
                    <v-divider class="my-4"></v-divider>

                    <!-- Botón "Continuar comprando" -->
                    <div class="d-flex justify-center align-center text-secondary" v-if="currentStep === 1">
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