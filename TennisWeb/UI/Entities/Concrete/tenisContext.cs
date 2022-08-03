using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UI.Entities.Concrete
{
    public partial class tenisContext : DbContext
    {
        public tenisContext()
        {
        }

        public tenisContext(DbContextOptions<tenisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aostype> Aostypes { get; set; }
        public virtual DbSet<Court> Courts { get; set; }
        public virtual DbSet<CourtPointArea> CourtPointAreas { get; set; }
        public virtual DbSet<CourtType> CourtTypes { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayingDatum> PlayingData { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=tenis;Username=tenis;Password=2sfcNavA89A294V4");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Aostype>(entity =>
            {
                entity.ToTable("AOSType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CourtPointAreaId).HasColumnName("court_point_area_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.CourtPointArea)
                    .WithMany(p => p.Aostypes)
                    .HasForeignKey(d => d.CourtPointAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("aostype_fk");
            });

            modelBuilder.Entity<Court>(entity =>
            {
                entity.ToTable("Court");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CourtTypeId).HasColumnName("court_type_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.CourtType)
                    .WithMany(p => p.Courts)
                    .HasForeignKey(d => d.CourtTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("court_fk");
            });

            modelBuilder.Entity<CourtPointArea>(entity =>
            {
                entity.ToTable("CourtPointArea");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AreaArray).HasColumnName("area_array");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<CourtType>(entity =>
            {
                entity.ToTable("CourtType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<PlayingDatum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AosTypeId).HasColumnName("aos_type_id");

                entity.Property(e => e.BallFallArray).HasColumnName("ball_fall_array");

                entity.Property(e => e.BallPositionArea).HasColumnName("ball_position_area");

                entity.Property(e => e.CourtId).HasColumnName("court_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.PlayerPositionArea).HasColumnName("player_position_area");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.HasOne(d => d.AosType)
                    .WithMany(p => p.PlayingData)
                    .HasForeignKey(d => d.AosTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playingdata_fk_2");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.PlayingData)
                    .HasForeignKey(d => d.CourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playingdata_fk_1");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayingData)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playingdata_fk");

                entity.HasOne(d => d.Stream)
                    .WithMany(p => p.PlayingData)
                    .HasForeignKey(d => d.StreamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playingdata_fk_3");
            });

            modelBuilder.Entity<Stream>(entity =>
            {
                entity.ToTable("Stream");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CourtLineArray).HasColumnName("court_line_array");

                entity.Property(e => e.IsActivated)
                    .IsRequired()
                    .HasColumnName("is_activated")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.KafkaTopicName).HasColumnName("kafka_topic_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
