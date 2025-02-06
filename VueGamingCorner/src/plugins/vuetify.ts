import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const myCustomLightTheme = {
  dark: false,
  colors: {
    background: '#FFFFFF', // Fondo principal claro
    surface: '#FFFFFF', // Fondo secundario
    primary: '#FF6F00', // Naranja personalizado
    'primary-darken-1': '#E6740F', // Naranja más oscuro
    secondary: '#FFCC70', // Secundario: Naranja pastel
    'secondary-darken-1': '#E6B960', // Secundario más oscuro
    error: '#FF453A', // Rojo para errores
    info: '#4A90E2', // Azul para información
    success: '#34C759', // Verde para éxito
    warning: '#FB8C00', // Naranja para advertencias
    'on-background': '#000000', // Color del texto sobre el fondo
    'on-surface': '#000000', // Color del texto sobre la superficie
    'on-primary': '#FFFFFF', // Color del texto sobre el color primario
    'on-secondary': '#000000', // Color del texto sobre el color secundario
    'on-error': '#FFFFFF', // Color del texto sobre el color de error
    'on-info': '#FFFFFF', // Color del texto sobre el color de información
    'on-success': '#FFFFFF', // Color del texto sobre el color de éxito
    'on-warning': '#FFFFFF', // Color del texto sobre el color de advertencia
    'border-color': '#E0E0E0', // Color de los bordes
    'hover-background': '#F5F5F5', // Color de fondo al pasar el ratón
    'hover-surface': '#EEEEEE', // Color de superficie al pasar el ratón
    'focus-background': '#E0E0E0', // Color de fondo al enfocar
    'focus-surface': '#D0D0D0', // Color de superficie al enfocar
    'active-background': '#C0C0C0', // Color de fondo al estar activo
    'active-surface': '#B0B0B0', // Color de superficie al estar activo
    'selected-background': '#A0A0A0', // Color de fondo al estar seleccionado
    'selected-surface': '#909090', // Color de superficie al estar seleccionado
  },
};

const myCustomDarkTheme = {
  dark: true,
  colors: {
    background: '#1A2A3E', // Fondo principal oscuro
    surface: '#101A23', // Fondo secundario
    primary: '#27659C', // azul personalizado
    'primary-darken-1': '#E6740F', // Naranja más oscuro
    secondary: '#FFCC70', // Secundario: Naranja pastel
    'secondary-darken-1': '#E6B960', // Secundario más oscuro
    error: '#CF6679', // Rojo para errores
    info: '#4A90E2', // Azul para información
    success: '#34C759', // Verde para éxito
    warning: '#FB8C00', // Naranja para advertencias
    'on-background': '#FFFFFF', // Color del texto sobre el fondo
    'on-surface': '#FFFFFF', // Color del texto sobre la superficie
    'on-primary': '#000000', // Color del texto sobre el color primario
    'on-secondary': '#000000', // Color del texto sobre el color secundario
    'on-error': '#000000', // Color del texto sobre el color de error
    'on-info': '#000000', // Color del texto sobre el color de información
    'on-success': '#000000', // Color del texto sobre el color de éxito
    'on-warning': '#000000', // Color del texto sobre el color de advertencia
    'border-color': '#333333', // Color de los bordes
    'hover-background': '#2A2A2A', // Color de fondo al pasar el ratón
    'hover-surface': '#3A3A3A', // Color de superficie al pasar el ratón
    'focus-background': '#4A4A4A', // Color de fondo al enfocar
    'focus-surface': '#5A5A5A', // Color de superficie al enfocar
    'active-background': '#6A6A6A', // Color de fondo al estar activo
    'active-surface': '#7A7A7A', // Color de superficie al estar activo
    'selected-background': '#8A8A8A', // Color de fondo al estar seleccionado
    'selected-surface': '#9A9A9A', // Color de superficie al estar seleccionado
  },
};

export default createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'myCustomDarkTheme',
    themes: {
      myCustomLightTheme,
      myCustomDarkTheme,
    },
  },
})