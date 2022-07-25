using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Configurations {
    public class BlogConfiguration : IEntityTypeConfiguration<Blog> {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Blog> builder) {

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(250);
            builder.Property(x => x.Url).HasMaxLength(300);

        }
    }
}