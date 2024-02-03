using Application.Consts;
using Application.Consts.Auth;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
        builder.HasData(new ApplicationUser {
            Id = RoleDefaults.SuperUser.Id,
            Username = UserDefaults.Users.SuperUser.Username,
            Name = UserDefaults.Users.SuperUser.Name,
            NormalizedName = UserDefaults.Users.SuperUser.Name.ToUpper(),
            Password = UserDefaults.Users.SuperUser.Password,
            TwoFactorEnabled = true,
            Email = UserDefaults.Users.SuperUser.Email,
            EmailApproved = true,
            PhoneNumberApproved = true,
            IsPersistent = true,
            Active = true
        },
        new ApplicationUser {
            Id = RoleDefaults.Admin.Id,
            Username = UserDefaults.Users.Admin.Username,
            Name = UserDefaults.Users.Admin.Name,
            NormalizedName = UserDefaults.Users.Admin.Name.ToUpper(),
            Password = UserDefaults.Users.Admin.Password,
            TwoFactorEnabled = true,
            EmailApproved = true,
            PhoneNumberApproved = true,
            IsPersistent = true,
            Active = true
        });

        builder.ToTable("ApplicationUser");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");

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

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.Email).HasColumnName("email");

        builder.Property(e => e.EmailApproved).HasColumnName("email_approved");

        builder.Property(e => e.Gender).HasColumnName("gender").HasDefaultValue("Unspecified");

        builder.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");

        builder.Property(e => e.LockoutEndDateUtc)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("lockout_end_date_utc");

        builder.Property(e => e.RefreshTokenEndDate)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("refresh_token_end_date");

        builder.Property(e => e.SecurityStampDate)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("security_stamp_date");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.Name).HasColumnName("name");

        builder.Property(e => e.Username).HasColumnName("user_name");

        builder.Property(e => e.NormalizedName).HasColumnName("normalized_name");

        builder.Property(e => e.Password).HasColumnName("password");

        builder.Property(e => e.PhoneNumber).HasColumnName("phone_number");

        builder.Property(e => e.PhoneNumberApproved).HasColumnName("phone_number_approved");

        builder.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");

        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");
    }
}
