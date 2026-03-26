using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SinteksApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleandDiscountTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusRule_BonusDefinition_BonusDefinitionId",
                table: "BonusRule");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandSubCompanyAssignment_Brands_BrandId",
                table: "BrandSubCompanyAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandSubCompanyAssignment_SubCompanies_SubCompanyId",
                table: "BrandSubCompanyAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountExcludedProduct_Discount_DiscountId",
                table: "DiscountExcludedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountExcludedProduct_Products_ProductId",
                table: "DiscountExcludedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBranchTransfer_Employee_EmployeeId",
                table: "EmployeeBranchTransfer");

            migrationBuilder.DropTable(
                name: "DiscountScopeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMonthlySalary",
                table: "EmployeeMonthlySalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeBranchTransfer",
                table: "EmployeeBranchTransfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountExcludedProduct",
                table: "DiscountExcludedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandSubCompanyAssignment",
                table: "BrandSubCompanyAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchMonthlySalesLimit",
                table: "BranchMonthlySalesLimit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusRule",
                table: "BonusRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusDefinition",
                table: "BonusDefinition");

            migrationBuilder.RenameTable(
                name: "EmployeeMonthlySalary",
                newName: "EmployeeMonthlySalaries");

            migrationBuilder.RenameTable(
                name: "EmployeeBranchTransfer",
                newName: "EmployeeBranchTransfers");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "DiscountExcludedProduct",
                newName: "DiscountExcludedProducts");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "BrandSubCompanyAssignment",
                newName: "BranchSubCompanyAssignments");

            migrationBuilder.RenameTable(
                name: "BranchMonthlySalesLimit",
                newName: "BranchMonthlySalesLimits");

            migrationBuilder.RenameTable(
                name: "BonusRule",
                newName: "BonusRules");

            migrationBuilder.RenameTable(
                name: "BonusDefinition",
                newName: "BonusDefinitions");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeBranchTransfer_EmployeeId",
                table: "EmployeeBranchTransfers",
                newName: "IX_EmployeeBranchTransfers_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountExcludedProduct_ProductId",
                table: "DiscountExcludedProducts",
                newName: "IX_DiscountExcludedProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountExcludedProduct_DiscountId",
                table: "DiscountExcludedProducts",
                newName: "IX_DiscountExcludedProducts_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSubCompanyAssignment_SubCompanyId",
                table: "BranchSubCompanyAssignments",
                newName: "IX_BranchSubCompanyAssignments_SubCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSubCompanyAssignment_BrandId",
                table: "BranchSubCompanyAssignments",
                newName: "IX_BranchSubCompanyAssignments_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BonusRule_BonusDefinitionId",
                table: "BonusRules",
                newName: "IX_BonusRules_BonusDefinitionId");

            migrationBuilder.AddColumn<decimal>(
                name: "NetPrice",
                table: "Sales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "AppliesToAllBranches",
                table: "Discounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppliesToAllBrands",
                table: "Discounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppliesToAllCategories",
                table: "Discounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppliesToAllProducts",
                table: "Discounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Discounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMonthlySalaries",
                table: "EmployeeMonthlySalaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeBranchTransfers",
                table: "EmployeeBranchTransfers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountExcludedProducts",
                table: "DiscountExcludedProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchSubCompanyAssignments",
                table: "BranchSubCompanyAssignments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchMonthlySalesLimits",
                table: "BranchMonthlySalesLimits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusRules",
                table: "BonusRules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusDefinitions",
                table: "BonusDefinitions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DiscountBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountBranches_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountBrands_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBranches_BranchId",
                table: "DiscountBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBranches_DiscountId",
                table: "DiscountBranches",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBrands_BrandId",
                table: "DiscountBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountBrands_DiscountId",
                table: "DiscountBrands",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_DiscountId",
                table: "DiscountCategories",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_ProductCategoryId",
                table: "DiscountCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_DiscountId",
                table: "DiscountProducts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_ProductId",
                table: "DiscountProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusRules_BonusDefinitions_BonusDefinitionId",
                table: "BonusRules",
                column: "BonusDefinitionId",
                principalTable: "BonusDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchSubCompanyAssignments_Brands_BrandId",
                table: "BranchSubCompanyAssignments",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchSubCompanyAssignments_SubCompanies_SubCompanyId",
                table: "BranchSubCompanyAssignments",
                column: "SubCompanyId",
                principalTable: "SubCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountExcludedProducts_Discounts_DiscountId",
                table: "DiscountExcludedProducts",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountExcludedProducts_Products_ProductId",
                table: "DiscountExcludedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBranchTransfers_Employees_EmployeeId",
                table: "EmployeeBranchTransfers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusRules_BonusDefinitions_BonusDefinitionId",
                table: "BonusRules");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchSubCompanyAssignments_Brands_BrandId",
                table: "BranchSubCompanyAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchSubCompanyAssignments_SubCompanies_SubCompanyId",
                table: "BranchSubCompanyAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountExcludedProducts_Discounts_DiscountId",
                table: "DiscountExcludedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountExcludedProducts_Products_ProductId",
                table: "DiscountExcludedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBranchTransfers_Employees_EmployeeId",
                table: "EmployeeBranchTransfers");

            migrationBuilder.DropTable(
                name: "DiscountBranches");

            migrationBuilder.DropTable(
                name: "DiscountBrands");

            migrationBuilder.DropTable(
                name: "DiscountCategories");

            migrationBuilder.DropTable(
                name: "DiscountProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMonthlySalaries",
                table: "EmployeeMonthlySalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeBranchTransfers",
                table: "EmployeeBranchTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountExcludedProducts",
                table: "DiscountExcludedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchSubCompanyAssignments",
                table: "BranchSubCompanyAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchMonthlySalesLimits",
                table: "BranchMonthlySalesLimits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusRules",
                table: "BonusRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonusDefinitions",
                table: "BonusDefinitions");

            migrationBuilder.DropColumn(
                name: "NetPrice",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "AppliesToAllBranches",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "AppliesToAllBrands",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "AppliesToAllCategories",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "AppliesToAllProducts",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeMonthlySalaries",
                newName: "EmployeeMonthlySalary");

            migrationBuilder.RenameTable(
                name: "EmployeeBranchTransfers",
                newName: "EmployeeBranchTransfer");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "DiscountExcludedProducts",
                newName: "DiscountExcludedProduct");

            migrationBuilder.RenameTable(
                name: "BranchSubCompanyAssignments",
                newName: "BrandSubCompanyAssignment");

            migrationBuilder.RenameTable(
                name: "BranchMonthlySalesLimits",
                newName: "BranchMonthlySalesLimit");

            migrationBuilder.RenameTable(
                name: "BonusRules",
                newName: "BonusRule");

            migrationBuilder.RenameTable(
                name: "BonusDefinitions",
                newName: "BonusDefinition");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeBranchTransfers_EmployeeId",
                table: "EmployeeBranchTransfer",
                newName: "IX_EmployeeBranchTransfer_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountExcludedProducts_ProductId",
                table: "DiscountExcludedProduct",
                newName: "IX_DiscountExcludedProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountExcludedProducts_DiscountId",
                table: "DiscountExcludedProduct",
                newName: "IX_DiscountExcludedProduct_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSubCompanyAssignments_SubCompanyId",
                table: "BrandSubCompanyAssignment",
                newName: "IX_BrandSubCompanyAssignment_SubCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchSubCompanyAssignments_BrandId",
                table: "BrandSubCompanyAssignment",
                newName: "IX_BrandSubCompanyAssignment_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BonusRules_BonusDefinitionId",
                table: "BonusRule",
                newName: "IX_BonusRule_BonusDefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMonthlySalary",
                table: "EmployeeMonthlySalary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeBranchTransfer",
                table: "EmployeeBranchTransfer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountExcludedProduct",
                table: "DiscountExcludedProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandSubCompanyAssignment",
                table: "BrandSubCompanyAssignment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchMonthlySalesLimit",
                table: "BranchMonthlySalesLimit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusRule",
                table: "BonusRule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonusDefinition",
                table: "BonusDefinition",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DiscountScopeItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<int>(type: "integer", nullable: true),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Scope = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountScopeItem", x => x.Id);
                    table.CheckConstraint("CK_DiscountScopeItems_ExactlyOneScope", "(\n                (CASE WHEN \"BranchId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"ProductId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"ProductCategoryId\" IS NULL THEN 0 ELSE 1 END) +\n                (CASE WHEN \"BrandId\" IS NULL THEN 0 ELSE 1 END)\n              ) = 1");
                    table.ForeignKey(
                        name: "FK_DiscountScopeItem_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountScopeItem_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountScopeItem_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountScopeItem_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountScopeItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountScopeItem_BranchId",
                table: "DiscountScopeItem",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountScopeItem_BrandId",
                table: "DiscountScopeItem",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountScopeItem_DiscountId",
                table: "DiscountScopeItem",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountScopeItem_ProductCategoryId",
                table: "DiscountScopeItem",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountScopeItem_ProductId",
                table: "DiscountScopeItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusRule_BonusDefinition_BonusDefinitionId",
                table: "BonusRule",
                column: "BonusDefinitionId",
                principalTable: "BonusDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSubCompanyAssignment_Brands_BrandId",
                table: "BrandSubCompanyAssignment",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSubCompanyAssignment_SubCompanies_SubCompanyId",
                table: "BrandSubCompanyAssignment",
                column: "SubCompanyId",
                principalTable: "SubCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountExcludedProduct_Discount_DiscountId",
                table: "DiscountExcludedProduct",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountExcludedProduct_Products_ProductId",
                table: "DiscountExcludedProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBranchTransfer_Employee_EmployeeId",
                table: "EmployeeBranchTransfer",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
