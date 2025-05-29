import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'

// Interfaz del genero
export interface Gender {
    genderId: number
    name: string
}

export interface GenderCreate {
    name: string
}



export const useGenderStore = defineStore('GenderStore', () => {
    // Estado
    const genders = reactive<Gender[]>([])
    const error = ref<string | null>(null)

    const gender = reactive<Gender>({name: '', genderId: 0})


    // Obtener todos los géneros
    const getAllGenders = async () => {
        debugger
        try {
            genders.splice(0, genders.length) // Limpiar la lista antes de obtener nuevos datos
            const response = await axios.get('http://localhost:5000/Gender')
            genders.push(...response.data)

        } catch (err) {
            error.value = 'Error al obtener los géneros'
        }
    }

    // Obteener un genero por ID
    const getGenderById = async (id: number) => {
        try {
            const response = await axios.get('http://localhost:5000/Gender/' + id)
            Object.assign(gender, response.data);
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido'
        }
    }

    async function createGender(gender: GenderCreate) {
        try {
            const response = await fetch('http://localhost:5000/Gender', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(gender),
            });
            if (response.ok) {
                alert('Genero creado exitosamente.' + response);
            } else {
                console.error('Error al crear el genero:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el genero:', error);
        }
    }


    return {
        getAllGenders,
        getGenderById,
        genders,
        gender,
        error,
        createGender

    }
})
