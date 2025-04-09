using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for canceling a Sale.
/// </summary>
public record UpdateSaleCommand : IRequest<UpdateSaleResponse>
{
    /// <summary>
    /// Gets the unique identifier of the Sale to cancel.
    /// </summary>
    public long SaleNumber { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the product in the sale.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in the sale.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleCommand"/> class.
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale to cancel.</param>
    public UpdateSaleCommand(long saleNumber)
    {
        SaleNumber = saleNumber;
    }
}
