using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Const.Auth;
using UI.Entity.Concrete.Employee;

namespace UI.Contexts.Configuration;


public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType> {
    public void Configure(EntityTypeBuilder<EmployeeType> builder) {

        builder.ToTable("EmployeeType");

        builder.HasData(new EmployeeType{
            Name = RoleDefaults.Manager.Name,
            ApplicationRoleId = RoleDefaults.Manager.Id
        },
        new EmployeeType{
            Name = RoleDefaults.IT.Name,
            ApplicationRoleId = RoleDefaults.IT.Id
        },
        new EmployeeType{
            Name = RoleDefaults.HumanResources.Name,
            ApplicationRoleId = RoleDefaults.HumanResources.Id
        },
        new EmployeeType{
            Name = RoleDefaults.Employee.Name,
            ApplicationRoleId = RoleDefaults.Employee.Id
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnName("id")
        .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
        .HasColumnName("name")
        .IsRequired();

        builder.Property(x=>x.ApplicationRoleId)
        .HasColumnName("application_role_id")
        .IsRequired();

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

        builder.Property(e => e.Active)
            .IsRequired()
            .HasColumnName("active")
            .HasDefaultValueSql("true");

        builder.Property(e => e.IsPersistent)
        .HasColumnName("is_persistent");
    }
}
