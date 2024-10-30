using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class AddWhoAnsweredLastToChatInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhoAnsweredLast",
                table: "ChatInfos",
                type: "TEXT",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhoAnsweredLast",
                table: "ChatInfos");
        }
    }
}
