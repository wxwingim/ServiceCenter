using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sparePartOnStorages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
