using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunMarka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListeFiyat = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Fiyat50 = table.Column<double>(type: "float", nullable: false),
                    Fiyat100 = table.Column<double>(type: "float", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { 1, " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar. ", 1900.0, 1880.0, 1890.0, 1, 1900.0, "/resimler/urunler/gramaltin.jpg", "Gram Altın", "grm01", "Ahlatcı Rafineri" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar.  ", 3500.0, 3470.0, 3480.0, 1, 3500.0, "/resimler/urunler/ceyrekaltin.jpg", "Çeyrek Altın", "cyr01", "Ahlatcı Rafineri" },
                    { 3, "Rafineri onaylı ve belgeli, özel kutusunda gram altın  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar. ", 5000.0, 4750.0, 4990.0, 1, 5000.0, "/resimler/urunler/yarim.jpg", "Yarım Altın", "yrm01", "Ahlatcı Rafineri" },
                    { 4, "Rafineri onaylı ve belgeli, özel kutusunda 10 Gram Külçe Altın  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar.  ", 18000.0, 17500.0, 17800.0, 2, 18000.0, "/resimler/urunler/20gramkulce.png", "20 Gram Külçe Altın", "Kulce0001", "Ahlatcı Rafineri" },
                    { 5, "Rafineri onaylı ve belgeli, özel kutusunda 30 gram 18 Ayar şık kadın bilekliği  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar. ", 50000.0, 49700.0, 49800.0, 3, 50000.0, "/resimler/urunler/30gramhasirseritbilezik.jpg", "30 Gram Altın Bileklik", "Ziynet001", "Ahlatcı Rafineri" },
                    { 6, "Rafineri onaylı ve belgeli, özel hediye kutusunda 50 gram 22 Ayar Burma Bilezik  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin sed feugiat arcu, sed facilisis ex. Aenean imperdiet molestie bibendum. Suspendisse bibendum orci id lacus efficitur, non mollis nisi laoreet. Ut et sollicitudin tellus, vitae eleifend urna. In elementum purus nec urna posuere, ut consequat nisl mattis. Vestibulum laoreet quis leo iaculis ultricies. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nCras ultricies ante ut diam rhoncus vestibulum. Integer a consequat quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam nec sapien vitae dui tristique facilisis et id mi. Proin venenatis malesuada ligula. Cras feugiat urna eu dolor eleifend feugiat. Nunc mollis erat at ipsum blandit pulvinar. ", 85000.0, 84600.0, 84850.0, 3, 85000.0, "/resimler/urunler/50grambilezik.jpg", "50 Gram Burma Bilezik", "Ziynet002", "Ahlatcı Rafineri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriId",
                table: "Urunler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
