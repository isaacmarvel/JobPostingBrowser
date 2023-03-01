﻿using Newtonsoft.Json;

namespace JobPostingBrowser.Core
{
    public class Jobs
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Result
        {
            [JsonProperty("jobId")]
            public int JobId { get; set; }

            [JsonProperty("employerId")]
            public int EmployerId { get; set; }

            [JsonProperty("employerName")]
            public string EmployerName { get; set; }

            [JsonProperty("employerProfileId")]
            public object EmployerProfileId { get; set; }

            [JsonProperty("employerProfileName")]
            public object EmployerProfileName { get; set; }

            [JsonProperty("jobTitle")]
            public string JobTitle { get; set; }

            [JsonProperty("locationName")]
            public string LocationName { get; set; }

            [JsonProperty("minimumSalary")]
            public double? MinimumSalary { get; set; }

            [JsonProperty("maximumSalary")]
            public double? MaximumSalary { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("expirationDate")]
            public string ExpirationDate { get; set; }

            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("jobDescription")]
            public string JobDescription { get; set; }

            [JsonProperty("applications")]
            public int Applications { get; set; }

            [JsonProperty("jobUrl")]
            public string JobUrl { get; set; }
        }

        public class Root
        {
            [JsonProperty("results")]
            public List<Result> Results { get; set; }

            [JsonProperty("ambiguousLocations")]
            public List<object> AmbiguousLocations { get; set; }

            [JsonProperty("totalResults")]
            public int TotalResults { get; set; }
        }


    }
}