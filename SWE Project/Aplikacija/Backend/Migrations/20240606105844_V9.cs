using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class V9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajID",
                table: "PlanoviProstora");

            migrationBuilder.DropIndex(
                name: "IX_PlanoviProstora_DogadjajID",
                table: "PlanoviProstora");

            migrationBuilder.RenameColumn(
                name: "DogadjajID",
                table: "PlanoviProstora",
                newName: "DogadjajFK");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoviProstora_DogadjajFK",
                table: "PlanoviProstora",
                column: "DogadjajFK",
                unique: true,
                filter: "[DogadjajFK] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora",
                column: "DogadjajFK",
                principalTable: "Dogadjaji",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajFK",
                table: "PlanoviProstora");

            migrationBuilder.DropIndex(
                name: "IX_PlanoviProstora_DogadjajFK",
                table: "PlanoviProstora");

            migrationBuilder.RenameColumn(
                name: "DogadjajFK",
                table: "PlanoviProstora",
                newName: "DogadjajID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoviProstora_DogadjajID",
                table: "PlanoviProstora",
                column: "DogadjajID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoviProstora_Dogadjaji_DogadjajID",
                table: "PlanoviProstora",
                column: "DogadjajID",
                principalTable: "Dogadjaji",
                principalColumn: "ID");
        }
    }
}
