import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import axios from 'axios'
import router from '@/router'

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
    // Estado
    const products = ref<[]>([])
    const error = ref<string | null>(null)
    const cookieName = "cartCookie";

    const product = ref<null>()

    async function addToCartCookie(productId: number) {
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
        } catch (error) {
            console.error("Error al actualizar la cookie del carrito:", error);
        }
    }

    const getCartItems = async (): Promise<number[]> => {
        const cookie = await cookieStore.get(cookieName);
        if (!cookie?.value) return [];
      
        try {
          return JSON.parse(cookie.value);
        } catch {
          return [];
        }
      }


    return {
        addToCartCookie,
        products,
        product,
        error,
        getCartItems
    }
})
