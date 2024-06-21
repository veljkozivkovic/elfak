using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocene_Dogadjaji_DogadjajID",
                table: "Ocene");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Dogadjaji_DogadjajID",
                table: "Rezervacije");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Dogadjaji",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocene_Dogadjaji_DogadjajID",
                table: "Ocene",
                column: "DogadjajID",
                principalTable: "Dogadjaji",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Dogadjaji_DogadjajID",
                table: "Rezervacije",
                column: "DogadjajID",
                principalTable: "Dogadjaji",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocene_Dogadjaji_DogadjajID",
                table: "Ocene");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Dogadjaji_DogadjajID",
                table: "Rezervacije");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Dogadjaji",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocene_Dogadjaji_DogadjajID",
                table: "Ocene",
                column: "DogadjajID",
                principalTable: "Dogadjaji",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Dogadjaji_DogadjajID",
                table: "Rezervacije",
                column: "DogadjajID",
                principalTable: "Dogadjaji",
                principalColumn: "ID");
        }
    }
}
