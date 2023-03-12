<script setup>
import { api } from "boot/axios";
import { onMounted } from "vue";

async function loadData() {
  return await api.get("/api/Reed", {
    params: {
      keywords: "accountant",
    },
  });
}

//load data with a parameter?
//or do you filter after you make the request?
let reed = [];

onMounted(async () => {
  const result = await loadData();
  console.log(result);

  reed = result.data;
});
</script>

<template>
  <div>
    <!-- <ul>
        <li v-for="w in weather" :key="w"> {{ w.temperatureF }}, {{ w.summary }}</li>
    </ul> -->
  </div>
</template>
