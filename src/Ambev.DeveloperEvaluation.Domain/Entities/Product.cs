using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class Product : BaseEntity
{
    /// <summary>
    /// Name of the product
    /// </summary>
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// The unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }
}