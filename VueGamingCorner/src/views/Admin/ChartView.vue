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
            <v-col cols="12" md="6">
                <v-card class="pa-4" >
                    <div class="text-h6 mb-4">Ventas por plataforma</div>
                    <Pie :data="pieData" :options="chartOptions" />
                </v-card>
            </v-col>

            <v-col cols="12" md="6">
                <v-card class="pa-4" >
                    <div class="text-h6 mb-4">Comparativa de rendimiento</div>
                    <Radar :data="radarData" :options="chartOptions" />
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

ChartJS.register(
    Title, Tooltip, Legend,
    BarElement, LineElement, PointElement,
    ArcElement, RadarController,
    CategoryScale, LinearScale, RadialLinearScale
)

const kpis = [
    { title: 'Ventas hoy', value: '1.250 €', icon: 'mdi-cash' },
    { title: 'Pedidos hoy', value: '47', icon: 'mdi-package-variant' },
    { title: 'Ticket medio', value: '135 €', icon: 'mdi-chart-pie' },
    { title: 'Devoluciones', value: '3', icon: 'mdi-backup-restore' },
]

const chartOptions = {
    responsive: false,
    maintainAspectRatio: false,
    plugins: {
        legend: { position: 'top' as const, labels: { color: '#000' } },
        title: { display: false },
    },
    scales: {
        x: { ticks: { color: '#000' } },
        y: { beginAtZero: true, ticks: { color: '#000' } },
    },
} 

const barData = {
    labels: ['Lun', 'Mar', 'Mié', 'Jue', 'Vie', 'Sáb', 'Dom'],
    datasets: [
        {
            label: 'Ingresos (€)',
            data: [1200, 900, 1300, 800, 1500, 1000, 1400],
            backgroundColor: '#3f51b5',
            borderRadius: 5,
        },
    ],
}

const lineData = {
    labels: ['Semana 1', 'Semana 2', 'Semana 3', 'Semana 4'],
    datasets: [
        {
            label: 'Pedidos',
            data: [110, 95, 130, 120],
            borderColor: '#ff9800',
            fill: false,
            tension: 0.4,
        },
    ],
}

const pieData = {
    labels: ['PlayStation', 'Xbox', 'PC', 'Nintendo'],
    datasets: [
        {
            data: [35, 25, 20, 20],
            backgroundColor: ['#3f51b5', '#4caf50', '#ff9800', '#e91e63'],
        },
    ],
}

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

const headers = [
    { text: 'ID Pedido', value: 'id' },
    { text: 'Cliente', value: 'client' },
    { text: 'Fecha', value: 'date' },
    { text: 'Total', value: 'total' },
    { text: 'Estado', value: 'status' },
]

const orders = [
    { id: '#001', client: 'Mario R.', date: '01/05/2025', total: '69,90 €', status: 'Pagado' },
    { id: '#002', client: 'Laura V.', date: '01/05/2025', total: '129,99 €', status: 'Enviado' },
    { id: '#003', client: 'Carlos T.', date: '30/04/2025', total: '49,95 €', status: 'Pendiente' },
]
</script>

<style scoped>
.v-card {
    height: 100%;
}
</style>