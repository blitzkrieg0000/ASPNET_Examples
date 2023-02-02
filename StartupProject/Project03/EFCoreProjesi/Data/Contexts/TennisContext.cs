using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Configurations;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Contexts {
    public class TennisContext : DbContext {

        //Entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        public DbSet<Person> People { get; set; }

        //Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=localhost; user=sa; database=TennisEfCore; password=DGH2022.");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        //FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            //! Configurations
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(configuration: new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(configuration: new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleHistoryConfiguration());

            //! Employee
            //TPH -> TPT Employees.cs den kalıtılan her bir tabloyu ayrı ayrı ele alır.
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");

            base.OnModelCreating(modelBuilder);
        }
    }
}