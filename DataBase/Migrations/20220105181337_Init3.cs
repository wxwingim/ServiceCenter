using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataBase.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_Orders_Akt_Deliveries_numDeliveri",
                table: "Work_Orders");

            migrationBuilder.DropTable(
                name: "Akt_Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Work_Orders_numDeliveri",
                table: "Work_Orders");

            migrationBuilder.DropColumn(
                name: "numDeliveri",
                table: "Work_Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateDelivery",
                table: "Work_Orders",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateDelivery",
                table: "Work_Orders");

            migrationBuilder.AddColumn<int>(
                name: "numDeliveri",
                table: "Work_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Work_Orders_numDeliveri",
                table: "Work_Orders",
                column: "numDeliveri");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Orders_Akt_Deliveries_numDeliveri",
                table: "Work_Orders",
                column: "numDeliveri",
                principalTable: "Akt_Deliveries",
                principalColumn: "numDeliveri",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
