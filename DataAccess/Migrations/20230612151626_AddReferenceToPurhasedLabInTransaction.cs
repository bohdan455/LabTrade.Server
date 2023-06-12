using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddReferenceToPurhasedLabInTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchasedLabWorkId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PurchasedLabWorkId",
                table: "Transaction",
                column: "PurchasedLabWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_LabWork_PurchasedLabWorkId",
                table: "Transaction",
                column: "PurchasedLabWorkId",
                principalTable: "LabWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_LabWork_PurchasedLabWorkId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PurchasedLabWorkId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PurchasedLabWorkId",
                table: "Transaction");
        }
    }
}
