
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Concrete;

namespace DataAccess.Configurations {
    public class PlayingDatumConfiguration : IEntityTypeConfiguration<PlayingDatum> {

        public void Configure(EntityTypeBuilder<PlayingDatum> builder) {

            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .UseIdentityAlwaysColumn();

            builder.Property(e => e.AosTypeId).HasColumnName("aos_type_id");

            builder.Property(e => e.BallFallArray).HasColumnName("ball_fall_array");

            builder.Property(e => e.BallPositionArea).HasColumnName("ball_position_area");

            builder.Property(e => e.CourtId).HasColumnName("court_id");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            builder.Property(e => e.PlayerId).HasColumnName("player_id");

            builder.Property(e => e.PlayerPositionArea).HasColumnName("player_position_area");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Score).HasColumnName("score");

            builder.Property(e => e.StreamId).HasColumnName("stream_id");

            builder.HasOne(d => d.AosType)
                .WithMany(p => p.PlayingData)
                .HasForeignKey(d => d.AosTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playingdata_fk_2");

            builder.HasOne(d => d.Court)
                .WithMany(p => p.PlayingData)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playingdata_fk_1");

            builder.HasOne(d => d.Player)
                .WithMany(p => p.PlayingData)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playingdata_fk");

            builder.HasOne(d => d.Stream)
                .WithMany(p => p.PlayingData)
                .HasForeignKey(d => d.StreamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playingdata_fk_3");
        }
    }
}