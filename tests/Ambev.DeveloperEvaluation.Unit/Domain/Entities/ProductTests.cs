using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        private readonly Faker<Product> _productFaker;

        public ProductTests()
        {
            _productFaker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(1, 100));
        }

        [Fact]
        public void Product_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var product = new Product();

            // Assert
            product.Name.Should().BeNull();
            product.UnitPrice.Should().Be(0);
        }

        [Fact]
        public void Product_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var product = _productFaker.Generate();

            // Act & Assert
            product.Name.Should().NotBeNullOrEmpty();
            product.UnitPrice.Should().BeGreaterThan(0);
        }
    }
}
