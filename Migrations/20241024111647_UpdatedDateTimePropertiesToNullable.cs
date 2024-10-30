using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSOPS.DevChallenge.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDateTimePropertiesToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelReference",
                table: "ScheduledMessageInfos");

            migrationBuilder.AddColumn<string>(
                name: "ChannelReferenceId",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChannelReferenceName",
                table: "ScheduledMessageInfos",
                type: "TEXT",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelReferenceId",
                table: "ScheduledMessageInfos");

            migrationBuilder.DropColumn(
                name: "ChannelReferenceName",
                table: "ScheduledMessageInfos");

            migrationBuilder.AddColumn<int>(
                name: "ChannelReference",
                table: "ScheduledMessageInfos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
