using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class AddedContactInfoAndRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "MemberAssignedName",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "WhoAnsweredLast",
                table: "ChatInfos");

            migrationBuilder.AddColumn<string>(
                name: "ContactId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ChatInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentMemberId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastAttendantId",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMessageSource",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMessageState",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    AddressLine1 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastActiveUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsOptIn = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    GroupIdentifier = table.Column<string>(type: "TEXT", nullable: true),
                    Landline = table.Column<int>(type: "INTEGER", nullable: false),
                    ChannelIds = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAtUTC = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "SearchHistoryInfos",
                columns: table => new
                {
                    SearchHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsAnyAttendantAssigned = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWaiting = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastMessageTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastMessageSource = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    LastMessageState = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    MemberId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    LastAttendantId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ChatId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistoryInfos", x => x.SearchHistoryId);
                    table.ForeignKey(
                        name: "FK_SearchHistoryInfos_ChatInfos_ChatId",
                        column: x => x.ChatId,
                        principalTable: "ChatInfos",
                        principalColumn: "ChatId");
                });

            migrationBuilder.CreateTable(
                name: "NoteInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    CreatedAtUTC = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    ContactId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteInfos_ContactInfos_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactInfos",
                        principalColumn: "ContactId");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledMessageInfos",
                columns: table => new
                {
                    ScheduledMessageId = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChannelReference = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledMessageInfos", x => x.ScheduledMessageId);
                    table.ForeignKey(
                        name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactInfos",
                        principalColumn: "ContactId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatInfos_ContactId",
                table: "ChatInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteInfos_ContactId",
                table: "NoteInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMessageInfos_ContactId",
                table: "ScheduledMessageInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistoryInfos_ChatId",
                table: "SearchHistoryInfos",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos",
                column: "ContactId",
                principalTable: "ContactInfos",
                principalColumn: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInfos_ContactInfos_ContactId",
                table: "ChatInfos");

            migrationBuilder.DropTable(
                name: "NoteInfos");

            migrationBuilder.DropTable(
                name: "ScheduledMessageInfos");

            migrationBuilder.DropTable(
                name: "SearchHistoryInfos");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ChatInfos_ContactId",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "CurrentMemberId",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "LastAttendantId",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "LastMessageSource",
                table: "ChatInfos");

            migrationBuilder.DropColumn(
                name: "LastMessageState",
                table: "ChatInfos");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberAssignedName",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhoAnsweredLast",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 10,
                nullable: true);
        }
    }
}
