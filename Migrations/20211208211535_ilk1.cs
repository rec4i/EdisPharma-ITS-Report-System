using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ilk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eczanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eczane_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eczacı_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Şehir = table.Column<int>(type: "int", nullable: false),
                    İlçe = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mediporf_Kodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brick_500 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eczane_Konum_Tipi = table.Column<int>(type: "int", nullable: false),
                    GLN_No = table.Column<long>(type: "bigint", nullable: false),
                    Silinmişmi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eczanes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eczanes");
        }
    }
}
