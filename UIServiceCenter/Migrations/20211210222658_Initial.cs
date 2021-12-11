using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UIServiceCenter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akt_Deliveries",
                columns: table => new
                {
                    numDeliveri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateDelivery = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akt_Deliveries", x => x.numDeliveri);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    idCustom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastCustom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    firstCustom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    middleCustom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    mailCustom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telCustom = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.idCustom);
                });

            migrationBuilder.CreateTable(
                name: "Device_types",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_types", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    idWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastWork = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    firstWork = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    middleWork = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    mailWork = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phoneWork = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.idWork);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    keyService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priceService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.keyService);
                });

            migrationBuilder.CreateTable(
                name: "Device_models",
                columns: table => new
                {
                    keyModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    typeId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_models", x => x.keyModel);
                    table.ForeignKey(
                        name: "FK_Device_models_Device_types_typeId1",
                        column: x => x.typeId1,
                        principalTable: "Device_types",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Devices",
                columns: table => new
                {
                    idCustDev = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    defect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mechanicalDamage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCustom1 = table.Column<int>(type: "int", nullable: false),
                    keyModel1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Devices", x => x.idCustDev);
                    table.ForeignKey(
                        name: "FK_Customer_Devices_Customers_idCustom1",
                        column: x => x.idCustom1,
                        principalTable: "Customers",
                        principalColumn: "idCustom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Devices_Device_models_keyModel1",
                        column: x => x.keyModel1,
                        principalTable: "Device_models",
                        principalColumn: "keyModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admission_For_Repairs",
                columns: table => new
                {
                    num_admission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_limit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quarantee = table.Column<bool>(type: "bit", nullable: false),
                    date_admission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name_org = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    inn_org = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    addres_org = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel_org = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    mail_org = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_cust_devidCustDev = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission_For_Repairs", x => x.num_admission);
                    table.ForeignKey(
                        name: "FK_Admission_For_Repairs_Customer_Devices_id_cust_devidCustDev",
                        column: x => x.id_cust_devidCustDev,
                        principalTable: "Customer_Devices",
                        principalColumn: "idCustDev",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Orders",
                columns: table => new
                {
                    numOrder = table.Column<int>(type: "int", nullable: false),
                    numAdmission = table.Column<int>(type: "int", nullable: false),
                    durationQuarantee = table.Column<int>(type: "int", nullable: false),
                    statusRepair = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    statusPaymnt = table.Column<bool>(type: "bit", nullable: false),
                    statusDelivery = table.Column<bool>(type: "bit", nullable: false),
                    AdmissionForRepairnum_admission = table.Column<int>(type: "int", nullable: false),
                    numDeliverynumDeliveri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Orders", x => new { x.numOrder, x.numAdmission });
                    table.ForeignKey(
                        name: "FK_Work_Orders_Admission_For_Repairs_AdmissionForRepairnum_admission",
                        column: x => x.AdmissionForRepairnum_admission,
                        principalTable: "Admission_For_Repairs",
                        principalColumn: "num_admission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Orders_Akt_Deliveries_numDeliverynumDeliveri",
                        column: x => x.numDeliverynumDeliveri,
                        principalTable: "Akt_Deliveries",
                        principalColumn: "numDeliveri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Repairs",
                columns: table => new
                {
                    numWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateReady = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numOrder1 = table.Column<int>(type: "int", nullable: false),
                    numOrdernumAdmission = table.Column<int>(type: "int", nullable: false),
                    keyService1 = table.Column<int>(type: "int", nullable: false),
                    idWork1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Repairs", x => x.numWork);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Employees_idWork1",
                        column: x => x.idWork1,
                        principalTable: "Employees",
                        principalColumn: "idWork",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Services_keyService1",
                        column: x => x.keyService1,
                        principalTable: "Services",
                        principalColumn: "keyService",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Work_Orders_numOrder1_numOrdernumAdmission",
                        columns: x => new { x.numOrder1, x.numOrdernumAdmission },
                        principalTable: "Work_Orders",
                        principalColumns: new[] { "numOrder", "numAdmission" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admission_For_Repairs_id_cust_devidCustDev",
                table: "Admission_For_Repairs",
                column: "id_cust_devidCustDev");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_idCustom1",
                table: "Customer_Devices",
                column: "idCustom1");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_keyModel1",
                table: "Customer_Devices",
                column: "keyModel1");

            migrationBuilder.CreateIndex(
                name: "IX_Device_models_typeId1",
                table: "Device_models",
                column: "typeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_AdmissionForRepairnum_admission",
                table: "Work_Orders",
                column: "AdmissionForRepairnum_admission");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_numDeliverynumDeliveri",
                table: "Work_Orders",
                column: "numDeliverynumDeliveri");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_idWork1",
                table: "Work_Repairs",
                column: "idWork1");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_keyService1",
                table: "Work_Repairs",
                column: "keyService1");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_numOrder1_numOrdernumAdmission",
                table: "Work_Repairs",
                columns: new[] { "numOrder1", "numOrdernumAdmission" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Work_Repairs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Work_Orders");

            migrationBuilder.DropTable(
                name: "Admission_For_Repairs");

            migrationBuilder.DropTable(
                name: "Akt_Deliveries");

            migrationBuilder.DropTable(
                name: "Customer_Devices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Device_models");

            migrationBuilder.DropTable(
                name: "Device_types");
        }
    }
}
