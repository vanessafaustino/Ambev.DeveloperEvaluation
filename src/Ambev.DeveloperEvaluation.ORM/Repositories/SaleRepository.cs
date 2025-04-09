using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Sale in the database
    /// </summary>
    /// <param name="Sale">The Sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale</returns>
    public async Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(Sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Sale;
    }

    /// <summary>
    /// Cancels a Sale in the database
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale to cancel</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Sale was canceled, false if not found or already canceled</returns>
    public async Task<bool> CancelAsync(long saleNumber, CancellationToken cancellationToken = default)
    {
        var sale = await GetBySaleNumberAsync(saleNumber, cancellationToken);
        if (sale == null)
            return false;
        if (sale.Status == Domain.Enums.SaleStatus.Cancelled)
            return false;

        sale.Canceled();
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Cancels a specific product item in a Sale
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale</param>
    /// <param name="productId">The unique identifier of the product to cancel</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product item was canceled, false otherwise</returns>
    public async Task<bool> CancelItemAsync(long saleNumber, Guid productId, CancellationToken cancellationToken = default)
    {
        var sale = await GetBySaleNumberAsync(saleNumber, cancellationToken);
        if (sale == null)
            return false;
        if (sale.Status == Domain.Enums.SaleStatus.Cancelled)
            return false;

        if (sale.Products.Any(p => p.Product.Id == productId))
        {
            var productItem = sale.Products.FirstOrDefault(p => p.Product.Id == productId);
            if (productItem != null)
            {
                productItem.IsCancelled = true;
            }
        }

        if (sale.Products.All(p => p.IsCancelled))
        {
            sale.Canceled();
        }

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates the quantity of a product in a Sale
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale</param>
    /// <param name="productId">The unique identifier of the product</param>
    /// <param name="quantity">The new quantity for the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated Sale object if successful, or null if the Sale or product was not found</returns>
    public async Task<Sale?> UpdateSaleProductItemQuantityAsync(long saleNumber, Guid productId, int quantity, CancellationToken cancellationToken = default)
    {
        var sale = await GetBySaleNumberAsync(saleNumber, cancellationToken);
        if (sale == null)
            return null;
        if (sale.Status == Domain.Enums.SaleStatus.Cancelled)
            return null;
        var productItem = sale.Products.FirstOrDefault(p => p.Product.Id == productId);
        if (productItem != null)
        {
            productItem.Quantity = quantity;
        }
        sale.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Retrieves a Sale by its unique identifier
    /// </summary>
    /// <param name="saleNumber">The unique identifier of the Sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sale if found, null otherwise</returns>
    public async Task<Sale?> GetBySaleNumberAsync(long saleNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(o => o.SaleNumber == saleNumber, cancellationToken);
    }

    /// <summary>
    /// Retrieves the last Sale number from the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The last Sale number</returns>
    public async Task<long> GetLastSaleNumber(CancellationToken cancellationToken = default)
    {
        return await _context.Sales.MaxAsync(s => s.SaleNumber);
    }
}
