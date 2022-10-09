using Microsoft.EntityFrameworkCore;
using TennisWeb6.Core.Domains;
using TennisWeb6.Persistance.Configurations;

namespace TennisWeb6.Persistance.Context {
    public class MainContext : DbContext {
        public MainContext(DbContextOptions<MainContext> options) : base(options) {
        }
        
        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}