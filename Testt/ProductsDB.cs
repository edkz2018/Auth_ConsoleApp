using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testt
{
    class ProductsDB : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HNJMF5C\SQLEXPRESS;Database=Test;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(new Products
            {
                ProductId = 1,
                ProductName = "iPhone 8",
                ProductPrice = 210000
            },
            new Products
            {
                ProductId = 2,
                ProductName = "iPhone 11",
                ProductPrice = 330000
            },
            new Products
            {
                ProductId = 3,
                ProductName = "iPhone 12",
                ProductPrice = 440000
            },
            new Products
            {
                ProductId = 4,
                ProductName = "iPhone 11",
                ProductPrice = 520000
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}
