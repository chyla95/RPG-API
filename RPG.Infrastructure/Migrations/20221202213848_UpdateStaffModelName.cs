using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStaffModelName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Staff_StaffId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Roles",
                newName: "StaffMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_StaffId",
                table: "Roles",
                newName: "IX_Roles_StaffMemberId");

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StaffMembers_StaffMemberId",
                table: "Roles",
                column: "StaffMemberId",
                principalTable: "StaffMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StaffMembers_StaffMemberId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.RenameColumn(
                name: "StaffMemberId",
                table: "Roles",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_StaffMemberId",
                table: "Roles",
                newName: "IX_Roles_StaffId");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Staff_StaffId",
                table: "Roles",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
