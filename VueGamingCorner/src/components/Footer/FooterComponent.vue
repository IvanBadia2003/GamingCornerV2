<script setup lang="ts">
import IconLogo from '@/components/icons/IconLogo.vue'
import { useTheme } from 'vuetify'
import { useThemeStore } from '@/stores/themeStore'
import { ref, watch } from 'vue'

const theme = useTheme()
const isDarkTheme = ref(theme.global.current.value.dark)

// Actualiza `isDarkTheme` cuando el tema cambia
watch(() => theme.global.name.value, (newTheme) => {
  isDarkTheme.value = newTheme === 'dark'
})

const toggleTheme = () => {
  const current = theme.global.name.value
  const newTheme = current === 'light' ? 'dark' : 'light'

  theme.global.name.value = newTheme
  useThemeStore().setTheme(newTheme)
}
</script>
<template>
  <footer class="bg-background text-white py-8" app>
    <v-container>
      <v-row>
        <!-- Logo y descripción -->
        <v-col cols="12" md="4">
          <span class="text-h6 font-weight-bold">Gaming Corner</span>
          <p>
            Tu tienda online de videojuegos, consolas y productos de segunda mano. Envíos rápidos, precios justos y
            comunidad gamer.
          </p>
        </v-col>



          <!-- Contacto -->
          <v-col cols="12" md="4" class="text-center">
            <h6 class="text-uppercase font-weight-bold mb-3">Contacto</h6>
            <p><v-icon icon="mdi-map-marker" class="me-1 my-1" /> Zaragoza, España</p>
            <p><v-icon icon="mdi-email" class="me-1 my-1" /> soporte@gamingcorner.com</p>
            <p><v-icon icon="mdi-phone" class="me-1 my-1" /> +34 654 17 64 79</p>
          </v-col>

          <!-- Redes sociales -->
          <v-col cols="12" md="4" class="text-center">
            <v-row>
              <v-col>

                <h6 class="text-uppercase font-weight-bold mb-3">Síguenos</h6>
                  <v-icon icon="mdi-facebook" class="mr-2" />
                  <v-icon icon="mdi-twitter" class="mr-2" />
                  <v-icon icon="mdi-instagram" />
              </v-col>
            </v-row>
            <v-row>
              <v-col>

                <h6 class="text-uppercase font-weight-bold mb-3">Cambiar tema</h6>
                <v-btn @click="toggleTheme" icon>
                  <v-icon>
                    {{ isDarkTheme ? 'mdi-weather-night' : 'mdi-weather-sunny' }}
                  </v-icon>
                </v-btn>

              </v-col>
            </v-row>
          </v-col>
        </v-row>


      <!-- Divider y derechos -->
      <v-divider class="my-6 border-opacity-25" />
      <v-row justify="center">
        <span class="text-caption">&copy; {{ new Date().getFullYear() }} Gaming Corner. Todos los derechos
          reservados.</span>
      </v-row>
    </v-container>
  </footer>
</template>


<style scoped></style>
