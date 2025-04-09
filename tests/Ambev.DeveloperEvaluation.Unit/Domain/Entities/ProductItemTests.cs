using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductItemTests
    {
        private readonly Faker<ProductItem> _productItemFaker;

        public ProductItemTests()
        {
            _productItemFaker = new Faker<ProductItem>()
                .RuleFor(p => p.Product, f => new Product { Name = f.Commerce.ProductName(), UnitPrice = f.Random.Decimal(1, 100) })
                .RuleFor(p => p.Quantity, f => f.Random.Int(1, 10))
                .RuleFor(p => p.Discount, f => f.Random.Decimal(0, 10))
                .RuleFor(p => p.IsCancelled, f => false);
        }

        [Fact]
        public void ProductItem_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var productItem = new ProductItem();

            // Assert
            productItem.Product.Should().BeNull();
            productItem.Quantity.Should().Be(0);
            productItem.Discount.Should().Be(0);
            productItem.IsCancelled.Should().BeFalse();
        }

        [Fact]
        public void TotalAmount_ShouldCalculateCorrectly()
        {
            // Arrange
            var productItem = _productItemFaker.Generate();
            var expectedTotalAmount = productItem.Quantity * productItem.Product.UnitPrice - productItem.Discount;

            // Act
            var totalAmount = productItem.TotalAmount;

            // Assert
            totalAmount.Should().Be(expectedTotalAmount);
        }
    }
}
