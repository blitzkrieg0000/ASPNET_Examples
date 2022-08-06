
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entities.Concrete;

namespace DataAccess.Configurations {
    public class PlayerConfiguration : IEntityTypeConfiguration<Player> {

        public void Configure(EntityTypeBuilder<Player> builder) {

            builder.ToTable("Player");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Birthday).HasColumnName("birthday");

            builder.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }
}