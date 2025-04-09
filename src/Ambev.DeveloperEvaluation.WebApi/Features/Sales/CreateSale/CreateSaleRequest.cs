namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// The customer associated with the sale.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// The branch where the sale was made.
    /// </summary>
    public int BranchId { get; set; }

    /// <summary>
    /// The list of products included in the sale.
    /// </summary>
    public List<ProductItemRequest> Products { get; set; } = new();

    /// <summary>
    /// Represents a product item in the sale.
    /// </summary>
    public class ProductItemRequest
    {
        /// <summary>
        /// The product name or identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The quantity of the product.
        /// </summary>
        public int Quantity { get; set; }
    }

}
