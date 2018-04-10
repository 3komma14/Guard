using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests.Validators
{
    [TestFixture]
    public class ComparableValidatorTests : BaseTests
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

        #region IsGreaterThan

        [Test]
        public void IsGreaterThan_WhenArgumentIsLessThan_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsGreaterThan(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsGreaterThan_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsGreaterThan(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsGreaterThan_WhenArgumentIsGreather_DoesNotThrow()
        {
            // Arrange
            double arg1 = 1;
            double arg2 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsGreaterThan(arg2);
            });
        }

        #endregion

        #region IsGreaterThanOrEqual

        [Test]
        public void IsGreaterThanOrEqual_WhenArgumentIsLessThan_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsGreaterThanOrEqualTo(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsGreaterThanOrEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act
            // Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg1).IsGreaterThanOrEqualTo(arg2));
        }

        [Test]
        public void IsGreaterThanOrEqual_WhenArgumentIsGreather_DoesNotThrow()
        {
            // Arrange
            double arg1 = 1;
            double arg2 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsGreaterThanOrEqualTo(arg2);
            });
        }

        #endregion

        #region IsLessThan

        [Test]
        public void IsLessThan_WhenArgumentIsGreaterThan_Throws()
        {
            // Arrange
            int arg1 = 1;
            int arg2 = 0;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsLessThan(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsLessThan_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsLessThan(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsLessThan_WhenArgumentIsLess_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsLessThan(arg2);
            });
        }

        #endregion

        #region IsLessThanOrEqualTo

        [Test]
        public void IsLessThanOrEqual_WhenArgumentIsGreaterThan_Throws()
        {
            // Arrange
            int arg1 = 1;
            int arg2 = 0;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsLessThanOrEqualTo(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsLessThanOrEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act
            // Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg1).IsLessThanOrEqualTo(arg2));
        }

        [Test]
        public void IsLessThanOrEqual_WhenArgumentIsLess_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsLessThanOrEqualTo(arg2);
            });
        }

        #endregion

        #region IsEqual

        [Test]
        public void IsEqual_WhenArgumentIsNotEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsEqual(arg2));

            // Assert
            AssertArgumentNotEqualException(exception, "arg1", arg1, arg2);
        }


        [Test]
        public void IsEqual_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsEqual(arg2);
            });
        }

        [Test]
        public void IsEqual2_WhenArgumentIsNotEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg1).IsEqual(arg2));

            // Assert
            AssertArgumentNotEqualException(exception, "arg1", arg1, arg2);
        }

        [Test]
        public void IsEqual2_WhenArgumentIsEqual_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsEqual(arg2);
            });
        }

        #endregion

        #region IsNotEqual

        [Test]
        public void IsNotEqual_WhenFuncArgumentIsEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Guard.That(() => arg1).IsNotEqual(() => arg2);
            });
        }

        [Test]
        public void IsNotEqual_WhenArgumentIsEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Guard.That(() => arg1).IsNotEqual(arg2);
            });
        }

        #endregion

        [Test]
        public void IsInRange_WhenArgumentBetweenStartAndStop_DoesNotThrow()
        {
            // Arrange
            DateTime arg = DateTime.Now;
            DateTime start = DateTime.Now.AddDays(-1);
            DateTime stop = DateTime.Now.AddDays(1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg).IsInRange(start, stop);
            });
        }

        [Test]
        public void IsInRange_WhenArgumentEqualsStart_DoesNotThrow()
        {
            // Arrange
            DateTime arg = DateTime.Now;
            DateTime start = arg;
            DateTime stop = DateTime.Now.AddDays(1);

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg).IsInRange(start, stop);
            });
        }

        [Test]
        public void IsInRange_WhenArgumentOutOfRange_Throws()
        {
            // Arrange
            DateTime arg = DateTime.Now.AddDays(-1);
            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now.AddDays(1);

            //// Act/Assert
            //Assert.Throws<ArgumentOutOfRangeException>(() =>
            //{
            //    Guard.That(() => arg).IsInRange(start, stop);
            //});


            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.That(() => arg).IsInRange(start, stop));

            // Assert
            AssertArgumentOfRangeException(exception, "arg", arg, start, stop);

        }
    }
}
