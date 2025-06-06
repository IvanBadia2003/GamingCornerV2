import { defineStore } from 'pinia'
import { ref, computed, reactive, nextTick } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import type { Videogame } from './ProductStore'
import type { Console } from './ProductStore'
import { useProductStore } from './ProductStore'
import { useUserStore } from './UserStore'

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

    const userStore = useUserStore();

    // Array reactivo que almacena los productos del carrito (pueden ser consolas o videojuegos)
    const cartProducts = reactive<Console[] | Videogame[]>([]);

    // Contador de productos almacenados en la cookie (solo se usa si el usuario no está autenticado)
    const cartCountCookies = ref<number>(0);

    // Variable para almacenar mensajes de error
    const error = ref<string | null>(null);

    // Nombre de la cookie donde se guardan los productos del carrito para usuarios no autenticados
    const cookieName = "cartCookie";

    // Producto temporal reactivo (no se utiliza directamente aquí, pero puede usarse en formularios o ediciones)
    const cartProduct = reactive<Videogame | Console>({ productId: 0, sales: '' } as Videogame | Console);

    // Añade un producto al carrito, ya sea a través de la API o guardándolo en cookies si el usuario no está autenticado
    async function addToCart(productId: number) {
        if (userStore.isAuthenticated) {
            addToCartAPI(productId);
        } else {
            addToCartCookie(productId);
        }
        await getCartProducts()

    }

    // Añade un producto al carrito guardado en la base de datos (modo autenticado)
    async function addToCartAPI(productId: number) {
        try {
            axios.post('http://localhost:5000/Basket', { userId: userStore.user.userId, productId: productId });
            await nextTick(); // Asegura que la UI se actualice después de la operación


            updateCartCount(); // Actualiza el contador desde la base de datos
        } catch (error) {
            console.error("Error al añadir a la base de datos:", error);
        }
    }

    // Añade un producto al carrito guardado en cookies (modo invitado)
    async function addToCartCookie(productId: number) {
         
        const time = 5 * 60 * 1000; // Duración de la cookie: 5 minutos

        try {
            // Obtener la cookie actual del carrito
            const cookie = await cookieStore.get(cookieName);
            let currentCart: number[] = [];

            // Si hay productos guardados, los parseamos
            if (cookie?.value) {
                currentCart = JSON.parse(cookie.value);
            }

            // Agregamos el producto solo si aún no está en la lista
            if (!currentCart.includes(productId)) {
                currentCart.push(productId);
            }

            // Guardamos nuevamente la cookie con el producto añadido
            await cookieStore.set({
                name: cookieName,
                value: JSON.stringify(currentCart),
                expires: Date.now() + time // Fecha de expiración de la cookie
            });

            // Actualizamos el contador de productos
            await nextTick(); // Asegura que la UI se actualice después de la operación

            updateCartCount();
            getCartProducts();

        } catch (error) {
            console.error("Error al actualizar la cookie del carrito:", error);
        }
    }

    async function removeFromCart(productId: number) {
        if (userStore.isAuthenticated) {
            await removeFromCartAPI(productId);
        } else {
            await removeFromCartCookie(productId);
        }

        await nextTick(); // Asegura que la UI se actualice después de la operación

        updateCartCount();
        getCartProducts(); // Para refrescar los productos visibles
    }

    async function removeFromCartCookie(productId: number) {
        try {
            const cookie = await cookieStore.get(cookieName);
            let currentCart: number[] = cookie?.value ? JSON.parse(cookie.value) : [];

            // Filtramos el producto a eliminar
            currentCart = currentCart.filter(id => id !== productId);

            // Reescribimos la cookie sin ese producto
            await cookieStore.set({
                name: cookieName,
                value: JSON.stringify(currentCart),
                expires: Date.now() + (5 * 60 * 1000) // Mismo tiempo que antes
            });
        } catch (error) {
            console.error("Error al eliminar el producto de la cookie:", error);
        }
    }

    async function removeFromCartAPI(productId: number) {
        try {
            await axios.delete(`http://localhost:5000/Basket/User/${userStore.user.userId}/Product/${productId}`);
        } catch (error) {
            console.error("Error al eliminar el producto de la base de datos:", error);
        }
    }



    //Actualiza el contador de productos del carrito basándose en la cookie
    const updateCartCount = async () => {
        if (userStore.isAuthenticated) {
            try {
                cartCountCookies.value = cartProducts.length; // Actualiza el contador desde los productos cargados
            } catch {
                cartCountCookies.value = 0;
            }
        } else {
            try {
                const cookie = await cookieStore.get(cookieName);
                const cart = cookie?.value ? JSON.parse(cookie.value) : [];
                cartCountCookies.value = cart.length;
            } catch {
                cartCountCookies.value = 0;
            }
        }
    };



    //Obtiene los productos del carrito almacenados en la cookie y los carga desde la API
    const getCartProducts = async () => {
        cartProducts.splice(0, cartProducts.length);
         
        if (userStore.isAuthenticated) {
            try {
                const response = await axios.get('http://localhost:5000/Basket/User/' + userStore.user.userId);

                // La API devuelve un array de objetos con estructura { userId, product }
                const cartItems = response.data;

                for (const item of cartItems) {
                    cartProducts.push(item.product); // Solo empujamos el producto
                }
            } catch (err) {
                error.value = 'Error al obtener los productos del carrito desde la API';
            }
        } else {
            try {
                const cookie = await cookieStore.get(cookieName);
                const IdsCartCookie = cookie?.value ? JSON.parse(cookie.value) : [];

                for (const Id of IdsCartCookie) {
                    const response = await axios.get('http://localhost:5000/Product/' + Id);
                    cartProducts.push(response.data);
                }
            } catch (err) {
                error.value = 'Error al obtener los productos del carrito';
            }
        }
        updateCartCount();
    };


    // Precio oficial sin descuento
    const totalCartOficialPrice = computed(() => {
        return cartProducts.reduce((total, product) => {
            return total + (product.price ?? 0);
        }, 0);
    });

    const totalCartOficialPriceRounded = computed(() => {
        return Number(totalCartOficialPrice.value.toFixed(2));
    });


    // Precio con descuento
    const totalCartPrice = computed(() => {
        return cartProducts.reduce((total, product) => {
            const price = product.price ?? 0;
            const discount = product.discount ?? 0;
            const finalPrice = price - (price * discount / 100);
            return total + finalPrice;
        }, 0);
    });

    const totalCartPriceRounded = computed(() => {
        return Number(totalCartPrice.value.toFixed(2));
    });

    // Diferencia entre precio oficial y con descuento
    const totalCartDiscountPrice = computed(() => {
        const discount = totalCartOficialPrice.value - totalCartPrice.value;
        return discount.toFixed(2);
    });

    async function transferCookieCartToDatabase() {
        if (!userStore.isAuthenticated) return;

        try {
            const cookie = await cookieStore.get(cookieName);
            const ids = cookie?.value ? JSON.parse(cookie.value) : [];

            for (const productId of ids) {
                await addToCartAPI(productId); // Reutilizas la función ya creada
            }

            // Una vez migrados, borra la cookie
            cookieStore.delete(cookieName);

            updateCartCount();
            getCartProducts();
        } catch (error) {
            console.error("Error al migrar productos del carrito:", error);
        }
    }

    return {
        addToCartCookie,
        cartProducts,
        cartProduct,
        error,
        updateCartCount,
        getCartProducts,
        totalCartDiscountPrice,
        cartCountCookies,
        totalCartPriceRounded,
        addToCart,
        addToCartAPI,
        removeFromCart,
        totalCartOficialPriceRounded,
        transferCookieCartToDatabase
    }
})


