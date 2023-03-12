using System.ComponentModel.DataAnnotations;

namespace JobPostingBrowser.Api.Models
{
    public class ApiOptions
    {
        [Required]
        public string ReedApiKey { get; set; }
    }
}
