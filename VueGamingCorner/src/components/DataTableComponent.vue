<script setup lang="ts">
import { ref, computed } from 'vue'

interface Props {
    headers: any[]
    items: any[]
    title: string
    searchKey?: string
    icon?: string
    addLabel?: string
    onAdd: () => void
    onEdit: (item: any) => void
    onDelete: (item: any) => void
}

defineProps<Props>()

const search = ref('')
</script>

<template>
    <v-data-table :headers="headers" :items="items" class="elevation-1" item-value="id" v-model:search="search"
        :filter-keys="[searchKey || 'name']">
        <template #top>
            <v-toolbar flat>
                <v-toolbar-title>
                    <v-icon color="medium-emphasis" :icon="icon || 'mdi-database'" size="x-small" start></v-icon>
                    {{ title }}
                </v-toolbar-title>
                <v-text-field v-model="search" density="compact" label="Buscar" prepend-inner-icon="mdi-magnify"
                    variant="solo-filled" flat hide-details single-line style="max-width: 300px;" class="mr-3"></v-text-field>
                <v-btn class="me-2" prepend-icon="mdi-plus" rounded="lg" :text="addLabel || 'Añadir'" border
                    @click="onAdd"></v-btn>
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
