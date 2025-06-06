<template>
  <v-form @submit.prevent="guardar" ref="formRef">
    <v-row dense>
      <!-- Nombre -->
      <v-col cols="12" md="6">
        <v-text-field label="Nombre de usuario" v-model="editedUser.name"
          :rules="[v => !!v || 'El nombre es obligatorio']" />
      </v-col>

      <!-- Email -->
      <v-col cols="12" md="6">
        <v-text-field label="Correo electrónico" v-model="editedUser.email" type="email"
          :rules="[v => !!v || 'El correo es obligatorio']" />
      </v-col>

      <!-- Teléfono -->
      <v-col cols="12" md="6">
        <v-text-field label="Número de teléfono" v-model="editedUser.phoneNumber" type="text" />
      </v-col>

      <!-- Contraseña actual (solo visible) -->
      <v-col cols="12" md="6">
        <v-text-field label="Contraseña actual" type="password" v-model="editedUser.password" readonly
          :clearable="false" />
      </v-col>

      <v-expand-transition>
      <v-col cols="12" v-show="mostrarCambioContrasena" >
        <v-row>
          <!-- BLOQUE EXPANDIBLE -->
              <v-col cols="12" md="6">
                <v-text-field label="Nueva contraseña" type="password" v-model="newPassword"
                  />
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field label="Repetir nueva contraseña" type="password" v-model="repeatNewPassword" :rules="[
                  
                  v => v === newPassword || 'Las contraseñas no coinciden'
                ]" />
              </v-col>
          </v-row>
        </v-col>
      </v-expand-transition>


      <!-- Avatar -->
          <v-col cols="12" md="12">
                 <v-file-input v-model="cloudinaryStore.avatarImage" label="Avatar" />

          </v-col>


      <!-- Botones -->
      <v-col cols="12" class="d-flex gap-4">
        <v-btn color="primary" type="submit">Guardar</v-btn>
        <v-btn color="primary" class="ml-5" @click="mostrarCambioContrasena = !mostrarCambioContrasena">
          Cambiar contraseña
        </v-btn>
      </v-col>


    </v-row>
  </v-form>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, nextTick } from 'vue'
import { useUserStore } from '@/stores/UserStore'
import { useCloudinaryStore } from '@/stores/CloudinaryStore'

const userStore = useUserStore()
const cloudinaryStore = useCloudinaryStore()
const formRef = ref()

// Estado para mostrar/ocultar los campos de cambio de contraseña
const mostrarCambioContrasena = ref(false)

// Campos para la nueva contraseña
const newPassword = ref('')
const repeatNewPassword = ref('')

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

// Cargar datos al montar el componente
onMounted(() => {
  Object.assign(editedUser, userStore.user)
})

async function guardar() {
  await cloudinaryStore.uploadImages('usuario', userStore.user.email)
    await nextTick()
    const media = useCloudinaryStore().getMedia('usuario', userStore.user.email);

  const form = formRef.value
  if (!form) return

  const isValid = await form.validate()
  if (!isValid.valid) {
    console.warn('Formulario inválido')
    return
  }

  // Validar contraseñas si se cambió
  if (mostrarCambioContrasena.value) {
    editedUser.password = newPassword.value
  }

  editedUser.avatar = media.avatar

  try {
    await userStore.updateUser(editedUser.userId, { ...editedUser })
    mostrarCambioContrasena.value = false
    newPassword.value = ''
    repeatNewPassword.value = ''
  } catch (error) {
    console.error('Error al guardar los datos:', error)
  }
}
</script>