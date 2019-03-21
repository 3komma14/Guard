using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests.Validators
{
    [TestFixture]
    public class EnumValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        [OneTimeTearDown]
        public void Cleanup()
        {
            // Cleanup tests
        }

        #endregion

        #region ------ Test setup -----

        /// <summary>
        /// Called before each test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Setup test
        }

        /// <summary>
        /// Called before each test
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Cleanup after test       
        }

        #endregion

        [Test]
        public void IsValidValue_ArgumentIsValidEnumValue_DoesNotThrow()
        {
            // Arrange
            var arg = Cars.Volvo;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsValidValue());
        }

        [Test]
        public void IsValidValue_ArgumentIsInvalidEnumValue_DoesThrow()
        {
            // Arrange
            var arg = (Cars)(-1);

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsValidValue());
        }

        [Test]
        public void HasFlagSet_ArgumentDoesNotHaveFlagSet_DoesThrow()
        {
            // Arrange
            CarParts arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).HasFlagSet(CarParts.Engine));
        }

        [Test]
        public void HasFlagSet_ArgumentDoesHaveFlagSet_DoesNotThrow()
        {
            // Arrange
            CarParts arg = CarParts.Doors | CarParts.Trunk;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).HasFlagSet(CarParts.Trunk));
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
