using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogadjaji_RezervacijeProstora_RezervacijaProstoraFK",
                table: "Dogadjaji");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogadjaji_RezervacijeProstora_RezervacijaProstoraFK",
                table: "Dogadjaji",
                column: "RezervacijaProstoraFK",
                principalTable: "RezervacijeProstora",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora",
                column: "DogadjajFK",
                principalTable: "Dogadjaji",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogadjaji_RezervacijeProstora_RezervacijaProstoraFK",
                table: "Dogadjaji");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogadjaji_RezervacijeProstora_RezervacijaProstoraFK",
                table: "Dogadjaji",
                column: "RezervacijaProstoraFK",
                principalTable: "RezervacijeProstora",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora",
                column: "DogadjajFK",
                principalTable: "Dogadjaji",
                principalColumn: "ID");
        }
    }
}
