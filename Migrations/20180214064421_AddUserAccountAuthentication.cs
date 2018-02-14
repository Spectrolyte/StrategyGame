using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StrategyGame.Migrations
{
    public partial class AddUserAccountAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserAccountAuthentication_UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccountAuthentication",
                table: "UserAccountAuthentication");

            migrationBuilder.DropColumn(
                name: "UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccountAuthentication",
                newName: "UserAccountAuthentications");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountId",
                table: "UserAccountAuthentications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccountAuthentications",
                table: "UserAccountAuthentications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountAuthentications_UserAccountId",
                table: "UserAccountAuthentications",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccountAuthentications_UserAccounts_UserAccountId",
                table: "UserAccountAuthentications",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccountAuthentications_UserAccounts_UserAccountId",
                table: "UserAccountAuthentications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccountAuthentications",
                table: "UserAccountAuthentications");

            migrationBuilder.DropIndex(
                name: "IX_UserAccountAuthentications_UserAccountId",
                table: "UserAccountAuthentications");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "UserAccountAuthentications");

            migrationBuilder.RenameTable(
                name: "UserAccountAuthentications",
                newName: "UserAccountAuthentication");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountAuthenticationId",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccountAuthentication",
                table: "UserAccountAuthentication",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_UserAccountAuthenticationId",
                table: "UserAccounts",
                column: "UserAccountAuthenticationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_UserAccountAuthentication_UserAccountAuthenticationId",
                table: "UserAccounts",
                column: "UserAccountAuthenticationId",
                principalTable: "UserAccountAuthentication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
