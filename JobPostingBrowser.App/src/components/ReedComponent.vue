<script setup>
import { ref } from "vue";
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

let reed = ref(null);

onMounted(async () => {
  const result = await loadData();
  reed.value = result.data.results;
  console.log(reed);
  return reed;
});
</script>

<template>
  <div>
    <div v-if="reed == []">Loading</div>

    <div v-else>
      <ul>
        <li v-for="r in reed" :key="r">
          {{ r }}
        </li>
      </ul>
    </div>
  </div>
</template>
