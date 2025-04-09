using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class Sale : BaseEntity
{
    private decimal totalAmount;

    /// <summary>
    /// The unique sale number.
    /// </summary>
    public long SaleNumber { get; set; }

    /// <summary>
    /// The date when the sale was made.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// The last update date to the sale.
    /// </summary>
    public DateTime? UpdatedAt { get; set; } = null;

    /// <summary>
    /// The customer associated with the sale.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// The total sale amount.
    /// </summary>
    public decimal TotalAmount
    {
        get => totalAmount = Products.Sum(p => p.TotalAmount); set => totalAmount = value;
    }

    /// <summary>
    /// The branch where the sale was made.
    /// </summary>
    public Branch Branch { get; set; }

    /// <summary>
    /// The list of products included in the sale.
    /// </summary>
    public List<ProductItem> Products { get; set; } = new();

    /// <summary>
    /// The sale status.
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        Status = SaleStatus.Created;
    }

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">BranchId requirement</list>
    /// <list type="bullet">CustomerId requirement</list>
    /// <list type="bullet">ProductId requirement</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Cancel the Sale.
    /// Changes the Sale's status to Cancelled.
    /// </summary>
    public void Canceled()
    {
        Status = SaleStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }

}