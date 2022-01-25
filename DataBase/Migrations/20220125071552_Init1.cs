using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    mailWork = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
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
                    priceService = table.Column<int>(type: "int", nullable: false),
                    guarantee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.keyService);
                });

            migrationBuilder.CreateTable(
                name: "StatusRepairs",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRepairs", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TypeSpareParts",
                columns: table => new
                {
                    IdTypeSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSpareParts", x => x.IdTypeSP);
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
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCustom = table.Column<int>(type: "int", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Devices", x => x.idCustDev);
                    table.ForeignKey(
                        name: "FK_Customer_Devices_Customers_idCustom",
                        column: x => x.idCustom,
                        principalTable: "Customers",
                        principalColumn: "idCustom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Devices_Device_types_typeId",
                        column: x => x.typeId,
                        principalTable: "Device_types",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    idSpare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameSpare = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    priceSpare = table.Column<int>(type: "int", nullable: false),
                    IdTypeSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.idSpare);
                    table.ForeignKey(
                        name: "FK_SpareParts_TypeSpareParts_IdTypeSP",
                        column: x => x.IdTypeSP,
                        principalTable: "TypeSpareParts",
                        principalColumn: "IdTypeSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admission_For_Repairs",
                columns: table => new
                {
                    num_admission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_limit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    quarantee = table.Column<bool>(type: "bit", nullable: false),
                    date_admission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCustDev = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission_For_Repairs", x => x.num_admission);
                    table.ForeignKey(
                        name: "FK_Admission_For_Repairs_Customer_Devices_idCustDev",
                        column: x => x.idCustDev,
                        principalTable: "Customer_Devices",
                        principalColumn: "idCustDev",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    datePurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idSpare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_SpareParts_idSpare",
                        column: x => x.idSpare,
                        principalTable: "SpareParts",
                        principalColumn: "idSpare",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Orders",
                columns: table => new
                {
                    numOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusPaymnt = table.Column<bool>(type: "bit", nullable: false),
                    statusDelivery = table.Column<bool>(type: "bit", nullable: false),
                    num_admission = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    dateDelivery = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Orders", x => x.numOrder);
                    table.ForeignKey(
                        name: "FK_Work_Orders_Admission_For_Repairs_num_admission",
                        column: x => x.num_admission,
                        principalTable: "Admission_For_Repairs",
                        principalColumn: "num_admission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Orders_StatusRepairs_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusRepairs",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cunsumptions",
                columns: table => new
                {
                    IdConsumption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    idSpare = table.Column<int>(type: "int", nullable: false),
                    numOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cunsumptions", x => x.IdConsumption);
                    table.ForeignKey(
                        name: "FK_Cunsumptions_SpareParts_idSpare",
                        column: x => x.idSpare,
                        principalTable: "SpareParts",
                        principalColumn: "idSpare",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cunsumptions_Work_Orders_numOrder",
                        column: x => x.numOrder,
                        principalTable: "Work_Orders",
                        principalColumn: "numOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work_Repairs",
                columns: table => new
                {
                    numWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateReady = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numOrder = table.Column<int>(type: "int", nullable: false),
                    keyService = table.Column<int>(type: "int", nullable: false),
                    idWork = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_Repairs", x => x.numWork);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Employees_idWork",
                        column: x => x.idWork,
                        principalTable: "Employees",
                        principalColumn: "idWork",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Services_keyService",
                        column: x => x.keyService,
                        principalTable: "Services",
                        principalColumn: "keyService",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Repairs_Work_Orders_numOrder",
                        column: x => x.numOrder,
                        principalTable: "Work_Orders",
                        principalColumn: "numOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admission_For_Repairs_idCustDev",
                table: "Admission_For_Repairs",
                column: "idCustDev");

            migrationBuilder.CreateIndex(
                name: "IX_Cunsumptions_idSpare",
                table: "Cunsumptions",
                column: "idSpare");

            migrationBuilder.CreateIndex(
                name: "IX_Cunsumptions_numOrder",
                table: "Cunsumptions",
                column: "numOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_idCustom",
                table: "Customer_Devices",
                column: "idCustom");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_typeId",
                table: "Customer_Devices",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_idSpare",
                table: "Purchases",
                column: "idSpare");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_IdTypeSP",
                table: "SpareParts",
                column: "IdTypeSP");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_num_admission",
                table: "Work_Orders",
                column: "num_admission");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_StatusId",
                table: "Work_Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_idWork",
                table: "Work_Repairs",
                column: "idWork");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_keyService",
                table: "Work_Repairs",
                column: "keyService");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Repairs_numOrder",
                table: "Work_Repairs",
                column: "numOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cunsumptions");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Work_Repairs");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Work_Orders");

            migrationBuilder.DropTable(
                name: "TypeSpareParts");

            migrationBuilder.DropTable(
                name: "Admission_For_Repairs");

            migrationBuilder.DropTable(
                name: "StatusRepairs");

            migrationBuilder.DropTable(
                name: "Customer_Devices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Device_types");
        }
    }
}
