using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreProjesi.Data.Configurations {
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory> {
        public void Configure(EntityTypeBuilder<ProductCategory> builder) {
            
            //* Many -> Many (2x (One -> Many) Relationship Table)
            builder
            .HasKey(x => new { x.ProductId, x.CategoryId });

        }
    }
}