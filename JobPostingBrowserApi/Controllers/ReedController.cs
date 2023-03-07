using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using static JobPostingBrowser.Api.Clients.ReedAPIClient;
using static JobPostingBrowser.Core.Jobs;

namespace JobPostingBrowser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReedController : ControllerBase
    {
        //GET: api/1.0/search
        [HttpGet]
        public async Task<ActionResult<JobResponse>> GetJobs()
        {
            IReedAPI api = RestClient.For<IReedAPI>("https://www.reed.co.uk/");

            var job = await api.GetJobAsync();

            return job;
        }
        
    }
}
