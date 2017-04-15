using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{

    public class BooleanValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        public void Cleanup()
        {
            // Cleanup tests
        }

        #endregion

        #region ------ Test setup -----

        /// <summary>
        /// Called before each test
        /// </summary>
        public void Setup()
        {
            // Setup test
        }

        /// <summary>
        /// Called before each test
        /// </summary>
        public void TearDown()
        {
            // Cleanup after test       
        }

        #endregion

        [Fact]
        public void IsTrue_WhenArgumentIsFalse_Throws()
        {
            // Arrange
            var arg = false;

            // Act
            var exception =
                GetException<NotExpectedException<bool>>(() => Guard.That(arg, nameof(arg)).IsTrue());

            // Assert
            AssertNotExpectedException(exception, "arg", arg, true);
        }

        [Fact]
        public void IsTrue_WhenArgumentIsTrue_DoesNotThrow()
        {
            // Arrange
            var arg = true;

            // Act/Assert
            Guard.That(arg).IsTrue();
        }

        [Fact]
        public void IsFalse_WhenArgumentIsTrue_Throws()
        {
            // Arrange
            var arg = true;

            // Act
            var exception =
                GetException<NotExpectedException<bool>>(() => Guard.That(arg, nameof(arg)).IsFalse());

            // Assert
            AssertNotExpectedException(exception, "arg", arg, false);
        }

        [Fact]
        public void IsFalse_WhenArgumentIsFalse_DoesNotThrow()
        {
            // Arrange
            var arg = false;

            // Act/Assert
            Guard.That(arg).IsFalse();
        }
    }
}
