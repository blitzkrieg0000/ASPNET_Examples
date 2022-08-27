using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UI
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
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayingDatum> PlayingData { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<ProcessParameter> ProcessParameters { get; set; }
        public virtual DbSet<ProcessResponse> ProcessResponses { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionParameter> SessionParameters { get; set; }
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

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.GenderId)
                    .HasColumnName("gender_id")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("player_fk");
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

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsCompleted)
                    .HasColumnName("is_completed")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("process_fk");
            });

            modelBuilder.Entity<ProcessParameter>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Limit).HasColumnName("limit");

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ProcessParameter)
                    .HasForeignKey<ProcessParameter>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("processparameters_fk");

                entity.HasOne(d => d.Stream)
                    .WithMany(p => p.ProcessParameters)
                    .HasForeignKey(d => d.StreamId)
                    .HasConstraintName("processparameters_fk_1");
            });

            modelBuilder.Entity<ProcessResponse>(entity =>
            {
                entity.ToTable("ProcessResponse");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BallFallArray).HasColumnName("ball_fall_array");

                entity.Property(e => e.BallPositionArray).HasColumnName("ball_position_array");

                entity.Property(e => e.Canvas).HasColumnName("canvas");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PlayerPositionArray).HasColumnName("player_position_array");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ProcessResponse)
                    .HasForeignKey<ProcessResponse>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("processresponse_fk");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IsActivated)
                    .HasColumnName("is_activated")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<SessionParameter>(entity =>
            {
                entity.ToTable("SessionParameter");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AosTypeId).HasColumnName("aos_type_id");

                entity.Property(e => e.CourtId).HasColumnName("court_id");

                entity.Property(e => e.Force)
                    .HasColumnName("force")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Limit)
                    .HasColumnName("limit")
                    .HasDefaultValueSql("'-1'::integer");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.SaveDate)
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.HasOne(d => d.AosType)
                    .WithMany(p => p.SessionParameters)
                    .HasForeignKey(d => d.AosTypeId)
                    .HasConstraintName("processparameter_fk_1");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.SessionParameters)
                    .HasForeignKey(d => d.CourtId)
                    .HasConstraintName("processparameter_fk_3");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SessionParameter)
                    .HasForeignKey<SessionParameter>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sessionparameter_fk");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.SessionParameters)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("processparameter_fk_2");

                entity.HasOne(d => d.Stream)
                    .WithMany(p => p.SessionParameters)
                    .HasForeignKey(d => d.StreamId)
                    .HasConstraintName("processparameter_fk");
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
