

using JobPostingBrowser.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestEase;
using System.Net.Http.Headers;
using System.Text;
using static JobPostingBrowser.Api.Clients.ReedAPIClient;
using static JobPostingBrowser.Core.Jobs;

namespace JobPostingBrowser.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReedController : ControllerBase
    {
        private readonly IOptions<ApiOptions> options;

        public ReedController(IOptions<ApiOptions> options)
        {
            this.options = options;
        }

        //GET: api/1.0/search
        [HttpGet]
        public async Task<ActionResult<List<JobRoot>>> GetJobs([FromQuery] JobParameters parameters) //would use FromBody attribute for posts
        {
            IReedAPI api = RestClient.For<IReedAPI>("https://www.reed.co.uk/api/1.0/");

            var value = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{options.Value.ReedApiKey}:"));

            api.Authorization = new AuthenticationHeaderValue("Basic", value);

            var job = await api.GetJobsAsync(parameters.Keywords, parameters.LocationName, parameters.ResultsToTake, parameters.ResultsToSkip);
            
            return job.Results;
        }


    }
}
