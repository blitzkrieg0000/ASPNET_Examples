using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Contexts {
    public class TennisContext : DbContext {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        //Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=localhost; user=sa; database=TennisEfCore; password=DGH2022.");
        }

        //FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            //! Category
            modelBuilder.Entity<Category>().ToTable(name: "Categories", schema: "dbo");

            //! Customer
            //modelBuilder.Entity<Customer>().HasNoKey(); //PrimaryKey olmadan kaydetmek için
            modelBuilder.Entity<Customer>().HasKey(x => new { x.Number, x.Name }); //Çift PK için isimsiz obje notasyonu kullanılır.

            //! Product
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired(true);
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 3);
            //modelBuilder.Entity<Product>().Property(x => x.Name).HasDefaultValueSql("'Urun Bilgisi Girilmemiş'");
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique(true);

            //! Employee
            //TPH -> TPT Employees.cs den kalıtılan her bir tabloyu ayrı ayrı ele alır.
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");
            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");


            //!Relations
            //*One -> Many
            //byProduct (Principal)
            // modelBuilder.Entity<Product>()
            // .HasMany(x => x.SaleHistories)
            // .WithOne(x => x.Product)
            // .HasForeignKey(x => x.ProductId);

            //bySaleHistory (Dependent)
            modelBuilder.Entity<SaleHistory>()
            .HasOne(x => x.Product)
            .WithMany(x => x.SaleHistories)
            .HasForeignKey(x => x.ProductId);


            //* One -> One
            //byProduct (Principal)
            modelBuilder.Entity<Product>()
            .HasOne(x => x.ProductDetail)
            .WithOne(x => x.Product)
            .HasForeignKey<ProductDetail>(x => x.ProductId);


            //* Many -> Many (2x (One -> Many) Relationship Table)
            modelBuilder.Entity<ProductCategory>()
            .HasKey(x => new { x.ProductId, x.CategoryId });

            modelBuilder.Entity<Product>()
            .HasMany(x => x.ProductCategories)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Category>()
            .HasMany(x => x.ProductCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);



            base.OnModelCreating(modelBuilder);
        }

    }
}