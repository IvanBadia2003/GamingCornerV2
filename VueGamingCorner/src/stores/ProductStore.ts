import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
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
    //genderId?: number[]
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego
}

export interface VideogameCreate {
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string //Descripción del juego
    requisitos1?: string //Requisitos mínimos del juego
    requisitos2?: string //Requisitos recomendados del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    // platformId?: number
    //genderId?: number[]
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego
}



// Interfaz de la consola
export interface Console extends Product {
    id: number // ID del videojuego
    name: string // Nombre del videojuego
    description: string //Descripción del juego
    specifications?: string //Requisitos mínimos del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    // platformId?: number
    // genderId?: number
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    brand: string  //Distribuidor del juego

}


export const useProductStore = defineStore('ProductStore', () => {
    // Estado
    const videogames = reactive<Videogame[]>([])
    const consoles = reactive<Console[]>([])
    const products = reactive<Console[] | Videogame[]>([])
    const error = ref<string | null>(null)

    const product = reactive<Videogame | Console>({ productId: 0, sales: '' } as Videogame | Console) // Producto actual

    const requirementsTags = ['SO', 'Procesador', 'Memoria', 'Gráficos', 'Almacenamiento']
    const specificationsTags = ['CPU', 'GPU', 'Memoria', 'Almacenamiento', 'Peso', 'Entrada/Salida', 'Red', 'Alimentación', 'Consumo de energía', 'Salida AV']



    // Obteener un producto por ID
    const getProductById = async (id: number) => {
        try {
            const response = await axios.get('http://localhost:5000/Product/' + id)
            Object.assign(product, response.data);
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido'
        }
    }

    // variable para la fecha de lanzamiento formateada
    const formattedReleaseDate = computed(() => {
        if (!product.releaseDate) return ''
        const date = new Date(product.releaseDate)
        return new Intl.DateTimeFormat('es-ES', {
            day: '2-digit',
            month: 'long',
            year: 'numeric'
        }).format(date)
    })


    // Obtener todos los videojuegos
    const getProductsToCatalog = async (type: string) => {
        try {

            if (type === 'videogame') {
                const response = await axios.get('http://localhost:5000/Videogame')
                products.splice(0, products.length) // Actualiza el array de videojuegos
                products.push(...response.data)// Añade los nuevos videojuegos al array
            } else if (type === 'console') {
                const response = await axios.get('http://localhost:5000/Console')
                products.splice(0, products.length) // Borra el array de consolas
                products.push(...response.data)// Añade las consolas al array
            }

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

    /************ VIDEOJUEGOS **********/

    // Obtener todos los videojuegos
    const getAllVideogames = async () => {
        try {
            const response = await axios.get('http://localhost:5000/Videogame')
            videogames.splice(0, videogames.length) // Actualiza el array de videojuegos
            videogames.push(...response.data)// Añade los nuevos videojuegos al array

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

    // Requisitos mínimos del videojuego
    const minimumRequirements = computed(() => {
        // Decimos que el producto es un videojuego
        const videogame = product as Videogame

        // Verificamos que el producto no sea nulo y que sea un objeto
        if (!product || typeof product !== 'object') return []

        // Verificamos que el producto tenga la propiedad requisitos1 y que sea una cadena
        if ('requisitos1' in product && typeof product.requisitos1 === 'string') {

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
        const videogame = product as Videogame

        // Verificamos que el producto no sea nulo y que sea un objeto
        if (!product || typeof product !== 'object') return []

        // Verificamos que el producto tenga la propiedad requisitos2 y que sea una cadena
        if ('requisitos2' in product && typeof product.requisitos2 === 'string') {

            // Obtenemos los requisitos mínimos
            const requirements = videogame.requisitos2?.split(';').map(r => r.trim()) ?? []

            // Mapeamos los requisitos a un formato más legible
            return requirementsTags.map((tag, index) => ({
                tag,
                valor: requirements[index] ?? 'Desconocido'
            }))
        }
    })

    async function createGame(game: VideogameCreate) {
        try {
            const response = await fetch('http://localhost:5000/Videogame', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(game),
            });
            if (response.ok) {
                alert('Juego creado exitosamente.' + response);
            } else {
                console.error('Error al crear el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el juego:', error);
        }
    }

    /************ FIN VIDEOJUEGOS **********/


    /************ CONSOLAS **********/
    // Obtener todas las consolas
    const getAllConsoles = async () => {
        try {
            const response = await axios.get('http://localhost:5000/Console')
            consoles.splice(0, consoles.length) // Borra el array de consolas
            consoles.push(...response.data)// Añade las consolas al array

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }
    /************ FIN CONSOLAS **********/


    return {
        videogames,
        product,
        error,
        getAllVideogames,
        getAllConsoles,
        getProductById,
        formattedReleaseDate,
        minimumRequirements,
        recommendedRequirements,
        createGame,
        consoles,
        getProductsToCatalog,
        products
    }
})
