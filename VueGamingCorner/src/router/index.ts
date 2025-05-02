import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ProfileView from '../views/ProfileView.vue'
import ColorPaletteView from '../views/ColorPaletteView.vue'
import DescriptionView from '../views/DescriptionView.vue'
import CartView from '../views/CartView.vue'
import CatalogView from '@/views/CatalogView.vue'
import LoginView from '../views/AuthView.vue'
import AdminView from '../views/AdminView.vue'
import AdminEconomyView from '../views/Admin/EconomyView.vue'
import AdminChartView from '../views/Admin/ChartView.vue'
import { useAuthStore } from '@/stores/AuthStore' // o desde Pinia, etc.


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/perfil',
      name: 'perfil',
      component: ProfileView,
      meta: { requiresAuth: true },
    },
    {
      path: '/admin',
      name: 'admin',
      component: AdminView,
      meta: { requiresAuth: true },
    },
    {
      path: '/admin/economy',
      name: 'adminEconomy',
      component: AdminEconomyView,
      meta: { requiresAuth: true },
    },
    {
      path: '/admin/charts',
      name: 'chartsEconomy',
      component: AdminChartView,
/*       meta: { requiresAuth: true },
 */    },
    {
      path: '/catalog',
      name: 'catalog',
      component: CatalogView,
    },
    {
      path: '/description/:id',
      name: 'description',
      component: DescriptionView,
    },
    {
      path: '/cart',
      name: 'cart',
      component: CartView,

    },
    {
      path: '/colors',
      name: 'colors',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: ColorPaletteView,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
  ],
})

router.beforeEach((to, from, next) => {
  const authStore = useAuthStore()

  if (to.meta.requiresAuth && !authStore.isAuthenticated) {
    next({ name: 'login' })
  } else {
    next()
  }

})

export default router
