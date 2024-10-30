using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNullablePropertiesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteInfos_ContactInfos_ContactId",
                table: "NoteInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                table: "ScheduledMessageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryInfos_ChatInfos_ChatId",
                table: "SearchHistoryInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "SearchHistoryInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "NoteInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactInfos",
                type: "TEXT",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOptIn",
                table: "ContactInfos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ChatInfos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMessageContent",
                table: "ChatInfos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMessageId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteInfos_ContactInfos_ContactId",
                table: "NoteInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                table: "ScheduledMessageInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryInfos_ChatInfos_ChatId",
                table: "SearchHistoryInfos",
                column: "ChatId",
                principalTable: "ChatInfos",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteInfos_ContactInfos_ContactId",
                table: "NoteInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                table: "ScheduledMessageInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistoryInfos_ChatInfos_ChatId",
                table: "SearchHistoryInfos");

            migrationBuilder.DropColumn(
                name: "LastMessageContent",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "LastMessageId",
                table: "ChatInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "SearchHistoryInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "NoteInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactInfos",
                type: "TEXT",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOptIn",
                table: "ContactInfos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ChatInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteInfos_ContactInfos_ContactId",
                table: "NoteInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                table: "ScheduledMessageInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistoryInfos_ChatInfos_ChatId",
                table: "SearchHistoryInfos",
                column: "ChatId",
                principalTable: "ChatInfos",
                principalColumn: "ChatId");
        }
    }
}
