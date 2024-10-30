using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAnyAttendantAssigned",
                table: "ChatInfos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsWaiting",
                table: "ChatInfos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastMessageTime",
                table: "ChatInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MemberAssignedName",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "IsWaiting",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "LastMessageTime",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "MemberAssignedName",
                table: "ChatInfos");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAnyAttendantAssigned",
                table: "ChatInfos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "ChatInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 35);
        }
    }
}
