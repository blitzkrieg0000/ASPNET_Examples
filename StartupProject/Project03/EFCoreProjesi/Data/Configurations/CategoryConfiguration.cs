using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreProjesi.Data.Configurations {
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {

            //* Many -> Many (2x (One -> Many) Relationship Table)
            builder
             .HasMany(x => x.ProductCategories)
             .WithOne(x => x.Category)
             .HasForeignKey(x => x.CategoryId);

        }
    }
}