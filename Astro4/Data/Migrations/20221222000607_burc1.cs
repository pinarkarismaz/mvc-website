using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astro4.Data.Migrations
{
    public partial class burc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burc_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    burc_tarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    burc_resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ozellik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burc", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burc");
        }
    }
}
