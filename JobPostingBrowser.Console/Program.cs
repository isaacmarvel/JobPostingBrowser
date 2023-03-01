
using JobPostingBrowser.Core;

var pokemonClient = new JobApiClient();
var response = await pokemonClient.ListJobs("https://pokeapi.co/api/v2/item/");



foreach (var job in response.Results)
{
    Console.WriteLine(job.JobId);
}
Console.ReadLine();
