using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entity.Concrete.Work;

namespace UI.Contexts.Configuration;


public class OffWorkConfiguration : IEntityTypeConfiguration<OffWork> {
    public void Configure(EntityTypeBuilder<OffWork> builder) {


        builder.ToTable("off_work");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnName("id")
        .ValueGeneratedOnAdd();

        builder.Property(x => x.IsApproved)
        .HasColumnName("is_approved");


        builder.Property(e => e.OffStart)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("off_start")
            .HasDefaultValueSql("(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.OffEnd)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("off_end")
            .HasDefaultValueSql("(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.CreatedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time")
            .HasDefaultValueSql("(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.DeletedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("deleted_time");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.Active)
            .IsRequired()
            .HasColumnName("active")
            .HasDefaultValueSql("true");

        builder.Property(e => e.IsPersistent)
        .HasColumnName("is_persistent");
    }
}
