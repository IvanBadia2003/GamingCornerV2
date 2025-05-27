import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import type { Videogame } from './ProductStore'
import type { Console } from './ProductStore'
import { useProductStore } from './ProductStore'

///PARA QUE FUNCIONEN LAS COOCKIES///
interface CookieStore {
    get(name: string): Promise<{ name: string; value: string } | undefined>
    set(details: {
        name: string
        value: string
        expires?: number | Date
        domain?: string
        path?: string
        sameSite?: 'Lax' | 'Strict' | 'None'
    }): Promise<void>
    delete(name: string): Promise<void>
}

declare var cookieStore: CookieStore





export const useCartStore = defineStore('CartStore', () => {


    const cartProducts = reactive<Console[] | Videogame[]>([])          // Productos del carrito de la base de datos
    const cartCountCookies = ref<number>(0);                     // Cantidad de productos en la cookie

    const error = ref<string | null>(null)
    const cookieName = "cartCookie";

    const cartProduct = reactive<Videogame | Console>({ productId: 0, sales: '' } as Videogame | Console)

    async function addToCartCookie(productId: number) {
        debugger
        const time = 5 * 60 * 1000; // 5 minutos

        try {
            // Obtener la cookie actual
            const cookie = await cookieStore.get(cookieName);
            let currentCart: number[] = [];

            if (cookie?.value) {
                currentCart = JSON.parse(cookie.value);
            }

            // Agregar el producto solo si no está ya
            if (!currentCart.includes(productId)) {
                currentCart.push(productId);
            }

            // Establecer la cookie con los nuevos valores
            await cookieStore.set({
                name: cookieName,
                value: JSON.stringify(currentCart),
                expires: Date.now() + time
            });

            await updateCartCount();

        } catch (error) {
            console.error("Error al actualizar la cookie del carrito:", error);
        }
    }

    const updateCartCount = async () => {
        
        try {
            const cookie = await cookieStore.get(cookieName);
            const cart = cookie?.value ? JSON.parse(cookie.value) : [];
            cartCountCookies.value = cart.length;
        } catch {
            cartCountCookies.value = 0;
        }
    };

    const getCartProducts = async () => {
        debugger
        try {
            const cookie = await cookieStore.get(cookieName);
            const IdsCartCookie = cookie?.value ? JSON.parse(cookie.value) : [];
            cartProducts.splice(0, cartProducts.length); // Limpiar el array antes de agregar nuevos productos
            for (const Id of IdsCartCookie) {
                const response = await axios.get('http://localhost:5000/Product/' + Id)
                cartProducts.push(response.data); // Agregar el producto al array
            }

            console.log(cartProducts);
            
        } catch (err) {
            error.value = 'Error al obtener los productos del carrito';
        }
    }

    

    return {
        addToCartCookie,
        cartProducts,
        cartProduct,
        error,
        updateCartCount,
        getCartProducts
    }
})
