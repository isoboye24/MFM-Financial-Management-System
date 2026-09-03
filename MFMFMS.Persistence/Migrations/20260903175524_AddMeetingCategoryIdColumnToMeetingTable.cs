using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MFMFMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingCategoryIdColumnToMeetingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MeetingCategoryId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingCategoryId",
                table: "Meetings",
                column: "MeetingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_MeetingCategories_MeetingCategoryId",
                table: "Meetings",
                column: "MeetingCategoryId",
                principalTable: "MeetingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_MeetingCategories_MeetingCategoryId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_MeetingCategoryId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingCategoryId",
                table: "Meetings");
        }
    }
}
