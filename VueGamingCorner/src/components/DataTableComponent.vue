<script setup lang="ts">
import { usePlatformStore } from '@/stores/PlatformStore'
import { ref, computed } from 'vue'
const platformStore = usePlatformStore()
interface Props {
    headers: any[]
    items: any[]
    title: string
    searchKey?: string
    icon?: string
    addLabel?: string
    filterFields?: string[]
    onAdd: () => void
    onEdit: (item: any) => void
    onDelete: (item: any) => void
}
const categories = ['Acción', 'Aventura', 'RPG', 'Deportes', 'Carreras'];
const platforms = ['PlayStation', 'Xbox', 'Nintendo', 'PC'];
const stores = ['Steam', 'Epic Games', 'Ubisoft', 'PlayStation 4', 'PlayStation 5', 'Xbox One', 'Xbox Series X', 'Nintendo Switch'];
const props = defineProps<Props & { filterFields?: string[] }>()

const search = ref('')

function customFilter(value: any, search: string, item: any) {
  // Filtro de búsqueda por texto
  const searchText = search.toString().toLowerCase()
  const matchesSearch = props.filterFields?.some(field => {
    const keys = field.split('.')
    let fieldValue = item
    for (const key of keys) {
      if (fieldValue && typeof fieldValue === 'object') {
        fieldValue = fieldValue[key]
      } else {
        return false
      }
    }
    return String(fieldValue).toLowerCase().includes(searchText)
  }) ?? true

  // Filtro por plataforma
  const matchesPlatform = !selectedPlatform.value ||
    item.product?.platform?.name === selectedPlatform.value ||
    item.platform?.name === selectedPlatform.value

  // Filtro por categoría (si aplica)
  const matchesCategory = !selectedCategory.value || item.category === selectedCategory.value

  // Filtro por tienda (si aplica)
  const matchesStore = !selected.value || item.store === selected.value

  return matchesSearch && matchesPlatform && matchesCategory && matchesStore
}

const selectedPlatform = ref(null)
const selectedCategory = ref(null)
const selected = ref(null) 
</script>

<template>

<v-data-table
  :headers="headers"
  :items="items"
  class="elevation-1"
  item-value="id"
  v-model:search="search"
  :custom-filter="customFilter"
>

        <template #top>
            <v-toolbar flat class="flex-wrap">
                <v-toolbar-title class="mr-4">
                    <v-icon color="medium-emphasis" :icon="icon || 'mdi-database'" size="x-small" start></v-icon>
                    {{ title }}
                </v-toolbar-title>

                <!-- Filtro de búsqueda -->
                <v-text-field v-model="search" density="compact" label="Buscar" prepend-inner-icon="mdi-magnify"
                    variant="solo-filled" flat hide-details single-line style="max-width: 300px;" class="mr-3" />

                <!-- Filtro de platforms -->
                <v-select v-model="selectedPlatform" :items="platformStore.systemOptions" label="Sistema"
                    density="compact" variant="solo-filled" hide-details style="max-width: 200px;" class="mr-3"
                    clearable />
                <!-- Filtro de categoría -->
                <v-select v-if="title === 'Juegos'" v-model="selectedCategory" :items="categories" label="Categoría"
                    density="compact" variant="solo-filled" hide-details style="max-width: 200px;" class="mr-3"
                    clearable />
                <!-- Filtro de tiendas -->
                <v-select v-if="title === 'Juegos'" v-model="selected" :items="stores" label="Tienda" density="compact"
                    variant="solo-filled" hide-details style="max-width: 200px;" class="mr-3" clearable />

                <!-- Botón de acción -->
                <v-btn class="me-2" prepend-icon="mdi-plus" rounded="lg" :text="addLabel || 'Añadir'" border
                    @click="onAdd" />
            </v-toolbar>
        </template>

        <template #item.name="{ value }">
            <v-chip :text="value" border="thin opacity-25" prepend-icon="mdi-book" label>
                <template #prepend>
                    <v-icon color="medium-emphasis"></v-icon>
                </template>
            </v-chip>
        </template>

        <template #item.actions="{ item }">
            <div>
                <v-icon color="medium-emphasis" class="mr-1" icon="mdi-pencil" size="small"
                    @click="onEdit(item)"></v-icon>

                <v-icon color="medium-emphasis" class="ml-1" icon="mdi-delete" size="small"
                    @click="onDelete(item)"></v-icon>
            </div>
        </template>
    </v-data-table>
</template>
