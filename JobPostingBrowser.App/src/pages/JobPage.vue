<!-- <template>
  <q-page class="flex flex-center">
    <h1>Jobs</h1>
  </q-page>
</template>

<script>
import { defineComponent } from 'vue'

export default defineComponent({
})
</script> -->

<template>
  <q-page class="flex flex-center">
    <img
      alt="Quasar logo"
      src="~assets/quasar-logo-vertical.svg"
      style="width: 200px; height: 200px"
    >
    <WeatherComponent></WeatherComponent>
  </q-page>
</template>

<script>
import WeatherComponent from 'src/components/WeatherComponent.vue';
import { defineComponent } from 'vue'

export default defineComponent({
    name: "IndexPage",
    components: { WeatherComponent }
})
</script>

