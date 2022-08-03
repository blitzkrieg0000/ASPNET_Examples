
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entities.Concrete;

namespace DataAccess.Configurations {
    public class CourtPointAreaConfiguration : IEntityTypeConfiguration<CourtPointArea> {

        public void Configure(EntityTypeBuilder<CourtPointArea> builder) {

            builder.ToTable("CourtPointArea");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.AreaArray).HasColumnName("area_array");

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