using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Configurations {
    public class SessionConfiguration : IEntityTypeConfiguration<Session> {
        public void Configure(EntityTypeBuilder<Session> builder) {
            builder.ToTable("Session");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.IsActivated)
                .HasColumnName("is_activated")
                .HasDefaultValueSql("true");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("name");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Session)
                .HasForeignKey<Session>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_fk");
        }
    }
}