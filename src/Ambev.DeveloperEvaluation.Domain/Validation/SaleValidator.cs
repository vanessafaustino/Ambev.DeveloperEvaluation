using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(Sale => Sale.Branch)
            .NotNull()
            .WithMessage("Branch ID is required.");

        RuleFor(Sale => Sale.Customer)
            .NotNull()
            .WithMessage("Customer ID is required.");

        RuleFor(Sale => Sale.Products)
            .NotEmpty()
            .WithMessage("Products list cannot be empty.")
            .ForEach(productRule => productRule.SetValidator(new ProductValidator()));
    }
}
