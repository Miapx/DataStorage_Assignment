using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLazyLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusTypeEntityId",
                table: "StatusTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerEntityId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTypes_StatusTypeEntityId",
                table: "StatusTypes",
                column: "StatusTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductEntityId",
                table: "Products",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerEntityId",
                table: "Customers",
                column: "CustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_CustomerEntityId",
                table: "Customers",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductEntityId",
                table: "Products",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeEntityId",
                table: "StatusTypes",
                column: "StatusTypeEntityId",
                principalTable: "StatusTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_CustomerEntityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductEntityId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusTypes_StatusTypes_StatusTypeEntityId",
                table: "StatusTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StatusTypes_StatusTypeEntityId",
                table: "StatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerEntityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StatusTypeEntityId",
                table: "StatusTypes");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerEntityId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
