using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Command for canceling a Sale.
/// </summary>
public record CancelSaleCommand : IRequest<CancelSaleResponse>
{
    /// <summary>
    /// Gets the unique identifier of the Sale to cancel.
    /// </summary>
    public long SaleNumber { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleCommand"/> class.
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale to cancel.</param>
    public CancelSaleCommand(long saleNumber)
    {
        SaleNumber = saleNumber;
    }
}
