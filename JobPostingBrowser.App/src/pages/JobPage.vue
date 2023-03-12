<template>
  <q-page class="flex flex-center">
    <h1>Jobs</h1>
    <ReedComponent></ReedComponent>
  </q-page>
</template>

<script>
import ReedComponent from "src/components/ReedComponent.vue";
import { defineComponent } from "vue";

export default defineComponent({
  name: "IndexPage",
  components: { ReedComponent },
});
</script>
