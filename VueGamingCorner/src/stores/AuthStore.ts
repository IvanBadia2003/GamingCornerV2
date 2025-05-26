import { defineStore } from 'pinia'
import { ref, computed } from 'vue'
import axios from 'axios'
import router from '@/router'

interface User {
  id: number
  username: string
  email: string
  admin: boolean
  // agrega más campos si lo necesitas
}

export const useAuthStore = defineStore('auth', () => {
  // Estado
  const user = ref<User | null>(null)
  const isAuthenticated = computed(() => user.value !== null)
  const loading = ref(false)
  const error = ref<string | null>(null)

  // Login
  const login = async (email: string, password: string) => {
    debugger
    loading.value = true
    error.value = null
    try {
      const response = await axios.post('http://localhost:5000/User/login', { email, password }, { withCredentials: true })
      user.value = response.data.user
      console.log('Usuario logueado:', user.value);
      
      router.push('/')
    } catch (err: any) {
      error.value = err.response?.data?.message || 'Error al iniciar sesión'
      user.value = null
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
      user.value = response.data
      router.push('/login')
    } catch (err: any) {
      error.value = err.response?.data?.message || 'Error al registrarse'
      user.value = null
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
      user.value = null
    }
  }

  // Cargar usuario actual (por cookie)
  const fetchCurrentUser = async () => {
    try {
      const response = await axios.get('http://localhost:5000/User/me', { withCredentials: true })
      user.value = response.data
    } catch {
      user.value = null
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
