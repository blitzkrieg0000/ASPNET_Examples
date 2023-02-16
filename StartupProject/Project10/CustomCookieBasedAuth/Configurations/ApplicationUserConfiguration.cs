using CustomCookieBasedAuth.Data.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBasedAuth.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder) {

        builder.HasData(new ApplicationUser{
            Id = 1,
            Name = "root",
            Password = "root2023."
        });

        builder.ToTable("ApplicationUser");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.Name).HasColumnName("name");

        builder.Property(e => e.Password).HasColumnName("password");

    }
}
