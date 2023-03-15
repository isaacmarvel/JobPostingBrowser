<script setup>
import { api } from "boot/axios";
import { onMounted } from "vue";

async function loadData() {
  return await api.get("/api/Reed", {
    params: {
      keywords: "accountant",
      locationName: "london",
    },
  });
}

let reed = [];

onMounted(async () => {
  const result = await loadData();
  reed = result.data.results;
  console.log(reed);
  return reed;
});
</script>

<template>

  <p v-if="reed === []">Loading</p>

  <p v-else>
    <ul>
      <li v-for="r in reed" :key="r">
        {{ r }}
      </li>
    </ul>
  </p>
</template>
