using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class User_Talosu_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "cityies");

            migrationBuilder.DropTable(
                name: "eczanes");

            migrationBuilder.DropTable(
                name: "towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gorev_Yeri_İl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gorev_Yeri_İlçe",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Report_Users__");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report_Users__",
                table: "Report_Users__",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Report_Users___UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Report_Users__",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Report_Users___UserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report_Users__",
                table: "Report_Users__");

            migrationBuilder.RenameTable(
                name: "Report_Users__",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Gorev_Yeri_İl",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gorev_Yeri_İlçe",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cityies",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityies", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "eczanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brick_500 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eczacı_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eczane_Adı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eczane_Konum_Tipi = table.Column<int>(type: "int", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GLN_No = table.Column<long>(type: "bigint", nullable: false),
                    Mediporf_Kodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silinmişmi = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İlçe = table.Column<int>(type: "int", nullable: false),
                    Şehir = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eczanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "towns",
                columns: table => new
                {
                    TownID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towns", x => x.TownID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
