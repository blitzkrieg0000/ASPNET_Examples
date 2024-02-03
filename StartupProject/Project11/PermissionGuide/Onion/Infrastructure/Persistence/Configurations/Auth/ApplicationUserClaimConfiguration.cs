using Application.Consts;
using Application.Consts.Auth;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim> {
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder) {
        builder.HasData(new ApplicationUserClaim() {
            Id = Guid.NewGuid(),
            UserId = RoleDefaults.SuperUser.Id,
            ClaimType = UserDefaults.ClaimsTypes.ProfilePhoto,
            ClaimValue = ImageDefaults.UserProfilePhoto,
            IsPersistent = true,
            Active = true
        }, new ApplicationUserClaim() {
            Id = Guid.NewGuid(),
            UserId = RoleDefaults.Admin.Id,
            ClaimType = UserDefaults.ClaimsTypes.ProfilePhoto,
            ClaimValue = ImageDefaults.UserProfilePhoto,
            IsPersistent = true,
            Active = true
        });

        builder.ToTable("ApplicationUserClaim");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.ClaimType).HasColumnName("claim_type");

        builder.Property(e => e.ClaimValue).HasColumnName("claim_value");

        builder.Property(e => e.UserId).HasColumnName("user_id");

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

        builder.HasOne(d => d.User)
            .WithMany(p => p.ApplicationUserClaims)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("applicationuserclaim_fk");

        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");

    }
}
