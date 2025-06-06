// src/utils/validationRules.ts
export const validationRules = {
    required: (v: any) => !!v || 'Este campo es obligatorio',
  
    requiredTrimmed: (v: any) =>
      (typeof v === 'string' ? v.trim().length > 0 : !!v) || 'Este campo es obligatorio',
  
    minLength: (min: number) => (v: string) =>
      (!v || v.length >= min) || `Mínimo ${min} caracteres`,
  
    maxLength: (max: number) => (v: string) =>
      (!v || v.length <= max) || `Máximo ${max} caracteres`,
  
    numberRange: (min: number, max: number) => (v: number | null) =>
      v === null || (v >= min && v <= max) || `Debe estar entre ${min} y ${max}`,
  
    email: (v: string) =>
      !v || /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(v) || 'Correo electrónico inválido',
  
    onlyNumbers: (v: string) =>
      !v || /^\d+$/.test(v) || 'Solo se permiten números',
  
    onlyLetters: (v: string) =>
      !v || /^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$/.test(v) || 'Solo se permiten letras',
  
    url: (v: string) =>
      !v || /^(https?:\/\/)?[\w\-]+(\.[\w\-]+)+[/#?]?.*$/.test(v) || 'URL inválida',
  
    positiveNumber: (v: number) =>
      v >= 0 || 'Debe ser un número positivo',
  
    maxImages: (files: File[] | undefined) =>
      (files?.length || 0) <= 6 || 'Máximo 6 imágenes',
  
    atLeastOneImage: (files: File[] | undefined) =>
      (files?.length || 0) > 0 || 'Debes subir al menos una imagen',
  
    mustBeChecked: (v: boolean) =>
      v === true || 'Debes aceptar los términos',
  
    requiredDate: (v: string | Date) =>
      !!v || 'Selecciona una fecha válida',
  };
  