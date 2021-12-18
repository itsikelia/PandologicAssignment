using Microsoft.EntityFrameworkCore;

namespace PandologicAssignment.Models
{
    public class JobContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobView> JobViews { get; set; }

        public DbSet<ActiveJob> ActiveJobs { get; set; }

        public string DbPath { get; }
        public JobContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join("Jobs.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source=Jobs.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveJob>().HasKey(aj => new
            {
                aj.JobId,
                aj.PostDate
            });
        }

    }
}
