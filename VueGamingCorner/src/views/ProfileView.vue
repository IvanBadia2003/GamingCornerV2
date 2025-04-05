    <script setup lang="ts">
    import { computed, ref } from 'vue'
    import { useDisplay } from 'vuetify'
    import CardComponent from '@/components/CardComponent.vue'



    const { xs, sm, md, lg } = useDisplay()

    const avatarSize = computed(() => {
        if (xs.value) return 80
        if (sm.value) return 120
        if (md.value) return 150
        if (lg.value) return 200
        return 220
    })

    const tab = ref(0)
    const mostrarProductos = ref(false)
</script>
<template>

    <v-container style="width: 80%;">
        <v-row class=" pa-5">
            <v-col cols="12" sm="12" md="12" lg="12" class="d-flex flex-column align-center justify-center text-center">
                <v-row justify="center">
                    <v-col cols="12" class="d-flex flex-column align-center justify-center text-center">
                        <v-avatar :size="avatarSize">
                            <v-img alt="John" src="https://cdn.vuetifyjs.com/images/john.jpg"></v-img>
                        </v-avatar>
                    </v-col>
                </v-row>

                <v-row justify="center">
                    <v-col cols="12">
                        <v-row justify="center">
                            <v-col cols="12">

                                <p>nombre de usuario</p>
                                <p>16 de noviembre</p>
                            </v-col>
                        </v-row>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </v-container>

    <v-row class="bg-primary ">
        <v-col cols="12" class="pa-0 d-flex justify-center align-center">
            <v-tabs v-model="tab" bg-color="primary" style="width: 80%;">
                <v-row class="d-flex justify-space-between">
                    <v-col cols="12" md="7">
                        <v-row class="" no-gutters>

                            <v-col cols="3">
                                <v-tab value="one">General</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="two">Mis pedidos</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="three">favoritos</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="four">Biblioteca</v-tab>
                            </v-col>
                            <v-col cols="2">
                                <v-tab value="five">Reviews</v-tab>
                            </v-col>
                        </v-row>

                    </v-col>
                    <v-col cols="12" md="2">
                        <v-tab value="six">Configuración</v-tab>
                    </v-col>
                </v-row>
            </v-tabs>

        </v-col>
    </v-row>

    <v-row class="bg-surface">
        <v-container style="width: 80%;">
            <v-row class="py-10">
                <v-col cols="12">
                    <v-tabs-window v-model="tab">
                        <v-tabs-window-item value="one">
                            <v-row>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary">
                                        <v-card-title class="pt-5">PRODUCTOS COMPRADOS</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Juegos</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Consolas</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <div>
                                                        <p>Segunda Mano</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary h-100">
                                        <v-card-title class="pt-5">PRODUCTOS EN VENTA</v-card-title>
                                        <v-card-text class="py-10" v-if="mostrarProductos">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>En venta</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>Esperando Validación</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>

                                            </v-row>

                                        </v-card-text>
                                        <v-card-text class="py-10" v-else>
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12">
                                                    <div>
                                                        <p>AÚN NO HAS PUESTO NADA A LA VENTA</p>
                                                        <v-btn @click="mostrarProductos = true" color="primary">PON ALGO
                                                            A LA VENTA</v-btn>
                                                    </div>
                                                </v-col>


                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row >
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary">
                                        <v-card-title class="pt-5">ÚLTIMOS JUEGOS EN FAVORITOS</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Tom Clancy's" src="https://cdn1.epicgames.com/offer/acf914daf6034292a207051e3287f1c0/GRT_StoreLandscape_2560x1440_2560x1440-f79268e269a2b1e99eeb9934e18d3053"/>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Horizon Zero Down" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3bl4VJL9Anr3DpY2snWMGElBqFH15axLLbw&s"/>

                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Horizon Zero Down" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3bl4VJL9Anr3DpY2snWMGElBqFH15axLLbw&s"/>

                                                </v-col>
                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                                <v-col cols="12" md="2">
                                    <v-card class="text-center bg-primary h-100 ">
                                        <v-card-title class="pt-5">TOTAL AHORRADO</v-card-title>
                                        <v-card-text class="py-5 ">
                                            <v-row class="d-flex justify-space-between ">
                                                <v-col cols="12" class="pa-0">
                                                    <div>
                                                        <p>En juegos</p>
                                                        <h3>300€</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>
                                            <v-row class="d-flex justify-space-between pa-0">
                                                <v-col cols="12" class="pa-0">
                                                    <div>
                                                        <p>En consolas</p>
                                                        <h3>300€</h3>
                                                    </div>
                                                </v-col>
                                            </v-row>

                                        </v-card-text>
                                        
                                    </v-card>
                                </v-col>
                                <v-col cols="12" md="4">
                                    <v-card class="text-center bg-primary h-100">
                                        <v-card-title class="pt-5">DIRECCIÓN</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>En venta</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="6">
                                                    <div>
                                                        <p>Esperando Validación</p>
                                                        <h3>0</h3>
                                                    </div>
                                                </v-col>

                                            </v-row>

                                        </v-card-text>
                                       
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row >
                                <v-col cols="12" md="6">
                                    <v-card class="text-center bg-primary">
                                        <v-card-title class="pt-5">ÚLTIMOS CONSOLAS EN FAVORITOS</v-card-title>
                                        <v-card-text class="py-10">
                                            <v-row class="d-flex justify-space-between">
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Tom Clancy's" src="https://cdn1.epicgames.com/offer/acf914daf6034292a207051e3287f1c0/GRT_StoreLandscape_2560x1440_2560x1440-f79268e269a2b1e99eeb9934e18d3053"/>
                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Horizon Zero Down" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3bl4VJL9Anr3DpY2snWMGElBqFH15axLLbw&s"/>

                                                </v-col>
                                                <v-divider vertical />
                                                <v-col cols="12" md="4">
                                                    <CardComponent title="Horizon Zero Down" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3bl4VJL9Anr3DpY2snWMGElBqFH15axLLbw&s"/>

                                                </v-col>
                                            </v-row>

                                        </v-card-text>
                                    </v-card>
                                </v-col>
                                
                            </v-row>
                        </v-tabs-window-item>

                        <v-tabs-window-item value="two">
                            Two
                        </v-tabs-window-item>

                        <v-tabs-window-item value="three">
                            Three
                        </v-tabs-window-item>
                        <v-tabs-window-item value="four">
                            four
                        </v-tabs-window-item>
                        <v-tabs-window-item value="five">
                            five
                        </v-tabs-window-item>
                        <v-tabs-window-item value="six">
                            six
                        </v-tabs-window-item>
                    </v-tabs-window>
                </v-col>
            </v-row>
        </v-container>
    </v-row>








</template>



<style lang="scss" scoped>
.tilted-bottom {
    clip-path: polygon(0% 0%, 100% 0%, 100% 100%, 0% 90%);
    background-size: cover;
    /* Ajusta la imagen sin distorsionarla */
    background-position: center;
    /* Centra la imagen */
}

.blur-text {
    filter: blur(5px);
    user-select: none;
    transition: filter 0.3s ease-in-out;
}
</style>