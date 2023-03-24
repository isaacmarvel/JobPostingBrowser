<script setup>
import { ref } from "vue";
import { api } from "boot/axios";
import { useQuasar } from "quasar";

let initialJobs = ref(null);
let specificJob = ref(null);
const $q = useQuasar();

const keyword = ref(null);
const location = ref(null);
const toggle = ref(false);

async function loadInitialJobData() {
  return await api.get("/api/Reed", {
    params: {
      keywords: "accountant",
      locationName: "london",
      resultsToTake: 20,
      resultsToSkip: 0,
    },
  });
}

async function onSubmit() {
  const result = await loadInitialJobData();
  initialJobs.value = result.data;
  console.log(initialJobs);
  return initialJobs;
}

function onReset() {
  keyword.value = null;
  location.value = null;
  accept.value = false;
}

async function loadSpecificJobData(jobId) {
  return await api.get("/api/ReedJobInfo", {
    params: {
      jobId: jobId,
    },
  });
}

async function loadSpecificJobDataOnClick(jobId) {
  const result = await loadSpecificJobData(jobId);
  specificJob.value = result.data;
  console.log(specificJob);
  toggle.value = true;
  return specificJob;
}

async function postJob() {
  //do i need a parameter?
  // POST request using axios with async/await
  const response = await api.post("/api/JobDetails", specificJob.value);
  console.log(response);
}
</script>

<template>
  <q-page class="flex flex-center">
    <div>
      <div class="q-pa-md" @reset="onReset" style="max-width: 400px">
        <q-form @submit="onSubmit" class="q-gutter-md">
          <q-input
            filled
            v-model="keyword"
            label="Job Keyword or Keywords"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'Enter a keyword']"
          />
          <q-input
            filled
            v-model="location"
            label="Location"
            lazy-rules
            :rules="[(val) => (val && val.length > 0) || 'Enter a location']"
          />

          <div>
            <q-btn label="Search" type="submit" color="primary" />
          </div>
        </q-form>
      </div>

      <div class="q-pa-md row items-start q-gutter-md" v-if="toggle">
        <q-card dark bordered class="bg-grey-9 my-card">
          <q-card-section>
            <div class="q-pa-md q-gutter-sm">
              <q-btn
                color="white"
                text-color="black"
                label="Save this job"
                @click="postJob(specificJob)"
              />
            </div>

            <div class="q-pa-md q-gutter-sm">
              <q-btn
                color="white"
                text-color="black"
                label="Cancel"
                @click="toggle = false"
              />
            </div>
          </q-card-section>

          <q-separator dark inset />
          <q-card-section>
            <ul>
              <li>Job Title: {{ specificJob.jobTitle }}</li>
              <li>Date Posted: {{ specificJob.datePosted }}</li>
              <li>Employer Name: {{ specificJob.employerName }}</li>
              <li>Link to Job: {{ specificJob.jobUrl }}</li>
              <li>Location: {{ specificJob.locationName }}</li>
              <li>Max Salary: {{ specificJob.maximumSalary }}</li>
              <li>Min Salary: {{ specificJob.minimumSalary }}</li>
              <br />
              <li>
                Job description:
                <span v-html="specificJob.jobDescription"></span>
              </li>
            </ul>
          </q-card-section>
        </q-card>
      </div>

      <div class="q-pa-md row items-start q-gutter-md">
        <q-card class="my-card" v-for="r in initialJobs" :key="r">
          <q-card-section>
            <ul>
              <li>Job Title: {{ r.jobTitle }}</li>
              <li>Employer: {{ r.employerName }}</li>
              <li>Partial Job Description: {{ r.jobDescription }}</li>
              <li>Location: {{ r.locationName }}</li>
            </ul>

            <q-btn
              color="black"
              label="View This Job"
              @click="loadSpecificJobDataOnClick(r.jobId)"
            />
          </q-card-section>
        </q-card>
      </div>
    </div>
  </q-page>
</template>
