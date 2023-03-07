using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Net.Http.Headers;
using System.Text;
using static JobPostingBrowser.Api.Clients.ReedAPIClient;
using static JobPostingBrowser.Core.Jobs;
using static JobPostingBrowser.Core.ApiKeys;


namespace JobPostingBrowser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReedController : ControllerBase
    {
        //GET: api/1.0/search
        [HttpGet]
        public async Task<ActionResult<JobApiResults>> GetJobs()
        {
            IReedAPI api = RestClient.For<IReedAPI>("https://www.reed.co.uk/");

            var value = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiKey}:"));

            api.Authorization = new AuthenticationHeaderValue("Basic", value);

            var job = await api.GetJobAsync();

            return job;
        }
        

    }
}
