using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data {
    public class ProductContext : DbContext {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]{
            new(){
                Id=1,
                Name="Bilgisayar",
                CreatedDate=DateTime.Now.AddDays(-3),
                Price=15000,
                Stock=300
            },
                new(){
                Id=2,
                Name="Telefon",
                CreatedDate=DateTime.Now.AddDays(-30),
                Price=10000,
                Stock=500
            },
                new(){
                Id=3,
                Name="Klavye",
                CreatedDate=DateTime.Now.AddDays(-60),
                Price=100,
                Stock=1000
            }
           });

            base.OnModelCreating(modelBuilder);
        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) {
        }

    }
}