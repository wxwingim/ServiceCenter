using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class work100022Context : DbContext
    {
        public work100022Context()
        {
        }

        public work100022Context(DbContextOptions<work100022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Consumption> Consumptions { get; set; } = null!;
        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;
        public virtual DbSet<Employe> Employes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderRequest> OrderRequests { get; set; } = null!;
        public virtual DbSet<PartType> PartTypes { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<StatusesRepair> StatusesRepairs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Visit> Visits { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=45.10.244.15;Port=55532;Database=work100022;Username=work100022;Password=Zf#t*#o~~dSchp9nRj4R;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumption>(entity =>
            {
                entity.ToTable("consumptions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdPurchase).HasColumnName("id_purchase");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Consumptions)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_order");

                entity.HasOne(d => d.IdPurchaseNavigation)
                    .WithMany(p => p.Consumptions)
                    .HasForeignKey(d => d.IdPurchase)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_purchase");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("device_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameType)
                    .HasMaxLength(30)
                    .HasColumnName("name_type");
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("employes");

                entity.HasIndex(e => e.Id, "employes_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .HasColumnName("position");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employe)
                    .HasForeignKey<Employe>(d => d.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.Id, "orders_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_status");
            });

            modelBuilder.Entity<OrderRequest>(entity =>
            {
                entity.ToTable("order_requests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addres).HasColumnName("addres");

                entity.Property(e => e.DateLimit).HasColumnName("date_limit");

                entity.Property(e => e.DateRequest)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_request")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Defect).HasColumnName("defect");

                entity.Property(e => e.Equipment).HasColumnName("equipment");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdDeviceType).HasColumnName("id_device_type");

                entity.Property(e => e.MachanicalDamage).HasColumnName("machanical_damage");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Quarantee).HasColumnName("quarantee");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.OrderRequests)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_customer");

                entity.HasOne(d => d.IdDeviceTypeNavigation)
                    .WithMany(p => p.OrderRequests)
                    .HasForeignKey(d => d.IdDeviceType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_device_type");
            });

            modelBuilder.Entity<PartType>(entity =>
            {
                entity.ToTable("part_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameType)
                    .HasMaxLength(30)
                    .HasColumnName("name_type");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchases");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DatePurchase)
                    .HasColumnName("date_purchase")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdPartType).HasColumnName("id_part_type");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PurchasePrice)
                    .HasPrecision(12, 2)
                    .HasColumnName("purchase_price");

                entity.Property(e => e.Quarantee).HasColumnName("quarantee");

                entity.Property(e => e.RetailPrice)
                    .HasPrecision(12, 2)
                    .HasColumnName("retail_price");

                entity.HasOne(d => d.IdPartTypeNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.IdPartType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_part_type");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDeviceType).HasColumnName("id_device_type");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasPrecision(12, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Quarantee).HasColumnName("quarantee");

                entity.HasOne(d => d.IdDeviceTypeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdDeviceType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_device_type");
            });

            modelBuilder.Entity<StatusesRepair>(entity =>
            {
                entity.ToTable("statuses_repair");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameStatus)
                    .HasMaxLength(30)
                    .HasColumnName("name_status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Password, "users_password_key")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "users_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(250)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visits");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateVisit).HasColumnName("date_visit");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.TimeVisit).HasColumnName("time_visit");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_order");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("works");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_employee");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_order");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_service");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
