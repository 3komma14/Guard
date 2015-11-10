using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class IntegerValidatorTests : BaseTests
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
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsOdd());
        }

        [Test]
        public void IsOdd_ArgumentIsEven_Throws()
        {
            // Arrange
            int arg = 2;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsOdd());
        }

        [Test]
        public void IsEven_ArgumentIsEven_DoesNotThrow()
        {
            // Arrange
            int arg = 4;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsEven());
        }

        [Test]
        public void IsEven_ArgumentIsOdd_Throws()
        {
            // Arrange
            int arg = 5;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsEven());
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void IsPrime_ArgumentIsPrime_DoesNotThrow(int arg)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsPrime());
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(4)]
        public void IsPrime_ArgumentIsNotPrime_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPrime());
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPositive());
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void IsPositive_ArgumentIsNotPositive_Throws(long arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsPositive());
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow(int arg)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsPositive());
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(20)]
        public void IsPositive_ArgumentIsPositive_DoesNotThrow(long arg)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsPositive());
        }

        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws(int arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsNegative());
        }

        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        public void IsPositive_ArgumentIsNotNegative_Throws(long arg)
        {
            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsNegative());
        }

        [TestCase(-2)]
        [TestCase(-3)]
        [TestCase(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow(int arg)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsNegative());
        }

        [TestCase(-2)]
        [TestCase(-3)]
        [TestCase(-20)]
        public void IsPositive_ArgumentIsNegative_DoesNotThrow(long arg)
        {
            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).IsNegative());
        }
    }
}
