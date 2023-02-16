using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jwtapp.back.Persistance.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole[] 
            {
                new AppRole(){Id=1,Definition="Admin"},
                new AppRole(){  Id=2,Definition="Member"}

            });
        }
    }
}