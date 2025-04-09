using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Sale;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Services.Sale
{
    public class DiscountCalculatorTests
    {
        private readonly DiscountCalculator _discountCalculator;
        private readonly Faker<ProductItem> _productItemFaker;

        public DiscountCalculatorTests()
        {
            _discountCalculator = new DiscountCalculator();
            _productItemFaker = new Faker<ProductItem>()
                .RuleFor(p => p.Product, f => new Product { UnitPrice = f.Random.Decimal(1, 100) })
                .RuleFor(p => p.Quantity, f => f.Random.Int(1, 30));
        }

        [Theory]
        [InlineData(5, 0.1)]
        [InlineData(15, 0.2)]
        [InlineData(3, 0)]
        public void CalculateDiscount_ShouldReturnCorrectDiscount(int quantity, decimal expectedDiscountRate)
        {
            // Arrange
            var productItem = _productItemFaker.Generate();
            productItem.Quantity = quantity;
            var expectedDiscount = productItem.Product.UnitPrice * expectedDiscountRate;

            // Act
            var discount = _discountCalculator.CalculateDiscount(productItem);

            // Assert
            discount.Should().Be(expectedDiscount);
        }

        [Theory]
        [InlineData(5, true)]
        [InlineData(15, true)]
        [InlineData(3, false)]
        public void IsDiscountApplicable_ShouldReturnCorrectResult(int quantity, bool expectedResult)
        {
            // Arrange
            var productItem = _productItemFaker.Generate();
            productItem.Quantity = quantity;

            // Act
            var result = _discountCalculator.IsDiscountApplicable(productItem);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}

