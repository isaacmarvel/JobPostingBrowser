using RestEase;
using static JobPostingBrowser.Core.Jobs;
using System.Net.Http.Headers;
using JobPostingBrowser.Core;

namespace JobPostingBrowser.Api.Clients
{
    public class ReedJobInfoAPIClient
    {
        [Header("User-Agent", "RestEase")]
        public interface IReedJobInfoAPI
        {
            [Header("Authorization")]
            AuthenticationHeaderValue Authorization { get; set; }

            [Get("jobs/{jobId}")]
            Task<JobDetails> GetJobInfoAsync([Path] int jobId);
        }
    }
}
