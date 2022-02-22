using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyFinancesApp.Data.Migrations
{
    public partial class OperationModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpendingDate",
                table: "Spendings",
                newName: "OperationDate");

            migrationBuilder.RenameColumn(
                name: "SpendingDate",
                table: "Incomes",
                newName: "OperationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationDate",
                table: "Spendings",
                newName: "SpendingDate");

            migrationBuilder.RenameColumn(
                name: "OperationDate",
                table: "Incomes",
                newName: "SpendingDate");
        }
    }
}
