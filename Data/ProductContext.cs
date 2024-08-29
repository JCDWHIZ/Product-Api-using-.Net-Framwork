using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data;

public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
    public DbSet<Product> Product => Set<Product>();

    public DbSet<Category> Category => Set<Category>();



    // seed database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new {Id = 1, Name = "Electronics"},
            new {Id = 2, Name = "Clothes"},
            new {Id = 3, Name = "KitchenWare"},
            new {Id = 4, Name = "Accessories"}
        );
    }

}
