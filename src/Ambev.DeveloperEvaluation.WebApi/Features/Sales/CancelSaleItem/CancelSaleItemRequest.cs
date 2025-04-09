namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Request model for deleting a Sale
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the Sale to Cancel
    /// </summary>
    public long SaleNumber { get; set; }
    /// <summary>
    /// The unique identifier of the Sale Item to Cancel
    /// </summary>
    public Guid ProductId { get; set; }
}
