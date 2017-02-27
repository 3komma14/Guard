using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class NullableValidatorTests : BaseTests
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
        public void NotNull_ArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            int? arg = 1;

            // Act/Assert
            Guard.That(arg).IsNotNull();
        }

        [Fact]
        public void NotNull_ArgumentIsNull_Throws()
        {
            // Arrange
            int? arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(arg).IsNotNull());
        }
    }
}
