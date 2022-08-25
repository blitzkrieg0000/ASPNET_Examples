using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concrete {
    public class TennisContext : DbContext {

        public TennisContext(DbContextOptions<TennisContext> options) : base(options) {
        }

        public DbSet<AosType> Aostypes { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtPointArea> CourtPointAreas { get; set; }
        public DbSet<CourtType> CourtTypes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayingDatum> PlayingData { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionParameter> ProcessParameters { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessResponse> ProcessResponseConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.ApplyConfiguration(new AosTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourtConfiguration());
            modelBuilder.ApplyConfiguration(new CourtPointAreaConfiguration());
            modelBuilder.ApplyConfiguration(new CourtTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayingDatumConfiguration());
            modelBuilder.ApplyConfiguration(new StreamConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new SessionParameterConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessResponseConfiguration());
        }

    }
}