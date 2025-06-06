import { defineStore } from 'pinia'
import { ref, reactive } from 'vue'
import axios from 'axios'

export const useChartStore = defineStore('ChartStore', () => {

    const barChartData = reactive({
        labels: [] as string[],
        data: [] as number[]
    })

    const lineChartData = reactive({
        labels: [] as string[],
        data: [] as number[]
    })

    const pieChartData = reactive({
        labels: [] as string[],
        data: [] as number[]
    })

    const radarChartData = reactive({
        labels: [] as string[],
        data: [] as number[]
    })

    const principalStats = reactive({
        totalRevenueToday: 0,
        totalOrdersToday: 0,
        averageOrderValue: 0
    })



    const error = ref<string | null>(null)

    async function loadAllCharts() {
         
          await Promise.all([
            loadBarChart(),
            loadLineChart(),
            loadPieChart(),
            loadRadarChart(),
            loadPrincipalStats()
          ]);
        
      }
    async function loadBarChart() {
        try {
            const res = await axios.get('http://localhost:5000/Chart/WeeklyRevenue')
            const data = res.data
            barChartData.labels = data.labels
            barChartData.data = data.data
        } catch (err) {
            error.value = 'Error al cargar los datos de la gráfica de barras.'
        }
    }

    async function loadLineChart() {
        try {
            const res = await axios.get('http://localhost:5000/Chart/WeeklyOrders')
            const data = res.data
            lineChartData.labels = data.labels
            lineChartData.data = data.data
        } catch (err) {
            error.value = 'Error al cargar los datos de la gráfica de líneas.'
        }
    }

    async function loadPieChart() {
        try {
            const res = await axios.get('http://localhost:5000/Chart/PlatformFormSales')
            const data = res.data
            pieChartData.labels = data.labels
            pieChartData.data = data.data
        } catch (err) {
            error.value = 'Error al cargar los datos de la gráfica de pastel.'
        }
    }

    async function loadRadarChart() {
        try {
            const res = await axios.get('http://localhost:5000/Chart/RadarStats')
            const data = res.data
            radarChartData.labels = data.labels
            radarChartData.data = data.data
        } catch (err) {
            error.value = 'Error al cargar los datos de la gráfica radar.'
        }
    }

    async function loadPrincipalStats() {
        try {
            const res = await axios.get('http://localhost:5000/Chart/PrincipalStats')
            const data = res.data
            principalStats.totalRevenueToday = data.totalRevenueToday
            principalStats.totalOrdersToday = data.totalOrdersToday
            principalStats.averageOrderValue = data.averageOrderValue
        } catch (err) {
            error.value = 'Error al cargar las estadísticas principales.'
        }
    }

    return {
        error,
        barChartData,
        lineChartData,
        pieChartData,
        radarChartData,
        principalStats,
        loadBarChart,
        loadLineChart,
        loadPieChart,
        loadRadarChart,
        loadPrincipalStats,
        loadAllCharts,
    }
})
