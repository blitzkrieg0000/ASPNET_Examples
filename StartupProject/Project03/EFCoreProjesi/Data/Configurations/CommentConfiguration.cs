using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreProjesi.Data.Configurations {
    public class CommentConfiguration : IEntityTypeConfiguration<Comment> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder) {

            builder.Property(x => x.Content).HasMaxLength(300);
            builder.Property(x => x.Content).IsRequired();


        }
    }
}