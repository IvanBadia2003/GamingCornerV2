import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'

// Interfaz del genero
export interface Platform {
    platformId: number
    name: string
}

export interface PlatformCreate {
    name: string
}



export const usePlatformStore = defineStore('PlatformStore', () => {
    // Estado
    const platforms = reactive<Platform[]>([])
    const error = ref<string | null>(null)

    const platform = reactive<Platform>({name: '', platformId: 0})


    // Obtener todos los géneros
    const getAllPlatforms = async () => {
        debugger
        try {
            platforms.splice(0, platforms.length) // Limpiar la lista antes de obtener nuevos datos
            const response = await axios.get('http://localhost:5000/Platform')
            platforms.push(...response.data)

        } catch (err) {
            error.value = 'Error al obtener las plataformas'
        }
    }

    // Obteener una plataforma por ID
    const getPlatformById = async (id: number) => {
        try {
            const response = await axios.get('http://localhost:5000/Platform/' + id)
            Object.assign(platform, response.data);
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido'
        }
    }

    async function createPlatform(platform: PlatformCreate) {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Platform', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(platform),
            });
            if (response.ok) {
                alert('Plataforma creada exitosamente.' + response);
            } else {
                console.error('Error al crear la plataforma:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear la plataforma:', error);
        }
    }


    return {
        getAllPlatforms,
        getPlatformById,
        platforms,
        platform,
        error,
        createPlatform

    }
})
