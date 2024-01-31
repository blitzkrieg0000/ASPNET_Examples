using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Configurations {
    public class CommentConfiguration : IEntityTypeConfiguration<Comment> {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder) {

            builder.Property(x => x.Content).HasMaxLength(300);
            builder.Property(x => x.Content).IsRequired();


        }
    }
}