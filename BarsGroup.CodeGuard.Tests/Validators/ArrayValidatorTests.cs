using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class ArrayValidatorTests
    {
        [Fact]
        public void IsEmpty_ArgumentIsNotEmptyArray_DoesNotThrow()
        {
            // Arrange
            var arg = new[] { "item1" };

            // Act/Assert
            Guard.That(arg).IsNotEmpty();
        }

        [Fact]
        public void IsEmpty_ArgumentIsEmptyArray_Throws()
        {
            // Arrange
            var arg = new string[0];

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).IsNotEmpty());
        }

        [Fact]
        public void CountIs_ArgumentHasMoreItems_Throws()
        {
            // Arrange
            var arg = new[] { "item1", "item2" };

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(arg).CountIs(1));
        }

        [Fact]
        public void CountIs_ArgumentHasCorrectCount_DoesNotThrow()
        {
            // Arrange
            var arg = new[] { "item1", "item2" };

            // Act/Assert
            Guard.That(arg).CountIs(2);
        }
    }
}
