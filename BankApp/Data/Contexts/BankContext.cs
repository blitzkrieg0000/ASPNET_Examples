using BankApp.Data.Configurations;
using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Contexts {
    public class BankContext : DbContext {

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        // "DependencyInjection" ile bu şekilde kalıtım almak ve "ConfigureServices" içerisinde "AddDbContext" i kullanmak,
        // diğer classlarda bu contextin instance ını oluşturmayı kolaylaştırır.
        // Diğer türlü "OnConfiguring" da ayar yaparsak "DI" ile instance oluşturmayı kullanamayız.
        public BankContext(DbContextOptions<BankContext> options) : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}