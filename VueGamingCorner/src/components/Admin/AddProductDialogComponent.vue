<script setup lang="ts">
import { ref, computed, watch } from 'vue'

interface FormDataType {
    name: string
    price: number | null
    stock: number | null
    description: string
    platform?: string
    brand?: string
    images: File[]
}
const props = defineProps<{
    show: boolean
    type: 'juego' | 'consola'
    initialData?: Partial<FormDataType>
}>()

const emit = defineEmits<{
    (e: 'submit', data: FormDataType): void
    (e: 'cancel'): void
}>()


const dialogVisible = ref(props.show)
watch(() => props.show, val => (dialogVisible.value = val))

const valid = ref(false)
const form = ref()
const isGame = computed(() => props.type === 'juego')
const isEditing = computed(() => !!props.initialData)

const formData = ref<FormDataType>({
    name: '',
    price: null,
    stock: null,
    description: '',
    platform: '',
    brand: '',
    images: [],
    ...props.initialData, // sobrescribe si estás editando
})

const previewImages = ref<string[]>([])

const handleFileUpload = (files: File[]) => {
    formData.value.images = files.slice(0, 6)
    previewImages.value = formData.value.images.map(file =>
        typeof file === 'string' ? file : URL.createObjectURL(file)
    )
}

const handleSubmit = () => {
    if (!valid.value) return
    emit('submit', formData.value)
}

const rules = {
    required: (v: any) => !!v || 'Este campo es obligatorio',
    maxImages: (files: File[] | undefined) => (files?.length || 0) <= 6 || 'Máximo 6 imágenes',
}
</script>

<template>
    <v-dialog v-model="dialogVisible" max-width="800" transition="dialog-bottom-transition" persistent>
        <v-card class="pa-6">
            <v-card-title>
                {{ isEditing ? 'Editar' : 'Añadir' }} {{ isGame ? 'Juego' : 'Consola' }}
            </v-card-title>

            <v-card-text>
                <v-form ref="form" @submit.prevent="handleSubmit" v-model="valid">
                    <!-- Campos comunes -->
                    <v-text-field label="Nombre"  v-model="formData.name" :rules="[rules.required]" />
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
                        <v-file-input accept="image/*" multiple show-size counter :rules="[rules.maxImages]"
                            @change="handleFileUpload" :model-value="formData.images" label="Seleccionar imágenes"
                            prepend-icon="mdi-camera" />
                        <!-- Previsualización de imágenes -->
                        <!-- <div v-if="form.images.length" class="d-flex flex-wrap mt-4 gap-4">
                            <v-img v-for="(image, index) in imagePreviews" :key="index" :src="image" width="100"
                                height="100" cover class="rounded" />
                        </div> -->
                        <v-row class="mt-2" v-if="previewImages.length">
                            <v-col v-for="(image, index) in previewImages" :key="index" cols="4"
                                class="d-flex justify-center">
                                <v-img :src="image" height="100" width="100" cover />
                            </v-col>
                        </v-row>
                    </div>
                </v-form>
            </v-card-text>

            <v-card-actions class="justify-end">
                <v-btn @click="emit('cancel')">Cancelar</v-btn>
                <v-btn color="primary" :disabled="!valid" @click="handleSubmit">
                    {{ isEditing ? 'Guardar cambios' : 'Crear' }}
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

