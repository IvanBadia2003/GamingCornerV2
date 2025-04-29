
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { useAuthStore } from '@/stores/AuthStore'


import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(vuetify)

// verificar si el usuario está autenticado
const auth = useAuthStore()
auth.fetchCurrentUser()

app.mount('#app')