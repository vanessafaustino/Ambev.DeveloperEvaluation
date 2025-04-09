using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product item in the sale.
/// </summary>
public class ProductItem : BaseEntity
{
    /// <summary>
    /// The product name or identifier.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// The quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    public bool IsCancelled { get; set; }

    /// <summary>
    /// The total amount for the product (calculated as Quantity * UnitPrice - Discount).
    /// </summary>
    public decimal TotalAmount => (Quantity * Product.UnitPrice) - Discount;
}