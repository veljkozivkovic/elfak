using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogadjajTag_Tagovi_TagoviID",
                table: "DogadjajTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tagovi",
                table: "Tagovi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogadjajTag",
                table: "DogadjajTag");

            migrationBuilder.DropIndex(
                name: "IX_DogadjajTag_TagoviID",
                table: "DogadjajTag");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Tagovi");

            migrationBuilder.DropColumn(
                name: "TagoviID",
                table: "DogadjajTag");

            migrationBuilder.AddColumn<string>(
                name: "TagoviTagName",
                table: "DogadjajTag",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tagovi",
                table: "Tagovi",
                column: "TagName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogadjajTag",
                table: "DogadjajTag",
                columns: new[] { "DogadjajiID", "TagoviTagName" });

            migrationBuilder.CreateTable(
                name: "UserTags",
                columns: table => new
                {
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTags", x => x.TagName);
                });

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
                name: "IX_DogadjajTag_TagoviTagName",
                table: "DogadjajTag",
                column: "TagoviTagName");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUserTag_TagoviTagName",
                table: "KorisnikUserTag",
                column: "TagoviTagName");

            migrationBuilder.AddForeignKey(
                name: "FK_DogadjajTag_Tagovi_TagoviTagName",
                table: "DogadjajTag",
                column: "TagoviTagName",
                principalTable: "Tagovi",
                principalColumn: "TagName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogadjajTag_Tagovi_TagoviTagName",
                table: "DogadjajTag");

            migrationBuilder.DropTable(
                name: "KorisnikUserTag");

            migrationBuilder.DropTable(
                name: "UserTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tagovi",
                table: "Tagovi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogadjajTag",
                table: "DogadjajTag");

            migrationBuilder.DropIndex(
                name: "IX_DogadjajTag_TagoviTagName",
                table: "DogadjajTag");

            migrationBuilder.DropColumn(
                name: "TagoviTagName",
                table: "DogadjajTag");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Tagovi",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TagoviID",
                table: "DogadjajTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tagovi",
                table: "Tagovi",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogadjajTag",
                table: "DogadjajTag",
                columns: new[] { "DogadjajiID", "TagoviID" });

            migrationBuilder.CreateIndex(
                name: "IX_DogadjajTag_TagoviID",
                table: "DogadjajTag",
                column: "TagoviID");

            migrationBuilder.AddForeignKey(
                name: "FK_DogadjajTag_Tagovi_TagoviID",
                table: "DogadjajTag",
                column: "TagoviID",
                principalTable: "Tagovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
