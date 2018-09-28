using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class BooleanValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void IsFalse_WhenArgumentIsFalse_DoesNotThrow()
        {
            // Arrange
            bool arg = false;

            // Act/Assert
            Guard.That(() => arg).IsFalse();
        }

        [Fact]
        public void IsFalse_WhenArgumentIsTrue_Throws()
        {
            // Arrange
            bool arg = true;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsFalse());

            // Assert
            AssertArgumentOfRangeException(exception, "arg");
        }

        [Fact]
        public void IsTrue_WhenArgumentIsFalse_Throws()
        {
            // Arrange
            bool arg = false;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsTrue());

            // Assert
            AssertArgumentOfRangeException(exception, "arg");
        }

        [Fact]
        public void IsTrue_WhenArgumentIsTrue_DoesNotThrow()
        {
            // Arrange
            bool arg = true;

            // Act/Assert
            Guard.That(() => arg).IsTrue();
        }

        #endregion Public Methods
    }
}
