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

        // Define an interface representing the API
        // GitHub requires a User-Agent header, so specify one
        [Header("User-Agent", "RestEase")]
        public interface IReedAPI
        {
            // The [Get] attribute marks this method as a GET request
            // The "users" is a relative path the a base URL, which we'll provide later
            // "{userId}" is a placeholder in the URL: the value from the "userId" method parameter is used
            [Header("Authorization")]
            AuthenticationHeaderValue Authorization { get; set; }

            [Get("search")]
            Task<JobApiResults> GetJobsAsync(string keywords, string locationName, int resultsToTake, int resultsToSkip);
        }

        
    }
}
