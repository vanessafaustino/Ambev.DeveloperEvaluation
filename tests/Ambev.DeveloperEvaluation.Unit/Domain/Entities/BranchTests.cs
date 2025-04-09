using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class BranchTests
    {
        private readonly Faker<Branch> _branchFaker;

        public BranchTests()
        {
            _branchFaker = new Faker<Branch>()
                .RuleFor(b => b.Name, f => f.Company.CompanyName());
        }

        [Fact]
        public void Branch_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var branch = new Branch();

            // Assert
            branch.Name.Should().BeNull();
        }

        [Fact]
        public void Branch_ShouldSetNameCorrectly()
        {
            // Arrange
            var branch = _branchFaker.Generate();

            // Act & Assert
            branch.Name.Should().NotBeNullOrEmpty();
        }
    }
}
