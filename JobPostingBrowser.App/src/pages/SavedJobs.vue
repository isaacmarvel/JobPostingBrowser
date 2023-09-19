<script setup>
import { ref } from "vue";
import { api } from "boot/axios";
import { onMounted } from "vue";
import { useQuasar } from "quasar";
import { useSavedJobStore } from "stores/jobId.js";

let jobStore = useSavedJobStore();

// async function getSavedJobs() {
//   return await api.get("/api/JobDetails");
// }
let jobs;
onMounted(async () => {
  jobStore.getSavedJobs();
});
function consoleLog() {
  console.log(jobStore.savedJobs);
}
// async function deleteJobFromDb(jobId) {
//   const response = await api.delete(`/api/JobDetails/${jobId}`);
//   window.location.reload();
//   console.log(response);
// }
</script>

<template>
  <q-page class="flex flex-center">
    <button @click="consoleLog">get jobs</button>
    <div
      v-if="jobStore.savedJobs != null"
      class="q-pa-md row items-start q-gutter-md"
    >
      <li>test</li>
      <q-card class="my-card" v-for="job in jobStore.savedJobs" :key="job">
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
            @click="deleteJobFromDb(job.jobId)"
          />
          <q-separator dark inset />
          <br />
        </q-card-section>
      </q-card>
    </div>
  </q-page>
</template>
