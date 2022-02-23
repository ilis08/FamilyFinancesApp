using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyFinancesApp.Data.Migrations
{
    public partial class OnNewUpdate230222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_UsersInfo_UserInfoId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_UsersInfo_UserInfoId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_UserInfoId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_UserInfoId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Incomes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Spendings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Incomes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_UserInfoId",
                table: "Spendings",
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
                name: "FK_Spendings_UsersInfo_UserInfoId",
                table: "Spendings",
                column: "UserInfoId",
                principalTable: "UsersInfo",
                principalColumn: "Id");
        }
    }
}
