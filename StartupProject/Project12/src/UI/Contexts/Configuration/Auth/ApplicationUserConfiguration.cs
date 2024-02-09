using Application.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Const.Auth;
using UI.Entities.Auth;
using UI.Entity.Concrete.Employee;

namespace UI.Contexts.Configuration.Auth;


public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
        builder.HasData(new ApplicationUser {
            Id = RoleDefaults.SuperUser.Id,
            Username = UserDefaults.Users.SuperUser.Username,
            Password = UserDefaults.Users.SuperUser.Password,
            Email = UserDefaults.Users.SuperUser.Email,
            IsPersistent = true,
            Active = true
        },
        new ApplicationUser {
            Id = RoleDefaults.Admin.Id,
            Username = UserDefaults.Users.Admin.Username,
            Password = UserDefaults.Users.Admin.Password,
            IsPersistent = true,
            Active = true
        });

        builder.ToTable("ApplicationUser");

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

        builder.Property(e => e.Email).HasColumnName("email");

        builder.Property(e => e.ModifiedTime)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("modified_time");

        builder.Property(e => e.Username).HasColumnName("user_name");

        builder.Property(e => e.Password).HasColumnName("password");

        builder.Property(e => e.PhoneNumber).HasColumnName("phone_number");

        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");

        builder.HasOne(e=>e.Employee)
        .WithOne(p=>p.ApplicationUser)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasForeignKey<Employee>(d=>d.Id);

    }
}
