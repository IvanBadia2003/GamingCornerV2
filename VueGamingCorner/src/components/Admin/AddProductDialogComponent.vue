<script setup lang="ts">
import { ref, computed, watch, onMounted } from 'vue'
import { useGenderStore } from '@/stores/GenderStore';
import { useProductStore } from '@/stores/ProductStore';

const genderStore = useGenderStore()
const productStore = useProductStore()

interface VideogameCreate {
    name: string // Nombre del videojuego
    pegi: number // Pegi del juego
    description: string //Descripción del juego
    requisitos1?: string //Requisitos mínimos del juego
    requisitos2?: string //Requisitos recomendados del juego
    stock: number //Cantidad de stock del juego
    discount: number //Porcentaje de descuento sobre el precio del juego
    price: number //Precio del juego
    // platformId?: number
    //genderId?: number[]
    principalImageURL?: string //Imagen principal del juego
    releaseDate: Date //Fecha de lanzamiento del juego 
    distributor: string  //Distribuidor del juego
    developer: string //Desarrollador del juego
}

interface Gender {
    genderId: number
    name: string
}

const props = defineProps<{
    type: 'juego' | 'consola'
    initialData?: Partial<FormDataType>
}>()

const emit = defineEmits<{
    (e: 'cancel'): void
}>()
const gendersSelected = ref<Gender[]>([])

const osOptions = ['Windows 10', 'Windows 11', 'macOS', 'SteamOS', 'Linux']
const cpuOptions = ['Intel i5', 'Intel i7', 'AMD Ryzen 5', 'AMD Ryzen 7']
const ramOptions = ['8 GB', '16 GB', '32 GB']
const gpuOptions = ['GTX 1050', 'GTX 1660', 'RTX 2060', 'RTX 3070']
const storageOptions = ['10 GB', '20 GB', '50 GB', '100 GB']
const pegiOptions = [3, 7, 12, 16, 18]


// Define la interfaz para los datos del prdoducto
interface FormDataType {
    name: string
    price: number | null
    stock: number | null
    description: string
    platform?: string | null
    brand?: string | null
    gender?: number[]
    images: (string)[]
    requisitos1: string | null
    requisitos2: string | null
    pegi: number | null
    discount: number | null
    // provisional
    principalImageURL?: string | null
    developer?: string | null
    distributor?: string | null
    releaseDate?: Date | null
}

const valid = ref(false) // Estado de validación del formulario
const form = ref()
const isGame = computed(() => props.type === 'juego')
const isEditing = computed(() => !!props.initialData) // Si hay datos iniciales, estamos editando
const previewImages = ref<File[]>([]) // Imágenes para la vista previa

const minimumRequirements = ref<string[]>([
    ...props.initialData?.requisitos1?.split(';').map(r => r.trim()) ?? ['', '', '', '', '']
])
const recomendedRequirements = ref<string[]>([
    ...props.initialData?.requisitos2?.split(';').map(r => r.trim()) ?? ['', '', '', '', '']
])

// Datos del formulario
const formData = ref<FormDataType>({
    name: props.initialData?.name || '',
    price: props.initialData?.price || null,
    stock: props.initialData?.stock || null,
    description: props.initialData?.description || '',
    platform: props.initialData?.platform || null,
    brand: props.initialData?.brand || '',
    images: props.initialData?.images || [],
    gender: props.initialData?.gender || [],
    requisitos1: props.initialData?.requisitos1 || null,
    requisitos2: props.initialData?.requisitos2 || null,
    pegi: props.initialData?.pegi || null,
    discount: props.initialData?.discount || null,
    principalImageURL: props.initialData?.principalImageURL || null,
    distributor: props.initialData?.distributor || null,
    developer: props.initialData?.developer || null,
    releaseDate: props.initialData?.releaseDate || null,

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

const handleSubmit = async () => {
    const isValid = await form.value?.validate();
    const formDataVideogame: VideogameCreate = {
        name: formData.value.name,
        pegi: formData.value.pegi || 3,
        description: formData.value.description,
        requisitos1: minimumRequirements.value.join('; ') || '',
        requisitos2: recomendedRequirements.value.join('; ') || '',
        stock: formData.value.stock || 0,
        discount: formData.value.discount || 0,
        price: formData.value.price || 0,
        principalImageURL: formData.value.principalImageURL || '',
        releaseDate: formData.value.releaseDate || new Date(),
        distributor: formData.value.distributor || '',
        developer: formData.value.developer || '',
    }

    if (!isValid) return;

    if (isGame.value) {
        formData.value.requisitos1 = minimumRequirements.value.join('; ')
        formData.value.requisitos2 = recomendedRequirements.value.join('; ')
    }

    if (isEditing.value) {
        console.log('Formulario de edición listo:', formData.value, isEditing.value)
    } else {
        console.log('Formulario de creación listo:', formDataVideogame)
        productStore.createGame(formDataVideogame)
    }

    // Aquí puedes emitir el formulario o hacer algo con los datos
}


</script>

<template>
    <v-card class="pa-6">
        <v-card-title>
            {{ isEditing ? 'Editar' : 'Añadir' }} {{ isGame ? 'Juego' : 'Consola' }}
        </v-card-title>

        <v-card-text>
            <v-form ref="form" v-model="valid">
                <v-text-field label="IMAGEN PROVISIONAL" v-model="formData.principalImageURL"
                    :rules="[rules.required]" />
                <!-- Campos comunes -->
                <v-text-field label="Nombre" v-model="formData.name" :rules="[rules.required]" />
                <v-row>
                    <v-col>
                        <v-text-field label="Precio (€)" type="number" v-model="formData.price"
                            :rules="[rules.required]" />
                    </v-col>
                    <v-col>
                        <v-text-field label="Descuento" type="number" v-model="formData.discount"
                            :rules="[rules.required]" />
                    </v-col>

                </v-row>

                <v-text-field label="Stock" type="number" v-model="formData.stock" :rules="[rules.required]" />
                <v-textarea label="Descripción" v-model="formData.description" :rules="[rules.required]" />
                <v-text-field label="Desarrollador" type="text" v-model="formData.developer"
                    :rules="[rules.required]" />
                <v-text-field label="Distribuidor" type="text" v-model="formData.distributor"
                    :rules="[rules.required]" />

                <!-- Campos específicos -->
                <v-select v-if="isGame" label="Plataforma" :items="['PC', 'PlayStation', 'Xbox', 'Nintendo']"
                    v-model="formData.platform" :rules="[rules.required]" />
                <v-text-field v-model="formData.releaseDate" label="Fecha de lanzamiento" type="date"
                    :rules="[rules.required]" />
                <v-select v-if="isGame" label="PEGI" :items="pegiOptions" v-model="formData.pegi"
                    :rules="[rules.required]" />

                <v-select v-if="isGame" label="Género" :items="genderStore.genders" item-title="name"
                    item-value="genderId" v-model="formData.gender" :rules="[rules.required]" chips multiple />

                <v-row v-if="isGame">
                    <v-col cols="6">
                        <h5>Requisitos Mínimos</h5>
                        <v-row class="mt-2">
                            <v-col cols="12">
                                <v-select label="Sistema Operativo" :items="osOptions" v-model="minimumRequirements[0]"
                                    :rules="[rules.required]" />
                            </v-col>
                            <v-col cols="12">
                                <v-select label="Procesador" :items="cpuOptions" v-model="minimumRequirements[1]"
                                    :rules="[rules.required]" />
                            </v-col>

                            <v-col cols="12">
                                <v-select label="Memoria RAM" :items="ramOptions" v-model="minimumRequirements[2]"
                                    :rules="[rules.required]" />
                            </v-col>
                            <v-col cols="12">
                                <v-select label="Gráficos" :items="gpuOptions" v-model="minimumRequirements[3]"
                                    :rules="[rules.required]" />
                            </v-col>

                            <v-col cols="12">
                                <v-select label="Almacenamiento" :items="storageOptions"
                                    v-model="minimumRequirements[4]" :rules="[rules.required]" />
                            </v-col>
                        </v-row>
                    </v-col>
                    <v-col cols="6">
                        <h5>Requisitos Recomendados</h5>

                        <v-row class="mt-2">
                            <v-col cols="12">
                                <v-select label="Sistema Operativo" :items="osOptions"
                                    v-model="recomendedRequirements[0]" :rules="[rules.required]" />
                            </v-col>
                            <v-col cols="12">
                                <v-select label="Procesador" :items="cpuOptions" v-model="recomendedRequirements[1]"
                                    :rules="[rules.required]" />
                            </v-col>

                            <v-col cols="12">
                                <v-select label="Memoria RAM" :items="ramOptions" v-model="recomendedRequirements[2]"
                                    :rules="[rules.required]" />
                            </v-col>
                            <v-col cols="12">
                                <v-select label="Gráficos" :items="gpuOptions" v-model="recomendedRequirements[3]"
                                    :rules="[rules.required]" />
                            </v-col>

                            <v-col cols="12">
                                <v-select label="Almacenamiento" :items="storageOptions"
                                    v-model="recomendedRequirements[4]" :rules="[rules.required]" />
                            </v-col>
                        </v-row>
                    </v-col>
                </v-row>

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
            <v-btn color="primary" @click="handleSubmit">
                {{ isEditing ? 'Guardar cambios' : 'Crear' }}
            </v-btn>
        </v-card-actions>
    </v-card>
</template>
