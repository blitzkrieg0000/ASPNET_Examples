using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TennisWeb6.Core.Domains;

namespace TennisWeb6.Persistance.Configurations {
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser> {
        public void Configure(EntityTypeBuilder<AppUser> builder) {
            builder.HasOne(x => x.AppRoles).WithMany(x => x.AppUsers).HasForeignKey(x => x.AppRoleId);
        }
    }

}