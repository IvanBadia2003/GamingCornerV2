<template>
    <svg class="logo-svg" viewBox="0 0 300 260" xmlns="http://www.w3.org/2000/svg" aria-label="Gaming Corner logo">
        <!-- Líneas curvas -->
        <path class="curva1" d="M40,140 Q40,100 70,60 L240,60 Q270,100 270,140" stroke="black" fill="none"
            stroke-width="6" />
        <path class="curva2" d="M50,180 Q80,220 120,180" stroke="black" fill="none" stroke-width="6" />
        <path class="curva3" d="M200,180 Q230,220 270,180" stroke="black" fill="none" stroke-width="6" />

        <!-- Círculo -->
        <circle cx="200" cy="90" r="5" /> <!-- Arriba -->
        <circle cx="200" cy="110" r="5" /> <!-- Abajo -->
        <circle cx="190" cy="100" r="5" /> <!-- Izquierda -->
        <circle cx="210" cy="100" r="5" /> <!-- Derecha -->

        <!-- Triángulos -->
        <polygon points="95,85 100,98 105,85" /> <!-- Arriba -->
        <polygon points="95,115 100,102 105,115" /> <!-- Abajo -->
        <polygon points="85,95 98,100 85,105" /> <!-- Izquierda -->
        <polygon points="115,95 103,100 115,105" /> <!-- Derecha -->

        <path d="M130,130 Q120,135 130,140 L170,140 Q180,135 170,130 Z" stroke="black" fill="none" stroke-width="2" />

        <!-- Texto -->
        <text x="26" y="165" font-size="24" fill="#111" textLength="260" lengthAdjust="spacing">
            Gaming Corner
        </text>
    </svg>
</template>

<style scoped>
.logo-svg {
    width: 100%;
    max-width: 180px;
    height: auto;
    display: block;
    cursor: pointer;
}

.logo-svg:hover text {
    transform: scale(1.05);
}

.logo-svg:hover .curva1 {
    transform: rotate(-2deg) scale(1.05);
}

.logo-svg:hover .curva2 {
    transform: rotate(2deg) scale(1.05);
}

.logo-svg:hover .curva3 {
    transform: rotate(-1deg) scale(1.05);
}

text {
    font-family: 'Bayon', sans-serif;
    transition: transform 0.3s ease;
    transform-origin: center;
}

path {
    transition: transform 0.3s ease;
    transform-origin: center;
}
</style>