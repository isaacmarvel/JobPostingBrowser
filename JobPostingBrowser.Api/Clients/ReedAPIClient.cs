using Newtonsoft.Json;
using RestEase;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestEase;
using System.Net;
using static JobPostingBrowser.Core.Jobs;
using System.Net.Http.Headers;
using JobPostingBrowser.Api.Models;

namespace JobPostingBrowser.Api.Clients
{
    public class ReedAPIClient
    {

        [Header("User-Agent", "RestEase")]
        public interface IReedAPI
        {
            [Header("Authorization")]
            AuthenticationHeaderValue Authorization { get; set; }

            [Get("search")]
            Task<JobApiResults> GetJobsAsync(string keywords, string locationName, int resultsToTake, int resultsToSkip);
        }

        
    }
}
