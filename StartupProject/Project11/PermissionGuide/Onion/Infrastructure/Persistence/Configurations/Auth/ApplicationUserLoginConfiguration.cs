using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Auth;


public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin> {
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder) {
        builder.ToTable("ApplicationUserLogin");

        builder.Property(e => e.Id).HasColumnName("id");


        builder.Property(e => e.LoginProvider).HasColumnName("login_provider");


        builder.Property(e => e.ProviderKey).HasColumnName("provider_key");


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
            .WithMany(p => p.ApplicationUserLogins)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("applicationuserlogin_fk");
            
        builder.Property(e => e.IsPersistent).HasColumnName("is_persistent");
    }
}
