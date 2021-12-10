using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBServiceCenter
{
    public class ApplicationContext: DbContext
    {
        // classes
        public DbSet<Work_repair> Work_Repairs { get; set; }
        public DbSet<Work_order> Work_Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Device_type> Device_types { get; set; }
        public DbSet<Device_model> Device_models { get; set; }
        public DbSet<Customer_device> Customer_Devices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Akt_delivery> Akt_Deliveries { get; set; }
        public DbSet<Admission_for_repair> Admission_For_Repairs { get; set; }


        public ApplicationContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6LCNOOJ\\MSSQL;Database=servicecenter;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasCheckConstraint("tel_custom", "tel_custom LIKE '8%'");

            modelBuilder.Entity<Admission_for_repair>().HasCheckConstraint("date_admission", "date_admission <= date_limit");
            modelBuilder.Entity<Admission_for_repair>().HasCheckConstraint("tel_org", "tel_org LIKE '8%'");

            modelBuilder.Entity<Work_order>().HasCheckConstraint("status_repair", "status_repair IN ('Accepted', 'In progress', 'Awaiting a spare part', 'Ready', 'Issued by')");
            modelBuilder.Entity<Work_order>().HasCheckConstraint("status_payment", "(status_payment = FALSE AND status_delivery = FALSE) OR (status_repair = 'Issued by' AND status_payment = TRUE AND status_delivery = TRUE)");
            
            modelBuilder.Entity<Employee>().HasCheckConstraint("tel_work", "tel_org LIKE '8%'");

            modelBuilder.Entity<Service>().HasCheckConstraint("price_service", "price_service >= 0");

        }
    }
}
