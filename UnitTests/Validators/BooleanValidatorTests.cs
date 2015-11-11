using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests.Validators
{
    [TestFixture]
    public class BooleanValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        [TestFixtureTearDown]
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

        [Test]
        public void IsTrue_WhenArgumentIsTrue_DoesNotThrow()
        {
            // Arrange
            bool arg = true;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg).IsTrue();
            });
        }

        [Test]
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

        [Test]
        public void IsFalse_WhenArgumentIsFalse_DoesNotThrow()
        {
            // Arrange
            bool arg = false;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg).IsFalse();
            });
        }
    }
}
