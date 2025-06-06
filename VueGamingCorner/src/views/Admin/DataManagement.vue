<script setup lang="ts">
import { onMounted, ref } from 'vue'
import AddProductDialogComponent from '@/components/Admin/AddProductDialogComponent.vue'
import DataTableComponent from '@/components/DataTableComponent.vue'

import { useProductStore } from '@/stores/ProductStore';
import { useGenderStore } from '@/stores/GenderStore';
import { usePlatformStore } from '@/stores/PlatformStore';

const genderStore = useGenderStore();
const productStore = useProductStore();
const platformStore = usePlatformStore();

onMounted(() => {
  productStore.getAllSecondHand();
  productStore.getAllVideogames();
  productStore.getAllConsoles();
  genderStore.getAllGenders()
  platformStore.getAllPlatforms()
  console.log(productStore.videogames);

});


const tab = ref('juegos')
const dialogAbierto = ref(false)
const formType = ref<'juego' | 'consola' | 'genero' | 'plataforma'>('juego') // Tipo de formulario: 'juego', 'consola' o null para géneros
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
  { title: 'Vendedor', key: 'user.name' }, // Accedemos al nombre del vendedor
  { title: 'Estado', key: 'estado' },      // Usaremos un slot para mostrarlo
  { title: 'Precio', key: 'price' },
  { title: 'Acciones', key: 'actions', sortable: false },
]

const genderHeaders = [
  { title: 'Nombre', key: 'name' },
]

const platformHeaders = [
  { title: 'Nombre', key: 'name' },
]

const usedProducts = [
  { id: 1, name: 'Nintendo Switch usada', seller: 'usuario123', condition: 'Usado', price: '180 €' },
  { id: 2, name: 'The Last of Us 2', seller: 'laura45', condition: 'Nuevo', price: '25 €' },
]

// Acciones para juegos
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
////////////////////////////////////

// Acciones para consolas
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
////////////////////////////////////


// Acciones para generos
function añadirGenero() {
  formType.value = 'genero'
  isEditing.value = false
  selectedItem.value = null
  dialogAbierto.value = true
  console.log(formType.value)

}

function editarGenero(item: any) {
  formType.value = 'genero'
  isEditing.value = false
  selectedItem.value = item
  dialogAbierto.value = true
  console.log('Editar consola: ', item)
}
function eliminarGenero(item: any) {
  console.log('Eliminar género: ', item);

  //productStore.deleteConsole(item.id)
}
////////////////////////////////////

// Acciones para plataformas
function añadirPlataforma() {
  formType.value = 'plataforma'
  isEditing.value = false
  selectedItem.value = null
  dialogAbierto.value = true
}

function editarPlataforma(item: any) {
  formType.value = 'plataforma'
  isEditing.value = false
  selectedItem.value = item
  dialogAbierto.value = true
  console.log('Editar consola: ', item)
}
function eliminarPlataforma(item: any) {
  console.log('Eliminar género: ', item);

  //productStore.deleteConsole(item.id)
}
////////////////////////////////////

const aprobarProducto = (item: any) => {
  productStore.changeCheck(item.id)
}
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
      <v-tab value="generos">Géneros</v-tab>
      <v-tab value="plataformas">Plataformas</v-tab>
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

        <v-data-table :headers="usedHeaders" :items="productStore.secondHandProducts" class="elevation-1"
          item-value="id">
          <template #top>
            <v-toolbar flat>
              <v-toolbar-title>Productos de Segunda Mano</v-toolbar-title>
            </v-toolbar>
          </template>

          <!-- Vendedor (ya se accede directamente por user.name) -->

          <!-- Estado -->
          <template #item.estado="{ item }">
            <v-chip :color="item.isChecked ? 'green' : 'orange'" dark small>
              {{ item.isChecked ? 'Aprobado' : 'Pendiente' }}
            </v-chip>
          </template>

          <!-- Acciones -->
          <template #item.actions="{ item }">
            <v-icon class="me-2" color="green" @click="aprobarProducto(item)">mdi-check</v-icon>
            <v-icon color="red" @click="">mdi-close</v-icon>
          </template>
        </v-data-table>

      </v-window-item>

      <!-- GENEROS -->
      <v-window-item value="generos">
        <DataTableComponent :headers="genderHeaders" :items="genderStore.genders" title="Géneros" icon="mdi-controller"
          add-label="Añadir género" search-key="name" :on-add="añadirGenero" :on-edit="editarGenero"
          :on-delete="eliminarGenero" />

      </v-window-item>
      <!-- PLATAFORMAS -->
      <v-window-item value="plataformas">
        <DataTableComponent :headers="platformHeaders" :items="platformStore.platforms" title="Plataformas"
          icon="mdi-controller" add-label="Añadir plataforma" search-key="name"
          :filter-fields="['name', 'brand', 'description']" :on-add="añadirPlataforma" :on-edit="editarPlataforma"
          :on-delete="eliminarPlataforma" />

      </v-window-item>
    </v-window>
  </v-container>
</template>
