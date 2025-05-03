<script setup lang="ts">
import { ref, computed, watch } from 'vue'

const props = defineProps<{
    type: 'juego' | 'consola'
    initialData?: Partial<FormDataType>
}>()

const emit = defineEmits<{
    (e: 'cancel'): void
}>()

// Define la interfaz para los datos del prdoducto
interface FormDataType {
    name: string
    price: number | null
    stock: number | null
    description: string
    platform?: string
    brand?: string
    images: (string)[]
}


const valid = ref(false) // Estado de validación del formulario
const form = ref()
const isGame = computed(() => props.type === 'juego')
const isEditing = computed(() => !!props.initialData) // Si hay datos iniciales, estamos editando
const previewImages = ref<File[]>([]) // Imágenes para la vista previa

// Datos del formulario
const formData = ref<FormDataType>({
    name: props.initialData?.name || '',
    price: props.initialData?.price || null,
    stock: props.initialData?.stock || null,
    description: props.initialData?.description || '',
    platform: props.initialData?.platform || '',
    brand: props.initialData?.brand || '',
    images: props.initialData?.images || [],
})


// Observa los cambios en las imágenes y actualiza la vista previa
watch(() => previewImages.value, (files) => {
  formData.value.images = files.map(file =>
    typeof file === 'string' ? file : URL.createObjectURL(file)
  )
})

const rules = {
    required: (v: any) => !!v || 'Este campo es obligatorio',
    maxImages: (files: File[] | undefined) => (files?.length || 0) <= 6 || 'Máximo 6 imágenes',
}

</script>

<template>
    <v-card class="pa-6">
        <v-card-title>
            {{ isEditing ? 'Editar' : 'Añadir' }} {{ isGame ? 'Juego' : 'Consola' }}
        </v-card-title>

        <v-card-text>
            <v-form ref="form" v-model="valid">
                <!-- Campos comunes -->
                <v-text-field label="Nombre" v-model="formData.name" :rules="[rules.required]" />
                <v-text-field label="Precio (€)" type="number" v-model="formData.price" :rules="[rules.required]" />
                <v-text-field label="Stock" type="number" v-model="formData.stock" :rules="[rules.required]" />
                <v-textarea label="Descripción" v-model="formData.description" :rules="[rules.required]" />

                <!-- Campos específicos -->
                <v-select v-if="isGame" label="Plataforma" :items="['PC', 'PlayStation', 'Xbox', 'Nintendo']"
                    v-model="formData.platform" :rules="[rules.required]" />
                <v-text-field v-else label="Marca" v-model="formData.brand" :rules="[rules.required]" />

                <!-- Subida de imágenes -->
                <div class="my-4">
                    <p>Subir imágenes (máx. 6):</p>
                    <v-file-input v-model="previewImages" accept="image/*" multiple show-size counter
                        :rules="[rules.maxImages]" label="Seleccionar imágenes" prepend-icon="mdi-camera" />

                    <v-row class="mt-2" v-if="formData.images.length">
                        <v-col v-for="(image, index) in formData.images" :key="index" cols="4"
                            class="d-flex justify-center">
                            <v-img :src="image" height="100" width="100" cover />
                        </v-col>
                    </v-row>
                </div>
            </v-form>
        </v-card-text>

        <v-card-actions class="justify-end">
            <v-btn @click="emit('cancel')">Cancelar</v-btn>
            <v-btn color="primary" :disabled="!valid">
                {{ isEditing ? 'Guardar cambios' : 'Crear' }}
            </v-btn>
        </v-card-actions>
    </v-card>
</template>
