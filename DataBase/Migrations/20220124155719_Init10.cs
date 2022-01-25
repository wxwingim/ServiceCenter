using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "durationQuarantee",
                table: "Work_Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "durationQuarantee",
                table: "Work_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
