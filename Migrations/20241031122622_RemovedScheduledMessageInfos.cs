using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class RemovedScheduledMessageInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledMessageInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledMessageInfos",
                columns: table => new
                {
                    ScheduledMessageId = table.Column<string>(type: "TEXT", nullable: false),
                    ContactId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ChannelReferenceId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ChannelReferenceName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledMessageInfos", x => x.ScheduledMessageId);
                    table.ForeignKey(
                        name: "FK_ScheduledMessageInfos_ContactInfos_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactInfos",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMessageInfos_ContactId",
                table: "ScheduledMessageInfos",
                column: "ContactId");
        }
    }
}
