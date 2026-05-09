using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActivityService.Data.Configuration
{
    //public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    //{
    //    //public void Configure(EntityTypeBuilder<ActivityLog> builder)
    //    //{
    //    //    builder.ToTable("ActivityLogs");

    //    //    builder.HasKey(x => x.Id);

    //    //    builder.HasIndex(x => new { x.UserId, x.Date });
    //    //    builder.HasIndex(x => new { x.ActivityId, x.Date });

    //    //    builder.Property(x => x.Status)
    //    //           .IsRequired();

    //    //    builder.HasOne(x => x.Activity)
    //    //           .WithMany(a => a.Logs)
    //    //           .HasForeignKey(x => x.ActivityId);
    //    //}
    //}
}
