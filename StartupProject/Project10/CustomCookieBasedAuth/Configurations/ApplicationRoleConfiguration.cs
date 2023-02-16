using CustomCookieBasedAuth.Data.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomCookieBasedAuth.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole> {
    public void Configure(EntityTypeBuilder<ApplicationRole> builder) {

        builder.HasData(new ApplicationRole(){
            Id = 1,
            Name = "SuperUser"
        });

        builder.ToTable("ApplicationRole");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.Name).HasColumnName("name");


    }
}
