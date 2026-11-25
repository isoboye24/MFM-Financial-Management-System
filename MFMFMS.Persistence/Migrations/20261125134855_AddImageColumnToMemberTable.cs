using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MFMFMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImageColumnToMemberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Members");
        }
    }
}
