using Microsoft.EntityFrameworkCore;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Context;

public class SinteksAppDbContext : DbContext
{
    public SinteksAppDbContext(DbContextOptions<SinteksAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SubCompany> SubCompanies { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<BranchProductAssortment> BranchProductAssortments { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public DbSet<BonusDefinition> BonusDefinitions { get; set; }
    public DbSet<BonusRule> BonusRules { get; set; }
    public DbSet<BranchMonthlySalesLimit> BranchMonthlySalesLimits { get; set; }
    public DbSet<BrandSubCompanyAssignment> BranchSubCompanyAssignments { get; set; }

    public DbSet<Discount> Discounts { get; set; }
    public DbSet<DiscountBranch> DiscountBranches { get; set; }
    public DbSet<DiscountBrand> DiscountBrands { get; set; }
    public DbSet<DiscountCategory> DiscountCategories { get; set; }
    public DbSet<DiscountExcludedProduct> DiscountExcludedProducts { get; set; }
    public DbSet<DiscountProduct> DiscountProducts { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeBranchTransfer> EmployeeBranchTransfers { get; set; }
    public DbSet<EmployeeMonthlySalary> EmployeeMonthlySalaries { get; set; }
    public DbSet<EmployeeMonthlySales> EmployeeMonthlySales { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SinteksAppDbContext).Assembly);
    }
}