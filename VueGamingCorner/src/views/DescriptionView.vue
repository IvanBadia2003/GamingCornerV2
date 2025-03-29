<script setup lang="ts">
import PrincipalImage from '@/components/Images/PrincipalImage.vue';
import { ref } from 'vue';


const loading = ref(false)

function reserve() {
    loading.value = true
    setTimeout(() => (loading.value = false), 2000)
}
</script>


<template>




    <v-container fluid class="game-description">
        <!-- Imagen de fondo -->
        <v-img class="background-image"
            src="https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png"
            cover></v-img>

        <!-- Contenedor del contenido -->
        <v-container class="content">
            <v-row >
                <!-- Imagen principal del juego -->
                <v-col cols="12" md="6">
                    <v-sheet class="game-cover" max-width="600">
                        <v-img
                            src="https://preview.redd.it/zero-dawn-remastered-pre-load-v0-z4vhl1l56lwd1.jpeg?auto=webp&s=061dd572a460a5883ca3d6c86e95d6a0fefdffae"
                            cover width="100%" class="img" />
                    </v-sheet>
                </v-col>

                <!-- Información del juego -->
                <v-col cols="12" md="6" class="game-info" > 
                    <v-card height="100%" :disabled="loading" :loading="loading" class="d-flex flex-column align-center text-center"    style=" background: rgba(0, 0, 0, 0.7);"
                    >

                        <v-card-title class="text-overline">
                            <h1 class="game-title">Nombre del Juego</h1>
                        </v-card-title>



                        <v-card-actions>
                            <v-btn color="deep-purple-lighten-2" text="Añadir a favoritos" border
                                @click="reserve"></v-btn>
                            <v-btn color="deep-purple-lighten-2" text="Comprar Ahora" border @click="reserve"></v-btn>
                        </v-card-actions>

                    </v-card>

                </v-col>
            </v-row>
        </v-container>
    </v-container>


</template>


<style scoped>
.game-description {
    position: relative;
    width: 100%;
}

.background-image {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 50vh;
    /* Ajusta la altura según necesites */
    z-index: 1;
}

.content {
    position: relative;
    z-index: 2;
    margin-top: 20vh;
    border-radius: 10px;
    width: 80%;
}

/* .game-cover img {
    border-radius: 10px;
    width: 100%;
    height: auto;
} */
</style>