using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WorkRepair> Work_Repairs { get; set; }
        public DbSet<WorkOrder> Work_Orders { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<StatusRepair> StatusRepairs { get; set; }
        public DbSet<Consumption> Cunsumptions { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<TypeSparePart> TypeSpareParts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeviceType> Device_types { get; set; }
        public DbSet<CustomerDevice> Customer_Devices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AdmissionForRepair> Admission_For_Repairs { get; set; }

        public ApplicationContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6LCNOOJ\\MSSQL;Database=servicecenter;Trusted_Connection=True;");

            // mac
            //optionsBuilder.UseSqlServer("Server=KOMP-\\;Database=servicecenter;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Work_order>().HasKey(c => new { c.numOrder, c.num_admission });

        //    modelBuilder.Entity<ListEntry>().HasKey(c => new { c.numRow, c.numPurchase });

        //    modelBuilder.Entity<SalesInvoice>().HasKey(c => new { c.numSales, c.numWork });

        //    //modelBuilder.Entity<Work_repair>().HasKey(c => new { c.numOrder, c.numWork });
        //}

    }
}
