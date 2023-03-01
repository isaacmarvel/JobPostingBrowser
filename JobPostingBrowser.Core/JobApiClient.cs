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
    internal class JobApiClient
    {
        public class PokemonAPIClient //add api key?
        {
            //public async Task<JobApiResults> ListJobs(string url)
            //{
            //    var client = new HttpClient();

            //    var response = await client.GetAsync(url);
            //    response.EnsureSuccessStatusCode();
            //    var responseBody = await response.Content.ReadAsStringAsync();
            //    var pokemonApiResult = JsonConvert.DeserializeObject<JobApiResults>(responseBody);

            //    return pokemonApiResult;
            //}




            //var PokemonApiResultProperty = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");
            //pokemon = PokemonApiResultProperty.Results;
        }
    }
}
