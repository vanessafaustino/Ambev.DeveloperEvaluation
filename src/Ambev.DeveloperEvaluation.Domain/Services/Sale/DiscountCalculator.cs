using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.Sale
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(ProductItem product) 
            => product.Quantity switch
                                {
                                    > 10 and < 20 => product.Product.UnitPrice * 0.2m,
                                    > 4 => product.Product.UnitPrice * 0.1m,
                                    _ => 0,
                                };
        public bool IsDiscountApplicable(ProductItem product) => product.Quantity > 4;
    }
}
