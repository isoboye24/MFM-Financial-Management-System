using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MFMFMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingIdColumnToGivingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MeetingId",
                table: "Givings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Givings_MeetingId",
                table: "Givings",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Givings_Meetings_MeetingId",
                table: "Givings",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Givings_Meetings_MeetingId",
                table: "Givings");

            migrationBuilder.DropIndex(
                name: "IX_Givings_MeetingId",
                table: "Givings");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Givings");
        }
    }
}
