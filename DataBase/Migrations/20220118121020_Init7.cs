using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cunsumptions_Work_Repairs_numWork",
                table: "Cunsumptions");

            migrationBuilder.RenameColumn(
                name: "numWork",
                table: "Cunsumptions",
                newName: "numOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Cunsumptions_numWork",
                table: "Cunsumptions",
                newName: "IX_Cunsumptions_numOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Cunsumptions_Work_Orders_numOrder",
                table: "Cunsumptions",
                column: "numOrder",
                principalTable: "Work_Orders",
                principalColumn: "numOrder",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cunsumptions_Work_Orders_numOrder",
                table: "Cunsumptions");

            migrationBuilder.RenameColumn(
                name: "numOrder",
                table: "Cunsumptions",
                newName: "numWork");

            migrationBuilder.RenameIndex(
                name: "IX_Cunsumptions_numOrder",
                table: "Cunsumptions",
                newName: "IX_Cunsumptions_numWork");

            migrationBuilder.AddForeignKey(
                name: "FK_Cunsumptions_Work_Repairs_numWork",
                table: "Cunsumptions",
                column: "numWork",
                principalTable: "Work_Repairs",
                principalColumn: "numWork",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
