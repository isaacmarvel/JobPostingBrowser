using JobPostingBrowser.Core;
using Microsoft.EntityFrameworkCore;

namespace JobPostingBrowser.Api.Models
{
    public class JobContext : DbContext
    {
        public DbSet<JobDetails> JobDetailsSet { get; set; }

        public string DbPath { get; } //may not need this

        public JobContext(DbContextOptions<JobContext> options)
        : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Jobs.db"); //may not need this
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source=Jobs.db");
    }
}
