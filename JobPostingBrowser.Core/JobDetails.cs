using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPostingBrowser.Core
{
    public class JobDetails
    {

            [JsonProperty("employerId")]
            public int? EmployerId { get; set; }

            [JsonProperty("employerName")]
            public string? EmployerName { get; set; }

            [JsonProperty("jobId")]
            [Key]
            public int? JobId { get; set; }

            [JsonProperty("jobTitle")]
            public string? JobTitle { get; set; }

            [JsonProperty("locationName")]
            public string? LocationName { get; set; }

            [JsonProperty("minimumSalary")]
            public double? MinimumSalary { get; set; }

            [JsonProperty("maximumSalary")]
            public double? MaximumSalary { get; set; }

            [JsonProperty("datePosted")]
            public string? DatePosted { get; set; }


            [JsonProperty("externalUrl")]
            public string? ExternalUrl { get; set; }

            [JsonProperty("jobUrl")]
            public string? JobUrl { get; set; }


            [JsonProperty("contractType")]
            public string? ContractType { get; set; }

            [JsonProperty("jobDescription")]
            public string? JobDescription { get; set; }

            [JsonProperty("applicationCount")]
            public int? ApplicationCount { get; set; }
        }
}
