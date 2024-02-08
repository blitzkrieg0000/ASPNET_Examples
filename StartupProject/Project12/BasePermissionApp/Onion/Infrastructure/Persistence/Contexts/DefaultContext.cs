using System.Reflection;
using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;


public class DefaultContext : DbContext {
    //! Auth
    public DbSet<ApplicationUser> ApplicationUser => this.Set<ApplicationUser>();
    public DbSet<ApplicationRole> ApplicationRole => this.Set<ApplicationRole>();
    public DbSet<ApplicationUserRole> ApplicationUserRole => this.Set<ApplicationUserRole>();
    public DbSet<ApplicationUserClaim> ApplicationUserClaim => this.Set<ApplicationUserClaim>();
    public DbSet<ApplicationUserLogin> ApplicationUserLogin => this.Set<ApplicationUserLogin>();
    public DbSet<ApplicationRoleMenu> ApplicationRoleMenu => this.Set<ApplicationRoleMenu>();


    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);  //Postgresql,in timestamp değişkeni için bir UTC ayarı.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
        //? Bilgi: "newsequentialid()" : Postgresql fonksiyonudur ve Guid değer üretir. Tablolara manuel ekleme yapılacaksa, Id sütununa default value olarak bu fonksiyon verilebilir. EFCore zaten hallediyor.

        //! Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Otomatik Tüm Configuration'ları dahil et

        base.OnModelCreating(modelBuilder);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        // Tüm Modified veya Added state'ine sahip Entity'lerin tarihlerini SaveChangesAsync çağrıldığında otomatik olarak güncelle.
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas) {
            var _ = data.State switch {
                EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                EntityState.Modified => data.Entity.ModifiedTime = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}