using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bitirme.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Siparis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunMarka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListeFiyat = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Fiyat50 = table.Column<double>(type: "float", nullable: false),
                    Fiyat100 = table.Column<double>(type: "float", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad", "Siparis" },
                values: new object[,]
                {
                    { 1, "GramAltin", 1 },
                    { 2, "KulceAltin", 2 },
                    { 3, "ZiynetAltin", 3 },
                    { 4, "Diger", 4 }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aciklama", "Fiyat", "Fiyat100", "Fiyat50", "KategoriId", "ListeFiyat", "ResimUrl", "UrunAdi", "UrunKodu", "UrunMarka" },
                values: new object[,]
                {
                    { 1, "Rafineri onaylı ve belgeli, özel kutusunda gram altın ", 1900.0, 1880.0, 1890.0, 1, 1900.0, "", "Gram Altın", "grm01", "Ahlatcı Rafineri" },
                    { 2, "Rafineri onaylı ve belgeli, özel kutusunda gram altın ", 3500.0, 3470.0, 3480.0, 4, 3500.0, "", "Çeyrek Altın", "cyr01", "Ahlatcı Rafineri" },
                    { 3, "Rafineri onaylı ve belgeli, özel kutusunda gram altın ", 5000.0, 4750.0, 4990.0, 1, 5000.0, "", "Yarım Altın", "yrm01", "Ahlatcı Rafineri" },
                    { 4, "Rafineri onaylı ve belgeli, özel kutusunda 10 Gram Külçe Altın ", 18000.0, 17500.0, 17800.0, 2, 18000.0, "", "10 Gram Külçe Altın", "Kulce0001", "Ahlatcı Rafineri" },
                    { 5, "Rafineri onaylı ve belgeli, özel kutusunda 30 gram 18 Ayar şık kadın bilekliği ", 50000.0, 49700.0, 49800.0, 2, 50000.0, "", "30 Gram Altın Bileklik", "Ziynet001", "Ahlatcı Rafineri" },
                    { 6, "Rafineri onaylı ve belgeli, özel hediye kutusunda 50 gram 22 Ayar Burma Bilezik ", 85000.0, 84600.0, 84850.0, 3, 85000.0, "", "50 Gram Burma Bilezik", "Ziynet002", "Ahlatcı Rafineri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
