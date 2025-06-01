using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class updateRolePrivilageFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RolePrivilege_RoleId",
                table: "RolePrivilege",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePrivilege_Role_RoleId",
                table: "RolePrivilege",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePrivilege_Role_RoleId",
                table: "RolePrivilege");

            migrationBuilder.DropIndex(
                name: "IX_RolePrivilege_RoleId",
                table: "RolePrivilege");
        }
    }
}
