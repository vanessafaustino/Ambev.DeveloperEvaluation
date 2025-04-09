using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents customer entity.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// The unique customer name.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}