using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations {
    public class ProcessResponseConfiguration : IEntityTypeConfiguration<ProcessResponse> {
        public void Configure(EntityTypeBuilder<ProcessResponse> builder) {
            
            builder.ToTable("ProcessResponse");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.BallFallArray).HasColumnName("ball_fall_array");

            builder.Property(e => e.BallPositionArray).HasColumnName("ball_position_array");

            builder.Property(e => e.Canvas).HasColumnName("canvas");

            builder.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("false");

            builder.Property(e => e.PlayerPositionArray).HasColumnName("player_position_array");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }
}

