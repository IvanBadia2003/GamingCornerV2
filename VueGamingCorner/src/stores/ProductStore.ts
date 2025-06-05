import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'
import { useUserStore } from './UserStore'
import type { Gender } from './GenderStore'
import { de } from 'vuetify/locale'
import { nextTick } from 'vue';


// #region Interfaces

// Interfaz del producto
interface Product {
    productId: number
    sales: string
}

export enum OrderDirectionEnum {
    ASC = 1,
    DESC = 2
}
export interface Filters {
    platform: number | null
    genre: number | null
    minPrice: number | null
    maxPrice: number | null
    search: string
    system: number | null
    orderBy: string | null
    orderDirection: OrderDirectionEnum | null
    brand: string | null
}

export interface ProductImages {
    main?: string | null;
    background?: string | null;
    content1?: string | null;
    content2?: string | null;
    content3?: string | null;
    content4?: string | null;
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
    platformId?: number
    genderId: Gender[] //Géneros del juego
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego
    productImages: ProductImages

}



// Interfaz para crear el videojuego
export interface VideogameCreate {
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string //Descripción del juego
    requisitos1?: string //Requisitos mínimos del juego
    requisitos2?: string //Requisitos recomendados del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    genderId: number[] //Géneros del juego
    platformId?: number
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego
    main: string,
    background: string,
    content1: string,
    content2: string,
    content3: string,
    content4: string
}
// Interfaz para editar el videojuego

export interface VideogameUpdate {
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string // Descripción del juego
    requisitos1?: string // Requisitos mínimos del juego
    requisitos2?: string // Requisitos recomendados del juego
    stock: number // Cantidad de stock del juego
    discount: number // Porcentaje de descuento sobre el precio del juego
    price: number // Precio del juego
    genderId: number[] // Géneros del juego
    platformId?: number // Plataforma del juego
    principalImageURL?: string // Imagen principal del juego
    releaseDate: Date // Fecha de lanzamiento del juego 
    distributor: string // Distribuidor del juego
    developer: string // Desarrollador del juego
}


// Interfaz de la consola
export interface Console extends Product {
    id: number // ID de la consola
    name: string // Nombre de la consola
    description: string //Descripción de la consola
    specifications?: string //Especificaciones de la consola
    stock: number //Cantidad de stock de la consola
    discount: number //Porcentaje de descuento sobre el precio de la consola
    price: number //Precio de la consola
    platformId?: number
    principalImageURL?: string //Imagen principal de la consola
    releaseDate: Date //Fecha de lanzamiento de la consola
    brand: string  //Distribuidor de la consola
    productImages: ProductImages


}
// Interfaz para crear la consola 
export interface ConsoleCreate {
    name: string // Nombre de la consola
    description: string // Descripción de la consola
    stock: number // Cantidad de stock de la consola
    discount: number // Porcentaje de descuento sobre el precio de la consola
    price: number // Precio de la consola
    principalImageURL: string // Imagen principal de la consola
    releaseDate: Date // Fecha de lanzamiento de la consola
    specifications: string // Especificaciones de la consola
    brand: string // Marca o distribuidor de la consola
    platformId: number // ID de la plataforma
    generation: string // Generación de la consola
    colors: string // Colores disponibles
    services: string // Servicios compatibles
    main: string,
    background: string,
    content1: string,
    content2: string,
    content3: string,
    content4: string
}

// Interfaz para editar la consola 
export interface UpdateConsole {
    name: string // Nombre de la consola
    description: string // Descripción de la consola
    stock: number // Cantidad de stock de la consola
    discount: number // Porcentaje de descuento sobre el precio de la consola
    price: number // Precio de la consola
    principalImageURL: string // Imagen principal de la consola
    releaseDate: Date // Fecha de lanzamiento de la consola
    specifications: string // Especificaciones de la consola
    brand: string // Marca o distribuidor de la consola
    platformId: number // ID de la plataforma
    generation: string // Generación de la consola
    colors: string // Colores disponibles
    services: string // Servicios compatibles
}
// #endregion

export const useProductStore = defineStore('ProductStore', () => {
    // Estado
    const videogames = reactive<Videogame[]>([])
    const topVideogames = reactive<Videogame[]>([])
    const consoles = reactive<Console[]>([])
    const topConsoles = reactive<Console[]>([])
    const compatibleProducts = reactive<Console[] | Videogame[]>([])
    const products = reactive<Console[] | Videogame[]>([])
    const similarsProducts = reactive<Console[] | Videogame[]>([])
    const error = ref<string | null>(null)

    const productType = ref<string | null>(null);


    const product = reactive<Videogame | Console>({ productId: 0, sales: '' } as Videogame | Console) // Producto actual

    const requirementsTags = ['SO', 'Procesador', 'Memoria', 'Gráficos', 'Almacenamiento']
    const specificationsTags = ['CPU', 'GPU', 'Memoria', 'Almacenamiento', 'Peso', 'Entrada/Salida', 'Red', 'Alimentación', 'Consumo de energía', 'Salida AV']


    // Obteener un producto por ID
    const getProductById = async (id: number) => {
        try {
            compatibleProducts.splice(0, compatibleProducts.length);
            similarsProducts.splice(0, similarsProducts.length);
    
            const response = await axios.get('http://localhost:5000/Product/' + id);
    
            Object.assign(product, response.data); // producto reactivo
            console.log('Producto obtenido:', product);
    
            // Esperar un microtick para asegurar que Vue lo actualiza
            await nextTick(); 
            
            await getSimilarsProducts();
            await getCompatibleProducts();
    
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido';
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


    // Obtener todos los productos para el catálogo
    const getProductsToCatalog = async (type: string) => {
        try {
debugger
            if (type === 'videogame') {
                const response = await axios.get('http://localhost:5000/Videogame')
                products.splice(0, products.length) // Actualiza el array de videojuegos
                products.push(...response.data)// Añade los nuevos videojuegos al array
                console.log(products);
                
            } else if (type === 'console') {
                const response = await axios.get('http://localhost:5000/Console')
                products.splice(0, products.length) // Borra el array de consolas
                products.push(...response.data)// Añade las consolas al array
            }

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

    const getSimilarsProducts = async () => {
        debugger
        try {
            similarsProducts.splice(0, similarsProducts.length); // Limpiar el array antes de agregar nuevos productos
            const response = await axios.get('http://localhost:5000/Product/Similar/' + product.id);

            similarsProducts.push(...response.data); // Agregar el producto al array
            console.log(similarsProducts);

        } catch (err) {
            error.value = 'Error al obtener los productos del carrito';
        }
    }


            
        const getCompatibleProducts = async () => {
            debugger
            try {
                console.log(topConsoles);
    
                compatibleProducts.splice(0, compatibleProducts.length) // Actualiza el array de videojuegos
                const response = await axios.get('http://localhost:5000/Product/Compatible/     ' + product.id);
                compatibleProducts.push(...response.data)// Añade los nuevos videojuegos al array
                console.log(topConsoles);
    
            } catch (err) {
                error.value = 'Error al obtener los videojuegos'
            }
        }
    // #region /************ VIDEOJUEGOS **********/

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
        debugger
        try {
            const response = await fetch('http://localhost:5000/Videogame', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(game),
            });
            if (response.ok) {  
                getAllVideogames()
                alert('Juego creado exitosamente.' + response);
            } else {
                console.error('Error al crear el juego:', response.statusText);
                alert('Error al crear el juego:' + response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el juego:', error);
        }
    }


    async function deleteVideogame(id: number) {
        try {
            //TENGO QUE VER COMO USARLO  useUserStore().fetchCurrentUser
            const response = await fetch('http://localhost:5000/Videogame/' + id, {
                method: 'DELETE',
            });
            console.log("Eliminar videojuego " + id + " hecho desde ProductStore.ts");
            getAllVideogames()
            alert(`videojuego: ${id} eliminado con éxito` + response.ok);
        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    async function updateVideogame(id: number, videogame: VideogameUpdate) {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Videogame/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(videogame),
            });
            if (response.ok) {
                alert('Juego editado exitosamente.' + response);
                getAllVideogames()
                console.log('Juego editado exitosamente.' + response);
            } else {
                alert('Error al editar el juego:' + response.statusText);
                console.error('Error al editar el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar el juego:', error);
        }
    }

    // Obtener todos los videojuegos filtrados
    const getFilteredVideogames = async (filters: Filters) => {
        debugger
        try {
            console.log(videogames);

            products.splice(0, videogames.length) // Actualiza el array de videojuegos
            const response = await axios.post('http://localhost:5000/Videogame/Filter/', filters);
            products.push(...response.data)// Añade los nuevos videojuegos al array
            console.log(videogames);

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

    // Obtener los 12 productos más vendidos
    const TopSellingVideogames = async () => {
        debugger
        try {
            console.log(topVideogames);

            topVideogames.splice(0, videogames.length) // Actualiza el array de videojuegos
            const response = await axios.get('http://localhost:5000/Videogame/Top');
            topVideogames.push(...response.data)// Añade los nuevos videojuegos al array
            console.log(topVideogames);

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }
    /************ FIN VIDEOJUEGOS **********/
    // #endregion 


    // #region /************ CONSOLAS **********/

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

    // Requisitos recomendados del videojuego
    const specificationsConsole = computed(() => {
        // Decimos que el producto es un videojuego
        const console = product as Console

        // Verificamos que el producto no sea nulo y que sea un objeto
        if (!product || typeof product !== 'object') return []

        // Verificamos que el producto tenga la propiedad requisitos2 y que sea una cadena
        if ('specifications' in product && typeof product.specifications === 'string') {

            // Obtenemos los requisitos mínimos
            const specificationsConsole = console.specifications?.split(';').map(r => r.trim()) ?? []

            // Mapeamos los requisitos a un formato más legible
            return specificationsTags.map((tag, index) => ({
                tag,
                valor: specificationsConsole[index] ?? 'Desconocido'
            }))
        }
    })

    async function createConsole(_console: ConsoleCreate) {
        try {
            debugger
            const response = await fetch('http://localhost:5000/Console', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(_console),
            });
            if (response.ok) {
                alert('Consola creada exitosamente.' + response);
                console.log('Consola creada exitosamente.' + response);
                getAllConsoles()
            } else {
                console.error('Error al crear el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el juego:', error);
        }
    }

    async function updateConsole(id: number, _console: UpdateConsole) {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(_console),
            });
            if (response.ok) {
                alert('Consola editada exitosamente.' + response);
                console.log('Consola editada exitosamente.' + response);
                getAllConsoles()
            } else {
                console.error('Error al editar la consola:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar la consola:', error);
        }
    }


    async function deleteConsole(id: number) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'DELETE',
            });
            console.log("Eliminar consola " + id + " hecho desde ProductStore.ts");
            alert(`Consola: ${id} eliminado con éxito` + response.ok);
            getAllConsoles()
        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    // Obtener todas las consolas filtradas
    const getFilteredConsoles = async (filters: Filters) => {
        debugger
        try {
            console.log(consoles);

            products.splice(0, consoles.length) // Actualiza el array de videojuegos
            const response = await axios.post('http://localhost:5000/Console/Filter/', filters);
            products.push(...response.data)// Añade los nuevos videojuegos al array
            console.log(consoles);

        } catch (err) {
            error.value = 'Error al obtener los videojuegos'
        }
    }

        // Obtener los 12 productos más vendidos
        const TopSellingConsoles = async () => {
            debugger
            try {
                console.log(topConsoles);
    
                topConsoles.splice(0, videogames.length) // Actualiza el array de videojuegos
                const response = await axios.get('http://localhost:5000/Console/Top');
                topConsoles.push(...response.data)// Añade los nuevos videojuegos al array
                console.log(topConsoles);
    
            } catch (err) {
                error.value = 'Error al obtener los videojuegos'
            }
        }

    /************ FIN CONSOLAS **********/
    // #endregion


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
        products,
        createConsole,
        specificationsConsole,
        deleteConsole,
        deleteVideogame,
        getSimilarsProducts,
        similarsProducts,
        updateConsole,
        updateVideogame,
        getFilteredVideogames,
        productType,
        getFilteredConsoles,
        topVideogames,
        TopSellingVideogames,
        topConsoles,
        TopSellingConsoles,
        getCompatibleProducts,
        compatibleProducts
    }
})
