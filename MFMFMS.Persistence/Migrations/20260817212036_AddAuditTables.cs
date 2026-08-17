using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MFMFMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Positions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Positions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Meetings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Givings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Givings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Givings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Givings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Expenditures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Expenditures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastMofifiedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Meeting_NoOfChildrenAttendance_Positive",
                table: "Meetings",
                sql: "[NoOfChildrenAttendance] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Meeting_NoOfFemaleAttendance_Positive",
                table: "Meetings",
                sql: "[NoOfFemaleAttendance] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Meeting_NoOfMaleAttendance_Positive",
                table: "Meetings",
                sql: "[NoOfMaleAttendance] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Expenditure_Amount_Positive",
                table: "Expenditures",
                sql: "[Amount] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Meeting_NoOfChildrenAttendance_Positive",
                table: "Meetings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Meeting_NoOfFemaleAttendance_Positive",
                table: "Meetings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Meeting_NoOfMaleAttendance_Positive",
                table: "Meetings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Expenditure_Amount_Positive",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Givings");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Givings");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Givings");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Givings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastMofifiedBy",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
