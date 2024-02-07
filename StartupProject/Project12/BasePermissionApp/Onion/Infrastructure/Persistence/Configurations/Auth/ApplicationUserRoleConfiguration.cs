using Application.Consts.Auth;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole> {
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder) {
        builder.HasData(new ApplicationUserRole() {
            Id = Guid.NewGuid(),
            RoleId = RoleDefaults.SuperUser.Id,
            UserId = RoleDefaults.SuperUser.Id,
            IsPersistent = true,
            Active = true
        },
        new ApplicationUserRole() {
            Id = Guid.NewGuid(),
            RoleId = RoleDefaults.Admin.Id,
            UserId = RoleDefaults.Admin.Id,
            IsPersistent = true,
            Active = true
        });

        builder.ToTable("ApplicationUserRole");

        builder.HasIndex(e => e.RoleId, "IX_ApplicationUserRole_role_id");

        builder.HasIndex(e => e.UserId, "IX_ApplicationUserRole_user_id");

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

        builder.Property(e => e.RoleId).HasColumnName("role_id");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasOne(d => d.Role)
            .WithMany(p => p.ApplicationUserRoles)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("applicationuserrole_fk_1");

        builder.HasOne(d => d.User)
            .WithMany(p => p.ApplicationUserRoles)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .HasConstraintName("applicationuserrole_fk");

        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");
    }
}
