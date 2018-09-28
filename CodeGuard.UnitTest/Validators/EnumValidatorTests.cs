using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class EnumValidatorTests : BaseTests
    {
        #region Public Enums

        [Flags]
        public enum CarParts
        {
            Doors = 1,
            Wheels = 2,
            Engine = 4,
            Trunk = 8
        }

        public enum Cars
        {
            Volvo,
            Ferrari,
            Renault
        }

        #endregion Public Enums

        #region Public Methods

        [Fact]
        public void HasFlagSet_ArgumentDoesHaveFlagSet_DoesNotThrow()
        {
            // Arrange
            CarParts arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Guard.That(() => arg).HasFlagSet(CarParts.Trunk);
        }

        [Fact]
        public void HasFlagSet_ArgumentDoesNotHaveFlagSet_DoesThrow()
        {
            // Arrange
            CarParts arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).HasFlagSet(CarParts.Engine));
        }

        [Fact]
        public void IsValidValue_ArgumentIsInvalidEnumValue_DoesThrow()
        {
            // Arrange
            var arg = (Cars)(-1);

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsValidValue());
        }

        [Fact]
        public void IsValidValue_ArgumentIsValidEnumValue_DoesNotThrow()
        {
            // Arrange
            var arg = Cars.Volvo;

            // Act/Assert
            Guard.That(() => arg).IsValidValue();
        }

        #endregion Public Methods
    }
}
