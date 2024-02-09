using System.Reflection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Entity;
using UI.Entity.Concrete.Employee;
using UI.Entity.Concrete.Work;

namespace UI.Contexts;


public class DefaultContext(DbContextOptions<DefaultContext> options) : DbContext(options), IDataProtectionKeyContext {

    //! Auth
    public DbSet<Employee> Employee => this.Set<Employee>();
    public DbSet<EmployeeType> EmployeeType => this.Set<EmployeeType>();
    public DbSet<OffWork> OffWork => this.Set<OffWork>();

    //!Data Protection Keys
    public DbSet<DataProtectionKey> DataProtectionKeys => this.Set<DataProtectionKey>();
    
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