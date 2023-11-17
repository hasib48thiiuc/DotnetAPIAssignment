using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    /// <inheritdoc />
    public partial class logininfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfo",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserInfo",
                type: "datetime2",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "UserInfo",
                type: "varchar(60)",
                unicode: false,
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
