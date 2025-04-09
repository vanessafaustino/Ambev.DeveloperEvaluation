using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleCommandValidator"/> class.
    /// </summary>
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

        RuleFor(x => x.BranchId)
            .NotEmpty()
            .WithMessage("Branch ID is required.");

        RuleFor(x =>x.Products)
            .NotEmpty()
            .WithMessage("At least one product is required.")
            .Must(x => x.Count > 0)
            .WithMessage("At least one product is required.");
    }
}