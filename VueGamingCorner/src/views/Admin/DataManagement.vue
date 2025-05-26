<script setup lang="ts">
import { onMounted, ref } from 'vue'
import AddProductDialogComponent from '@/components/Admin/AddProductDialogComponent.vue'
import DataTableComponent from '@/components/DataTableComponent.vue'

import { useProductStore } from '@/stores/ProductStore';
import { useGenderStore } from '@/stores/GenderStore';

const genderStore = useGenderStore();
const productStore = useProductStore();

onMounted(() => {
  productStore.getAllVideogames();
  productStore.getAllConsoles();
  genderStore.getAllGenders()
});


const tab = ref('juegos')
const dialogAbierto = ref(false)
const formType = ref<'juego' | 'consola'>('juego')
const isEditing = ref(false)
const selectedItem = ref<any>(null)
const search = ref('')
// Cabeceras para cada tabla

const gameHeaders = [
  { title: 'Nombre', key: 'name' },
  { title: 'Plataforma', key: 'platform' },
  { title: 'Precio', key: 'price' },
  { title: 'Discount', key: 'discount' },
  { title: 'Stock', key: 'stock' },
  { title: 'Acciones', key: 'actions', sortable: false },
]

const consoleHeaders = [
  { title: 'Modelo', key: 'name' },
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
function deleteVideogame(item: any) {
  productStore.deleteVideogame(item.id)
}

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
function eliminarConsola(item: any) {
  productStore.deleteConsole(item.id)
}


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
        <DataTableComponent :headers="gameHeaders" :items="productStore.videogames" title="Juegos" icon="mdi-controller"
          add-label="Añadir juego" search-key="name" :on-add="añadirJuego" :on-edit="editarJuego"
          :on-delete="deleteVideogame" />

      </v-window-item>

      <!-- CONSOLAS -->
      <v-window-item value="consolas">
        <DataTableComponent :headers="consoleHeaders" :items="productStore.consoles" title="Consolas"
          icon="mdi-controller" add-label="Añadir consola" search-key="name" :on-add="añadirConsola"
          :on-edit="editarConsola" :on-delete="eliminarConsola" />
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
            <v-icon @click="aprobarProducto(item)">mdi-check</v-icon>
            <v-icon @click="rechazarProducto(item)">mdi-close</v-icon>
          </template>
        </v-data-table>
      </v-window-item>
    </v-window>
  </v-container>
</template>
