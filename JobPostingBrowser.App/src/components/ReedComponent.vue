<script setup>
import { ref } from "vue";
import { api } from "boot/axios";
import { useQuasar } from "quasar";

let viewJob = ref(false);
let initialJobs = ref(null);
const $q = useQuasar();

const keyword = ref(null);
const location = ref(null);

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
  console.log(result.data);
  return result.data;
}
</script>

<template>
  <div>
    <div class="q-pa-md" @reset="onReset" style="max-width: 400px">
      <q-form @submit="onSubmit" class="q-gutter-md">
        <q-input
          filled
          v-model="keyword"
          label="Job Keyword or Keywords"
          lazy-rules
          :rules="[(val) => (val && val.length > 0) || 'Please type something']"
        />
        <q-input
          filled
          v-model="location"
          label="Location"
          lazy-rules
          :rules="[(val) => (val && val.length > 0) || 'Please type something']"
        />

        <div>
          <q-btn label="Search" type="submit" color="primary" />
          <q-btn
            label="Reset"
            type="reset"
            color="primary"
            flat
            class="q-ml-sm"
          />
        </div>
      </q-form>
    </div>

    <div class="q-pa-md row items-start q-gutter-md">
      <q-card class="my-card" v-for="r in initialJobs" :key="r">
        <q-card-section>
          <ul>
            <li>{{ r.employerName }}</li>
            <li>{{ r.date }}</li>
            <li>{{ r.jobDescription }}</li>
            <li>{{ r.jobTitle }}</li>
            <li>{{ r.jobUrl }}</li>
            <li>{{ r.locationName }}</li>
          </ul>

          <q-btn
            color="black"
            label="View This Job"
            @click="
              viewJob = true;
              loadSpecificJobDataOnClick(r.jobId);
            "
          />

          <q-dialog v-model="viewJob" persistent>
            <q-card>
              <q-card-section class="row items-center">
                <q-avatar
                  icon="signal_wifi_off"
                  color="primary"
                  text-color="white"
                />
                <span class="q-ml-sm"
                  >You are currently not connected to any network.</span
                >
              </q-card-section>

              <q-card-actions>
                <q-btn flat label="Cancel" color="primary" v-close-popup />
                <q-btn
                  flat
                  label="Turn on Wifi"
                  color="primary"
                  v-close-popup
                />
              </q-card-actions>
            </q-card>
          </q-dialog>
        </q-card-section>
      </q-card>
    </div>
  </div>
</template>
