namespace JobPostingBrowser.Api.Models
{
    public class JobParameters
    {
        public string Keywords { get; set; }

        public string LocationName { get; set; }

        public int ResultsToTake { get; set; }

        public int ResultsToSkip { get; set; }

    }
}
