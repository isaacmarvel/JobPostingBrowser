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

// let reed = [];

onMounted(async () => {
  const result = await loadData();
  // reed = result.data;
  for (let r in result.data.results) {
    console.log(r);
  }
});
</script>

<template>
  <div>
    <!-- <ul>
      <li v-for="r in result" :key="r">
        {{ r.data }}
      </li>
    </ul> -->
  </div>
</template>
