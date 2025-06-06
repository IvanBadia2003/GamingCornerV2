<template>
  <v-card class="review-card pa-4 d-flex flex-column align-center h-100 bg-primary" elevation="3">
    <v-card-title class="text-center font-weight-bold text-white">
      {{ review.userName }}
    </v-card-title>

    <v-divider class="mx-auto mb-3" thickness="2" width="90%" />

    <v-card-subtitle class="text-h6 font-weight-bold text-center">
      {{ review.productName }}
    </v-card-subtitle>

    <v-card-text class="text-center">
      <p>{{ review.comment }}</p>
    </v-card-text>

    <v-divider class="mx-auto mt-3 mb-3" thickness="2" width="90%" />

    <div class="d-flex flex-column align-center mt-auto">
      <v-rating
        :model-value="Math.min(review.rating, 5)"
        length="5"
        half-increments
        readonly
        size="24"
        color="yellow-accent-4"
        background-color="white"
        class="mb-1"
      />
      <v-rating
        :model-value="Math.max(review.rating - 5, 0)"
        length="5"
        half-increments
        readonly
        size="24"
        color="yellow-accent-4"
        background-color="white"
      />
    </div>
  </v-card>
</template>

  
  <script setup lang="ts">
  defineProps<{
    review: {
      userName: string
      productName: string
      comment: string
      rating: number
    }
  }>()
  </script>
  