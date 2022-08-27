using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Configurations {
    public class ProcessConfiguration : IEntityTypeConfiguration<Process> {
        public void Configure(EntityTypeBuilder<Process> builder) {
            builder.ToTable("Process");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.IsCompleted)
                .HasColumnName("is_completed")
                .HasDefaultValueSql("false");

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("false");

            builder.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.SessionId).HasColumnName("session_id");

            builder.HasOne(d => d.Session)
                .WithMany(p => p.Processes)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("process_fk");
        }
    }
}