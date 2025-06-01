using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class updateUserRoleMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePrivilege_Role_RoleId",
                table: "RolePrivilege");

            migrationBuilder.CreateTable(
                name: "UserRoleMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RolePrivilegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMapping_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMapping_RolePrivilege_RolePrivilegeId",
                        column: x => x.RolePrivilegeId,
                        principalTable: "RolePrivilege",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMapping_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMapping_RoleId",
                table: "UserRoleMapping",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMapping_RolePrivilegeId",
                table: "UserRoleMapping",
                column: "RolePrivilegeId");

            migrationBuilder.CreateIndex(
                name: "UK_UserRoleMapping",
                table: "UserRoleMapping",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePrivilege_Role",
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
                name: "FK_RolePrivilege_Role",
                table: "RolePrivilege");

            migrationBuilder.DropTable(
                name: "UserRoleMapping");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePrivilege_Role_RoleId",
                table: "RolePrivilege",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
