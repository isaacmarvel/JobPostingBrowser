using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostingBrowser.Core
{
    internal class JobDetails
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class JobDetailsRoot
        {
            [JsonProperty("employerId")]
            public int EmployerId { get; set; }

            [JsonProperty("employerName")]
            public object EmployerName { get; set; }

            
            [JsonProperty("jobId")]
            [Key]
            public int JobId { get; set; }

            [JsonProperty("jobTitle")]
            public object JobTitle { get; set; }

            [JsonProperty("locationName")]
            public object LocationName { get; set; }

            [JsonProperty("minimumSalary")]
            public object MinimumSalary { get; set; }

            [JsonProperty("maximumSalary")]
            public object MaximumSalary { get; set; }

            [JsonProperty("yearlyMinimumSalary")]
            public object YearlyMinimumSalary { get; set; }

            [JsonProperty("yearlyMaximumSalary")]
            public object YearlyMaximumSalary { get; set; }

            [JsonProperty("currency")]
            public object Currency { get; set; }

            [JsonProperty("salaryType")]
            public object SalaryType { get; set; }

            [JsonProperty("salary")]
            public object Salary { get; set; }

            [JsonProperty("datePosted")]
            public object DatePosted { get; set; }

            [JsonProperty("expirationDate")]
            public object ExpirationDate { get; set; }

            [JsonProperty("externalUrl")]
            public object ExternalUrl { get; set; }

            [JsonProperty("jobUrl")]
            public object JobUrl { get; set; }

            [JsonProperty("partTime")]
            public bool PartTime { get; set; }

            [JsonProperty("fullTime")]
            public bool FullTime { get; set; }

            [JsonProperty("contractType")]
            public object ContractType { get; set; }

            [JsonProperty("jobDescription")]
            public object JobDescription { get; set; }

            [JsonProperty("applicationCount")]
            public int ApplicationCount { get; set; }
        }


    }
}
