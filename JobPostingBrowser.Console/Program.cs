using JobPostingBrowser.Core;
//where to put api key? gitignore file?

var pokemonClient = new JobApiClient();
var response = await pokemonClient.ListJobs("https://www.reed.co.uk/api/1.0/search?keywords=accountant&location=london&employerid=123&distancefromlocation=15");



foreach (var job in response.Results)
{
    Console.WriteLine(job.JobId);
}
Console.ReadLine();
