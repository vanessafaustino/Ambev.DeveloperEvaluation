using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemCommand
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
{
    /// <summary>
    /// Initializes validation rules for CancelSaleItemCommand
    /// </summary>
    public CancelSaleItemValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("Sale Number is required");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId is required");

        RuleFor(x => x.QuantityToCancel)
            .NotEmpty()
            .WithMessage("QuantityToCancel is required");
    }
}
