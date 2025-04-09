namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Request model for deleting a Sale
/// </summary>
public class CancelSaleRequest
{
    /// <summary>
    /// The unique identifier of the Sale to Cancel
    /// </summary>
    public long SaleNumber { get; set; }
}
