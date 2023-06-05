using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class LabWorkRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LabWork");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "LabWork");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "LabWork");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "LabWork");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "LabWork",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "LabWork",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LabWork",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "LabWork",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "LabWork",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "LabWork",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
