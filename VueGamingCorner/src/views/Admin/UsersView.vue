<template>
    <v-container style="width: 80%;">
      <h1 class="text-h5 mb-6">Gestión de Usuarios</h1>
  
      <v-row dense>
        <v-col
          v-for="user in users"
          :key="user.id"
          cols="12"
          sm="6"
          md="4"
          lg="4"
        >
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
                <div class="text-caption">ID: {{ user.id }}</div>
                <div class="text-caption">{{ user.email }}</div>
                <div class="text-caption">Usuario desde: {{ user.lastLogin }}</div>
                <v-chip
                  class="ma-1 mt-2"
                  :color="user.role === 'admin' ? 'deep-purple accent-4' : 'primary'"
                  label
                  small
                >
                  {{ user.role }}
                </v-chip>
                <v-chip
                  class="ma-1 mt-2"
                  :color="user.status === 'activo' ? 'green' : 'red'"
                  label
                  small
                >
                  {{ user.status }}
                </v-chip>
              </v-col>
            </v-row>
  
            <v-divider class="my-3" />
  
            <div class="d-flex justify-center flex-wrap gap-2">
              <v-btn size="small" color="error" variant="text">Bloquear</v-btn>
              <v-btn size="small" color="red-darken-3" variant="text">Eliminar</v-btn>
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup lang="ts">
  const users = [
    {
      id: '1',
      name: 'Laura Gómez',
      email: 'laura@example.com',
      role: 'admin',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/women/1.jpg',
      lastLogin: '2025-05-01 12:20',
    },
    {
      id: '2',
      name: 'Carlos Martínez',
      email: 'carlos@example.com',
      role: 'cliente',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/men/2.jpg',
      lastLogin: '2025-04-30 18:45',
    },
    {
      id: '3',
      name: 'Ana Torres',
      email: 'ana@example.com',
      role: 'cliente',
      status: 'bloqueado',
      avatar: 'https://randomuser.me/api/portraits/women/3.jpg',
      lastLogin: '2025-03-28 10:05',
    },
    {
      id: '1',
      name: 'Laura Gómez',
      email: 'laura@example.com',
      role: 'admin',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/women/1.jpg',
      lastLogin: '2025-05-01 12:20',
    },
    {
      id: '2',
      name: 'Carlos Martínez',
      email: 'carlos@example.com',
      role: 'cliente',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/men/2.jpg',
      lastLogin: '2025-04-30 18:45',
    },
    {
      id: '3',
      name: 'Ana Torres',
      email: 'ana@example.com',
      role: 'cliente',
      status: 'bloqueado',
      avatar: 'https://randomuser.me/api/portraits/women/3.jpg',
      lastLogin: '2025-03-28 10:05',
    },
    {
      id: '1',
      name: 'Laura Gómez',
      email: 'laura@example.com',
      role: 'admin',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/women/1.jpg',
      lastLogin: '2025-05-01 12:20',
    },
    {
      id: '2',
      name: 'Carlos Martínez',
      email: 'carlos@example.com',
      role: 'cliente',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/men/2.jpg',
      lastLogin: '2025-04-30 18:45',
    },
    {
      id: '3',
      name: 'Ana Torres',
      email: 'ana@example.com',
      role: 'cliente',
      status: 'bloqueado',
      avatar: 'https://randomuser.me/api/portraits/women/3.jpg',
      lastLogin: '2025-03-28 10:05',
    },
    {
      id: '1',
      name: 'Laura Gómez',
      email: 'laura@example.com',
      role: 'admin',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/women/1.jpg',
      lastLogin: '2025-05-01 12:20',
    },
    {
      id: '2',
      name: 'Carlos Martínez',
      email: 'carlos@example.com',
      role: 'cliente',
      status: 'activo',
      avatar: 'https://randomuser.me/api/portraits/men/2.jpg',
      lastLogin: '2025-04-30 18:45',
    },
    {
      id: '3',
      name: 'Ana Torres',
      email: 'ana@example.com',
      role: 'cliente',
      status: 'bloqueado',
      avatar: 'https://randomuser.me/api/portraits/women/3.jpg',
      lastLogin: '2025-03-28 10:05',
    },
  ]
  </script>
  