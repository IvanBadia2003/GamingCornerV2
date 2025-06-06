// stores/mediaStore.ts
import { defineStore } from 'pinia';
import { ref } from 'vue';

type EntityType = 'juego' | 'consola' | 'genero' | 'plataforma' | 'segundamano' | 'usuario';

type MediaMap = {
    [entityType: string]: Record<string, Record<string, string>>; // ahora key es el nombre
  };

export const useCloudinaryStore = defineStore('cloudinaryStore', () => {
  const media = ref<MediaMap>({
    juego: {},
    consola: {},
    genero: {},
    plataforma: {},
    segundamano: {}, 
    usuario: {}
  });

// Añade en CloudinaryStore
const avatarImage = ref<File | null>(null);
const mainImage = ref<File | null>(null);
const backgroundImage = ref<File | null>(null);
const contentImages = ref<(File | null)[]>([null, null, null, null]);


  function setMedia(
    entity: EntityType,
    name: string,
    key: string,
    url: string
  ) {
    if (!media.value[entity][name]) {
      media.value[entity][name] = {};
    }
    media.value[entity][name][key] = url;
  }
  
  function getMedia(entity: EntityType, name: string) {
    
    return media.value[entity][name] || {};
  }
  

async function uploadToCloudinary(
    file: File,
    publicPath: string // ejemplo: 'products/123/main'
  ): Promise<string> {
    const formData = new FormData();
    formData.append('file', file);
    formData.append('upload_preset', 'gamingcorner_unsigned'); // tu upload preset
    formData.append('public_id', publicPath); // la ruta que tú defines
  
    const res = await fetch('https://api.cloudinary.com/v1_1/dsaptfjxa/image/upload', {
      method: 'POST',
      body: formData,
    });
  
    const data = await res.json();
  
    if (!res.ok) {
      throw new Error(data.error?.message || 'Error subiendo imagen');
    }
  
    return data.secure_url; // URL pública de la imagen subida
  }
  
  async function uploadImages(entityType: EntityType, entityName: string) {

    
    if (avatarImage.value) {
      const url = await uploadToCloudinary(avatarImage.value, `${entityType}/${entityName}/avatar`);
      setMedia(entityType, entityName, 'avatar', url);
    }
  
    if (mainImage.value) {
      const url = await uploadToCloudinary(mainImage.value, `${entityType}/${entityName}/main`);
      setMedia(entityType, entityName, 'main', url);
    }
  
    if (backgroundImage.value) {
      const url = await uploadToCloudinary(backgroundImage.value, `${entityType}/${entityName}/background`);
      setMedia(entityType, entityName, 'background', url);
    }
  
    for (let i = 0; i < contentImages.value.length; i++) {
      if (contentImages.value[i]) {
        const url = await uploadToCloudinary(contentImages.value[i]!, `${entityType}/${entityName}/content${i + 1}`);
        setMedia(entityType, entityName, `content${i + 1}`, url);
      }
    }
  }
  

  function getMediaForApi(entity: EntityType, name: string): Record<string, string> {
    return media.value[entity][name] || {};
  }

  return {
    media,
    setMedia,
    getMedia,
    uploadToCloudinary,
    uploadImages,
    avatarImage,
    mainImage,
    backgroundImage,
    contentImages,
    getMediaForApi
  };
  });
