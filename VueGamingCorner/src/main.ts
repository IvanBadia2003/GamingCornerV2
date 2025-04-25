import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import { createMyVuetify } from './plugins/vuetify'
///PARA QUE FUNCIONEN LAS COOCKIES///
interface CookieStore {
    get(name: string): Promise<{ name: string; value: string } | undefined>
    set(details: {
      name: string
      value: string
      expires?: number | Date
      domain?: string
      path?: string
      sameSite?: 'Lax' | 'Strict' | 'None'
    }): Promise<void>
    delete(name: string): Promise<void>
  }

  declare var cookieStore: CookieStore

  let savedTheme: 'dark' | 'light' = 'dark'

try {
    const cookie = await cookieStore.get('cookieTheme')
    if (cookie?.value === 'dark' || cookie?.value === 'light') {
      savedTheme = cookie.value
    }
  } catch (e) {
    console.warn('No se pudo leer la cookie del tema:', e)
  }

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(createMyVuetify(savedTheme))

app.mount('#app')