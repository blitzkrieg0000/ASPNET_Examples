using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace UI.Entities.Concrete {
    public partial class TenisContext : DbContext {
        public TenisContext() {
        }

        public TenisContext(DbContextOptions<TenisContext> options) : base(options) {
        }

        public virtual DbSet<Aostype> Aostypes { get; set; }
        public virtual DbSet<Court> Courts { get; set; }
        public virtual DbSet<CourtPointArea> CourtPointAreas { get; set; }
        public virtual DbSet<CourtType> CourtTypes { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayingDatum> PlayingData { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.ApplyConfiguration(new AostypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourtConfiguration());
            modelBuilder.ApplyConfiguration(new CourtPointAreaConfiguration());
            modelBuilder.ApplyConfiguration(new CourtTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayingDatumConfiguration());
            modelBuilder.ApplyConfiguration(new StreamConfiguration());

        }

    }
}
