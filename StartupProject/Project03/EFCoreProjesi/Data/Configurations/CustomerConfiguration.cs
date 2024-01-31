using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreProjesi.Data.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {

            //modelBuilder.Entity<Customer>().HasNoKey(); //PrimaryKey olmadan kaydetmek için
            builder.HasKey(x => new { x.Number, x.Name }); //Çift PK için isimsiz obje notasyonu kullanılır.

        }
    }
}