using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new Sale in the repository.
    /// </summary>
    /// <param name="Sale">The Sale to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Sale.</returns>
    Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a sale by its unique sale number.
    /// </summary>
    /// <param name="saleNumber">The unique sale number to cancel.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the sale was successfully canceled, false otherwise.</returns>
    Task<bool> CancelAsync(long saleNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels a specific product item in a sale.
    /// </summary>
    /// <param name="saleNumber">The unique sale number containing the product item.</param>
    /// <param name="productId">The unique identifier of the product to cancel.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the product item was successfully canceled, false otherwise.</returns>
    Task<bool> CancelItemAsync(long saleNumber, Guid productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the quantity of a specific product item in a sale.
    /// </summary>
    /// <param name="saleNumber">The unique sale number containing the product item.</param>
    /// <param name="productId">The unique identifier of the product to update.</param>
    /// <param name="quantity">The new quantity for the product item.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated Sale object if successful, or null if the sale or product item was not found.</returns>
    Task<Sale?> UpdateSaleProductItemQuantityAsync(long saleNumber, Guid productId, int quantity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its unique sale number.
    /// </summary>
    /// <param name="saleNumber">The unique sale number to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Sale object if found, or null if not found.</returns>
    Task<Sale?> GetBySaleNumberAsync(long saleNumber, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the last sale number from the repository.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The last sale number.</returns>
    Task<long> GetLastSaleNumber(CancellationToken cancellationToken = default);
}
