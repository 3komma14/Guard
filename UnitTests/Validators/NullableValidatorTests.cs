using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests.Validators
{
    [TestFixture]
    public class NullableValidatorTests : BaseTests
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
        public void IsNotNull_ArgumentIsNotNull_DoesNotThrow()
        {
            // Arrange
            int? arg = 1;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsNotNull());
        }

        [Test]
        public void IsNotNull_ArgumentIsNull_Throws()
        {
            // Arrange
            int? arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(() => arg).IsNotNull());
        }
    }
}
