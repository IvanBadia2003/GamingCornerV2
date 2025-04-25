// stores/counter.ts

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

import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useThemeStore = defineStore('themeStore', () => {
  const theme = ref<'light' | 'dark'>('light')

  async function setTheme(value: 'light' | 'dark') {
    const day = 60 * 1000;//  // 1 minute
    const cookieName = "cookieTheme";

      // Set cookie: passing options
      await cookieStore.set({
        name: cookieName,
        value: value,
        expires: Date.now() + day
      })


    // Log the new cookie
    const cookie = await cookieStore.get(cookieName);
    console.log(cookie);
  }

  async function loadTheme() {
    const cookie = await cookieStore.get('cookieTheme')
    if (cookie?.value === 'dark' || cookie?.value === 'light') {
      theme.value = cookie.value
    }
  }

  return {
    theme,
    setTheme,
    loadTheme
  }
})