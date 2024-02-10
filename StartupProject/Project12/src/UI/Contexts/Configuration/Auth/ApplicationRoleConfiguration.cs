using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Const.Auth;
using UI.Entities.Auth;

namespace UI.Contexts.Configuration.Auth;


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
            Id = RoleDefaults.Manager.Id,
            Name = RoleDefaults.Manager.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.IT.Id,
            Name = RoleDefaults.IT.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.HumanResources.Id,
            Name = RoleDefaults.HumanResources.Name,
            IsPersistent = true,
            Active = true
        },
        new ApplicationRole() {
            Id = RoleDefaults.Employee.Id,
            Name = RoleDefaults.Employee.Name,
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
