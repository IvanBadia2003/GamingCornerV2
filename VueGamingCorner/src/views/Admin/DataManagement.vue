<script setup lang="ts">
import { ref } from 'vue'
import AddProductDialogComponent from '@/components/Admin/AddProductDialogComponent.vue'

const tab = ref('juegos')
const dialogAbierto = ref(false)
const formType = ref<'juego' | 'consola'>('juego')
const isEditing = ref(false)
const selectedItem = ref<any>(null)
// Cabeceras para cada tabla

const gameHeaders = [
  { title: 'Nombre', key: 'name' },
  { title: 'Plataforma', key: 'platform' },
  { title: 'Precio', key: 'price' },
  { title: 'Stock', key: 'stock' },
  { title: 'Acciones', key: 'actions', sortable: false },
]

const consoleHeaders = [
  { title: 'Modelo', key: 'model' },
  { title: 'Marca', key: 'brand' },
  { title: 'Precio', key: 'price' },
  { title: 'Stock', key: 'stock' },
  { title: 'Acciones', key: 'actions', sortable: false },
]

const usedHeaders = [
  { title: 'Producto', key: 'name' },
  { title: 'Vendedor', key: 'seller' },
  { title: 'Estado', key: 'condition' },
  { title: 'Precio', key: 'price' },
  { title: 'Acciones', key: 'actions', sortable: false },
]

// Datos simulados
const games = [
  { id: 1, name: 'Elden Ring', platform: 'PC', price: '59.99 €', stock: 10, co: 10 },
  { id: 2, name: 'God of War', platform: 'PlayStation', price: '49.99 €', stock: 5, co: 5 },
  { id: 3, name: 'Halo Infinite', platform: 'Xbox', price: '39.99 €', stock: 8, co: 8 },
  { id: 4, name: 'The Legend of Zelda', platform: 'Nintendo', price: '59.99 €', stock: 12, co: 12 },
]

const consoles = [
  { id: 1, model: 'PlayStation 5', brand: 'Sony', price: '499 €', stock: 8 },
  { id: 2, model: 'Xbox Series X', brand: 'Microsoft', price: '479 €', stock: 4 },
]

const usedProducts = [
  { id: 1, name: 'Nintendo Switch usada', seller: 'usuario123', condition: 'Usado', price: '180 €' },
  { id: 2, name: 'The Last of Us 2', seller: 'laura45', condition: 'Nuevo', price: '25 €' },
]

// Acciones simuladas
function añadirJuego() {
  formType.value = 'juego'
  isEditing.value = false
  selectedItem.value = null
  dialogAbierto.value = true
}
function editarJuego(item: any) {
  formType.value = 'juego'
  isEditing.value = false
  selectedItem.value = item
  dialogAbierto.value = true
  console.log('Editar juego: ', item)
}
const eliminarJuego = (item: any) => alert('Eliminar juego: ' + item.name)

function añadirConsola() {
  formType.value = 'consola'
  isEditing.value = false
  selectedItem.value = null
  dialogAbierto.value = true
}

function editarConsola(item: any) {
  formType.value = 'consola'
  isEditing.value = false
  selectedItem.value = item
  dialogAbierto.value = true
  console.log('Editar consola: ', item)
}

const eliminarConsola = (item: any) => alert('Eliminar consola: ' + item.model)

const aprobarProducto = (item: any) => alert('Producto aprobado: ' + item.name)
const rechazarProducto = (item: any) => alert('Producto rechazado: ' + item.name)
</script>


<template>
  <v-dialog v-model="dialogAbierto" max-width="800" transition="dialog-bottom-transition" persistent>
    <AddProductDialogComponent :type="formType" :initialData="selectedItem" @cancel="dialogAbierto = false" />
  </v-dialog>

  <v-container fluid class="pa-6">

    <h1 class="text-h5 mb-6">Gestión de Contenidos</h1>

    <v-tabs v-model="tab" background-color="primary" dark>
      <v-tab value="juegos">Juegos</v-tab>
      <v-tab value="consolas">Consolas</v-tab>
      <v-tab value="segundaMano">Segunda Mano</v-tab>
    </v-tabs>

    <v-window v-model="tab" class="mt-4">
      <!-- JUEGOS -->
      <v-window-item value="juegos">
        <v-data-table :headers="gameHeaders" :items="games" class="elevation-1" item-value="id"  :footer-props="{
          itemsPerPageOptions: [5, 10, 25],
          itemsPerPageText: 'Elementos por página:',
          showFirstLastPage: true,
        }">
          <template #top>
            <v-toolbar flat>
              <v-toolbar-title>Juegos</v-toolbar-title>
              <v-spacer></v-spacer>

              <!-- Filtro por plataforma -->
              <v-select label="Plataforma" dense hide-details style="max-width: 150px" />

              <!-- Filtro por nombre -->
              <v-text-field label="Buscar por nombre" dense hide-details append-icon="mdi-magnify"
                style="max-width: 250px; margin-left: 10px;" />

              <!-- Botón de añadir -->
              <v-btn color="primary" @click="añadirJuego">Añadir Juego</v-btn>
            </v-toolbar>

          </template>

          <template #item.actions="{ item }">
            <v-btn icon size="small" color="info" @click="editarJuego(item)" class="mr-1">
              <v-icon>mdi-pencil</v-icon>
            </v-btn>
            <v-btn icon size="small" color="error" @click="eliminarJuego(item)" class="ml-1">
              <v-icon>mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-window-item>

      <!-- CONSOLAS -->
      <v-window-item value="consolas">
        <v-data-table :headers="consoleHeaders" :items="consoles" class="elevation-1" item-value="id">
          <template #top>
            <v-toolbar flat>
              <v-toolbar-title>Consolas</v-toolbar-title>
              <v-spacer></v-spacer>
              <v-btn color="primary" @click="añadirConsola">Añadir Consola</v-btn>

            </v-toolbar>
          </template>

          <template #item.actions="{ item }">
            <v-btn icon size="small" color="info" @click="editarConsola(item)" class="mr-1">
              <v-icon>mdi-pencil</v-icon>
            </v-btn>
            <v-btn icon size="small" color="error" @click="eliminarConsola(item)" class="ml-1">
              <v-icon>mdi-delete</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-window-item>

      <!-- SEGUNDA MANO -->
      <v-window-item value="segundaMano">
        <v-data-table :headers="usedHeaders" :items="usedProducts" class="elevation-1" item-value="id">
          <template #top>
            <v-toolbar flat>
              <v-toolbar-title>Productos de Segunda Mano</v-toolbar-title>
            </v-toolbar>
          </template>

          <template #item.actions="{ item }">
            <v-btn icon color="success" @click="aprobarProducto(item)">
              <v-icon>mdi-check</v-icon>
            </v-btn>
            <v-btn icon color="error" @click="rechazarProducto(item)">
              <v-icon>mdi-close</v-icon>
            </v-btn>
          </template>
        </v-data-table>
      </v-window-item>
    </v-window>
  </v-container>
</template>
