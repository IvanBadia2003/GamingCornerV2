<script setup lang="ts">
defineProps({
  title: String,
  text: String
});
</script>
<template>
  <v-card class="pa-3">
    <v-card-title>{{ title }}</v-card-title>
    <v-card-text>{{ text }}</v-card-text>
  </v-card>
</template>
