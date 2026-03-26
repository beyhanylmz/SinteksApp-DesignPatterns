using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinteksApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeMonthlySalesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSalesAmount",
                table: "EmployeeMonthlySales",
                newName: "TotalNetSalesAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ReturnedSalesAmount",
                table: "EmployeeMonthlySales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ReturnedSalesCount",
                table: "EmployeeMonthlySales",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSalesCount",
                table: "EmployeeMonthlySales",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnedSalesAmount",
                table: "EmployeeMonthlySales");

            migrationBuilder.DropColumn(
                name: "ReturnedSalesCount",
                table: "EmployeeMonthlySales");

            migrationBuilder.DropColumn(
                name: "TotalSalesCount",
                table: "EmployeeMonthlySales");

            migrationBuilder.RenameColumn(
                name: "TotalNetSalesAmount",
                table: "EmployeeMonthlySales",
                newName: "TotalSalesAmount");
        }
    }
}
