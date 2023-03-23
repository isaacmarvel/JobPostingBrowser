using RestEase;
using static JobPostingBrowser.Core.Jobs;
using System.Net.Http.Headers;

namespace JobPostingBrowser.Api.Clients
{
    public class ReedJobInfoAPIClient
    {
        [Header("User-Agent", "RestEase")]
        public interface IReedJobInfoAPI
        {
            // The [Get] attribute marks this method as a GET request
            // The "users" is a relative path the a base URL, which we'll provide later
            // "{userId}" is a placeholder in the URL: the value from the "userId" method parameter is used
            [Header("Authorization")]
            AuthenticationHeaderValue Authorization { get; set; }

            [Get("jobs/{jobId}")]
            Task<JobDetailsRoot> GetJobInfoAsync([Path] int jobId);
        }
    }
}
