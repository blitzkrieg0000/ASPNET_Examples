
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Configurations {
    public class StreamConfiguration : IEntityTypeConfiguration<Stream> {

        public void Configure(EntityTypeBuilder<Stream> builder) {
            builder.ToTable("Stream");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.CourtLineArray).HasColumnName("court_line_array");

            builder.Property(e => e.IsActivated)
                .IsRequired()
                .HasColumnName("is_activated")
                .HasDefaultValueSql("true");

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("true");

            builder.Property(e => e.IsVideo).HasColumnName("is_video");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Source)
                .IsRequired()
                .HasColumnName("source");
        }
    }
}