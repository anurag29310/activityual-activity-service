using ActivityService.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.Data
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext(DbContextOptions<ActivityDbContext> options)
          : base(options) { }


        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ActivityTracking> Trackings { get; set; }
        public DbSet<ActivitySchedule> Schedules { get; set; }
        public DbSet<AnalyticsLogs> AnalyticsLogs { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityDbContext).Assembly);
        }
    }
}
