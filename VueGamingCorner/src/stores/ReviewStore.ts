import { defineStore } from 'pinia'
import { ref, computed, reactive, nextTick } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import type { Videogame } from './ProductStore'
import type { Console } from './ProductStore'
import { useProductStore } from './ProductStore'
import { useUserStore } from './UserStore'

export interface CreateReview{
    comment: string
    rating: number
    productId: number
    userId: number
}

export interface Review{
    id: number
    comment: string
    rating: number
    productName: string
    userName: string
    createdDate: Date
}

export const useReviewStore = defineStore('ReviewStore', () => {

    const userStore = useUserStore();

    // Array reactivo que almacena los productos del carrito (pueden ser consolas o videojuegos)
    const reviews = reactive<Review[]>([]);

    // Variable para almacenar mensajes de error
    const error = ref<string | null>(null);

    // Producto temporal reactivo (no se utiliza directamente aquí, pero puede usarse en formularios o ediciones)
    const review = reactive<Review>({id: 0, comment: '', rating: 0, userName: '', createdDate: new Date,  productName: ''});

    const AverageRating = ref<number | null>(null);
    const ReviewCount = ref<number | null>(null);

    // Añade un producto al carrito guardado en la base de datos (modo autenticado)
    async function addReview(review: CreateReview) {
        try {
            var response = await axios.post('http://localhost:5000/Review', review);
            reviews.push(...response.data)
        } catch (error) {
            console.error("Error al añadir a la base de datos:", error);
        }
    }

         //Obtiene los productos del carrito almacenados en la cookie y los carga desde la API
     const getReviewByUserId = async () => {
        reviews.splice(0, reviews.length);
    debugger
            try {
                const response = await axios.get('http://localhost:5000/Review/User/' + userStore.user.userId);
                    
                    reviews.push(...response.data); // Solo empujamos el producto

                    ReviewCount.value = reviews.length
            } catch (err) {
                error.value = 'Error al obtener los productos del carrito desde la API';
            }
        
    };
    

    const getReviewByProductId = async (productId: number) => {
        reviews.splice(0, reviews.length);
    debugger
            try {
                const response = await axios.get('http://localhost:5000/Review/Product/' + productId);

                reviews.push(...response.data); 
                ReviewCount.value = reviews.length

            } catch (err) {
                error.value = 'Error al obtener los productos del carrito desde la API';
            }
        
    };

    const getAverageRatingByProductId = async (productId: number) => {
    debugger
            try {
                const response = await axios.get('http://localhost:5000/Review/AverageRating/' + productId);

                AverageRating.value = response.data
            } catch (err) {
                error.value = 'Error al obtener los productos del carrito desde la API';
            }
        
    };
    
    
    

    return {

        error,
        AverageRating,
        ReviewCount,
        reviews,
        getAverageRatingByProductId,
        getReviewByProductId,
        getReviewByUserId,
        addReview



    }
})


