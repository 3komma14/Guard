using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class ClassValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void NotNull_ArgumentIsNotNull_Throws()
        {
            // Arrange
            TestClass arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(() => arg).NotNull());
        }

        [Fact]
        public void NotNull_ArgumentIsNull_Throws()
        {
            // Arrange
            var arg = new TestClass();

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(() => arg).Null());
        }

        [Fact]
        public void NotNull_ArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            var arg = new TestClass();

            // Act/Assert
            Guard.That(() => arg).NotNull();
        }

        [Fact]
        public void Null_ArgumentNull_DoesNotThrow()
        {
            // Arrange
            TestClass arg = null;

            // Act/Assert
            Guard.That(() => arg).Null();
        }

        #endregion Public Methods

        #region Private Classes

        private class TestClass
        { }

        #endregion Private Classes
    }
}
