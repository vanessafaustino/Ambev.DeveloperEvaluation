using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - BranchId: Must be greater than 0
    /// - CustomerId: Must be greater than 0
    /// - Products: Must not be empty and each product must have:
    /// - ProductId: Must be greater than 0
    /// - Quantity: Must be greater than 0
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(Sale => Sale.BranchId).GreaterThan(0).WithMessage("BranchId must be greater than 0.");
        RuleFor(Sale => Sale.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than 0.");
        RuleFor(Sale => Sale.Products)
            .NotEmpty().WithMessage("Products list cannot be empty.")
            .ForEach(productRule =>
            {
                productRule.ChildRules(product =>
                {
                    product.RuleFor(p => p.ProductId)
                        .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
                    product.RuleFor(p => p.Quantity)
                        .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
                });
            });
    }
}