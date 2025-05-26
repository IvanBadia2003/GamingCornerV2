import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import axios from 'axios'
import router from '@/router'

// Interfaz del producto
interface Product {
    productId: number
    sales: string
}

// Interfaz del videojuego
export interface Videogame extends Product {
    id: number // ID del videojuego
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string //Descripción del juego
    requisitos1?: string //Requisitos mínimos del juego
    requisitos2?: string //Requisitos recomendados del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    // platformId?: number
    // genderId?: number
    principalImageURL?: string //Imagen principal del juego
    releaseDate: string //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego

}

// Interfaz de la consola
export interface Console extends Product {
    id: number // ID del videojuego
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string //Descripción del juego
    specifications?: string //Requisitos mínimos del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    // platformId?: number
    // genderId?: number
    principalImageURL?: string //Imagen principal del juego
    releaseDate: string //Fecha de lanzamiento del juego 
    brand: string  //Distribuidor del juego

}


export const useProductStore = defineStore('ProductStore', () => {
    // Estado
    const videogames = ref<Videogame[]>([])
    const error = ref<string | null>(null)

    const product = ref<Videogame | Console>()

    const requirementsTags = ['SO', 'Procesador', 'Memoria', 'Gráficos', 'Almacenamiento']
    const specificationsTags = ['CPU', 'GPU', 'Memoria', 'Almacenamiento', 'Peso', 'Entrada/Salida', 'Red', 'Alimentación', 'Consumo de energía', 'Salida AV']

    // Obtener todos los videojuegos
    const getAllVideogames = async () => {
        try {
            const response = await axios.get('http://localhost:5000/Videogame')
            videogames.value = response.data

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

    // Obteener un producto por ID
    const getProductById = async (id: number) => {
        try {
            const response = await axios.get('http://localhost:5000/Product/' + id)
            product.value = response.data
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido'
        }
    }

    // variable para la fecha de lanzamiento formateada
    const formattedReleaseDate = computed(() => {
        if (!product.value?.releaseDate) return ''
        const date = new Date(product.value.releaseDate)
        return new Intl.DateTimeFormat('es-ES', {
            day: '2-digit',
            month: 'long',
            year: 'numeric'
        }).format(date)
    })

    // Requisitos mínimos del videojuego
    const minimumRequirements = computed(() => {
        // Decimos que el producto es un videojuego
        const videogame = product.value as Videogame

        // Verificamos que el producto no sea nulo y que sea un objeto
        if (!product.value || typeof product.value !== 'object') return []

        // Verificamos que el producto tenga la propiedad requisitos1 y que sea una cadena
        if ('requisitos1' in product.value && typeof product.value.requisitos1 === 'string') {

            // Obtenemos los requisitos mínimos
            const requirements = videogame.requisitos1?.split(';').map(r => r.trim()) ?? []

            // Mapeamos los requisitos a un formato más legible
            return requirementsTags.map((tag, index) => ({
                tag,
                valor: requirements[index] ?? 'Desconocido'
            }))
        }
    })

    // Requisitos recomendados del videojuego
    const recommendedRequirements = computed(() => {
        // Decimos que el producto es un videojuego
        const videogame = product.value as Videogame

        // Verificamos que el producto no sea nulo y que sea un objeto
        if (!product.value || typeof product.value !== 'object') return []

        // Verificamos que el producto tenga la propiedad requisitos2 y que sea una cadena
        if ('requisitos2' in product.value && typeof product.value.requisitos2 === 'string') {

            // Obtenemos los requisitos mínimos
            const requirements = videogame.requisitos2?.split(';').map(r => r.trim()) ?? []

            // Mapeamos los requisitos a un formato más legible
            return requirementsTags.map((tag, index) => ({
                tag,
                valor: requirements[index] ?? 'Desconocido'
            }))
        }
    })

    return {
        videogames,
        product,
        error,
        getAllVideogames,
        getProductById,
        formattedReleaseDate,
        minimumRequirements,
        recommendedRequirements
    }
})
