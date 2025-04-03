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
    "https://i.blogs.es/23b32a/0000/1366_2000.jpeg",
    "https://img.redbull.com/images/c_limit,w_1500,h_1000/f_auto,q_auto/redbullcom/2022/11/8/woz7urmjqlvaat1roixn/kratos-god-of-war-ragnarok",
    "https://www.diez.hn/binrepository/1200x675/0c0/0d0/none/3014757/QLHS/god2_7637565_20240531011042.jpg"

]);

const selectedImage = ref(images.value[0]);




/* PARA LA DESCRIPCIÓN */
const maxLength = 800; // Caracteres antes de truncar
const isExpanded = ref(false);

const descriptionTxt = computed(() => {
    let truncatedDescr = description.value.replace(/\n/g, "<br>")
    return truncatedDescr;

});

    const truncatedDescription = computed(() => {
    let truncatedDescr = description.value.replace(/\n/g, "<br>")
    // Primero truncamos la descripción si excede el maxLength
    let truncatedText = descriptionTxt.value.length > maxLength
        ? descriptionTxt.value.substring(0, maxLength) + '...'
        : descriptionTxt.value;

    // Luego reemplazamos los saltos de línea por <br> en el texto truncado
    return truncatedText;
});

const description = ref(
    `God of War Ragnarök es un videojuego de acción y aventura desarrollado por Santa Monica Studio y publicado por Sony Interactive Entertainment. Es la secuela directa de God of War (2018) y continúa la historia de Kratos y su hijo Atreus, mientras navegan por los complejos mitos nórdicos y enfrentan las amenazas que surgen del inminente fin del mundo, conocido como el Ragnarök. El juego fue lanzado en noviembre de 2022 para PlayStation 4 y PlayStation 5. A continuación, se presenta un resumen detallado de la trama, los personajes y la jugabilidad del juego.

Contexto y Trama Principal:
God of War Ragnarök se desarrolla en los últimos días antes de que se desate el Ragnarök, el apocalipsis en la mitología nórdica, que es el evento que destruirá el mundo y traerá consigo la muerte de varios dioses, incluyendo a los principales como Odín y Thor. El juego sigue a Kratos, el antiguo dios griego de la guerra, y su hijo Atreus, ahora un adolescente, mientras luchan por encontrar su lugar en este nuevo mundo que está al borde de la destrucción.

La trama comienza con Kratos y Atreus tratando de vivir en relativa paz en el reino de Vanaheim, después de los eventos de la entrega anterior. Sin embargo, pronto se ven envueltos en una serie de eventos que los obligan a enfrentarse a nuevos desafíos. Atreus, quien ahora busca respuestas sobre su identidad como Loki y su rol en los acontecimientos del Ragnarök, quiere entender su destino y cómo evitar la tragedia que se avecina. Kratos, por su parte, lucha con su propio pasado y la responsabilidad de ser un padre protector, mientras trata de evitar que su hijo repita sus propios errores y se convierta en una figura de destrucción como él lo fue en su juventud.

Personajes Principales:
1. Kratos: Es el protagonista de la serie, un hombre endurecido por la guerra y la pérdida, pero que ahora busca redención y quiere evitar que su hijo cometa los mismos errores que él. En Ragnarök, se enfrenta a la difícil tarea de ser un padre, mientras lucha por proteger a Atreus de los peligros del mundo.

2. Atreus (Loki): El hijo de Kratos, quien se ha convertido en un joven que tiene su propio camino por recorrer. A lo largo del juego, Atreus busca comprender su herencia, especialmente su vínculo con los gigantes y su identidad como Loki, el dios de las travesuras. Atreus también tiene un papel clave en la lucha contra el Ragnarök y, a diferencia de su padre, está mucho más dispuesto a desafiar a los dioses y cambiar el curso de los eventos.

3. Odín: El principal antagonista del juego, Odín es el líder de los dioses de Asgard. Un dios sabio pero manipulador y calculador, Odín está dispuesto a hacer todo lo necesario para evitar el Ragnarök y mantener su poder. A lo largo del juego, su relación con Kratos y Atreus se vuelve cada vez más tensa y peligrosa.

4. Thor: El dios del trueno, hijo de Odín y uno de los antagonistas principales. Después de la muerte de su hijos en el primer juego, Thor se presenta como un personaje mucho más oscuro y violento, aunque sigue siendo una figura trágica, atrapada en las expectativas de su padre.

5. Freya: En God of War (2018), Freya fue una aliada, pero en Ragnarök se convierte en una enemiga después de la muerte de su hijo Baldur a manos de Kratos. La relación entre Freya y Kratos es tensa, pero su historia también está llena de tragedia y complejidad, ya que busca venganza por la muerte de su hijo, mientras también lidia con su propia culpabilidad.

6. Mimir: El sabio decapitado y aliado cercano de Kratos y Atreus, que ofrece consejos y conocimientos durante su travesía. Mimir sigue siendo un personaje clave en la historia, proporcionando información vital sobre los eventos del Ragnarök y los dioses nórdicos.
`
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
                            src="https://image.api.playstation.com/vulcan/ap/rnd/202207/1210/aqZdSwWyy9JcQ66BxHDKrky6.jpg"
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
                    <p class="game-text" v-html="isExpanded ? descriptionTxt : truncatedDescription"></p>

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
                                    GOD OF WAR: RAGNAROK
                                </v-card-subtitle>

                                <v-card-text class="">
                                    <p>Hermano que juegazo, lo recomiendo a todos ¡Aún estoy flipando! ¡Hermano!
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