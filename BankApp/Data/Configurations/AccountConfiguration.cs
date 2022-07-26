using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations {
    public class AccountConfiguration : IEntityTypeConfiguration<Account> {

        public void Configure(EntityTypeBuilder<Account> builder) {

            builder.Property(x => x.AccountNumber).IsRequired(true);
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Balance).IsRequired();
        
        }

    }
}