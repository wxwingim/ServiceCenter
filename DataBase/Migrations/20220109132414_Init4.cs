using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataBase.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_PurchaseInvoices_PurchaseInvoicenumPurchase",
                table: "SpareParts");

            migrationBuilder.DropTable(
                name: "ListEntries");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_PurchaseInvoicenumPurchase",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "statusRepair",
                table: "Work_Orders");

            migrationBuilder.DropColumn(
                name: "PurchaseInvoicenumPurchase",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "unitSpare",
                table: "SpareParts");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Work_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTypeSP",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cunsumptions",
                columns: table => new
                {
                    IdConsumption = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    idSpare = table.Column<int>(type: "int", nullable: false),
                    numWork = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Cunsumptions_Work_Repairs_numWork",
                        column: x => x.numWork,
                        principalTable: "Work_Repairs",
                        principalColumn: "numWork",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_StatusId",
                table: "Work_Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_IdTypeSP",
                table: "SpareParts",
                column: "IdTypeSP");

            migrationBuilder.CreateIndex(
                name: "IX_Cunsumptions_idSpare",
                table: "Cunsumptions",
                column: "idSpare");

            migrationBuilder.CreateIndex(
                name: "IX_Cunsumptions_numWork",
                table: "Cunsumptions",
                column: "numWork");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_idSpare",
                table: "Purchases",
                column: "idSpare");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_TypeSpareParts_IdTypeSP",
                table: "SpareParts",
                column: "IdTypeSP",
                principalTable: "TypeSpareParts",
                principalColumn: "IdTypeSP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Orders_StatusRepairs_StatusId",
                table: "Work_Orders",
                column: "StatusId",
                principalTable: "StatusRepairs",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_TypeSpareParts_IdTypeSP",
                table: "SpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Orders_StatusRepairs_StatusId",
                table: "Work_Orders");

            migrationBuilder.DropTable(
                name: "Cunsumptions");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "StatusRepairs");

            migrationBuilder.DropTable(
                name: "TypeSpareParts");

            migrationBuilder.DropIndex(
                name: "IX_Work_Orders_StatusId",
                table: "Work_Orders");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_IdTypeSP",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Work_Orders");

            migrationBuilder.DropColumn(
                name: "IdTypeSP",
                table: "SpareParts");

            migrationBuilder.AddColumn<string>(
                name: "statusRepair",
                table: "Work_Orders",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseInvoicenumPurchase",
                table: "SpareParts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unitSpare",
                table: "SpareParts",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    idProv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addresProv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailProv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    innProv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phoneProv = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.idProv);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    numSales = table.Column<int>(type: "int", nullable: false),
                    numWork = table.Column<int>(type: "int", nullable: false),
                    amountSales = table.Column<int>(type: "int", nullable: false),
                    dateSales = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_PurchaseInvoicenumPurchase",
                table: "SpareParts",
                column: "PurchaseInvoicenumPurchase");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_PurchaseInvoices_PurchaseInvoicenumPurchase",
                table: "SpareParts",
                column: "PurchaseInvoicenumPurchase",
                principalTable: "PurchaseInvoices",
                principalColumn: "numPurchase",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
