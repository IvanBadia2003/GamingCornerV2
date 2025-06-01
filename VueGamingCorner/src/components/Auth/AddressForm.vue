<template>
  <v-card class="pa-5">
    <v-card-title >Dirección de Envío</v-card-title>
    <v-form>
      <v-row>
        <v-col cols="12" md="12">
          <v-text-field label="Dirección" v-model="addressShipping.address" required />
        </v-col>
        <v-col cols="12" md="4">
          <v-select label="País" v-model="addressShipping.country" :items="countries" required />
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Ciudad" v-model="addressShipping.city" required />
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Código Postal" v-model="addressShipping.zip" required />
        </v-col>
      </v-row>

    </v-form>
    <v-card-actions v-if="!haveAddress">
      <v-btn color="primary" @click="saveAddress">Guardar Dirección</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { useUserStore } from '@/stores/UserStore';
import { onMounted, reactive, ref } from 'vue'

const props = defineProps<{
  haveAddress?: boolean
  direction?: string
  country?: string
  city?: string
  zip?: string

}>()

// Copia local del usuario
const editedUser = reactive({
  userId: 0,
  name: '',
  email: '',
  password: '',
  phoneNumber: '',
  avatar: '',
  rol: 0,
  state: 0,
  address: null,
  admin: false,
  dateCreated: ''
})


const userStore = useUserStore()

const countries = ['España', 'México', 'Argentina', 'Chile', 'Colombia']


// Dirección de envío
const addressShipping = ref({
  address: props.direction || '',
  country: props.country || '',
  city: props.city || '',
  zip: props.zip || ''
})

// Función para construir la cadena final
function setAddress(direccion: {
  address: string
  country: string
  city: string
  zip: string
}) {
  return `${direccion.address}; ${direccion.country}; ${direccion.city}; ${direccion.zip}`
}

// Guardar dirección
function saveAddress() {

    const envioFinal = setAddress(addressShipping.value)
    userStore.updateUser(userStore.user.userId, {
      ...editedUser,
      address: envioFinal
    })
    console.log('Dirección de envío:', envioFinal)
  
}
</script>
