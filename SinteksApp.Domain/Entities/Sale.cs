using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Sale : BaseEntity
{
    public int BranchId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal BasePrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public decimal NetPrice { get; set; }
    public decimal DiscountPercent { get; set; }
    public int EmployeeId { get; set; }
    public int? CustomerId { get; set; }
    
    public DateTime SaleDate { get; set; }
    public bool IsReturned { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Branch Branch { get; set; }
    public Product Product { get; set; }
}
