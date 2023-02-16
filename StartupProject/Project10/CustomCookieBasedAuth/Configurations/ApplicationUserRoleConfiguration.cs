using CustomCookieBasedAuth.Data.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBasedAuth.Configurations;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole> {
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder) {

        builder.HasData(new ApplicationUserRole() {
            RoleId = 1,
            UserId = 1
        });

        builder.HasKey(x => new { x.UserId, x.RoleId });

        builder.ToTable("ApplicationUserRole");

        builder.Property(e => e.RoleId).HasColumnName("role_id");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasOne(d => d.Role)
            .WithMany()
            .HasForeignKey(d => d.RoleId)
            .HasConstraintName("applicationuserrole_fk_1");

        builder.HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("applicationuserrole_fk");

    }
}
