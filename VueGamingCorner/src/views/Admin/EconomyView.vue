<template>
    <v-container>
      <!-- KPIs -->
      <v-row class="mb-6">
        <v-col cols="12" sm="6" md="3" v-for="kpi in kpis" :key="kpi.title">
          <v-card class="pa-4 text-center">
            <v-icon size="36" color="primary">{{ kpi.icon }}</v-icon>
            <div class="text-h6 mt-2">{{ kpi.title }}</div>
            <div class="text-h5 font-weight-bold">{{ kpi.value }}</div>
          </v-card>
        </v-col>
      </v-row>
  
      <!-- Gráfico -->
      <v-row class="mb-6">
        <v-col cols="12">
          <v-card class="pa-4">
            <div class="text-h6 mb-4">Ingresos últimos 7 días</div>
          </v-card>
        </v-col>
      </v-row>
  
      <!-- Tabla de pedidos recientes -->
      <v-row>
        <v-col cols="12">
          <v-card>
            <v-card-title class="text-h6">Pedidos recientes</v-card-title>
            <v-data-table :headers="headers" :items="orders" class="elevation-1" />
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { Bar } from 'vue-chartjs'
  import {
    Chart as ChartJS,
    Title, Tooltip, Legend,
    BarElement, CategoryScale, LinearScale
  } from 'chart.js'
  
  ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
  
  const kpis = [
    { title: 'Ventas hoy', value: '1.250 €', icon: 'mdi-cash' },
    { title: 'Pedidos hoy', value: '47', icon: 'mdi-package-variant' },
    { title: 'Ticket medio', value: '135 €', icon: 'mdi-chart-pie' },
    { title: '', value: '', icon: '' },
  ]
  
  const chartData = {
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
  
  const chartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    scales: {
      x: { ticks: { color: '#000' } },
      y: { beginAtZero: true, ticks: { color: '#000' } },
    },
    plugins: {
      legend: { position: 'top', labels: { color: '#000' } },
    },
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
  