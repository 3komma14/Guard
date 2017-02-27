using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class EnumValidatorTests : BaseTests
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
        public void IsValidValue_ArgumentIsValidEnumValue_DoesNotThrow()
        {
            // Arrange
            var arg = Cars.Volvo;

            // Act/Assert
            Guard.That(arg).IsValidValue();
        }

        [Fact]
        public void IsValidValue_ArgumentIsInvalidEnumValue_DoesThrow()
        {
            // Arrange
            var arg = (Cars)(-1);

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).IsValidValue());
        }

        [Fact]
        public void HasFlagSet_ArgumentDoesNotHaveFlagSet_DoesThrow()
        {
            // Arrange
            var arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).HasFlagSet(CarParts.Engine));
        }

        [Fact]
        public void HasFlagSet_ArgumentDoesHaveFlagSet_DoesNotThrow()
        {
            // Arrange
            var arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Guard.That(arg).HasFlagSet(CarParts.Trunk);
        }

        public enum Cars
        {
            Volvo,
            Ferrari,
            Renault
        }

        [Flags]
        public enum CarParts
        {
            Doors = 1,
            Wheels = 2,
            Engine = 4,
            Trunk = 8
        }
    }
}
