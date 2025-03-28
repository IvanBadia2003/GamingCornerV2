<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="6" v-for="(color, name) in colors" :key="name">
        <v-card :style="{ backgroundColor: color }" class="mb-4">
          <v-card-title :style="{ color: getTextColor(color) }">{{ name }}</v-card-title>
          <v-card-text :style="{ color: getTextColor(color) }">{{ color }}</v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useTheme } from 'vuetify'

const theme = useTheme()

const colors = computed(() => theme.global.current.value.colors)

const getTextColor = (backgroundColor: string) => {
  // Simple function to determine text color based on background color brightness
  const brightness = parseInt(backgroundColor.slice(1, 3), 16) * 0.299 +
                     parseInt(backgroundColor.slice(3, 5), 16) * 0.587 +
                     parseInt(backgroundColor.slice(5, 7), 16) * 0.114
  return brightness > 186 ? '#000000' : '#FFFFFF'
}
</script>

<style scoped>
.mb-4 {
  margin-bottom: 1rem;
}
</style>