using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace verstatest.Models
{
    public class verstatestContext : DbContext
    {
        public verstatestContext ()            
        {            
            //система ролей и удаление записей из бд не предусмотрены в задании            
            //почистить базу можно только сторонним приложением для работы с бд или удалив её
            //TestLaunch добавит две записи 

            //Database.EnsureDeleted();
            Database.EnsureCreated(); 
            //TestLaunch();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //файл БД будет там же,куда собран проект
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;AttachDbFilename=" + Environment.CurrentDirectory + "\\verstatest.mdf;Database=verstatestDb;Trusted_Connection=True;");
        }
        public void TestLaunch() //добавлет пару записей в бд для тестов
        {
            //using (var context = new verstatestContext())
            {
                Address a1 = new() { City = "city1", Region = "region1", Details = "street1, house1, apartment1" };
                Address a2 = new() { City = "city2", Region = "region2", Details = "street2, house2, apartment2" };
                Address a3 = new() { City = "city3", Region = "region3", Details = "street3, house3, apartment3" };
                Address a4 = new() { City = "city4", Region = "region4", Details = "street4, house4, apartment4" };                           
                Order o1 = new() { Customer = "Name1", CargoWeight = 1, DeliveryAddress = a1, SendersAddress = a2, PickupDate = DateTime.Today.AddDays(1) };
                Order o2 = new() { Customer = "Name2", CargoWeight = 2, DeliveryAddress = a3, SendersAddress = a4, PickupDate = DateTime.Today.AddDays(2) };
                Orders.AddRange(o1, o2);
                SaveChanges();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Order>()
            //    .OwnsOne(o => o.SendersAddress);
            //modelBuilder.Entity<Order>()
            //    .OwnsOne(o => o.DeliveryAddress);

        }        
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Address> Addresses { get; set; }
    }
}
