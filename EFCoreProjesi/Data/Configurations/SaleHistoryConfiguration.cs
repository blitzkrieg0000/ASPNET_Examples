using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreProjesi.Data.Configurations {
    public class SaleHistoryConfiguration : IEntityTypeConfiguration<SaleHistory> {
        public void Configure(EntityTypeBuilder<SaleHistory> builder) {

            //*One -> Many
            //bySaleHistory (Dependent)
            builder
            .HasOne(x => x.Product)
            .WithMany(x => x.SaleHistories)
            .HasForeignKey(x => x.ProductId);

        }
    }
}