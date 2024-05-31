using AssetTracking.Assets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Data
{
    public class AssetContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<MobilePhone> MobilePhones { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AssetTrackingDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Laptop>().HasData(
                new Laptop { Id = 1, Brand = "MacBook", ModelName = "Pro 16", PurchaseDate = new DateTime(2021, 1, 1), Price = 2500 },
                new Laptop { Id = 2, Brand = "Asus", ModelName = "ZenBook", PurchaseDate = new DateTime(2022, 6, 15), Price = 1500 },
                new Laptop { Id = 3, Brand = "Lenovo", ModelName = "ThinkPad X1", PurchaseDate = new DateTime(2023, 3, 10), Price = 1800 }
            );

            modelBuilder.Entity<MobilePhone>().HasData(
                new MobilePhone { Id = 1, Brand = "iPhone", ModelName = "13 Pro", PurchaseDate = new DateTime(2021, 9, 20), Price = 1200 },
                new MobilePhone { Id = 2, Brand = "Samsung", ModelName = "Galaxy S21", PurchaseDate = new DateTime(2022, 1, 5), Price = 1000 },
                new MobilePhone { Id = 3, Brand = "Nokia", ModelName = "3310", PurchaseDate = new DateTime(2023, 5, 25), Price = 50 }
            );
        }
    }
}
