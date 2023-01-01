using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astro4.Data.Migrations
{
    public partial class retro1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gezegen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarih_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gun_burc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gezegen", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gezegen");
        }
    }
}
