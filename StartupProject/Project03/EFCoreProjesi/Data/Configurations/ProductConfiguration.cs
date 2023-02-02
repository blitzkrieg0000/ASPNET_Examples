using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Configurations {
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder) {

            //! Product
            // modelBuilder.Entity<Product>(). yerine builder kullanılıyor.
            builder.Property(x => x.Name).HasColumnName("product_name");
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Id).HasColumnName("product_id");
            builder.Property(x => x.Price).HasColumnName("product_price");
            builder.Property(x => x.Price).HasPrecision(18, 3);
            //builder.Property(x => x.Name).HasDefaultValueSql("'Urun Bilgisi Girilmemiş'");
            builder.HasIndex(x => x.Name).IsUnique(true);

            //*One -> Many
            // byProduct (Principal)
            builder
            .HasMany(x => x.SaleHistories)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);


            //* One -> One
            //byProduct (Principal)
            builder
            .HasOne(x => x.ProductDetail)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductDetail>(x => x.ProductId);

            //* Many -> Many (2x (One -> Many) Relationship Table)
            builder
            .HasMany(x => x.ProductCategories)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        }
    }
}