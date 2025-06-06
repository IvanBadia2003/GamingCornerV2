<template>
    <v-form @submit.prevent="uploadImages">
      <v-file-input v-model="mainImage" label="Imagen principal" />
      <v-file-input v-model="backgroundImage" label="Imagen de fondo" />
      <v-file-input v-model="contentImages[0]" label="Contenido 1" />
      <v-file-input v-model="contentImages[1]" label="Contenido 2" />
      <v-btn type="submit" color="primary">Subir</v-btn>
    </v-form>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  import { useCloudinaryStore } from '@/stores/CloudinaryStore';
  
  const productId = 123; // Por ejemplo, el ID actual del producto
  const cloudinaryStore = useCloudinaryStore();
  
  const mainImage = ref<File | null>(null);
  const backgroundImage = ref<File | null>(null);
  const contentImages = ref<(File | null)[]>([null, null]);
  
  const uploadImages = async () => {
    if (mainImage.value) {
      const url = await  cloudinaryStore.uploadToCloudinary(mainImage.value, `products/${productId}/main`);
      cloudinaryStore.setMedia('products', productId, 'main', url);
    }
  
    if (backgroundImage.value) {
      const url = await cloudinaryStore.uploadToCloudinary(backgroundImage.value, `products/${productId}/background`);
      cloudinaryStore.setMedia('products', productId, 'background', url);
    }
  
    for (let i = 0; i < contentImages.value.length; i++) {
      if (contentImages.value[i]) {
        const url = await cloudinaryStore.uploadToCloudinary(contentImages.value[i]!, `products/${productId}/content${i + 1}`);
        cloudinaryStore.setMedia('products', productId, `content${i + 1}`, url);
      }
    }
  };
  </script>
  