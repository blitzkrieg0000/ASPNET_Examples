using Application.Consts.Auth;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole> {
    public void Configure(EntityTypeBuilder<ApplicationRole> builder) {
        builder.HasData(new ApplicationRole() {
            Id = RoleDefaults.SuperUser.Id,
            Name = RoleDefaults.SuperUser.Name,
            IsPersistent = true,
            Active = true
        }, new ApplicationRole() {
            Id = RoleDefaults.Admin.Id,
            Name = RoleDefaults.Admin.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.Member.Id,
            Name = RoleDefaults.Member.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.NewsAnnouncementModule.Id,
            Name = RoleDefaults.NewsAnnouncementModule.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.GrantSupportModule.Id,
            Name = RoleDefaults.GrantSupportModule.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.GrowingSuggestionModule.Id,
            Name = RoleDefaults.GrowingSuggestionModule.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.CooperativesModule.Id,
            Name = RoleDefaults.CooperativesModule.Name,
            IsPersistent = true,
            Active = true
        });

        builder.ToTable("ApplicationRole");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Active)
            .IsRequired()
            .HasColumnName("active")
            .HasDefaultValueSql("true");

        builder.Property(e => e.CreatedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_time")
            .HasDefaultValueSql("(CURRENT_TIMESTAMP AT TIME ZONE 'UTC'::text)");

        builder.Property(e => e.DeletedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("deleted_time");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.Name).HasColumnName("name");


        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");

    }
}
