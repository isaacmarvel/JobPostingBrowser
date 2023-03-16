

using JobPostingBrowser.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestEase;
using System.Net.Http.Headers;
using System.Text;
using static JobPostingBrowser.Api.Clients.ReedAPIClient;
using static JobPostingBrowser.Api.Clients.ReedJobInfoAPIClient;
using static JobPostingBrowser.Core.Jobs;

namespace JobPostingBrowser.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReedJobInfoController : ControllerBase
    {
        private readonly IOptions<ApiOptions> options;

        public ReedJobInfoController(IOptions<ApiOptions> options)
        {
            this.options = options;
        }

        //GET: api/1.0/search
        [HttpGet]
        public async Task<ActionResult<JobResponse>> GetJobInfo([FromQuery] JobInfoParameters parameters) //would use FromBody attribute for posts
        {
            IReedJobInfoAPI api = RestClient.For<IReedJobInfoAPI>("https://www.reed.co.uk/");

            var value = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{options.Value.ReedApiKey}:"));

            api.Authorization = new AuthenticationHeaderValue("Basic", value);

            var JobInfo = await api.GetJobInfoAsync(parameters.JobId);

            return JobInfo;
        }


    }
}
