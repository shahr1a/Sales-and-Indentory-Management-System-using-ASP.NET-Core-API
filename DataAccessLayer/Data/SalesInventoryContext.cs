using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class SalesInventoryContext : DbContext
    {
        public SalesInventoryContext()
        {

        }
        public SalesInventoryContext(DbContextOptions<SalesInventoryContext> options):base(options)
        {

        }

        public  DbSet<Category> Categories { get; set; } = null!;
        public  DbSet<Dealer> Dealers { get; set; } = null!;
        public  DbSet<DealerType> DealerTypes { get; set; } = null!;
        public  DbSet<Inventory> Inventories { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=OPTIMUS\\SALESINVENTORY;Database=SalesAndInventory;Trusted_Connection=True;");
            }
        }
    }
}
