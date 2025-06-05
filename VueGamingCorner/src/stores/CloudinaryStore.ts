// stores/mediaStore.ts
import { defineStore } from 'pinia';
import { ref } from 'vue';

type EntityType = 'products' | 'users' | 'platforms' | 'genres';

type MediaMap = {
  [entityType: string]: Record<number, Record<string, string>>;
};

export const useCloudinaryStore = defineStore('cloudinaryStore', () => {
  const media = ref<MediaMap>({
    products: {},
    users: {},
    platforms: {},
    genres: {},
  });

  function setMedia(
    entity: EntityType,
    id: number,
    key: string,
    url: string
  ) {
    if (!media.value[entity][id]) {
      media.value[entity][id] = {};
    }
    media.value[entity][id][key] = url;
  }

  function getMedia(entity: EntityType, id: number) {
    return media.value[entity][id] || {};
  }

// composables/useCloudinaryUpload.ts
async function uploadToCloudinary(
    file: File,
    publicPath: string // ejemplo: 'products/123/main'
  ): Promise<string> {
    const formData = new FormData();
    formData.append('file', file);
    formData.append('upload_preset', 'gamingcorner_unsigned'); // tu upload preset
    formData.append('public_id', publicPath); // la ruta que tú defines
  
    const res = await fetch('https://api.cloudinary.com/v1_1/gamingcorner/image/upload', {
      method: 'POST',
      body: formData,
    });
  
    const data = await res.json();
  
    if (!res.ok) {
      throw new Error(data.error?.message || 'Error subiendo imagen');
    }
  
    return data.secure_url; // URL pública de la imagen subida
  }
  

  return { media, setMedia, getMedia, uploadToCloudinary };
});
