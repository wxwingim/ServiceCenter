using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Work_repair> Work_Repairs { get; set; }
        public DbSet<Work_order> Work_Orders { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ListEntry> ListEntries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Device_type> Device_types { get; set; }
        public DbSet<Device_model> Device_models { get; set; }
        public DbSet<Customer_device> Customer_Devices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Akt_delivery> Akt_Deliveries { get; set; }
        public DbSet<Admission_for_repair> Admission_For_Repairs { get; set; }

        public ApplicationContext(): base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6LCNOOJ\\MSSQL;Database=servicecenter;Trusted_Connection=True;");

            // mac
            //optionsBuilder.UseSqlServer("Server=KOMP-\\;Database=servicecenter;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Work_order>().HasKey(c => new { c.numOrder, c.num_admission });

            modelBuilder.Entity<ListEntry>().HasKey(c => new { c.numRow, c.numPurchase });

            modelBuilder.Entity<SalesInvoice>().HasKey(c => new { c.numSales, c.numWork });

            //modelBuilder.Entity<Work_repair>().HasKey(c => new { c.numOrder, c.numWork });
        }

    }
}
