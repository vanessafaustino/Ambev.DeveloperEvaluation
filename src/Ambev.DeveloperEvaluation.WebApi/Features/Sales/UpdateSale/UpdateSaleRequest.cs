namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;


/// <summary>
/// Represents a request to update a sale.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// Gets or sets the unique sale number.
    /// </summary>
    public long SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product associated with the sale.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in the sale.
    /// </summary>
    public int Quantity { get; set; }
}
