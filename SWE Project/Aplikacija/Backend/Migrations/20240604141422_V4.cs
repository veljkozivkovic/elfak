using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikUserTag");

            migrationBuilder.CreateTable(
                name: "KorisnikTagovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserTagTagName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikTagovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KorisnikTagovi_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KorisnikTagovi_UserTags_UserTagTagName",
                        column: x => x.UserTagTagName,
                        principalTable: "UserTags",
                        principalColumn: "TagName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTagovi_KorisnikId",
                table: "KorisnikTagovi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTagovi_UserTagTagName",
                table: "KorisnikTagovi",
                column: "UserTagTagName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikTagovi");

            migrationBuilder.CreateTable(
                name: "KorisnikUserTag",
                columns: table => new
                {
                    KorisniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagoviTagName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUserTag", x => new { x.KorisniciId, x.TagoviTagName });
                    table.ForeignKey(
                        name: "FK_KorisnikUserTag_AspNetUsers_KorisniciId",
                        column: x => x.KorisniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikUserTag_UserTags_TagoviTagName",
                        column: x => x.TagoviTagName,
                        principalTable: "UserTags",
                        principalColumn: "TagName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUserTag_TagoviTagName",
                table: "KorisnikUserTag",
                column: "TagoviTagName");
        }
    }
}
