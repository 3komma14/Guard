using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class GuidValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void IsNotEmpty_ArgumentIsEmpty_Throws()
        {
            // Arrange
            var arg = Guid.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Fact]
        public void IsNotEmpty_ArgumentValidGuid_DoesNotThrow()
        {
            // Arrange
            var arg = Guid.NewGuid();

            // Act/Assert
            Guard.That(() => arg).IsNotEmpty();
        }

        #endregion Public Methods
    }
}
