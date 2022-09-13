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

            builder.Property(e => e.Description).HasColumnName("description");

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("false");

            builder.Property(e => e.PlayerPositionArray).HasColumnName("player_position_array");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Score).HasColumnName("score");
            
            builder.Property(e => e.KafkaTopicName).HasColumnName("kafka_topic_name");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.ProcessResponse)
                .HasForeignKey<ProcessResponse>(d => d.Id)
                .HasConstraintName("processresponse_fk");
        }
    }
}


