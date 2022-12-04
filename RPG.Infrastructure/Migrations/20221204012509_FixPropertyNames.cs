using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPropertyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleStaff_Staff_staffMembersId",
                table: "RoleStaff");

            migrationBuilder.RenameColumn(
                name: "staffMembersId",
                table: "RoleStaff",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleStaff_staffMembersId",
                table: "RoleStaff",
                newName: "IX_RoleStaff_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStaff_Staff_StaffId",
                table: "RoleStaff",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleStaff_Staff_StaffId",
                table: "RoleStaff");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "RoleStaff",
                newName: "staffMembersId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleStaff_StaffId",
                table: "RoleStaff",
                newName: "IX_RoleStaff_staffMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleStaff_Staff_staffMembersId",
                table: "RoleStaff",
                column: "staffMembersId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
