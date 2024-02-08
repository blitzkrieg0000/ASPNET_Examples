using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.Entity.Concrete.Employee;

namespace UI.Contexts.Configuration;


public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType> {
    public void Configure(EntityTypeBuilder<EmployeeType> builder) {

        builder.ToTable("employee_type");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnName("id")
        .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
        .HasColumnName("name")
        .IsRequired();

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

        builder.Property(e => e.Active)
            .IsRequired()
            .HasColumnName("active")
            .HasDefaultValueSql("true");

        builder.Property(e => e.IsPersistent)
        .HasColumnName("is_persistent");
    }
}
