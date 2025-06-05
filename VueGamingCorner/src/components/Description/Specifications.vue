<script lang="ts" setup>
import { useProductStore } from '@/stores/ProductStore';

const productStore = useProductStore();

</script>
<template>
    <div v-if="productStore.product">
        <!-- Si es un videojuego -->
        <div v-if="'developer' in productStore.product">
            <h3>CONFIGURACIÓN</h3>
            <v-row dense>
                <v-col cols="12" lg="6">
                    <h4>MINIMA</h4>
                    <v-row dense>
                        <template v-for="(item, index) in productStore.minimumRequirements" :key="'min-' + index">
                            <v-col cols="5">
                                <strong>{{ item.tag.toUpperCase() }}:</strong>
                            </v-col>
                            <v-col cols="7">
                                {{ item.valor }}
                            </v-col>
                        </template>
                    </v-row>
                </v-col>

                <v-col cols="12" lg="6">
                    <h4>MAXIMA</h4>
                    <v-row dense>
                        <template v-for="(item, index) in productStore.recommendedRequirements" :key="'max-' + index">
                            <v-col cols="5">
                                <strong>{{ item.tag.toUpperCase() }}:</strong>
                            </v-col>
                            <v-col cols="7">
                                {{ item.valor }}
                            </v-col>
                        </template>
                    </v-row>
                </v-col>
            </v-row>
        </div>

        <!-- Si es una consola -->
        <div v-else-if="'brand' in productStore.product">
            <h3>ESPECIFICACIONES</h3>
            <v-row dense>
                <template v-for="(item, index) in productStore.specificationsConsole" :key="'spec-' + index">
                    <v-col cols="3">
                        <strong>{{ item.tag.toUpperCase() }}:</strong>
                    </v-col>
                    <v-col cols="3">
                        {{ item.valor }}
                    </v-col>
                </template>
            </v-row>
        </div>
    </div>
</template>




<style lang="css" scoped></style>