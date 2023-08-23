using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bitirme.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAlisverisSepetiToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlisverisSepetleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlisverisSepetleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlisverisSepetleri_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlisverisSepetleri_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                column: "ResimUrl",
                value: "/resimler/urunler/30grhasirseritbilezik.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_AlisverisSepetleri_ApplicationUserId",
                table: "AlisverisSepetleri",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlisverisSepetleri_UrunId",
                table: "AlisverisSepetleri",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlisverisSepetleri");

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                column: "ResimUrl",
                value: "/resimler/urunler/50grambilezik.jpg");
        }
    }
}
