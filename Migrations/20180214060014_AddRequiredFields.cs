using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StrategyGame.Migrations
{
    public partial class AddRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAccounts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountAuthenticationId",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserAccountAuthentication",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EncryptedPassword = table.Column<string>(nullable: false),
                    PasswordSalt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountAuthentication", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_UserAccountAuthentication_UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserAccountAuthentication");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "UserAccountAuthenticationId",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserAccounts",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
