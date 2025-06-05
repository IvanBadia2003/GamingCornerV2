import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'
import { useCartStore } from './CartStore'

export enum RolEnum {
  Admin = 1,
  Usuario = 2,
  User
}

export enum UserStateEnum {
  Activo = 1,
  Bloqueado = 2
}


export interface User {
  userId: number // ID del usuario
  name: string // Nombre del usuario
  address: string | null // Dirección del usuario
  email: string // Email del usuario
  password: string // Contraseña del usuario
  phoneNumber: string | null // Número de teléfono del usuario
  admin: boolean // Si es administrador
  rol: number // Rol del usuario (puedes usar un enum si lo tienes)
  state: number // Estado del usuario (también puedes usar un enum si aplica)
  dateCreated: string // Fecha de creación en formato ISO
  avatar: string // URL del avatar del usuario (opcional)
}

export interface UpdateUser {
  name: string
  address: string | null
  email: string
  password: string
  phoneNumber: string | null
  rol: number | null
  state: number | null
  avatar: string
}

export const useUserStore = defineStore('userStore', () => {


  const users = reactive<User[]>([])
  const addressTags = ['Direccion', 'Pais', 'Ciudad', 'Zip']
const cartStore = useCartStore()

  // Objeto reactivo con valores por defecto
  const user = reactive<User>({
    userId: 0,
    name: '',
    address: null,
    email: '',
    password: '',
    phoneNumber: null,
    admin: false,
    rol: RolEnum.Usuario,
    state: UserStateEnum.Activo,
    dateCreated: new Date().toISOString(),
    avatar: ''
  })
  const isAuthenticated = computed(() => user.email === '' ? false : true)
  const loading = ref(false)
  const error = ref<string | null>(null)

  // Login
  const login = async (email: string, password: string) => {
    debugger
    loading.value = true
    error.value = null
    try {
      const response = await axios.post('http://localhost:5000/User/login', { email, password }, { withCredentials: true })
      Object.assign(user, response.data.user);
      console.log('Usuario logueado:', user);
      cartStore.transferCookieCartToDatabase()// Transfiere el carrito de cookies a la base de datos

      router.push('/')
    } catch (err: any) {
      error.value = err.response?.data?.message || 'Error al iniciar sesión'
      Object.assign(user, null);
    } finally {
      loading.value = false
    }
  }

  // Registro
  const register = async (name: string, email: string, password: string) => {
    loading.value = true
    error.value = null
    try {
      const response = await axios.post('http://localhost:5000/User', { name, email, password }, { withCredentials: true })
      Object.assign(user, response.data.user);
      router.push('/login')
    } catch (err: any) {
      error.value = err.response?.data?.message || 'Error al registrarse'
      Object.assign(user, null);
    } finally {
      loading.value = false
    }
  }

  // Logout
  const logout = async () => {
    try {
      await axios.post('http://localhost:5000/User/logout', {}, { withCredentials: true })
      router.push('/')
    } catch (err) {
      // No pasa nada si falla
    } finally {
      Object.assign(user, null);
    }
  }

  // Cargar usuario actual (por cookie)
  const fetchCurrentUser = async () => {
    debugger
    try {
      const response = await axios.get('http://localhost:5000/User/me', { withCredentials: true })
      Object.assign(user, response.data.value);
      
    } catch {
      Object.assign(user, null);
      
    }
  }

  const getAllUsers = async () => {
    try {
      debugger
      const response = await axios.get('http://localhost:5000/User')
      users.splice(0, users.length) // Actualiza el array de usuarios
      users.push(...response.data)// Añade los nuevos usuarios al array

    } catch (err) {
      error.value = 'Error al obtener los videojuegos'
    }
  }

  async function updateUser(id: number, userToUpdate: UpdateUser) {
    debugger
    try {
      console.log(JSON.stringify(userToUpdate));

      const response = await fetch('http://localhost:5000/User/' + id, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(userToUpdate),
      });
      if (response.ok) {
        getAllUsers(); // Actualiza la lista de usuarios después de editar
        fetchCurrentUser();
        alert('Usuario editado exitosamente.' + response.text);
        console.log('Usuario editado exitosamente.' + response);
      } else {
        alert('Error al editar el Usuario:' + response.statusText);
        console.error('Error al editar el Usuario:', response.statusText);
      }
    } catch (error) {
      console.error('Error al editar el Usuario:', error);
    }
  }

  async function deleteUser(id: number) {
    try {
       
        const response = await fetch('http://localhost:5000/User/' + id, {
            method: 'DELETE',
        });
        if (response.ok) {
          getAllUsers(); // Actualiza la lista de usuarios después de editar
          console.log("Eliminar usuairo " + id + " hecho desde UserStore.ts");
          alert(`usuario: ${id} eliminado con éxito` + response.ok);
        }

    } catch (error) {
        console.error('Error al eliminar:', error);
    }
}

  const cratedDateFormated = computed(() => {
    if (!user.dateCreated) return ''
    return new Intl.DateTimeFormat('es-ES', {
      day: 'numeric',
      month: 'long',
      year: 'numeric'
    }).format(new Date(user.dateCreated))
  })

   const addressFormatted = computed(() => {
        // Verificamos que el producto tenga la propiedad requisitos2 y que sea una cadena

            // Obtenemos los requisitos mínimos
            const address = user.address?.split(';').map(r => r.trim()) ?? []

            // Mapeamos los requisitos a un formato más legible
            return addressTags.map((tag, index) => ({
                tag,
                valor: address[index]
            }))
        }
    )


  return {
    user,
    isAuthenticated,
    loading,
    error,
    login,
    register,
    logout,
    fetchCurrentUser,
    getAllUsers,
    users,
    cratedDateFormated,
    updateUser,
    deleteUser,
    addressFormatted
  }
})
