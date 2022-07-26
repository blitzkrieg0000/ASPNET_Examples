using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations {
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder) {

            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(250);
            builder.Property(x => x.Surname).IsRequired(true);

            builder
            .HasMany(x => x.Accounts)
            .WithOne(x => x.ApplicationUser)
            .HasForeignKey(x => x.ApplicationUserId);

        }

    }
}