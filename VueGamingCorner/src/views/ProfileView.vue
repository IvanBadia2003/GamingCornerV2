    <script setup lang="ts">
    import { computed, ref } from 'vue'
    import { useDisplay } from 'vuetify'


    const { xs, sm, md, lg } = useDisplay()

    const avatarSize = computed(() => {
        if (xs.value) return 80
        if (sm.value) return 120
        if (md.value) return 150
        if (lg.value) return 200
        return 220
    })

    const tab = ref(1)
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
            <v-row class="">
                <v-col cols="12">
                    <v-tabs-window v-model="tab">
                        <v-tabs-window-item value="one">
                            One
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
</style>