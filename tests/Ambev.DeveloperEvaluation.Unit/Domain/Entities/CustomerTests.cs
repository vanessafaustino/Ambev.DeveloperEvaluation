using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class CustomerTests
    {
        private readonly Faker<Customer> _customerFaker;

        public CustomerTests()
        {
            _customerFaker = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Person.FullName);
        }

        [Fact]
        public void Customer_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var customer = new Customer();

            // Assert
            customer.Name.Should().BeNull();
        }

        [Fact]
        public void Customer_ShouldSetNameCorrectly()
        {
            // Arrange
            var customer = _customerFaker.Generate();

            // Act & Assert
            customer.Name.Should().NotBeNullOrEmpty();
        }
    }
}
