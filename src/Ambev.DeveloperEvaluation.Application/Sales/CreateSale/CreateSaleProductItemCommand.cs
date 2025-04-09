namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents a product item in the sale.
/// </summary>
public class CreateSaleProductItemCommand
{
    /// <summary>
    /// The product name or identifier.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product.
    /// </summary>
    public int Quantity { get; set; }
}