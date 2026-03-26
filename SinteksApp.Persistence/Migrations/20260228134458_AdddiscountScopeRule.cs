using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinteksApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdddiscountScopeRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "DiscountScopeItem");

            migrationBuilder.AddCheckConstraint(
                name: "CK_DiscountScopeItems_ExactlyOneScope",
                table: "DiscountScopeItem",
                sql: "(\n                (CASE WHEN \"BranchId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"ProductId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"ProductCategoryId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"BrandId\" IS NULL THEN 0 ELSE 1 END)\n              ) = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_DiscountScopeItems_ExactlyOneScope",
                table: "DiscountScopeItem");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "DiscountScopeItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
