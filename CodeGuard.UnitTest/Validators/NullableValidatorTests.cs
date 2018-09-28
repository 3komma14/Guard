using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class NullableValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void NotNull_ArgumentIsNull_Throws()
        {
            // Arrange
            int? arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(() => arg).NotNull());
        }

        [Fact]
        public void NotNull_ArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            int? arg = 1;

            // Act/Assert
            Guard.That(() => arg).NotNull();
        }

        #endregion Public Methods
    }
}
