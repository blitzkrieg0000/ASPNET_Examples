using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entities.Concrete;

namespace DataAccess.Configurations {
    public class GenderConfiguration : IEntityTypeConfiguration<Gender> {
        public void Configure(EntityTypeBuilder<Gender> builder) {
            builder.ToTable("Gender");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        }
    }
}