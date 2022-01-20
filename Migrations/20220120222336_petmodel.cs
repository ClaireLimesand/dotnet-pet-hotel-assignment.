using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class petmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "petOwnerId",
                table: "Pets",
                newName: "petOwnerid");

            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Pets",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "breed");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                column: "petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pets",
                newName: "petOwnerId");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Pets",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Pets",
                newName: "PetBreed");
        }
    }
}
