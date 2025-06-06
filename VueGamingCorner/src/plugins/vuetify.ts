import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import '@mdi/font/css/materialdesignicons.css'



const light = {
  dark: false,
  colors: {
    background: '#F5F7FA',             // Fondo principal claro
    surface: '#FFFFFF',                // Superficies / tarjetas
    primary: '#27659C',                // Mismo azul personalizado
    'primary-darken-1': '#E6740F',     // Contraste (naranja)
    secondary: '#FFA940',              // Naranja pastel más vivo
    'secondary-darken-1': '#E69138',   // Naranja más oscuro

    error: '#B00020',
    info: '#1976D2',
    success: '#2E7D32',
    warning: '#F57C00',

    'on-background': '#1A1A1A',        // Texto sobre fondo
    'on-surface': '#1A1A1A',           // Texto sobre superficie
    'on-primary': '#FFFFFF',
    'on-secondary': '#1A1A1A',
    'on-error': '#FFFFFF',
    'on-info': '#FFFFFF',
    'on-success': '#FFFFFF',
    'on-warning': '#FFFFFF',

    'border-color': '#E0E0E0',
    'hover-background': '#F0F0F0',
    'hover-surface': '#F9F9F9',
    'focus-background': '#E8F0FE',
    'focus-surface': '#E3F2FD',
    'active-background': '#D1E3FF',
    'active-surface': '#C8E0FF',
    'selected-background': '#BBDFFF',
    'selected-surface': '#AED4FF',
  },
};

const dark = {
  dark: true,
  colors: {
    background: '#1A2A3E',             // Fondo principal
    surface: '#101A23',                // Fondo de tarjetas/superficies
    primary: '#27659C',                // Azul personalizado
    'primary-darken-1': '#E6740F',     // Contraste (naranja)
    secondary: '#FFCC70',              // Naranja pastel
    'secondary-darken-1': '#E6B960',   // Naranja más oscuro

    error: '#CF6679',
    info: '#4A90E2',
    success: '#34C759',
    warning: '#FB8C00',

    'on-background': '#FFFFFF',
    'on-surface': '#FFFFFF',
    'on-primary': '#FFFFFF',
    'on-secondary': '#FFFFFF',
    'on-error': '#000000',
    'on-info': '#000000',
    'on-success': '#000000',
    'on-warning': '#000000',

    'border-color': '#333333',
    'hover-background': '#2A2A2A',
    'hover-surface': '#3A3A3A',
    'focus-background': '#4A4A4A',
    'focus-surface': '#5A5A5A',
    'active-background': '#6A6A6A',
    'active-surface': '#7A7A7A',
    'selected-background': '#8A8A8A',
    'selected-surface': '#9A9A9A',
  },
};

export function createMyVuetify(defaultTheme: 'light' | 'dark') {
  return createVuetify({
    components,
    directives,
    theme: {
      defaultTheme,
      themes: {
        light,
        dark,
      },
    },
    icons: {
      defaultSet: 'mdi',
    },
    defaults: {
      VTextField: {
        variant: 'outlined',
        color: 'background',
        density: 'comfortable',
        class: 'my-2'
       },
      VSelect: {
        variant: 'outlined',
        color: 'primary',
        density: 'comfortable',
      },
      VTextarea: {
        variant: 'outlined',
        color: 'primary',
        autoGrow: true,
        density: 'comfortable',
      },
      VCheckbox: {
        color: 'primary',
      },
      VRadioGroup: {
        color: 'primary',
      },
      VSwitch: {
        color: 'primary',
      },
      VFileInput: {
        variant: 'outlined',
        color: 'primary',
        density: 'comfortable',
        prependIcon: 'mdi-upload', // opcional, puedes cambiarlo
        showSize: true,            // muestra el tamaño del archivo
        multiple: false,           // o true si aceptas varios archivos por defecto
      },
/*       VBtn: {
        rounded: 'lg',
        color: 'secondary',
        elevation: 2,
      }, */
    },
  })
}