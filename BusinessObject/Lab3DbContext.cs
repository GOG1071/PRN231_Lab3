using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject;

public class Lab3DbContext : DbContext
{
    public Lab3DbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Lab3Db"));
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CategoryName = "Banh" },
            new Category { Id = 2, CategoryName = "Keo" },
            new Category { Id = 3, CategoryName = "Trai Cay" },
            new Category { Id = 4, CategoryName = "Do Uong" },
            new Category { Id = 5, CategoryName = "Do An" },
            new Category { Id = 6, CategoryName = "Do Khac" }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ProductName = "Banh Mi", CategoryId = 1, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 2, ProductName = "Banh Quy", CategoryId = 1, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 3, ProductName = "Banh Trang", CategoryId = 1, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 4, ProductName = "Keo", CategoryId = 2, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 5, ProductName = "Keo Mut", CategoryId = 2, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 6, ProductName = "Trai Cay", CategoryId = 3, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 7, ProductName = "Trai Cay Say", CategoryId = 3, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 8, ProductName = "Trai Cay Tuoi", CategoryId = 3, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 9, ProductName = "Nuoc Ngot", CategoryId = 4, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 10, ProductName = "Nuoc Ngot Co Gas", CategoryId = 4, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 11, ProductName = "Nuoc Ngot Khong Gas", CategoryId = 4, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 12, ProductName = "Do An Vat", CategoryId = 5, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 13, ProductName = "Do An Nhanh", CategoryId = 5, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) },
            new Product { Id = 14, ProductName = "Pin", CategoryId = 6, UnitsInStock = new Random().Next(100), UnitPrice = new Random().Next(10000) }
        );
    }
}