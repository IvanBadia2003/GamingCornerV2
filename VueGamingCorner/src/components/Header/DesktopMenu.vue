<script setup lang="ts">
import { computed, ref } from 'vue';
import { useTheme } from 'vuetify';
import { useThemeStore } from '@/stores/themeStore'
import { useAuthStore } from '@/stores/AuthStore'
import IconLogo from '@/components/icons/IconLogo.vue'

const auth = useAuthStore()

defineProps<{
    platforms: { name: string, route: string }[]
}>()

</script>
<template>

    </template>

<style scoped lang="scss">


</style>