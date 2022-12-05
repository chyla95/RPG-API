using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClassRestrictionToWeaponModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ClassId",
                table: "Weapons",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Classes_ClassId",
                table: "Weapons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Classes_ClassId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_ClassId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Weapons");
        }
    }
}
