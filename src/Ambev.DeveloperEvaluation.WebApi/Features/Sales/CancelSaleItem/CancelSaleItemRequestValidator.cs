using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemRequest
/// </summary>
public class CancelSaleItemRequestValidator : AbstractValidator<CancelSaleItemRequest>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleItemRequest
    /// </summary>
    public CancelSaleItemRequestValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("Sale Number is required");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product Item is required");
    }
}
