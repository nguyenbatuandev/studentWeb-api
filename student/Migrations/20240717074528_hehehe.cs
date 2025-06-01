﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class hehehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType",
                table: "User",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypeId",
                table: "User");
        }
    }
}
