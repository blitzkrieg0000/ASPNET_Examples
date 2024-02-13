﻿// <auto-generated />
using System;
using EFCoreProjesi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreProjesi.Migrations
{
    [DbContext(typeof(TennisContext))]
    [Migration("20220724153546_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("category_name");

                    b.HasKey("Id");

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number", "Name");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("product_name");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)")
                        .HasColumnName("product_price");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.SaleHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleHistories");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.FullTimeEmployee", b =>
                {
                    b.HasBaseType("EFCoreProjesi.Data.Entities.Employee");

                    b.Property<decimal>("HourlyWage")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("FullTimeEmployee");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.PartTimeEmployee", b =>
                {
                    b.HasBaseType("EFCoreProjesi.Data.Entities.Employee");

                    b.Property<decimal>("DailyWage")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("PartTimeEmployee");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.ProductCategory", b =>
                {
                    b.HasOne("EFCoreProjesi.Data.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreProjesi.Data.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.ProductDetail", b =>
                {
                    b.HasOne("EFCoreProjesi.Data.Entities.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("EFCoreProjesi.Data.Entities.ProductDetail", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.SaleHistory", b =>
                {
                    b.HasOne("EFCoreProjesi.Data.Entities.Product", "Product")
                        .WithMany("SaleHistories")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.FullTimeEmployee", b =>
                {
                    b.HasOne("EFCoreProjesi.Data.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("EFCoreProjesi.Data.Entities.FullTimeEmployee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.PartTimeEmployee", b =>
                {
                    b.HasOne("EFCoreProjesi.Data.Entities.Employee", null)
                        .WithOne()
                        .HasForeignKey("EFCoreProjesi.Data.Entities.PartTimeEmployee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("EFCoreProjesi.Data.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductDetail");

                    b.Navigation("SaleHistories");
                });
#pragma warning restore 612, 618
        }
    }
}