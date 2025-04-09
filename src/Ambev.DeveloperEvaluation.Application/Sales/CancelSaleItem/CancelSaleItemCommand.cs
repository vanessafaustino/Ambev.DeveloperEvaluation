using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command for deleting a Sale
/// </summary>
public record CancelSaleItemCommand : IRequest<CancelSaleItemResponse>
{
    /// <summary>
    /// The unique identifier of the Sale that items belong
    /// </summary>
    public long SaleNumber { get; }

    /// <summary>
    /// The unique identifier of the Product
    /// </summary>
    public Guid ProductId { get; }

    /// <summary>
    /// The amount items to be cancelled
    /// </summary>
    public int QuantityToCancel { get; }

    /// <summary>
    /// Initializes a new instance of CancelSaleItemCommand
    /// </summary>
    /// <param name="saleNumber">The ID of the Sale</param>
    /// <param name="productId">The ID of the Product</param>
    /// <param name="quantityToCancel">The amount items to be cancelled</param>
    public CancelSaleItemCommand(long saleNumber, Guid productId, int quantityToCancel)
    {
        SaleNumber = saleNumber;
        ProductId = productId;
        QuantityToCancel = quantityToCancel;
    }
}
