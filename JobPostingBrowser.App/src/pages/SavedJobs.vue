<script setup>
import { ref, computed, onMounted } from "vue";
import { api } from "boot/axios";
import { useQuasar } from "quasar";
import { useSavedJobStore } from "stores/jobId.js";

let jobStore = useSavedJobStore();

// async function getSavedJobs() {
//   return await api.get("/api/JobDetails");
// }
onMounted(async () => {
  console.log("test");
  await jobStore.fetchSavedJobs();
  await console.log(getSavedJobs);
});
const getSavedJobs = computed(() => {
  return jobStore.getSavedJobs;
});

// async function deleteJobFromDb(jobId) {
//   const response = await api.delete(`/api/JobDetails/${jobId}`);
//   window.location.reload();
//   console.log(response);
// }
</script>

<template>
  <q-page class="flex flex-center">
    <div class="q-pa-md row items-start q-gutter-md">
      <q-card class="my-card" v-for="job in getSavedJobs" :key="job">
        <q-card-section>
          <ul>
            <li>Job Title: {{ job.jobTitle }}</li>
            <li>Date Posted: {{ job.datePosted }}</li>
            <li>Employer Name: {{ job.employerName }}</li>
            <li>Link to Job: {{ job.jobUrl }}</li>
            <li>Location: {{ job.locationName }}</li>
            <li>Max Salary: {{ job.maximumSalary }}</li>
            <li>Min Salary: {{ job.minimumSalary }}</li>
            <br />
            <li>
              Job description:
              <span v-html="job.jobDescription"></span>
            </li>
          </ul>

          <q-btn
            color="black"
            label="Delete This Job"
            @click="jobStore.deleteSavedJob(job.jobId)"
          />
          <q-separator dark inset />
          <br />
        </q-card-section>
      </q-card>
    </div>
  </q-page>
</template>
