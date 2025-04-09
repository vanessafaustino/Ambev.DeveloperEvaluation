using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Sale
{
    public interface IDiscountCalculator
    {
        /// <summary>
        /// Calculates the discount for a given sale.
        /// </summary>
        /// <param name="product">ProductItem</param>
        /// <returns>The calculated discount amount.</returns>
        decimal CalculateDiscount(ProductItem product);
        /// <summary>
        /// Validates if the discount is applicable for the given sale.
        /// </summary>
        /// <param name="product">ProductItem</param>
        /// <returns>True if the discount is applicable, false otherwise.</returns>
        bool IsDiscountApplicable(ProductItem product);
    }
}
