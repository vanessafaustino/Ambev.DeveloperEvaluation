using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    internal class ProductValidator : AbstractValidator<ProductItem>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Product)
                .NotEmpty()
                .WithMessage("Product ID is required");

            RuleFor(p => p.Quantity)
                .NotEmpty()
                .WithMessage("Quantity is required")
                .GreaterThan(0)
                .WithMessage("Quantity must be a valid positive integer")
                .LessThanOrEqualTo(20)
                .WithMessage("Quantity must be less than or equal to 20");
        }
    }
}