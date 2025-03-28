import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
//import ProfileView from '../views/ProfileView.vue'
import ColorPaletteView from '../views/ColorPaletteView.vue'
import CatalogView from '../views/CatalogView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    } ,
     /* {
      path: '/perfil',
      name: 'perfil',
      component: ProfileView,
    } , */ 
    {
      path: '/catalog',
      name: 'catalog',
      component: CatalogView,
    } , 
    {
      path: '/colors',
      name: 'colors',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: ColorPaletteView,
    }, 
  ],
})

export default router
