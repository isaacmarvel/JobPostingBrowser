using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPostingBrowser.Core.Jobs;
using static System.Net.WebRequestMethods;

namespace JobPostingBrowser.Core
{
    public class JobApiClient
    {
        //add api key?

        public async Task<JobApiResults> ListJobs(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var jobApiResult = JsonConvert.DeserializeObject<JobApiResults>(responseBody);

            return jobApiResult;
        }




        //var PokemonApiResultProperty = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");
        //pokemon = PokemonApiResultProperty.Results;

    }
}
