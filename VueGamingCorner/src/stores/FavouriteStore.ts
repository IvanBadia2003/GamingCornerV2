import { defineStore } from 'pinia'
import { ref, computed, reactive, nextTick } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import type { ProductImages, Videogame } from './ProductStore'
import type { Console } from './ProductStore'
import { useProductStore } from './ProductStore'
import { useUserStore } from './UserStore'

export interface Productfavourite {
    id: number
    sales: number
    platformId: number
    name: string
    price: number
    discount: number
    system: number
    productImages: ProductImages
  }
  
  export interface Favourite {
    userId: number
    product: Productfavourite
    dateAdd: Date
    platformName: string
  }
  
export const useFavouriteStore = defineStore('FavouriteStore', () => {

    const userStore = useUserStore();

    // Array reactivo que almacena los productos del carrito (pueden ser consolas o videojuegos)
    const favouriteProducts = reactive<Favourite[]>([]);

    // Variable para almacenar mensajes de error
    const error = ref<string | null>(null);

    // Producto temporal reactivo (no se utiliza directamente aquí, pero puede usarse en formularios o ediciones)
    const favouriteProduct = reactive<Videogame | Console>({ productId: 0, sales: '' } as Videogame | Console);


    // Añade un producto al carrito guardado en la base de datos (modo autenticado)
    async function addFavourite(productId: number) {
        try {
            axios.post('http://localhost:5000/Favourite', { userId: userStore.user.userId, productId: productId });
            await nextTick(); // Asegura que la UI se actualice después de la operación
            getFavouriteProducts()
        } catch (error) {
            console.error("Error al añadir a la base de datos:", error);
        }
    }

    

    async function deleteFavourite(productId: number) {
        try {
            await axios.delete(`http://localhost:5000/Favourite/User/${userStore.user.userId}/Product/${productId}`);
            await nextTick(); // Asegura que la UI se actualice después de la operación
            getFavouriteProducts()
        } catch (error) {
            console.error("Error al eliminar el producto de la base de datos:", error);
        }
    }
    
   
     //Obtiene los productos del carrito almacenados en la cookie y los carga desde la API
     const getFavouriteProducts = async () => {
        favouriteProducts.splice(0, favouriteProducts.length);
     
            try {
                const response = await axios.get('http://localhost:5000/Favourite/User/' + userStore.user.userId);
                
                favouriteProducts.push(...response.data); // Solo empujamos el producto
                // La API devuelve un array de objetos con estructura { userId, product }

            } catch (err) {
                error.value = 'Error al obtener los productos del carrito desde la API';
            }
        
    };
    
    
    

    return {

        error,
        getFavouriteProducts,
        favouriteProducts,
        addFavourite,
        deleteFavourite,
        favouriteProduct


    }
})


