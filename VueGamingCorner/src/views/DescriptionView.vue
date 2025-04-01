<script setup lang="ts">
import PrincipalImage from '@/components/Images/PrincipalImage.vue';
import { computed, ref } from 'vue';
import CardComponent from '@/components/CardComponent.vue'


const loading = ref(false)

function reserve() {
    loading.value = true
    setTimeout(() => (loading.value = false), 2000)
}



/* PARA EL CARRUSEL */

const images = ref([
    "https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png",
    "https://preview.redd.it/zero-dawn-remastered-pre-load-v0-z4vhl1l56lwd1.jpeg?auto=webp&s=061dd572a460a5883ca3d6c86e95d6a0fefdffae",
    "https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png",
    "https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png"

]);

const selectedImage = ref(images.value[0]);




/* PARA LA DESCRIPCIÓN */
const maxLength = 800; // Caracteres antes de truncar
const isExpanded = ref(false);

const truncatedDescription = computed(() =>
    description.value.length > maxLength
        ? description.value.substring(0, maxLength) + '...'
        : description.value
);

const description = ref(
    `Obligados a rebelarse. Perseguidos desde dentro. Esto es Call of Duty: Black Ops 6.
Desarrollado por Treyarch y Raven, Black Ops 6 es un thriller de acción y espionaje ambientado a principios de los 90, un periodo de transición y agitación en el ámbito político mundial caracterizado por el fin de la Guerra Fría y el auge de Estados Unidos como superpotencia. Con una apasionante narrativa y libre de ataduras, presentamos el inconfundible Black Ops.
La campaña de Black Ops 6 ofrece una mecánica dinámica a cada momento, distintos espacios de juego con escenas impactantes y situaciones, asaltos de alto riesgo y actividades de espionaje clandestinas cargados de acción.
En esta experiencia Multijugador inmejorable, los jugadores pondrán a prueba sus habilidades en 16 nuevos mapas, que incluyen 12 mapas principales 6c6 y 4 mapas de asalto que pueden jugarse en 2c2 o 6c6.
Black Ops 6 marca también el regreso de Zombis por rondas, con dos mapas nuevos de ese modo tan querido en el que los jugadores acaban con hordas de no muertos. Entre el contenido adicional que vendrá, habrá disponibles más mapas emocionantes y experiencias demoledoras, tanto para el Multijugador como para Zombis.
</br>Obligados a rebelarse. Perseguidos desde dentro. Esto es Call of Duty: Black Ops 6.
Desarrollado por Treyarch y Raven, Black Ops 6 es un thriller de acción y espionaje ambientado a principios de los 90, un periodo de transición y agitación en el ámbito político mundial caracterizado por el fin de la Guerra Fría y el auge de Estados Unidos como superpotencia. Con una apasionante narrativa y libre de ataduras, presentamos el inconfundible Black Ops.
La campaña de Black Ops 6 ofrece una mecánica dinámica a cada momento, distintos espacios de juego con escenas impactantes y situaciones, asaltos de alto riesgo y actividades de espionaje clandestinas cargados de acción.
En esta experiencia Multijugador inmejorable, los jugadores pondrán a prueba sus habilidades en 16 nuevos mapas, que incluyen 12 mapas principales 6c6 y 4 mapas de asalto que pueden jugarse en 2c2 o 6c6.
Black Ops 6 marca también el regreso de Zombis por rondas, con dos mapas nuevos de ese modo tan querido en el que los jugadores acaban con hordas de no muertos. Entre el contenido adicional que vendrá, habrá disponibles más mapas emocionantes y experiencias demoledoras, tanto para el Multijugador como para Zombis.`
);


const toggleExpand = () => {
    isExpanded.value = !isExpanded.value;
};



/* PARA LOS PRODUCTOS SIMILARES */
const populars = [
    {
        img: "image/1.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/2.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/3.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/4.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/1.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/2.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/3.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
    {
        img: "image/4.png",
        title: "Appel Mac Book Pro",
        price: "$ 93.358.01",
        bio: " Small plates, salads & sandwiches - an intimate setting with 12 indoor seats plus patio seating.",
    },
]

/* RESEÑAS */
const rating = ref(4.5)

</script>


<template>




    <v-container fluid class="game-description">
        <!-- Imagen de fondo -->
        <v-img class="background-image"
            src="https://helios-i.mashable.com/imagery/articles/02aR11GDLtX9X3OuVX7Oh9E/images-4.fill.size_2000x1125.v1667406172.png"
            cover></v-img>

        <!-- Contenedor del contenido -->
        <v-container class="content">
            <v-row style="width: 80%;" class="">
                <!-- Imagen principal del juego -->
                <v-col cols="12" md="6">
                    <v-sheet class="game-cover">
                        <v-img
                            src="https://preview.redd.it/zero-dawn-remastered-pre-load-v0-z4vhl1l56lwd1.jpeg?auto=webp&s=061dd572a460a5883ca3d6c86e95d6a0fefdffae"
                            cover width="100%" class="img" />
                    </v-sheet>
                </v-col>

                <!-- Información del juego -->
                <v-col cols="12" md="6" class="game-info">
                    <v-card height="100%" :disabled="loading" :loading="loading"
                        class="d-flex flex-column align-center justify-space-around text-center "
                        style=" background: #1A2A3EB3">

                        <v-card-title class="text-overline">
                            <h1 class="game-title">God of war</h1>
                        </v-card-title>

                        <div class="d-flex py-3 justify-space-between bg-background">
                            <v-list-item density="compact">
                                <v-list-item-subtitle>123</v-list-item-subtitle>
                            </v-list-item>

                            <v-list-item density="compact">
                                <v-list-item-subtitle>48%</v-list-item-subtitle>
                            </v-list-item>
                            <v-list-item density="compact">
                                <v-list-item-subtitle>48%</v-list-item-subtitle>
                            </v-list-item>
                        </div>
                        <div class="d-flex py-3 justify-space-between">
                            <v-list-item density="compact">
                                <v-list-item-subtitle>123</v-list-item-subtitle>
                            </v-list-item>

                            <v-list-item density="compact">
                                <v-list-item-subtitle>48%</v-list-item-subtitle>
                            </v-list-item>
                        </div>

                        <v-card-actions>
                            <v-btn color="deep-purple-lighten-2" text="Añadir a favoritos" border
                                @click="reserve"></v-btn>
                            <router-link to="/cart">
                                <v-btn color="deep-purple-lighten-2" text="Comprar Ahora" border
                                    @click="reserve"></v-btn></router-link>
                        </v-card-actions>

                    </v-card>

                </v-col>

            </v-row>
            <v-row style="width: 100%;" class="pt-15">
                <v-col cols="12" md="6">
                    <h3>MULTIMEDIA</h3>

                    <!-- Imagen principal -->
                    <v-img :src="selectedImage" class="main-image rounded-lg border-primary" cover></v-img>

                    <!-- Miniaturas -->
                    <v-row class="mt-3 thumbnails">
                        <v-col v-for="(image, index) in images" :key="index" cols="3">
                            <v-img :src="image" class="thumbnail rounded-lg" cover
                                @click="selectedImage = image"></v-img>
                        </v-col>
                    </v-row>

                </v-col>
                <v-col cols="12" md="6">
                    <h3>INFORMACIÓN</h3>

                    <v-card class="game-card">
                        <v-card-text>
                            <div class="review-score">
                                <v-avatar class="score-circle" color="green-darken-2">9</v-avatar>
                                <span class="reviews">Basado en 30 reseñas</span>
                            </div>
                            <v-divider class="my-3"></v-divider>
                            <v-container>
                                <v-row dense>
                                    <v-col cols="12">
                                        <strong>Género:</strong>
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <strong>Fecha de lanzamiento:</strong>
                                    </v-col>
                                    <v-col cols="12" sm="6">
                                        24 de octubre de 2024
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <strong>Desarrollador:</strong>
                                    </v-col>
                                    <v-col cols="12" sm="6">
                                        Raven Software Treyarch
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <strong>Distribuidor:</strong>
                                    </v-col>
                                    <v-col cols="12" sm="6">
                                        Activision
                                    </v-col>

                                    <v-col cols="12" sm="6">
                                        <strong>Instalación:</strong>
                                    </v-col>
                                    <v-col cols="12" sm="6">
                                        Cómo activar tu producto
                                    </v-col>
                                </v-row>
                            </v-container>

                            <v-divider class="my-3"></v-divider>
                            <div class="tags">
                                <v-chip class="mr-2" color="blue-darken-3">UN JUGADOR</v-chip>
                                <v-chip class="mr-2" color="blue-darken-3">UN JUGADOR</v-chip>
                                <v-chip color="blue-darken-3">UN JUGADOR</v-chip>
                            </div>
                            <v-img class="pegi-logo" src="https://www.pegi.info/themes/custom/pegi/public/pegi18.png"
                                height="50" contain></v-img>
                        </v-card-text>
                    </v-card>

                </v-col>
            </v-row>
            <v-row style="width: 100%;" class="pt-15">


                <v-col cols="12">
                    <h3>ACERCA DE</h3>
                    <p class="game-text">
                        {{ isExpanded ? description : truncatedDescription }}

                    </p>
                    <v-btn variant="text" class="text-primary" @click="toggleExpand">
                        {{ isExpanded ? 'Ver menos' : 'Ver más' }}
                    </v-btn>


                </v-col>

            </v-row>

            <v-row style="width: 100%;" class="py-15">


                <v-col cols="12">
                    <h3>CONFIGURACIÓN</h3>
                    <v-row dense>
                        <v-col cols="12" lg="6">
                            <h4>MINIMA</h4>

                            <v-row dense>
                                <v-col cols="5">
                                    <strong>SO:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Windows 10 - 64-bit
                                </v-col>

                                <v-col cols="5">
                                    <strong>PROCESADOR:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Intel Core i5-2500K / AMD FX-6300
                                </v-col>

                                <v-col cols="5">
                                    <strong>MEMORIA:</strong>
                                </v-col>
                                <v-col cols="7">
                                    8 GB RAM
                                </v-col>

                                <v-col cols="5">
                                    <strong>GRÁFICOS:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Nvidia GeForce GTX 770 2GB / AMD Radeon R9 280 3GB
                                </v-col>

                                <v-col cols="5">
                                    <strong>ALMACENAMIENTO:</strong>
                                </v-col>
                                <v-col cols="7">
                                    150 GB available space
                                </v-col>
                            </v-row>

                        </v-col>
                        <v-col cols="12" lg="6">
                            <h4>MAXIMA</h4>
                            <v-row dense>
                                <v-col cols="5">
                                    <strong>SO:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Windows 10 - 64-bit
                                </v-col>

                                <v-col cols="5">
                                    <strong>PROCESADOR:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Intel Core i5-2500K / AMD FX-6300
                                </v-col>

                                <v-col cols="5">
                                    <strong>MEMORIA:</strong>
                                </v-col>
                                <v-col cols="7">
                                    8 GB RAM
                                </v-col>

                                <v-col cols="5">
                                    <strong>GRÁFICOS:</strong>
                                </v-col>
                                <v-col cols="7">
                                    Nvidia GeForce GTX 770 2GB / AMD Radeon R9 280 3GB
                                </v-col>

                                <v-col cols="5">
                                    <strong>ALMACENAMIENTO:</strong>
                                </v-col>
                                <v-col cols="7">
                                    150 GB available space
                                </v-col>
                            </v-row>

                        </v-col>

                    </v-row>


                </v-col>

            </v-row>

        </v-container>


        <v-row class="bg-primary my-15">
            <v-container class="content mt-0">
                <v-col cols="12">
                    <h3>Productos similares</h3>
                    <v-carousel height="auto" hide-delimiters style=" position: relative;">
                        <!-- Botón Anterior -->
                        <template v-slot:prev="{ props }">
                            <v-btn variant="elevated" class="custom-prev" @click="props.onClick"
                                style="position: absolute;  left: 0;">
                                ◀
                            </v-btn>
                        </template>

                        <!-- Botón Siguiente -->
                        <template v-slot:next="{ props }">
                            <v-btn variant="elevated" class="custom-next" @click="props.onClick"
                                style="position: absolute;  right:  0;">
                                ▶
                            </v-btn>
                        </template>
                        <v-carousel-item v-for="(item, i) in 2" :key="i">
                            <v-row>
                                <v-col v-for="(item, i) in 4" :key="i" cols="6" lg="3">

                                    <CardComponent title="Silent Hill"
                                        src="https://media.vandal.net/m/4-2024/21/202442110133878_1.jpg" />
                                </v-col>

                            </v-row>

                        </v-carousel-item>
                    </v-carousel>
                </v-col>
            </v-container>

        </v-row>
        <v-row class="bg-primary my-15">
            <v-container class="content mt-0">
                <v-col cols="12">
                    <h3>CONSOLAS COMPATIBLES</h3>
                    <v-carousel height="auto" hide-delimiters style=" position: relative;">
                        <!-- Botón Anterior -->
                        <template v-slot:prev="{ props }">
                            <v-btn variant="elevated" class="custom-prev" @click="props.onClick"
                                style="position: absolute;  left: 0;">
                                ◀
                            </v-btn>
                        </template>

                        <!-- Botón Siguiente -->
                        <template v-slot:next="{ props }">
                            <v-btn variant="elevated" class="custom-next" @click="props.onClick"
                                style="position: absolute;  right:  0;">
                                ▶
                            </v-btn>
                        </template>
                        <v-carousel-item v-for="(item, i) in 2" :key="i">
                            <v-row>
                                <v-col v-for="(item, i) in 4" :key="i" cols="6" lg="3">

                                    <CardComponent title="Silent Hill"
                                        src="https://media.vandal.net/m/4-2024/21/202442110133878_1.jpg" />
                                </v-col>

                            </v-row>

                        </v-carousel-item>
                    </v-carousel>
                </v-col>
            </v-container>

        </v-row>

        <v-container class="content mt-0">
            <v-row style="width: 100%;" class="pt-15">
                <v-col cols="12">
                    <h3>RESEÑAS</h3>
                    <v-row>
                        <v-col cols="12" sm="6" md="4" lg="3" v-for="(item, index) in 4" :key="index">
                            <v-card class="review-card pa-4" elevation="3">
                                <v-card-title class="text-center font-weight-bold text-white">
                                    Usuario
                                </v-card-title>

                                <v-divider class="mx-auto mb-3" thickness="2" width="90%"></v-divider>

                                <v-card-subtitle class="text-h6 font-weight-bold text-center">
                                    SILENT HILL 2
                                </v-card-subtitle>

                                <v-card-text class="">
                                    <p>Hermano que juegazo, pero puto juegazo no? OMG, ¡Aún estoy flipando! ¡Hermano!
                                    </p>
                                </v-card-text>

                                <v-divider class="mx-auto mt-3" thickness="2" width="90%"></v-divider>

                                <v-rating v-model="rating" active-color="yellow-accent-4" color="white" half-increments
                                    density="comfortable" hover></v-rating>

                            </v-card>
                        </v-col>
                    </v-row>
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
    display: flex;
    flex-direction: column;
    align-items: center;
}

/* .game-cover img {
    border-radius: 10px;
    width: 100%;
    height: auto;
} */




.main-image {
    border: 2px solid #1976d2;

}



.thumbnail {
    cursor: pointer;
    border: 2px solid transparent;
    transition: border 0.3s
}

.thumbnail:hover {
    border: 2px solid #1976d2;
}







.game-card {
    background: #1e293b;
    color: white;
    padding: 16px;
    border-radius: 8px;
}

.review-score {
    display: flex;
    align-items: center;
}

.score-circle {
    width: 40px;
    height: 40px;
    font-size: 20px;
    color: white;
    text-align: center;
}

.reviews {
    margin-left: 12px;
    font-size: 14px;
}

.tags {
    display: flex;
    flex-wrap: wrap;
    gap: 4px;
}

.pegi-logo {
    margin-top: 12px;
    align-self: flex-end;
}
</style>