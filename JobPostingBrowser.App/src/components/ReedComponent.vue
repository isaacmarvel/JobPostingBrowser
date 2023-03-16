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
  console.log(result);
  reed.value = result.data;
  console.log(reed);
  return reed;
});
</script>

<!-- Need to display json so people can save the job Loop through list of x amount of
jobs, and display job.data or whatever then have a button that saves them if
you're interested i guess--it sends to backend. -->

<!-- will need at some point to request another api call for the individual job -->

<!-- make backend give single array of objects. -->

<!-- for display--need to loop through and do another api call to get job specific data, like in pokemon -->
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
