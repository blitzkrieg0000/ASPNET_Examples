using System.Collections.Immutable;
using jwtapp.back.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jwtapp.back.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            builder.HasOne(x=>x.AppRole).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.AppRoleId);
            builder.HasData(new AppUser[]
            {
                new AppUser(){Id=1,AppRoleId=1,Username="Admin",Password="1"},
                new AppUser(){Id=2,AppRoleId=2,Username="Member",Password="1"}     
            });
           
        }
        
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
            builder.HasData(new Product[]
            {
                new Product(){Id=1,Name="Elbise",Stock=100,Price=40,CategoryId=1},
                new Product(){Id=2,Name="Buzdolabı",Stock=100,Price=40,CategoryId=2}
            });
        }
    }
    
}