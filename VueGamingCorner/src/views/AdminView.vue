<template>
    <v-container>
      <v-row>
        <v-col cols="12" md="6">
          <v-card class="pa-6" @click="goTo('economy')" hover>
            <v-icon size="40" color="primary">mdi-cash</v-icon>
            <h3>Datos Económicos</h3>
          </v-card>
        </v-col>
  
        <v-col cols="12" md="6">
          <v-card class="pa-6" @click="goTo('charts')" hover>
            <v-icon size="40" color="primary">mdi-chart-bar</v-icon>
            <h3>Gráficos</h3>
          </v-card>
        </v-col>
  
        <v-col cols="12" md="6">
          <v-card class="pa-6" @click="goTo('datamanagement')" hover>
            <v-icon size="40" color="primary">mdi-database-edit</v-icon>
            <h3>Gestión de Contenidos</h3>
          </v-card>
        </v-col>
  
        <v-col cols="12" md="6">
          <v-card class="pa-6" @click="goTo('users')" hover>
            <v-icon size="40" color="primary">mdi-account-group</v-icon>
            <h3>Gestión de Usuarios</h3>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { useRouter } from 'vue-router'
  const router = useRouter()
  
  function goTo(section: string) {
    router.push(`/admin/${section}`)
  }
  </script>
  
  <style scoped>
  h3 {
    margin-top: 1rem;
  }
  .v-card {
    cursor: pointer;
    text-align: center;
  }
  </style>
  