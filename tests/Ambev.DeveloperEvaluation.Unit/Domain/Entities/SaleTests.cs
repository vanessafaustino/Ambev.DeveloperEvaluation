using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        private readonly Faker<Sale> _saleFaker;

        public SaleTests()
        {
            _saleFaker = new Faker<Sale>()
                .RuleFor(s => s.SaleNumber, f => f.Random.Long(1, 1000))
                .RuleFor(s => s.Customer, f => new Customer { Name = f.Person.FullName })
                .RuleFor(s => s.Branch, f => new Branch { Name = f.Company.CompanyName() })
                .RuleFor(s => s.Products, f => new List<ProductItem>
                {
                    new ProductItem
                    {
                        Product = new Product { Name = f.Commerce.ProductName(), UnitPrice = f.Random.Decimal(1, 100) },
                        Quantity = f.Random.Int(1, 10),
                        Discount = f.Random.Decimal(0, 10),
                        IsCancelled = false
                    }
                })
                .RuleFor(s => s.Status, f => f.PickRandom<SaleStatus>());
        }

        [Fact]
        public void Sale_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var sale = new Sale();

            // Assert
            sale.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            sale.Status.Should().Be(SaleStatus.Created);
        }

        [Fact]
        public void TotalAmount_ShouldCalculateCorrectly()
        {
            // Arrange
            var sale = _saleFaker.Generate();

            // Act
            var totalAmount = sale.TotalAmount;

            // Assert
            totalAmount.Should().Be(sale.Products.Sum(p => p.TotalAmount));
        }

        [Fact]
        public void Canceled_ShouldUpdateStatusAndUpdatedAt()
        {
            // Arrange
            var sale = _saleFaker.Generate();

            // Act
            sale.Canceled();

            // Assert
            sale.Status.Should().Be(SaleStatus.Cancelled);
            sale.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }
    }
}
