using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class IntegerValidatorTests
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
        public void IsOdd_ArgumentIsOdd_DoesNotThrow()
        {
            // Arrange
            int arg = 3;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => arg).IsOdd());
        }

        [Test]
        public void IsOdd_ArgumentIsEven_Throws()
        {
            // Arrange
            int arg = 2;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Check(() => arg).IsOdd());
        }

        [Test]
        public void IsEven_ArgumentIsEven_DoesNotThrow()
        {
            // Arrange
            int arg = 4;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => arg).IsEven());
        }

        [Test]
        public void IsEven_ArgumentIsOdd_Throws()
        {
            // Arrange
            int arg = 5;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Check(() => arg).IsEven());
        }
    }
}
