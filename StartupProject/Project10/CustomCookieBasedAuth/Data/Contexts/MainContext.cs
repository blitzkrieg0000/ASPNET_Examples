using CustomCookieBasedAuth.Configurations;
using CustomCookieBasedAuth.Data.Auth;
using Microsoft.EntityFrameworkCore;

namespace CustomCookieBasedAuth.Data.Contexts;

public class MainContext : DbContext {

    public DbSet<ApplicationUser> ApplicationUser => this.Set<ApplicationUser>();
    public DbSet<ApplicationRole> ApplicationRole => this.Set<ApplicationRole>();
    public DbSet<ApplicationUserRole> ApplicationUserRole => this.Set<ApplicationUserRole>();

    public MainContext(DbContextOptions<MainContext> options) : base(options) {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

        //! Configurations
        modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());


        base.OnModelCreating(modelBuilder);
    }
}
