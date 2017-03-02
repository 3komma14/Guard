using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;
using ArgumentException = BarsGroup.CodeGuard.Exceptions.ArgumentException;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class GuidValidatorTests : BaseTests
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
        public void IsNotEmpty_ArgumentValidGuid_DoesNotThrow()
        {
            // Arrange
            var arg = Guid.NewGuid();

            // Act/Assert
            Guard.That(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_ArgumentIsEmpty_Throws()
        {
            // Arrange
            var arg = Guid.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).IsNotEmpty());
        }
    }
}
