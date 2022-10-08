using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Configurations {
    public class SessionParameterConfiguration : IEntityTypeConfiguration<SessionParameter> {
        public void Configure(EntityTypeBuilder<SessionParameter> builder) {
            builder.ToTable("SessionParameter");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.AosTypeId).HasColumnName("aos_type_id");

            builder.Property(e => e.CourtId).HasColumnName("court_id");

            builder.Property(e => e.Force)
                .HasColumnName("force")
                .HasDefaultValueSql("false");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            builder.Property(e => e.Limit)
                .HasColumnName("limit")
                .HasDefaultValueSql("'-1'::integer");

            builder.Property(e => e.PlayerId).HasColumnName("player_id");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.StreamId).HasColumnName("stream_id");

            builder.HasOne(d => d.AosType)
                .WithMany(p => p.SessionParameters)
                .HasForeignKey(d => d.AosTypeId)
                .HasConstraintName("processparameter_fk_1");

            builder.HasOne(d => d.Court)
                .WithMany(p => p.SessionParameters)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("processparameter_fk_3");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.SessionParameter)
                .HasForeignKey<SessionParameter>(d => d.Id)
                .HasConstraintName("sessionparameter_fk");

            builder.HasOne(d => d.Player)
                .WithMany(p => p.SessionParameters)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("processparameter_fk_2");

            builder.HasOne(d => d.Stream)
                .WithMany(p => p.SessionParameters)
                .HasForeignKey(d => d.StreamId)
                .HasConstraintName("processparameter_fk");
        }
    }
}