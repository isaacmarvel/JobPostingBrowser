<script setup>
    import { api } from 'boot/axios';
    import { onMounted } from 'vue'

    
    async function loadData () {
        return await api.get('/api/WeatherForecast');
    }

    let weather = [];

    onMounted(async () => {
        const result = await loadData();
        console.log(result);

        weather = result.data;
    })

</script>

<template>
<div>
    <ul>
        <li v-for="w in weather" :key="w"> {{ w.temperatureF }}, {{ w.summary }}</li>
    </ul>
</div>
</template>