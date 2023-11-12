﻿// <auto-generated />
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(Lab3DbContext))]
    partial class Lab3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Banh"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Keo"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Trai Cay"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Do Uong"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Do An"
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Do Khac"
                        });
                });

            modelBuilder.Entity("BusinessObject.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductName = "Banh Mi",
                            UnitPrice = 3620m,
                            UnitsInStock = 90
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ProductName = "Banh Quy",
                            UnitPrice = 6081m,
                            UnitsInStock = 8
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ProductName = "Banh Trang",
                            UnitPrice = 3205m,
                            UnitsInStock = 98
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ProductName = "Keo",
                            UnitPrice = 5140m,
                            UnitsInStock = 83
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            ProductName = "Keo Mut",
                            UnitPrice = 8105m,
                            UnitsInStock = 41
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            ProductName = "Trai Cay",
                            UnitPrice = 6419m,
                            UnitsInStock = 28
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            ProductName = "Trai Cay Say",
                            UnitPrice = 7678m,
                            UnitsInStock = 44
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            ProductName = "Trai Cay Tuoi",
                            UnitPrice = 1309m,
                            UnitsInStock = 44
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            ProductName = "Nuoc Ngot",
                            UnitPrice = 1804m,
                            UnitsInStock = 25
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            ProductName = "Nuoc Ngot Co Gas",
                            UnitPrice = 2442m,
                            UnitsInStock = 14
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            ProductName = "Nuoc Ngot Khong Gas",
                            UnitPrice = 3447m,
                            UnitsInStock = 36
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 5,
                            ProductName = "Do An Vat",
                            UnitPrice = 7818m,
                            UnitsInStock = 37
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 5,
                            ProductName = "Do An Nhanh",
                            UnitPrice = 5371m,
                            UnitsInStock = 47
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 6,
                            ProductName = "Pin",
                            UnitPrice = 333m,
                            UnitsInStock = 72
                        });
                });

            modelBuilder.Entity("BusinessObject.Product", b =>
                {
                    b.HasOne("BusinessObject.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObject.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
