import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import axios from 'axios'
import router from '@/router'

// Interfaz del genero
interface Gender {
    genderId: number
    name: string
}



export const useGenderStore = defineStore('GenderStore', () => {
    // Estado
    const genders = ref<Gender[]>([])
    const error = ref<string | null>(null)

    const gender = ref<Gender>()


    // Obtener todos los géneros
    const getAllGenders = async () => {
        debugger
        try {
            const response = await axios.get('http://localhost:5000/Gender')
            genders.value = response.data

        } catch (err) {
            error.value = 'Error al obtener los géneros'
        }
    }

    // Obteener un genero por ID
    const getGenderById = async (id: number) => {
        try {
            const response = await axios.get('http://localhost:5000/Gender/' + id)
            gender.value = response.data
        } catch (err: any) {
            error.value = err.response?.data || 'Error desconocido'
        }
    }



    return {
        getAllGenders,
        getGenderById,
        genders,
        gender,
        error

    }
})
