<script setup lang="ts">
import PrincipalImage from '@/components/Images/PrincipalImage.vue';
import VideogameCardInformation from '@/components/Description/InformationCard.vue';
import Specifications from '@/components/Description/Specifications.vue';
import { computed, nextTick, onMounted, ref, watchEffect } from 'vue';
import CardComponent from '@/components/CardComponent.vue'
import { useProductStore, type Videogame } from '@/stores/ProductStore';
import { useRoute } from 'vue-router';
import ReviewCard from '@/components/ReviewCard.vue'
import pegi3 from '@/assets/Pegi/Pegi3.svg'
import pegi7 from '@/assets/Pegi/Pegi7.svg'
import pegi12 from '@/assets/Pegi/Pegi12.svg'
import pegi16 from '@/assets/Pegi/Pegi16.svg'
import pegi18 from '@/assets/Pegi/Pegi18.svg'
import { useCartStore } from '@/stores/CartStore';
import { useUserStore } from '@/stores/UserStore';
import router from '@/router';
import { useFavouriteStore } from '@/stores/FavouriteStore';
import { useReviewStore, type CreateReview, type Review } from '@/stores/ReviewStore';

onMounted(() => {
    const id = parseInt(route.params.id as string)
    productStore.getProductById(id);
    reviewStore.getAverageRatingByProductId(id);
    reviewStore.getReviewByProductId(id)

});


import { useCloudinaryStore } from '@/stores/CloudinaryStore';

const cloudinaryStore = useCloudinaryStore();

const pegiMap: Record<number, string> = {
    3: pegi3,
    7: pegi7,
    12: pegi12,
    16: pegi16,
    18: pegi18
}

const route = useRoute()

const productStore = useProductStore();
const favouriteStore = useFavouriteStore();
const reviewStore = useReviewStore();
const userStore = useUserStore();
const cartStore = useCartStore();
const loading = ref(false)
const dialog = ref(false)

// Es juego
const isGame = computed(() => {
    return !!productStore.product && 'developer' in productStore.product && 'distributor' in productStore.product
})

async function reserve(productId: number) {
    await cartStore.addToCart(productId); // Espera que se añada correctamente
    await nextTick()
    router.push('/cart'); // Luego navega al carrito
}


/* PARA EL CARRUSEL */

const selectedImage = ref("");

// Actualizar cuando productImages cambie
watchEffect(() => {
    const productImages = productStore.product?.productImages;
    if (productImages) {
        const firstContentImage = Object.entries(productImages)
            .find(([key]) => key.toLowerCase().startsWith('content'));

        if (firstContentImage) {
            selectedImage.value = firstContentImage[1] ?? '';
        }
    }
});
// //Obtenemos los datos de cloudinary
// const mediaCloudinary = computed(() => cloudinaryStore.getMedia('products', productStore.product.id));
// // Creamos un array de imágenes miniatura (solo las que existan)
// const imagesCloudinary = computed(() =>
//     ['main', 'background', 'content1', 'content2', 'content3', 'content4']
//         .map(key => mediaCloudinary.value[key])
//         .filter(url => !!url) // Solo si existe
// );


/* PARA LA DESCRIPCIÓN */
const maxLength = 800; // Caracteres antes de truncar
const isExpanded = ref(false);

// Cambiar los saltos de línea por <br> en la descripción
const descriptionTxt = computed(() => {
    let truncatedDescr = productStore.product?.description?.replace(/\n/g, "<br>") ?? ''
    return truncatedDescr;

});


// Truncar la descripción si excede el maxLength
const truncatedDescription = computed(() => {
    const description = descriptionTxt.value ?? ''

    const truncatedText = description.length > maxLength
        ? description.substring(0, maxLength) + '...'
        : description

    return truncatedText
})

const toggleExpand = () => {
    isExpanded.value = !isExpanded.value;
};


const rating = ref<number>(0)
const review = ref('')

const sendReview = () => {

    const reviewData: CreateReview = {
        comment: review.value,
        rating: rating.value,
        userId: userStore.user.userId,
        productId: productStore.product.id
    };

    reviewStore.addReview(reviewData)
    rating.value = 0
    review.value = ''


};

const isFavourite = computed(() =>
    favouriteStore.favouriteProducts.some(fav => fav.product.id === productStore.product.id)
)

async function toggleFavourite(productId: number) {
  if (isFavourite.value) {
    await favouriteStore.deleteFavourite(productId);
  } else {
    await favouriteStore.addFavourite(productId);
  }
}



</script>


<template>



    <v-dialog v-model="dialog" max-width="600">
        <v-card>
            <v-card-title class="text-h6">
                Reseña para {{ productStore.product?.name }}
            </v-card-title>

            <v-card-text>
                <v-rating v-model="rating" color="yellow darken-3" background-color="grey lighten-1" length="10"
                    half-increments hover size="32" class="mb-4"></v-rating>

                <v-textarea v-model="review" label="Escribir reseña" rows="4" auto-grow outlined></v-textarea>
            </v-card-text>

            <v-card-actions class="justify-end">
                <v-btn @click="dialog = false">Cancelar</v-btn>
                <v-btn @click="sendReview" color="primary">Enviar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>

    <v-container fluid class="game-description">
        <!-- Imagen de fondo -->
        <v-img class="background-image" :src="productStore.product?.productImages?.background || ''" cover>
        </v-img>

        <!-- Contenedor del contenido -->
        <v-container class="content">
            <v-row style="width: 80%;" class="">
                <!-- Imagen principal del juego -->
                <v-col cols="12" md="6">
                    <v-sheet class="game-cover" elevation="5">
                        <v-img :src="productStore.product?.productImages?.main || ''" cover width="100%" class="img" />
                    </v-sheet>
                </v-col>

                <!-- Información del juego -->
                <v-col cols="12" md="6" class="game-info">
                    <v-card height="100%" :disabled="loading" :loading="loading"
                        class="d-flex flex-column align-center justify-space-around text-center "
                        style=" background: #1A2A3EB3">

                        <v-card-title class="text-overline">
                            <h1 class="game-title">{{ productStore.product?.name }}</h1>
                        </v-card-title>

                        <div v-if="productStore.product && !('isChecked' in productStore.product)"
                            class="d-flex py-3 justify-space-between bg-background" style="border-radius: 50px;">
                            <v-list-item density="compact">
                                <v-list-item-subtitle>
                                    <v-avatar>
                                        <v-img alt="Steam"
                                            src="data:image/jpeg;base64,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"></v-img>
                                    </v-avatar>
                                </v-list-item-subtitle>
                            </v-list-item>
                            <v-divider :thickness="2" class="border-opacity-100" vertical></v-divider>
                            <v-list-item density="compact">
                                <v-list-item-subtitle><v-icon> {{ productStore.product?.stock === 0 ? "mdi-close" :
                                    "mdi-check" }}</v-icon> Stock</v-list-item-subtitle>
                            </v-list-item>
                            <v-divider :thickness="2" class="border-opacity-100" vertical></v-divider>
                            <v-list-item density="compact">
                                <v-list-item-subtitle>
                                    <v-avatar rounded="0" size="50">
                                        <v-img alt="Steam"
                                            :src="pegiMap[(productStore.product as Videogame).pegi ?? 3]">
                                        </v-img>
                                    </v-avatar>
                                </v-list-item-subtitle>
                            </v-list-item>
                        </div>
                        <v-row class="py-3 align-center" dense>
                            <v-col v-if="productStore.product && !('isChecked' in productStore.product)" cols="auto"
                                class="d-flex align-center">
                                <v-icon>mdi-tag-arrow-down</v-icon>
                                <h5 class="ml-2" style="text-decoration: line-through;">{{ productStore.product?.price
                                }}€</h5>
                            </v-col>
                            <v-col v-if="productStore.product && !('isChecked' in productStore.product)" cols="auto"
                                class="mr-2">
                                <h5 class="text-primary">-{{ productStore.product?.discount }}%</h5>
                            </v-col>
                            <v-col cols="auto" class="ml-2">
                                <h2>{{ ((productStore.product?.price as number) - ((productStore.product?.price as
                                    number) * (productStore.product?.discount as number) / 100)).toFixed(2) }}€</h2>
                            </v-col>
                        </v-row>

                        <v-card-actions>
                            <v-btn icon variant="text" :color="isFavourite ? 'red-darken-2' : 'deep-purple-lighten-2'"
                                @click="toggleFavourite(productStore.product?.id)">
                                <v-icon>{{ isFavourite ? 'mdi-heart' : 'mdi-heart-outline' }}</v-icon>
                            </v-btn>


                            <v-btn
                                v-if="productStore.product?.stock > 0 || productStore.product && 'isChecked' in productStore.product"
                                color="deep-purple-lighten-2" text="Comprar Ahora" border
                                @click="reserve(productStore.product?.id)"></v-btn>
                            <v-btn v-else color="deep-purple-lighten-2" text="Avisar cuando repongan stock"
                                border></v-btn>
                        </v-card-actions>

                    </v-card>

                </v-col>

            </v-row>
            <v-row style="width: 100%;" class="pt-15">
                <v-col cols="12" md="6">
                    <h3>MULTIMEDIA</h3>

                    <!-- Imagen principal -->
                    <v-img :src="selectedImage" class="main-image rounded-lg border-primary" cover height="400"></v-img>

                    <!-- Miniaturas -->
                    <v-row class="mt-3 thumbnails">
                        <v-col
                            v-for="([key, image], index) in Object.entries(productStore.product?.productImages || {}).filter(([key]) => key.toLowerCase().startsWith('content'))"
                            :key="index" cols="3">
                            <v-img v-if="image" :src="image" class="thumbnail rounded-lg" cover height="100"
                                @click="selectedImage = image" />
                        </v-col>

                    </v-row>

                </v-col>
                <v-col cols="12" md="6">
                    <h3>INFORMACIÓN</h3>

                    <v-card class="game-card">
                        <v-card-text>
                            <v-avatar v-if="productStore.product && 'isChecked' in productStore.product" color="">
                                <v-img :alt="productStore.product.user.name"
                                    :src="productStore.product.user.avatar"></v-img>
                            </v-avatar>
                            <div v-if="productStore.product && !('isChecked' in productStore.product)"
                                class="review-score">
                                <v-avatar class="score-circle" color="green-darken-2">{{ reviewStore.AverageRating
                                    }}</v-avatar>
                                <span class="reviews">Basado en {{ reviewStore.ReviewCount }} reseña(s)</span>
                            </div>
                            <v-divider class="my-3"></v-divider>
                            <v-container>
                                <VideogameCardInformation />
                            </v-container>

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
                    <Specifications />
                </v-col>

            </v-row>

        </v-container>


        <v-row class="bg-primary my-15" v-if="productStore.product && !('isChecked' in productStore.product)">
            <v-container class="content mt-0">
                <v-col cols="12">
                    <h3>Productos similares</h3>
                    <!-- Botón Anterior -->

                    <v-row style="width: 100%;">
                        <v-col v-for="(similarProduct, i) in productStore.similarsProducts" :key="i" cols="6" lg="3">
                            <CardComponent :title="similarProduct.name" :discount="similarProduct.discount"
                                :price="similarProduct.price" :product-id="similarProduct.id"
                                :src="similarProduct.productImages.main || ''" />
                        </v-col>

                    </v-row>

                </v-col>
            </v-container>

        </v-row>
        <v-row class="bg-primary my-15" v-if="productStore.product && !('isChecked' in productStore.product)">
            <v-container class="content mt-0">
                <v-col cols="12">
                    <h3>Productos compatibles</h3>
                    <v-row style="width: 100%;">
                        <v-col v-for="(compatibleProduct, i) in productStore.compatibleProducts" :key="i" cols="6"
                            lg="3">
                            <CardComponent :title="compatibleProduct.name" :discount="compatibleProduct.discount"
                                :price="compatibleProduct.price" :product-id="compatibleProduct.id"
                                :src="compatibleProduct.productImages?.main || ''" />
                        </v-col>

                    </v-row>
                </v-col>
            </v-container>

        </v-row>

        <v-container v-if="productStore.product && !('isChecked' in productStore.product)" class="content mt-0">
            <v-row style="width: 100%;" class="pt-15">
                <v-col cols="12">
                    <v-row>
                        <v-col cols="6">
                            <h3>RESEÑAS</h3>
                        </v-col>
                        <v-col cols="6" class="text-right" v-if="userStore.isAuthenticated">
                            <v-btn prepend-icon="mdi-plus" text="Hacer Reseña" @click="dialog = true"></v-btn>
                        </v-col>

                    </v-row>
                    <v-row>
                        <ReviewCard v-for="(item, index) in reviewStore.reviews" :key="index" :review="item" />
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
    mask-image: linear-gradient(black 50%, transparent);

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