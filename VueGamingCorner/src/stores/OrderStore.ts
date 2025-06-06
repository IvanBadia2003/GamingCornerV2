import { defineStore } from 'pinia'
import { ref, computed, reactive, nextTick } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import type { Videogame } from './ProductStore'
import type { Console } from './ProductStore'
import { useProductStore } from './ProductStore'
import { useUserStore } from './UserStore'

export interface CreateOrder {
    userId: number
    billingAddress: string
    createdAt: Date
    paymentMethod: number
}

export interface Order {
    id: number
    userId: string
    billingAddress: string
    createdAt: Date
    orderNumber: string
    paymentMethod: PaymentMethodEnum
    orderLines: OrderLine[]
    totalPrice: number
}

export interface OrderLine {
    id: number
    orderHeaderId: number
    productId: number
    productName: string
    price: number
    productType: string
    productSystem: string
    productPlatform: string
    digitalCode: string
    createdAt: Date
    orderImg: string
}

export enum PaymentMethodEnum {
    Tarjeta = 1,
    Paypal = 2,
    Bizum = 3
}

export interface VideogamePurchase {
    name: string
    digitalCode: string
}

export interface UserStats {
    totalVideogames: number;
    totalConsoles: number;
    totalSecondHandProducts: number;

    totalSavedOnVideogames: number;
    totalSavedOnConsoles: number;

    totalProductsOnSale: number;
    checkedProductsOnSale: number;
    uncheckedProductsOnSale: number;
}



export const useOrderStore = defineStore('OrderStore', () => {

    const userStore = useUserStore();

    // Array reactivo que almacena los productos del carrito (pueden ser consolas o videojuegos)
    const orders = reactive<Order[]>([]);

    // Variable para almacenar mensajes de error
    const error = ref<string | null>(null);

    const VideogamePurchases = reactive<VideogamePurchase[]>([])

    const VideogameByUser = reactive<Videogame[]>([])

    const userStats = reactive<UserStats>({
        checkedProductsOnSale: 0,
        totalConsoles: 0,
        totalProductsOnSale: 0,
        totalSavedOnConsoles: 0,
        totalSavedOnVideogames: 0,
        totalSecondHandProducts: 0,
        totalVideogames: 0,
        uncheckedProductsOnSale: 0
    })
    // Añade un producto al carrito guardado en la base de datos (modo autenticado)
    async function addOrder(order: CreateOrder) {
         
        try {

            VideogamePurchases.splice(0, VideogamePurchases.length)
            var response = await axios.post('http://localhost:5000/OrderHeader', order);
            VideogamePurchases.push(...response.data)

        } catch (error) {
            console.error("Error al añadir a la base de datos:", error);
        }
    }



    //Obtiene los productos del carrito almacenados en la cookie y los carga desde la API
    const getOrderByUserId = async () => {
        orders.splice(0, orders.length);
         
        try {
            const response = await axios.get('http://localhost:5000/OrderHeader/User/' + userStore.user.userId);

            orders.push(...response.data); // Solo empujamos el producto
        } catch (err) {
            error.value = 'Error al obtener los productos del carrito desde la API';
        }

    };

    const GetPurchasedVideogamesByUser = async () => {
        VideogameByUser.slice(0, VideogameByUser.length)
        try {
            const response = await axios.get('http://localhost:5000/OrderHeader/VideogamePurchased/User/' + userStore.user.userId);

            VideogameByUser.push(...response.data); // Solo empujamos el producto
        } catch (err) {
            error.value = 'Error al obtener los productos del carrito desde la API';
        }
    };

    const GetUserStats = async () => {
        try {
            const response = await axios.get('http://localhost:5000/OrderHeader/UserStats/' + userStore.user.userId);

            Object.assign(userStats, response.data); // producto reactivo

        } catch (err) {
            error.value = 'Error al obtener las estadísticas del usuario';
        }
    };




    return {

        error,
        addOrder,
        getOrderByUserId,
        orders,
        VideogamePurchases,
        VideogameByUser,
        GetPurchasedVideogamesByUser,
        GetUserStats,
        userStats



    }
})


