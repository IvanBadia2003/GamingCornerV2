<script setup lang="ts">

import { onMounted, ref } from 'vue'
import { RolEnum, UserStateEnum, useUserStore, type UpdateUser } from '@/stores/UserStore'

const userStore = useUserStore()

onMounted(() => {
  userStore.getAllUsers()
})

// Formatea la fecha al formato dd-mm-yyyy
function formatDate(dateString: string): string {
  const date = new Date(dateString);
  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0'); // los meses van de 0 a 11
  const year = date.getFullYear();
  return `${day}-${month}-${year}`;
}

function modifyRole(rol: RolEnum, user: UpdateUser, userId: number) {
  debugger
  const updateUser: UpdateUser = {
    name: user.name,
    address: user.address,
    email: user.email,
    password: user.password,
    phoneNumber: user.phoneNumber,
    state: user.state,
    rol: rol,
    avatar: user.avatar,

  }
  userStore.updateUser(userId, updateUser)
  alert(`Cambiando rol de ${RolEnum[user.rol ?? 0]} a ${RolEnum[rol ?? 0]}`);


}

function modifyStatus(state: UserStateEnum, user: UpdateUser, userId: number) {
  debugger
  const updateUser: UpdateUser = {
    name: user.name,
    address: user.address,
    email: user.email,
    password: user.password,
    phoneNumber: user.phoneNumber,
    state: state,
    rol: user.rol,
    avatar: user.avatar,

  }
  userStore.updateUser(userId, updateUser)
  alert(`Cambiando estado de ${RolEnum[user.state ?? 0]} a ${RolEnum[state ?? 0]}`);

}

</script>


<template>
  <v-container style="width: 80%;">
    <h1 class="text-h5 mb-6">Gestión de Usuarios</h1>

    <v-row dense>
      <v-col v-for="user in userStore.users" :key="user.userId" cols="12" sm="6" md="4" lg="4">
        <v-card class="pa-4" elevation="4">
          <v-row no-gutters>
            <v-col cols="4" class="d-flex justify-center align-center">
              <v-avatar size="64">
                <v-img :src="user.avatar" alt="Avatar" />
              </v-avatar>
            </v-col>

            <v-col cols="8">
              <div class="text-subtitle-1 font-weight-medium">
                {{ user.name }}
              </div>
              <div class="text-caption">ID: {{ user.userId }}</div>
              <div class="text-caption">{{ user.email }}</div>
              <div class="text-caption">{{ user.phoneNumber }}</div>
              <div class="text-caption">Usuario desde: {{ formatDate(user.dateCreated) }}</div>
              <v-chip class="ma-1 mt-2" :color="user.rol === RolEnum.Admin ? 'deep-purple accent-4' : 'primary'" label
                small>
                {{ RolEnum[user.rol] }}
              </v-chip>
              <v-chip class="ma-1 mt-2" :color="user.state === UserStateEnum.Activo ? 'green' : 'red'" label small>
                {{ UserStateEnum[user.state] }}
              </v-chip>
            </v-col>
          </v-row>

          <v-divider class="my-3" />

          <div class="d-flex justify-center flex-wrap gap-2">
            <v-btn v-if="user.rol == RolEnum.Usuario" size="small" color="error" variant="text"
              @click="modifyRole(RolEnum.Admin, user, user.userId)">Hacer admin</v-btn>
            <v-btn v-if="user.rol == RolEnum.Admin" size="small" color="error" variant="text"
              @click="modifyRole(RolEnum.Usuario, user, user.userId)">Quitar de admin</v-btn>
            <v-btn v-if="user.state == UserStateEnum.Activo" size="small" color="error" variant="text"
              @click="modifyStatus(UserStateEnum.Bloqueado, user, user.userId)">Bloquear</v-btn>
            <v-btn v-if="user.state == UserStateEnum.Bloqueado" size="small" color="error" variant="text"
              @click="modifyStatus(UserStateEnum.Activo, user, user.userId)">Desbloquear</v-btn>
            <v-btn size="small" color="red-darken-3" variant="text"
              @click="userStore.deleteUser(user.userId)">Eliminar</v-btn>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>