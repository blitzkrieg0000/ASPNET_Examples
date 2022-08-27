using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations {
    public class ProcessParameterConfiguration : IEntityTypeConfiguration<ProcessParameter> {
        public void Configure(EntityTypeBuilder<ProcessParameter> builder) {

            builder.Property(e => e.Id)
                                .ValueGeneratedNever()
                                .HasColumnName("id");

            builder.Property(e => e.Limit).HasColumnName("limit");

            builder.Property(e => e.StreamId).HasColumnName("stream_id");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.ProcessParameter)
                .HasForeignKey<ProcessParameter>(d => d.Id)
                .HasConstraintName("processparameters_fk");

            builder.HasOne(d => d.Stream)
                .WithMany(p => p.ProcessParameters)
                .HasForeignKey(d => d.StreamId)
                .HasConstraintName("processparameters_fk_1");
        }
    }
}