<script lang="ts" setup>
import { useProductStore } from '@/stores/ProductStore';

const productStore = useProductStore();

</script>

<template>
    <v-row dense v-if="productStore.product && 'developer' in productStore.product">
        <v-col cols="12" sm="5">
            <strong>Género:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            <div class="tags">
                <v-chip v-for="(gender, index) in productStore.product?.genders" :key="index" class="mr-2" color="blue-darken-3">{{gender.name}}</v-chip>
            </div>
        </v-col>

        <v-col cols="12" sm="5">
            <strong>Fecha de lanzamiento:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            {{ productStore.formattedReleaseDate }}
        </v-col>

        <v-col cols="12" sm="5" v-if="productStore.product && 'developer' in productStore.product">
            <strong>Desarrollador:</strong>
        </v-col>
        <v-col cols="12" sm="7" v-if="productStore.product && 'developer' in productStore.product">
            {{ productStore.product?.developer }}
        </v-col>

        <v-col cols="12" sm="5" v-if="productStore.product && 'distributor' in productStore.product">
            <strong>Distribuidor:</strong>
        </v-col>
        <v-col cols="12" sm="7" v-if="productStore.product && 'distributor' in productStore.product">
            {{ productStore.product?.distributor }}
        </v-col>

        <v-col cols="12" sm="5">
            <strong>Instalación:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            Cómo activar tu producto
        </v-col>
    </v-row>

    <v-row dense v-if="productStore.product && 'brand' in productStore.product">

        <v-col cols="12" sm="5">
            <strong>Marca:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            {{ productStore.product.brand }}
        </v-col>
        <v-col cols="12" sm="5">
            <strong>Generación:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            8ª Generación
        </v-col>
        <v-col cols="12" sm="5">
            <strong>Servicios:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            PlayStation Plus, PS Now, PS Store
        </v-col>
        <v-col cols="12" sm="5">
            <strong>Colores:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            Blanco, Negro, Rojo Edición Limitada
        </v-col>
        <v-col cols="12" sm="5">
            <strong>Fecha de lanzamiento:</strong>
        </v-col>
        <v-col cols="12" sm="7">
            {{ productStore.formattedReleaseDate }}
        </v-col>



    </v-row>
</template>

<style scoped lang="scss"></style>