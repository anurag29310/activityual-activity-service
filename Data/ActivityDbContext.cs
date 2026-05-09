using ActivityService.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data
{
    public class ActivityDbContext : DbContext
    {
        public DbSet<UserActivity> Activities { get; set; }

        public ActivityDbContext(DbContextOptions<ActivityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityDbContext).Assembly);
        }
    }
}
