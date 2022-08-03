
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entities.Concrete;

namespace DataAccess.Configurations {
    public class AostypeConfiguration : IEntityTypeConfiguration<Aostype> {

        public void Configure(EntityTypeBuilder<Aostype> builder) {

            builder.ToTable("AOSType");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.CourtPointAreaId).HasColumnName("court_point_area_id");

            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(e => e.SaveDate)
                .HasColumnName("save_date")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(d => d.CourtPointArea)
                .WithMany(p => p.Aostypes)
                .HasForeignKey(d => d.CourtPointAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aostype_fk");
                
        }

    }
}