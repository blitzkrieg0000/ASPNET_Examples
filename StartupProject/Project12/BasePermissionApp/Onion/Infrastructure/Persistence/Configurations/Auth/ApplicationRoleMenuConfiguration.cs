using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationRoleMenuConfiguration : IEntityTypeConfiguration<ApplicationRoleMenu> {
    public void Configure(EntityTypeBuilder<ApplicationRoleMenu> builder) {

        builder.ToTable("ApplicationRoleMenu");

        builder.HasIndex(e => e.RoleId, "IX_ApplicationRoleMenu_role_id");

        builder.HasIndex(e => e.MenuId, "IX_ApplicationRoleMenu_menu_id");

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

        builder.Property(e => e.MenuId).HasColumnName("menu_id");

        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");

        builder.HasOne(e=>e.Role)
        .WithMany(p=>p.ApplicationRoleMenus)
        .HasForeignKey(e=>e.RoleId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("applicationrolemenu_fk_1");

        builder.HasOne(e=>e.Menu)
        .WithMany(p=>p.ApplicationRoleMenus)
        .HasForeignKey(e=>e.MenuId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("applicationrolemenu_fk_2");

    }
}
