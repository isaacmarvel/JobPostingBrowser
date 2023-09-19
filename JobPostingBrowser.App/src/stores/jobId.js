import { defineStore } from "pinia";
import { api } from "boot/axios";

export const useSavedJobStore = defineStore("savedJobs", {
  state: () => ({
    savedJobs: null,
  }),
  actions: {
    async getSavedJobs() {
      try {
        return (this.savedJobs = await api.get("/api/JobDetails"));
      } catch (error) {
        console.log(error);
        return error;
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
