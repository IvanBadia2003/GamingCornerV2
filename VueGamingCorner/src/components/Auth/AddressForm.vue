<template>
  <v-card class="pa-5">
    <v-card-title  v-if="props.withTransition">Dirección de Facturación</v-card-title>
    <v-form>
      <v-row>
        <v-col cols="12" md="12">
          <v-text-field label="Dirección" required />
        </v-col>
        <v-col cols="12" md="4">
          <v-select
            label="País"
            :items="countries"
            required
          />
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Ciudad" required />
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Código Postal" required />
        </v-col>
      </v-row>

      <v-checkbox v-if="props.withTransition"
        v-model="useSameAddress"
        label="Usar la misma dirección para el envío"
      />

      <v-expand-transition v-if="!useSameAddress && props.withTransition">
          <v-card-title>Dirección de Envío</v-card-title>
          <v-row>
            <v-col cols="12" md="6">
              <v-text-field label="Nombre Completo" required />
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field label="Dirección" required />
            </v-col>
            <v-col cols="12" md="4">
              <v-text-field label="Ciudad" required />
            </v-col>
            <v-col cols="12" md="4">
              <v-text-field label="Código Postal" required />
            </v-col>
            <v-col cols="12" md="4">
              <v-select
                label="País"
                :items="countries"
                required
              />
            </v-col>
          </v-row>
      </v-expand-transition>
    </v-form>
    <v-card-actions>
      <v-btn color="primary" >Guardar Dirección</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const props = defineProps<{
  withTransition?: boolean
}>()

const useSameAddress = ref(true)

const countries = ['España', 'México', 'Argentina', 'Chile', 'Colombia']
</script>
