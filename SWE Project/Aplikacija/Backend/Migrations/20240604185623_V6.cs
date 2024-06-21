using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitorRankID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitorRanks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorRanks", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VisitorRankID",
                table: "AspNetUsers",
                column: "VisitorRankID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VisitorRanks_VisitorRankID",
                table: "AspNetUsers",
                column: "VisitorRankID",
                principalTable: "VisitorRanks",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VisitorRanks_VisitorRankID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "VisitorRanks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VisitorRankID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VisitorRankID",
                table: "AspNetUsers");
        }
    }
}
