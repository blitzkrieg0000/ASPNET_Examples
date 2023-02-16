using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jwtapp.back.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category[] {
                new Category(){Id=1,Definition="Giyim"},
                new Category(){Id=2,Definition="Elektronik"}
            });
            
        }
    }
}