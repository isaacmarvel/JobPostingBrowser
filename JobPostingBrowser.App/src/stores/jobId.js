import { defineStore } from "pinia";
import { api } from "boot/axios";

export const useSavedJobStore = defineStore("savedJobs", {
  state: () => ({
    savedJobs: null,
  }),
  getters: {
    getSavedJobs(state) {
      console.log(state.savedJobs);
      return JSON.parse(JSON.stringify(state.savedJobs));
    },
  },
  actions: {
    async fetchSavedJobs() {
      try {
        const data = await api.get("/api/JobDetails");
        this.savedJobs = data.data;
        console.log(this.savedJobs);
        //maybe can json stringify this stuff here?
      } catch (error) {
        console.log(error);
        alert(error);
      }
    },
    async deleteSavedJob(jobId) {
      try {
        const response = await api.delete(`/api/JobDetails/${jobId}`);
        console.log(response);
      } catch (error) {
        console.log(error);
        alert(error);
      }
    },
    // create(title, description) {
    //     const created = {id: this.count + 1, title, description};
    //     this.todos = [created, ...this.todos];
    // },
    // update(title, description) {
    //     const index = this.findIndex(this.id);
    //     this.todos[index] = {...this.todos[index], title, description};
    // },
    // deleteJobFromDb(jobId) {
    //   const response = api.delete(`/api/JobDetails/${jobId}`);
    //   window.location.reload();
    //   console.log(response);
    // }
  },
});
