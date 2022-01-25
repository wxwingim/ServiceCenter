using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataBase.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Devices_Device_models_keyModel",
                table: "Customer_Devices");

            migrationBuilder.DropTable(
                name: "Device_models");

            migrationBuilder.RenameColumn(
                name: "keyModel",
                table: "Customer_Devices",
                newName: "typeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Devices_keyModel",
                table: "Customer_Devices",
                newName: "IX_Customer_Devices_typeId");

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Customer_Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_limit",
                table: "Admission_For_Repairs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Devices_Device_types_typeId",
                table: "Customer_Devices",
                column: "typeId",
                principalTable: "Device_types",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Devices_Device_types_typeId",
                table: "Customer_Devices");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Customer_Devices");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "Customer_Devices",
                newName: "keyModel");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Devices_typeId",
                table: "Customer_Devices",
                newName: "IX_Customer_Devices_keyModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_limit",
                table: "Admission_For_Repairs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Device_models_typeId",
                table: "Device_models",
                column: "typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Devices_Device_models_keyModel",
                table: "Customer_Devices",
                column: "keyModel",
                principalTable: "Device_models",
                principalColumn: "keyModel",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
