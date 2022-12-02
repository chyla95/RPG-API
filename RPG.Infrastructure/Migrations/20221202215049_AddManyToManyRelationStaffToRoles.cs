using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationStaffToRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_StaffMembers_StaffMemberId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_StaffMemberId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "StaffMemberId",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "RoleStaffMember",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    staffMembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleStaffMember", x => new { x.RolesId, x.staffMembersId });
                    table.ForeignKey(
                        name: "FK_RoleStaffMember_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleStaffMember_StaffMembers_staffMembersId",
                        column: x => x.staffMembersId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleStaffMember_staffMembersId",
                table: "RoleStaffMember",
                column: "staffMembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleStaffMember");

            migrationBuilder.AddColumn<int>(
                name: "StaffMemberId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StaffMemberId",
                table: "Roles",
                column: "StaffMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_StaffMembers_StaffMemberId",
                table: "Roles",
                column: "StaffMemberId",
                principalTable: "StaffMembers",
                principalColumn: "Id");
        }
    }
}
