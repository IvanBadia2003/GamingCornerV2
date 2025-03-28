<script setup lang="ts">
import { ref } from 'vue';
import { useTheme } from 'vuetify'

const theme = useTheme()

const toggleTheme = () => {
  theme.global.name.value = theme.global.name.value === 'myCustomLightTheme' ? 'myCustomDarkTheme' : 'myCustomLightTheme'
}

const toggleMenu = ref<boolean>(false);
</script>

<template>
    <header id="Header" class="bg-primary">
        <router-link  :to="'/'">
            
            <img src="../../assets/logo.png" class="logo" alt="logo" >
        </router-link>

        <v-btn @click="toggleTheme">Cambiar Tema</v-btn>
        <button @click="toggleMenu = !toggleMenu" :class="{ 'open': toggleMenu }">
            <div></div>
            <div></div>
            <div></div>
        </button>

        <ul class="menu" :class="{ 'open': toggleMenu }">
            <router-link class="item" :to="'/'">Inicio</router-link>
            <router-link class="item" :to="'/catalog'">Productos</router-link>
            <router-link class="item" :to="'/grid-segunda-mano'">Segunda Mano</router-link>
            <router-link class="item" :to="'/perfil'">Perfil</router-link>
            <!-- <router-link v-if="UserStore.user.isAuthenticated == false" class="btn" :to="'/login'">Login</router-link>
            <div v-else>
                <router-link class="item" :to="'/cart'">
                    <IconCart/>
                </router-link>
                <router-link class="item" :to="'/profile'">
                    <IconUser/>
                </router-link>
                <router-link v-if="UserStore.user.admin == true" class="item" :to="'/admin'">
                    Menú Admin
                </router-link>

            </div> -->

        </ul>
    </header>
</template>

<style scoped lang="scss">

#Header {
    width: 100%;

    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 5%;
    height: 100px;

    .logo {
        max-width: 70px;

        @media (min-width: 764px) {
            max-width: 150px;
        }
    }
}
/* * {
    list-style: none;
    box-sizing: border-box;
}

header {
    width: 100%;
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 5%;
    height: 100px;
    animation: changeColor both;
    animation-timeline: scroll(root);
    animation-range: 0 200px;
    backdrop-filter: blur(3px);
    z-index: 10;

    .logo {
        max-width: 70px;

        @media (min-width: 764px) {
            max-width: 150px;
        }
    }
}



.menu {
    padding: 30px;
    margin: 0;
    position: absolute;
    top: 100%;
    left: 0;
    right: 0;
    background-color: rgba($color: #323337, $alpha: .8);
    display: none;
    flex-direction: column;

    &.open {
        display: flex;
        align-items: center;
    }



    @media (min-width: 764px) {
        display: flex;
        justify-content: center;
        align-items: center;
        position: static;
        background-color: transparent;
        flex-direction: row;
        padding: 0;
    }
}

.item {
    margin: 0 0 20px 0;
    width: 100%;
    font-size: 18px;
    font-weight: 600;
    cursor: pointer;
    color: white;
    text-decoration: none;

    &:hover {
        color: orange;
    }

    @media (min-width: 764px) {
        margin: 0 15px;
        width: auto;
    }
}

.btn {
    padding: 10px 24px;
    border-radius: 30px;
    background-color: orange;
    color: white;
    font-weight: 600px;
    cursor: pointer;
    text-decoration: none;


    &:hover {
        background-color: orangered;
    }

    @media (min-width: 764px) {
        width: auto;
    }
}

button {
    display: flex;
    flex-direction: column;
    width: 3rem;
    height: 2rem;
    border: 0;
    background: transparent;
    gap: .65rem;

    &.open>div:first-child {
        transform: rotate(45deg);
    }

    &.open>div:nth-child(2) {
        opacity: 0;
    }

    &.open>div:last-child {
        transform: rotate(-45deg);
    }

    >div {
        background-color: black;
        height: 2px;
        width: 100%;
        border-radius: 5px;
        transition: all .5s;
        transform-origin: left;
    }

    @media (min-width: 764px) {
        display: none;
    }
}


@keyframes changeColor {
    to {
        background-color: orange;
    }
} */
  
</style>