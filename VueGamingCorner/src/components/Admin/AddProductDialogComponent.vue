<script setup lang="ts">
import { ref, computed, watch, onMounted, nextTick } from 'vue'
import { useGenderStore, type GenderCreate } from '@/stores/GenderStore';
import { useProductStore, type ConsoleCreate, type UpdateConsole, type VideogameCreate } from '@/stores/ProductStore';
import { SystemEnum, usePlatformStore, type PlatformCreate } from '@/stores/PlatformStore';
import { de } from 'vuetify/locale';
import UploadImagesComponent from '../UploadImagesComponent.vue';
import { useCloudinaryStore } from '@/stores/CloudinaryStore';

const genderStore = useGenderStore()
const productStore = useProductStore()
const platformStore = usePlatformStore()
const cloudinaryStore = useCloudinaryStore()


interface Gender {
    genderId: number
    name: string
}

const props = defineProps<{
    type: 'juego' | 'consola' | 'genero' | 'plataforma'
    initialData?: Partial<FormDataType>
}>()

const emit = defineEmits<{
    (e: 'cancel'): void
}>()
const gendersSelected = ref<Gender[]>([])

const osOptions = ['Windows 10', 'Windows 11', 'macOS', 'SteamOS', 'Linux']
const cpuOptions = ['Intel i5', 'Intel i7', 'AMD Ryzen 5', 'AMD Ryzen 7']
const ramOptions = ['2 GB', '4 GB', '8 GB', '16 GB', '32 GB']
const gpuOptions = ['GTX 1050', 'GTX 1660', 'RTX 2060', 'RTX 3070']
const storageOptions = ['10 GB', '20 GB', '50 GB', '100 GB']
const pegiOptions = [3, 7, 12, 16, 18]
const weightOptions = ['1 kg', '2 kg', '3 kg', '4 kg', '5 kg']
const networkOptions = ['Wi-Fi', 'Ethernet', 'Bluetooth']
const powerOptions = ['50W', '100W', '150W', '200W']
const energyOptions = ['B', 'C', 'D', 'E', 'F']
const AVOptions = ['HDMI', 'DisplayPort', 'VGA', 'DVI']
const portsOptions = ['USB-A', 'USB-C', 'HDMI', 'Ethernet']
const generationsOptions = ['1ª Generación', '2ª Generación', '3ª Generación', '4ª Generación', '5ª Generación', '6ª Generación', '7ª Generación', '8ª Generación', '9ª Generación']


// Define la interfaz para los datos del prdoducto
interface FormDataType {
    name: string
    price: number | null
    stock: number | null
    description: string
    platformId?: number | null
    brand?: string | null
    genderId?: number[]
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
    specifications?: string | null
    colors?: string | null,
    generation?: string | null,
    services?: string | null,
    id: number | null,
    system?: SystemEnum | null
    main: string | null,
    background: string | null,
    content1: string | null,
    content2: string | null,
    content3: string | null,
    content4: string | null
}

const valid = ref(false) // Estado de validación del formulario
const form = ref()
const isGame = computed(() => props.type === 'juego')
const isConsole = computed(() => props.type === 'consola')
const isPlatform = computed(() => props.type === 'plataforma')
const isGender = computed(() => props.type === 'genero')
const isGenderOrPlatform = computed(() => props.type === 'genero' || props.type === 'plataforma')
const isEditing = computed(() => !!props.initialData) // Si hay datos iniciales, estamos editando
const previewImages = ref<File[]>([]) // Imágenes para la vista previa

const minimumRequirements = ref<string[]>([
    ...props.initialData?.requisitos1?.split(';').map(r => r.trim()) ?? ['', '', '', '', '']
])
const recomendedRequirements = ref<string[]>([
    ...props.initialData?.requisitos2?.split(';').map(r => r.trim()) ?? ['', '', '', '', '']
])
const specificationsConsole = ref<Array<string[]>>(
    props.initialData?.specifications
        ? props.initialData.specifications.split(';').map(s => s.split(',').map(i => i.trim()))
        : Array(10).fill([]) // 10 campos vacíos
)


// Datos del formulario
const formData = ref<FormDataType>({
    name: props.initialData?.name || '',
    price: props.initialData?.price || null,
    stock: props.initialData?.stock || null,
    description: props.initialData?.description || '',
    platformId: props.initialData?.platformId || null,
    brand: props.initialData?.brand || '',
    images: props.initialData?.images || [],
    genderId: props.initialData?.genderId || [],
    requisitos1: props.initialData?.requisitos1 || null,
    requisitos2: props.initialData?.requisitos2 || null,
    specifications: props.initialData?.specifications || null,
    pegi: props.initialData?.pegi || null,
    discount: props.initialData?.discount || null,
    principalImageURL: props.initialData?.principalImageURL || null,
    distributor: props.initialData?.distributor || null,
    developer: props.initialData?.developer || null,
    releaseDate: props.initialData?.releaseDate || null,
    colors: props.initialData?.colors || '',
    generation: props.initialData?.generation || '',
    services: props.initialData?.services || '',
    id: props.initialData?.id || null,
    system: props.initialData?.system || null,
    background: props.initialData?.background || null,
    content1: props.initialData?.content1 || null,
    content2: props.initialData?.content2 || null,
    content3: props.initialData?.content3 || null,
    content4: props.initialData?.content4 || null,
    main: props.initialData?.main || null



})

// Formatea la fecha de lanzamiento para el input de tipo date
const releaseDateFormatted = computed({
    get: () => {
        const date = formData.value.releaseDate
        return date ? new Date(date).toISOString().split('T')[0] : null
    },
    // Setter para actualizar la fecha de lanzamiento
    set: (value: string) => {
        formData.value.releaseDate = value ? new Date(value) : null
    }
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
    debugger
    console.log(formData.value);
    await cloudinaryStore.uploadImages(props.type, formData.value.name)
    await nextTick()
    const media = useCloudinaryStore().getMedia(props.type, formData.value.name);

    const isValid = await form.value?.validate();


    // Preparar los datos del formulario para crear el videojuego
    const formDataVideogame: VideogameCreate = {
        platformId: formData.value.platformId || 0,
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
        genderId: formData.value.genderId || [],
        background: media.background,
        content1: media.content1,
        content2: media.content2,
        content3: media.content3,
        content4: media.content4,
        main: media.main
    }

    const formDataVideogameUpdate: VideogameCreate = {
        platformId: formData.value.platformId || 0,
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
        genderId: formData.value.genderId || [],
        background: media.background,
        content1: media.content1,
        content2: media.content2,
        content3: media.content3,
        content4: media.content4,
        main: media.main
    }

    // Preparar los datos del formulario para crear la consola
    const formDataCreateConsole: ConsoleCreate = {
        platformId: formData.value.platformId || 0,
        name: formData.value.name,
        description: formData.value.description,
        stock: formData.value.stock || 0,
        discount: formData.value.discount || 0,
        price: formData.value.price || 0,
        principalImageURL: formData.value.principalImageURL || '',
        releaseDate: formData.value.releaseDate || new Date(),
        brand: formData.value.brand || '',
        specifications: specificationsConsole.value.map(items => items.map(i => `${i}`).join(', ')).join('; ') || '',
        colors: formData.value.colors || '',
        generation: formData.value.generation || '',
        services: formData.value.services || '',
        background: media.background,
        content1: media.content1,
        content2: media.content2,
        content3: media.content3,
        content4: media.content4,
        main: media.main
    }

    // Preparar los datos del formulario para editar la consola
    const formDataUpdateConsole: UpdateConsole = {
        platformId: formData.value.platformId || 0,
        name: formData.value.name,
        description: formData.value.description,
        stock: formData.value.stock || 0,
        discount: formData.value.discount || 0,
        price: formData.value.price || 0,
        principalImageURL: formData.value.principalImageURL || '',
        releaseDate: formData.value.releaseDate || new Date(),
        brand: formData.value.brand || '',
        specifications: specificationsConsole.value.map(items => items.map(i => `${i}`).join(', ')).join('; ') || '',
        colors: formData.value.colors || '',
        generation: formData.value.generation || '',
        services: formData.value.services || '',
    }

    const formDataGender: GenderCreate = {
        name: formData.value.name,
    }
    const formDataPlatform: PlatformCreate = {
        name: formData.value.name,
        system: formData.value.system || SystemEnum.PC,
    }

    if (!isValid) return;

    if (isGame.value) {

    }

    //Si es videojuego y edición
    if (isEditing.value && isGame.value) {
        console.log("Datos que le llegan" + formDataVideogameUpdate);
        productStore.updateVideogame(formData.value.id as number, formDataVideogameUpdate)
        console.log('Formulario de edición listo:', formDataVideogameUpdate, isEditing.value)
        emit('cancel')

    }
    //Si es videojuego y creación
    else if (!isEditing.value && isGame.value) {
        console.log('Formulario de creación listo:', formDataVideogame)
        debugger
        productStore.createGame(formDataVideogame)
        emit('cancel')

    }
    //Si es consola y edición
    else if (isEditing.value && isConsole.value) {
        console.log('Formulario de edición listo:', formDataCreateConsole, isEditing.value)
        productStore.updateConsole(formData.value.id as number, formDataUpdateConsole)
        emit('cancel')

    }
    //Si es consola y creación
    else if (!isEditing.value && isConsole.value) {
        console.log('Formulario de creación listo:', formDataCreateConsole)
        productStore.createConsole(formDataCreateConsole)
        emit('cancel')

    }
    //Si es genero y creación
    else if (!isEditing.value && isGender.value) {
        console.log('Formulario de creación listo:', formDataGender)
        genderStore.createGender(formDataGender)
        emit('cancel')

    }
    //Si es genero y edición
    else if (isEditing.value && isGender.value) {
        console.log('Formulario de edición listo:', formDataGender, isEditing.value)
        emit('cancel')

    }
    //Si es plataforma y creación
    else if (!isEditing.value && isPlatform.value) {
        console.log('Formulario de creación listo:', formDataPlatform)
        platformStore.createPlatform(formDataPlatform)
        emit('cancel')
    }
    //Si es plataforma y edición
    else if (isEditing.value && isPlatform.value) {
        console.log('Formulario de edición listo:', formDataPlatform, isEditing.value)
        emit('cancel')

    }

    // Aquí puedes emitir el formulario o hacer algo con los datos
}


</script>

<template>
    <v-card class="pa-6">
        <v-card-title>
            {{ isEditing ? 'Editar' : 'Añadir' }} {{ isGame ? 'Juego' : isConsole ? 'Consola' : isGender ? 'Género' :
                isPlatform ? 'Plataforma' : 'Producto' }}
        </v-card-title>

        <v-card-text>
            <v-form ref="form" v-model="valid">
                <!-- Campos comunes -->
                <v-text-field label="Nombre" v-model="formData.name" :rules="[rules.required]" />
                <v-row v-if="!isGenderOrPlatform">
                    <v-col>
                        <v-text-field label="Precio (€)" type="number" v-model="formData.price"
                            :rules="[rules.required]" />
                    </v-col>
                    <v-col>
                        <v-text-field label="Descuento" type="number" v-model="formData.discount"
                            :rules="[rules.required]" />
                    </v-col>

                </v-row>

                <v-text-field v-if="!isGenderOrPlatform" label="Stock" type="number" v-model="formData.stock"
                    :rules="[rules.required]" />
                <v-textarea v-if="!isGenderOrPlatform" label="Descripción" v-model="formData.description"
                    :rules="[rules.required]" />
                <!-- Campos específicos -->
                <v-text-field v-if="isGame" label="Desarrollador" type="text" v-model="formData.developer"
                    :rules="[rules.required]" />

                <v-text-field v-if="isGame" label="Distribuidor" type="text" v-model="formData.distributor"
                    :rules="[rules.required]" />

                <v-select v-if="isGame || isConsole" label="Plataforma" :items="platformStore.platforms"
                    v-model="formData.platformId" :rules="[rules.required]" item-title="name" item-value="platformId" />

                <v-text-field v-if="!isGenderOrPlatform" v-model="releaseDateFormatted" label="Fecha de lanzamiento"
                    type="date" :rules="[rules.required]" />

                <v-select v-if="isGame" label="PEGI" :items="pegiOptions" v-model="formData.pegi"
                    :rules="[rules.required]" />

                <v-select v-if="isGame" label="Género" :items="genderStore.genders" item-title="name"
                    item-value="genderId" v-model="formData.genderId" :rules="[rules.required]" chips multiple />

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


                <v-text-field v-if="isConsole" label="Marca" v-model="formData.brand" :rules="[rules.required]" />
                <v-select v-if="isConsole" label="Generación" v-model="formData.generation"
                    :items="generationsOptions" />
                <v-text-field v-if="isConsole" label="Servicios" v-model="formData.services"
                    :rules="[rules.required]" />
                <v-text-field v-if="isConsole" label="Colores" v-model="formData.colors" :rules="[rules.required]" />
                <v-row v-if="isConsole">
                    <v-col cols="12">
                        <h5>Especificacoines</h5>
                        <v-row class="mt-2">
                            <v-col cols="6">
                                <v-select label="CPU" :items="cpuOptions" v-model="specificationsConsole[0]"
                                    :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="GPU" :items="gpuOptions" v-model="specificationsConsole[1]"
                                    :rules="[rules.required]" multiple />
                            </v-col>

                            <v-col cols="6">
                                <v-select label="Memoria" :items="ramOptions" v-model="specificationsConsole[2]"
                                    :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Almacenamiento" :items="storageOptions"
                                    v-model="specificationsConsole[3]" :rules="[rules.required]" multiple />
                            </v-col>

                            <v-col cols="6">
                                <v-select label="Peso" :items="weightOptions" v-model="specificationsConsole[4]"
                                    :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Entrada/Salida" :items="portsOptions"
                                    v-model="specificationsConsole[5]" :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Red" :items="networkOptions" v-model="specificationsConsole[6]"
                                    :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Alimentación" :items="powerOptions" v-model="specificationsConsole[7]"
                                    :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Consumo de energía" :items="energyOptions"
                                    v-model="specificationsConsole[8]" :rules="[rules.required]" multiple />
                            </v-col>
                            <v-col cols="6">
                                <v-select label="Salida AV" :items="AVOptions" v-model="specificationsConsole[9]"
                                    :rules="[rules.required]" multiple />
                            </v-col>

                        </v-row>
                    </v-col>
                </v-row>

                <v-select v-if="isPlatform" label="Sistema" :items="platformStore.systemOptions"
                    v-model="formData.system" :rules="[rules.required]" item-title="label" item-value="value" />


                <!-- Subida de imágenes -->
                <v-divider class="my-4" />
                <h5 class="mb-2">Subir imágenes</h5>

                <!-- <v-file-input v-if="entityType === 'users'" v-model="cloudinaryStore.avatarImage" label="Avatar" /> -->

                <v-file-input v-if="isConsole || isGame || isPlatform" 
                    v-model="cloudinaryStore.mainImage" label="Imagen principal" />

                <v-file-input v-if="isGame"  v-model="cloudinaryStore.backgroundImage"
                    label="Imagen de fondo" />

                <v-file-input v-if="isConsole || isGame"  v-model="cloudinaryStore.contentImages[0]"
                    label="Contenido 1" />
                <v-file-input v-if="isConsole || isGame"  v-model="cloudinaryStore.contentImages[1]"
                    label="Contenido 2" />
                <v-file-input v-if="isConsole || isGame"  v-model="cloudinaryStore.contentImages[2]"
                    label="Contenido 3" />
                <v-file-input v-if="isConsole || isGame"  v-model="cloudinaryStore.contentImages[3]"
                    label="Contenido 4" />
                <!-- <div v-if="!isGenderOrPlatform" class="my-4">
                    <p>Subir imágenes (máx. 6):</p>
                    <v-file-input v-model="previewImages" accept="image/*" multiple show-size counter
                        :rules="[rules.maxImages]" label="Seleccionar imágenes" prepend-icon="mdi-camera" />

                    <v-row class="mt-2" v-if="formData.images.length">
                        <v-col v-for="(image, index) in formData.images" :key="index" cols="4"
                            class="d-flex justify-center">
                            <v-img :src="image" height="100" width="100" cover />
                        </v-col>
                    </v-row>
                </div> -->
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
