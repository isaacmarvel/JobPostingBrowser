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

async function callInitialReedData(
  keywords,
  locationName,
  resultsToTake,
  resultsToSkip
) {
  return await api.get("/api/Reed", {
    params: {
      keywords: keywords,
      locationName: locationName,
      resultsToTake: 20,
      resultsToSkip: 0,
    },
  });
}

async function getInitialJobs(
  keywords,
  locationName,
  resultsToTake,
  resultsToSkip
) {
  const result = await callInitialReedData(
    keywords,
    locationName,
    resultsToTake,
    resultsToSkip
  );
  initialJobs.value = result.data;
  console.log(initialJobs);
  return initialJobs;
}

function resetRefs() {
  keyword.value = null;
  location.value = null;
  accept.value = false;
}

async function callSpecificReedData(jobId) {
  return await api.get("/api/ReedJobInfo", {
    params: {
      jobId: jobId,
    },
  });
}

async function getSpecificJobs(jobId) {
  const result = await callSpecificReedData(jobId);
  specificJob.value = result.data;
  console.log(specificJob);
  toggle.value = true;
  return specificJob;
}

async function postSpecificJob() {
  const response = await api.post("/api/JobDetails", specificJob.value);
  console.log(response);
}
</script>

<template>
  <q-page class="flex flex-center">
    <div>
      <!-- The initial search form, submit button, and eventually the next and previous jobs buttons: -->
      <div class="q-pa-md" @reset="resetRefs" style="max-width: 400px">
        <q-form
          @submit="getInitialJobs(keyword, locationName)"
          class="q-gutter-md"
        >
          <q-input
            filled
            v-model="keyword"
            label="Job Keyword or Keywords"
            lazy-rules
            :rules="[
              (val) => (val !== null && val !== '') || 'Enter a keyword',
            ]"
          />
          <q-input
            filled
            v-model="locationName"
            label="Location"
            lazy-rules
            :rules="[
              (val) => (val !== null && val !== '') || 'Enter a location',
            ]"
          />

          <div>
            <q-btn label="Search" type="submit" color="primary" />
            <!-- <br />
            <br />
            <q-btn
              color="black"
              label="Previous Results"
              v-if="initialJobs != null"
            ></q-btn>
            <br />
            <br />

            <q-btn
              color="black"
              label="Next Results"
              v-if="initialJobs != null"
            ></q-btn> -->
          </div>

          <div class="q-pa-md q-gutter-sm"></div>
        </q-form>
      </div>

      <!-- The list of jobs that appears after a search: -->
      <!-- Should this appear at top of page? -->
      <div class="q-pa-md row items-start q-gutter-md" v-if="toggle">
        <q-card dark bordered class="bg-grey-9 my-card">
          <q-card-section>
            <div class="q-pa-md q-gutter-sm">
              <q-btn
                color="white"
                text-color="black"
                label="Save this job"
                @click="postSpecificJob(specificJob)"
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

      <!-- The specific job that appears when you click "view this job:" -->
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
              @click="getSpecificJobs(r.jobId)"
            />
          </q-card-section>
        </q-card>
      </div>
    </div>
  </q-page>
</template>
