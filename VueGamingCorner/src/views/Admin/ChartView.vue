<template>
    <v-container style="width: 80%;">


        <!-- Gráfico de ingresos (Barras) -->
        <v-row class="mb-6">
            <v-col cols="12" md="6">
                <v-card class="pa-4" >
                    <div class="text-h6 mb-4">Ingresos últimos 7 días</div>
                    <Bar :data="barData" :options="chartOptions" height="300" />
                </v-card>
            </v-col>
            <v-col cols="12" md="6">
                <v-card class="pa-4" >
                    <div class="text-h6 mb-4">Evolución semanal de pedidos</div>
                    <Line :data="lineData" :options="chartOptions" height="300" />
                </v-card>
            </v-col>
            <v-col cols="12" md="6" offset="3">
                <v-card class="pa-4" >
                    <div class="text-h6 mb-4">Ventas por plataforma</div>
                    <Pie :data="pieData" :options="chartOptions" />
                </v-card>
            </v-col>

        </v-row>

       

        
    </v-container>
</template>

<script setup lang="ts">
import { Bar, Line, Pie, Radar } from 'vue-chartjs'
import {
    Chart as ChartJS,
    Title, Tooltip, Legend,
    BarElement, LineElement, PointElement,
    ArcElement, RadarController,
    CategoryScale, LinearScale, RadialLinearScale
} from 'chart.js'
import { computed, onMounted } from 'vue'
import { useChartStore } from '@/stores/ChartStore'

ChartJS.register(
    Title, Tooltip, Legend,
    BarElement, LineElement, PointElement,
    ArcElement, RadarController,
    CategoryScale, LinearScale, RadialLinearScale
)

const chartStore = useChartStore()

onMounted(() => {
chartStore.loadAllCharts()

})

const chartOptions = {
    responsive: true,
    maintainAspectRatio: true,
    plugins: {
        legend: { position: 'top' as const, labels: { color: '#fff' } },
        title: { display: false },
    },
    scales: {
        x: { ticks: { color: '#fff' } },
        y: { beginAtZero: true, ticks: { color: '#fff' } },
    },
} 

const barData = computed(() => ({
  labels: chartStore.barChartData.labels,
  datasets: [
    {
      label: 'Ingresos (€)',
      data: chartStore.barChartData.data,
      backgroundColor: '#3f51b5',
      borderRadius: 5,
    },
  ],
}));

const lineData = computed(() => ({
    labels: chartStore.lineChartData.labels,
    datasets: [
        {
            label: 'Pedidos',
            data: chartStore.lineChartData.data,
            borderColor: '#ff9800',
            fill: false,
            tension: 0.4,
        },
    ],
}));


const pieData = computed(() => ({
    labels: chartStore.pieChartData.labels,
    datasets: [
        {
            data: chartStore.pieChartData.data,
            backgroundColor: ['#3f51b5', '#4caf50', '#ff9800', '#e91e63'],
        },
    ],
}));

const radarData = {
    labels: ['Ventas', 'Envíos', 'Reseñas', 'Reembolsos', 'Soporte'],
    datasets: [
        {
            label: 'Este mes',
            data: [90, 70, 85, 40, 60],
            backgroundColor: 'rgba(63,81,181,0.4)',
            borderColor: '#3f51b5',
        },
        {
            label: 'Mes pasado',
            data: [80, 65, 78, 55, 50],
            backgroundColor: 'rgba(255,152,0,0.3)',
            borderColor: '#ff9800',
        },
    ],
}


</script>

<style scoped>
.v-card {
    height: 100%;
}
</style>