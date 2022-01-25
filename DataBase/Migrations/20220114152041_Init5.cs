using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataBase.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datePurchase",
                table: "Purchases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "sparePartOnStorages",
                columns: table => new
                {
                    idSpare = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sparePartOnStorages", x => x.idSpare);
                    table.ForeignKey(
                        name: "FK_sparePartOnStorages_SpareParts_idSpare",
                        column: x => x.idSpare,
                        principalTable: "SpareParts",
                        principalColumn: "idSpare",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sparePartOnStorages");

            migrationBuilder.DropColumn(
                name: "datePurchase",
                table: "Purchases");
        }
    }
}
