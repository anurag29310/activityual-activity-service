using ActivityService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityService.Data.Configuration
{
    public class AnalyticsLogConfiguration
    : IEntityTypeConfiguration<AnalyticsLogs>
    {
        public void Configure(EntityTypeBuilder<AnalyticsLogs> builder)
        {
            builder.ToTable("AnalyticsLogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .HasConversion<string>();

            builder.Property(x => x.LogDate)
                .IsRequired();

            builder.HasOne(x => x.Activity)
                .WithMany(x => x.AnalyticsLogs)
                .HasForeignKey(x => x.ActivityId);
        }
    }
}
