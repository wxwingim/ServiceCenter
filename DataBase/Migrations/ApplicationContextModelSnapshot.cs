// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataBase.AdmissionForRepair", b =>
                {
                    b.Property<int>("num_admission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date_admission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_limit")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCustDev")
                        .HasColumnType("int");

                    b.Property<bool>("quarantee")
                        .HasColumnType("bit");

                    b.HasKey("num_admission");

                    b.HasIndex("idCustDev");

                    b.ToTable("Admission_For_Repairs");
                });

            modelBuilder.Entity("DataBase.Consumption", b =>
                {
                    b.Property<int>("IdConsumption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("idSpare")
                        .HasColumnType("int");

                    b.Property<int>("numOrder")
                        .HasColumnType("int");

                    b.HasKey("IdConsumption");

                    b.HasIndex("idSpare");

                    b.HasIndex("numOrder");

                    b.ToTable("Cunsumptions");
                });

            modelBuilder.Entity("DataBase.Customer", b =>
                {
                    b.Property<int>("idCustom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("firstCustom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("lastCustom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("mailCustom")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("middleCustom")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("telCustom")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("idCustom");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataBase.CustomerDevice", b =>
                {
                    b.Property<int>("idCustDev")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("defect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCustom")
                        .HasColumnType("int");

                    b.Property<string>("mechanicalDamage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.HasKey("idCustDev");

                    b.HasIndex("idCustom");

                    b.HasIndex("typeId");

                    b.ToTable("Customer_Devices");
                });

            modelBuilder.Entity("DataBase.DeviceType", b =>
                {
                    b.Property<int>("typeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nameType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("typeId");

                    b.ToTable("Device_types");
                });

            modelBuilder.Entity("DataBase.Employee", b =>
                {
                    b.Property<int>("idWork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("firstWork")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("lastWork")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("mailWork")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("middleWork")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("phoneWork")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idWork");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataBase.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("datePurchase")
                        .HasColumnType("datetime2");

                    b.Property<int>("idSpare")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("idSpare");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("DataBase.Service", b =>
                {
                    b.Property<int>("keyService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("guarantee")
                        .HasColumnType("int");

                    b.Property<string>("nameService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priceService")
                        .HasColumnType("int");

                    b.HasKey("keyService");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DataBase.SparePart", b =>
                {
                    b.Property<int>("idSpare")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTypeSP")
                        .HasColumnType("int");

                    b.Property<string>("nameSpare")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("priceSpare")
                        .HasColumnType("int");

                    b.HasKey("idSpare");

                    b.HasIndex("IdTypeSP");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("DataBase.StatusRepair", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("StatusRepairs");
                });

            modelBuilder.Entity("DataBase.TypeSparePart", b =>
                {
                    b.Property<int>("IdTypeSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTypeSP");

                    b.ToTable("TypeSpareParts");
                });

            modelBuilder.Entity("DataBase.WorkOrder", b =>
                {
                    b.Property<int>("numOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<int>("num_admission")
                        .HasColumnType("int");

                    b.Property<bool>("statusDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("statusPaymnt")
                        .HasColumnType("bit");

                    b.HasKey("numOrder");

                    b.HasIndex("StatusId");

                    b.HasIndex("num_admission");

                    b.ToTable("Work_Orders");
                });

            modelBuilder.Entity("DataBase.WorkRepair", b =>
                {
                    b.Property<int>("numWork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("dateReady")
                        .HasColumnType("datetime2");

                    b.Property<int>("idWork")
                        .HasColumnType("int");

                    b.Property<int>("keyService")
                        .HasColumnType("int");

                    b.Property<int>("numOrder")
                        .HasColumnType("int");

                    b.HasKey("numWork");

                    b.HasIndex("idWork");

                    b.HasIndex("keyService");

                    b.HasIndex("numOrder");

                    b.ToTable("Work_Repairs");
                });

            modelBuilder.Entity("DataBase.AdmissionForRepair", b =>
                {
                    b.HasOne("DataBase.CustomerDevice", "customerDevice")
                        .WithMany("admissionForRepairs")
                        .HasForeignKey("idCustDev")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customerDevice");
                });

            modelBuilder.Entity("DataBase.Consumption", b =>
                {
                    b.HasOne("DataBase.SparePart", "sparePart")
                        .WithMany("consumptions")
                        .HasForeignKey("idSpare")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.WorkOrder", "workOrder")
                        .WithMany("consumptions")
                        .HasForeignKey("numOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sparePart");

                    b.Navigation("workOrder");
                });

            modelBuilder.Entity("DataBase.CustomerDevice", b =>
                {
                    b.HasOne("DataBase.Customer", "customer")
                        .WithMany("devices")
                        .HasForeignKey("idCustom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.DeviceType", "type")
                        .WithMany("customer_Devices")
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("type");
                });

            modelBuilder.Entity("DataBase.Purchase", b =>
                {
                    b.HasOne("DataBase.SparePart", "sparePart")
                        .WithMany("purchases")
                        .HasForeignKey("idSpare")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sparePart");
                });

            modelBuilder.Entity("DataBase.SparePart", b =>
                {
                    b.HasOne("DataBase.TypeSparePart", "typeSparePart")
                        .WithMany("spareParts")
                        .HasForeignKey("IdTypeSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typeSparePart");
                });

            modelBuilder.Entity("DataBase.WorkOrder", b =>
                {
                    b.HasOne("DataBase.StatusRepair", "statusRepair")
                        .WithMany("workOrders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.AdmissionForRepair", "AdmissionForRepair")
                        .WithMany("work_Order")
                        .HasForeignKey("num_admission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdmissionForRepair");

                    b.Navigation("statusRepair");
                });

            modelBuilder.Entity("DataBase.WorkRepair", b =>
                {
                    b.HasOne("DataBase.Employee", "employee")
                        .WithMany("workRepairs")
                        .HasForeignKey("idWork")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Service", "service")
                        .WithMany("workRepairs")
                        .HasForeignKey("keyService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.WorkOrder", "workOrder")
                        .WithMany("workRepairs")
                        .HasForeignKey("numOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("service");

                    b.Navigation("workOrder");
                });

            modelBuilder.Entity("DataBase.AdmissionForRepair", b =>
                {
                    b.Navigation("work_Order");
                });

            modelBuilder.Entity("DataBase.Customer", b =>
                {
                    b.Navigation("devices");
                });

            modelBuilder.Entity("DataBase.CustomerDevice", b =>
                {
                    b.Navigation("admissionForRepairs");
                });

            modelBuilder.Entity("DataBase.DeviceType", b =>
                {
                    b.Navigation("customer_Devices");
                });

            modelBuilder.Entity("DataBase.Employee", b =>
                {
                    b.Navigation("workRepairs");
                });

            modelBuilder.Entity("DataBase.Service", b =>
                {
                    b.Navigation("workRepairs");
                });

            modelBuilder.Entity("DataBase.SparePart", b =>
                {
                    b.Navigation("consumptions");

                    b.Navigation("purchases");
                });

            modelBuilder.Entity("DataBase.StatusRepair", b =>
                {
                    b.Navigation("workOrders");
                });

            modelBuilder.Entity("DataBase.TypeSparePart", b =>
                {
                    b.Navigation("spareParts");
                });

            modelBuilder.Entity("DataBase.WorkOrder", b =>
                {
                    b.Navigation("consumptions");

                    b.Navigation("workRepairs");
                });
#pragma warning restore 612, 618
        }
    }
}
