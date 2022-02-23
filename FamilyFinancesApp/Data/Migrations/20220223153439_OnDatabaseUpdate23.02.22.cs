using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyFinancesApp.Data.Migrations
{
    public partial class OnDatabaseUpdate230222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "SpendingTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Spendings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "IncomeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Incomes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpendingTypes_UserInfoId",
                table: "SpendingTypes",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_UserInfoId",
                table: "Spendings",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTypes_UserInfoId",
                table: "IncomeTypes",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_UserInfoId",
                table: "Incomes",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_UsersInfo_UserInfoId",
                table: "Incomes",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeTypes_UsersInfo_UserInfoId",
                table: "IncomeTypes",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_UsersInfo_UserInfoId",
                table: "Spendings",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpendingTypes_UsersInfo_UserInfoId",
                table: "SpendingTypes",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_UsersInfo_UserInfoId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeTypes_UsersInfo_UserInfoId",
                table: "IncomeTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_UsersInfo_UserInfoId",
                table: "Spendings");

            migrationBuilder.DropForeignKey(
                name: "FK_SpendingTypes_UsersInfo_UserInfoId",
                table: "SpendingTypes");

            migrationBuilder.DropIndex(
                name: "IX_SpendingTypes_UserInfoId",
                table: "SpendingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_UserInfoId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_IncomeTypes_UserInfoId",
                table: "IncomeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_UserInfoId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "SpendingTypes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "IncomeTypes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Incomes");
        }
    }
}
