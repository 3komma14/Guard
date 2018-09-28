using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class ArrayValidatorTests
    {
        #region Public Methods

        [Fact]
        public void CountIs_ArgumentHasCorrectCount_DoesNotThrow()
        {
            // Arrange
            var arg = new string[] { "item1", "item2" };

            // Act/Assert
            Guard.That(() => arg).CountIs(2);
        }

        [Fact]
        public void CountIs_ArgumentHasMoreItems_Throws()
        {
            // Arrange
            var arg = new string[] { "item1", "item2" };

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).CountIs(1));
        }

        [Fact]
        public void IsEmpty_ArgumentIsEmptyArray_Throws()
        {
            // Arrange
            var arg = new string[0];

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Fact]
        public void IsEmpty_ArgumentIsNotEmptyArray_DoesNotThrow()
        {
            // Arrange
            var arg = new string[] { "item1" };

            // Act/Assert
            Guard.That(() => arg).IsNotEmpty();
        }

        #endregion Public Methods
    }
}
