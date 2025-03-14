<template>

    <v-container style="width: 80%;">
        <v-row class="bg-primary pa-5">
            <v-col cols="12" sm="12" md="12" lg="12" class="d-flex flex-column align-center justify-center text-center">
                <v-row justify="center">
                    <v-col cols="12" class="d-flex flex-column align-center justify-center text-center">
                        <h2>IMG del usuario</h2>
                    </v-col>
                </v-row>

                <v-row justify="center">
                    <v-col cols="12">
                        <v-btn variant="outlined">
                            nombre de usuario, fecha de registro, etc 
                        </v-btn>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>

        <v-row class="bg-primary">
            <v-col cols="8" class="">
                <v-row class="bg-primary ">
                    <v-col cols="3" class="">
                        <h5>Panel de control</h5>
                    </v-col>
                    <v-col cols="2" class="">
                        <h5>Mis Pedidos</h5>
                    </v-col>
                    <v-col cols="2" class="">
                        <h5>Lista deseos</h5>
                    </v-col>
                    <v-col cols="2" class="">
                        <h5>Biblioteca</h5>
                    </v-col>
                    <v-col cols="2" class="">
                        <h5>Reviews</h5>
                    </v-col>
                </v-row>
            </v-col>
            <v-col cols="4" class="">
                <v-row class="bg-primary" justify="end">
                    <v-col cols="4" class="">
                        <h5>Configuración</h5>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
        <v-row >
            <!-- Primera tarjeta: Vista general -->
            <v-col cols="6" class="d-flex flex-column">
                <v-card class="pa-4 flex-grow-1" color="grey darken-4" dark elevation="2">
                    <!-- Ícono, título y contenido -->
                    <div class="text-h6 mt-2">Vista general</div>

                    <!-- Estadísticas: Amigo, Reseña, Wishlist, Juegos -->
                    <v-row class="mt-4">

                        <v-col cols="4">
                            <div class="text-subtitle-1">0</div>
                            <small>Reseñas</small>
                        </v-col>
                        <v-col cols="4">
                            <div class="text-subtitle-1">12</div>
                            <small>Consolas</small>
                        </v-col>
                        <v-col cols="4">
                            <div class="text-subtitle-1">12</div>
                            <small>Juegos</small>
                        </v-col>
                    </v-row>
                </v-card>
            </v-col>

            <!-- Segunda tarjeta: Cartera -->
            <v-col cols="3" class="d-flex flex-column">
                <v-card class="pa-4 flex-grow-1" color="grey darken-4" dark elevation="2">
                    <div class="text-h6 mt-2">Productos vendidos</div>

                    <div class="mt-4">
                        Afiliación: <strong>0€</strong>
                    </div>
                    <div>
                        E-wallet: <strong>0.00€</strong>
                    </div>
                </v-card>
            </v-col>

            <!-- Tercera tarjeta: Ranking -->
            <v-col cols="3" class="d-flex flex-column">
                <v-card class="pa-4 flex-grow-1" color="grey darken-4" dark elevation="2">
                    <div class="text-h6 mt-2">Pedidos</div>

                    <div class="mt-4">
                        22
                    </div>
                </v-card>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="12" class="d-flex flex-column">
                <v-card class="pa-4 flex-grow-1" color="grey darken-4" dark elevation="2">
                    <div class="text-h6 mt-2">Lista de deseos</div>

                    <div class="mt-4">
                        aqui irian los productos en la lista de deseos
                    </div>
                </v-card>
            </v-col>
        </v-row>
    </v-container>








</template>

<script setup lang="ts">
import DestacablesComponent from '@/components/Home/DestacablesComponent.vue';
import GridComponentTopConsoles from '@/components/Home/GridComponentTopConsoles.vue';
import GridComponentTopGames from '@/components/Home/GridComponentTopGames.vue';
import PrincipalImage from '@/components/Images/PrincipalImage.vue';

</script>


<style lang="scss" scoped>
.tilted-bottom {
    clip-path: polygon(0% 0%, 100% 0%, 100% 100%, 0% 90%);
    background-size: cover;
    /* Ajusta la imagen sin distorsionarla */
    background-position: center;
    /* Centra la imagen */
}
</style>