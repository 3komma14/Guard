using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class EnumerableValidatorTests : BaseTests
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
        public void IsNotEmpty_ArgumentIsListWithItems_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>() { "Item1" };

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Test]
        public void IsNotEmpty_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Test]
        public void Contains_ArgumentContainsElement_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>() {"SomeItem"};

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).Contains(x => x == "SomeItem"));
        }

        [Test]
        public void Conatins_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).Contains(x => x == "SomeItem"));
        }

    }
}
