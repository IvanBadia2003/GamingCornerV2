import { defineStore } from 'pinia'
import { ref, computed, reactive } from 'vue'
import axios from 'axios'
import router from '@/router'
import { de } from 'vuetify/locale'

interface User {
  id: number
  username: string
  email: string
  admin: boolean
  // agrega más campos si lo necesitas
}

export const useAuthStore = defineStore('auth', () => {
  // Estado
  const user = reactive<User>({
    id: 0,
    username: '',
    email: '',
    admin: false,
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

  return {
    user,
    isAuthenticated,
    loading,
    error,
    login,
    register,
    logout,
    fetchCurrentUser,
  }
})
