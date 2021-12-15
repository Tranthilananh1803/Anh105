using Microsoft.EntityFrameworkCore.Migrations;

namespace Anh105.Migrations
{
    public partial class Create_Table_TA105s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TA105s",
                columns: table => new
                {
                    TAid = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TAName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TAGener = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TA105s", x => x.TAid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TA105s");
        }
    }
}
