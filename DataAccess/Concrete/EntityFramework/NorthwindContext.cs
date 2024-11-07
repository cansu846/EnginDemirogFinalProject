using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context: db taabloları ile entities teki classları baglar
    public class NorthwindContext : DbContext
    {
        //Hangi database ile baglanacagını belirtir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //@: derleyicinin stringte "/" işaretini normal olarak algılamasını saglar
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=master; Trusted_Connection=true");
        }

        //Tablo isimleri
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
