using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init : Migration
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
                    mailWork = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phoneWork = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.idWork);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    idProv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    innProv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    addresProv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneProv = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    emailProv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.idProv);
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
                    typeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_models", x => x.keyModel);
                    table.ForeignKey(
                        name: "FK_Device_models_Device_types_typeId",
                        column: x => x.typeId,
                        principalTable: "Device_types",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    numPurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datePurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idProvider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.numPurchase);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Providers_idProvider",
                        column: x => x.idProvider,
                        principalTable: "Providers",
                        principalColumn: "idProv",
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
                    idCustom = table.Column<int>(type: "int", nullable: false),
                    keyModel = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Customer_Devices_Device_models_keyModel",
                        column: x => x.keyModel,
                        principalTable: "Device_models",
                        principalColumn: "keyModel",
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
                    unitSpare = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PurchaseInvoicenumPurchase = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.idSpare);
                    table.ForeignKey(
                        name: "FK_SpareParts_PurchaseInvoices_PurchaseInvoicenumPurchase",
                        column: x => x.PurchaseInvoicenumPurchase,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "numPurchase",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ListEntries",
                columns: table => new
                {
                    numRow = table.Column<int>(type: "int", nullable: false),
                    numPurchase = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    idSpare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListEntries", x => new { x.numRow, x.numPurchase });
                    table.ForeignKey(
                        name: "FK_ListEntries_PurchaseInvoices_numPurchase",
                        column: x => x.numPurchase,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "numPurchase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListEntries_SpareParts_idSpare",
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
                    durationQuarantee = table.Column<int>(type: "int", nullable: false),
                    statusRepair = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    statusPaymnt = table.Column<bool>(type: "bit", nullable: false),
                    statusDelivery = table.Column<bool>(type: "bit", nullable: false),
                    num_admission = table.Column<int>(type: "int", nullable: false),
                    numDeliveri = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Work_Orders_Akt_Deliveries_numDeliveri",
                        column: x => x.numDeliveri,
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

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    numSales = table.Column<int>(type: "int", nullable: false),
                    numWork = table.Column<int>(type: "int", nullable: false),
                    dateSales = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amountSales = table.Column<int>(type: "int", nullable: false),
                    idSpare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => new { x.numSales, x.numWork });
                    table.ForeignKey(
                        name: "FK_SalesInvoices_SpareParts_idSpare",
                        column: x => x.idSpare,
                        principalTable: "SpareParts",
                        principalColumn: "idSpare",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Work_Repairs_numWork",
                        column: x => x.numWork,
                        principalTable: "Work_Repairs",
                        principalColumn: "numWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admission_For_Repairs_idCustDev",
                table: "Admission_For_Repairs",
                column: "idCustDev");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_idCustom",
                table: "Customer_Devices",
                column: "idCustom");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Devices_keyModel",
                table: "Customer_Devices",
                column: "keyModel");

            migrationBuilder.CreateIndex(
                name: "IX_Device_models_typeId",
                table: "Device_models",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListEntries_idSpare",
                table: "ListEntries",
                column: "idSpare");

            migrationBuilder.CreateIndex(
                name: "IX_ListEntries_numPurchase",
                table: "ListEntries",
                column: "numPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_idProvider",
                table: "PurchaseInvoices",
                column: "idProvider");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_idSpare",
                table: "SalesInvoices",
                column: "idSpare");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_numWork",
                table: "SalesInvoices",
                column: "numWork");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_PurchaseInvoicenumPurchase",
                table: "SpareParts",
                column: "PurchaseInvoicenumPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_num_admission",
                table: "Work_Orders",
                column: "num_admission");

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_numDeliveri",
                table: "Work_Orders",
                column: "numDeliveri");

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
                name: "ListEntries");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "Work_Repairs");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Work_Orders");

            migrationBuilder.DropTable(
                name: "Providers");

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
