using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class IComparableValidatorTests
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
        public void IsGreaterThan_WhenArgumentIsLessThan_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsGreaterThan(arg2));

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
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsGreaterThan(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
        }

        [Test]
        public void IsGreaterThan_WhenArgumentIsGreather_DoesNotThrow()
        {
            // Arrange
            int arg1 = 1;
            int arg2 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.Check(() => arg1).IsGreaterThan(arg2);
            });
        }

        [Test]
        public void IsLessThan_WhenArgumentIsGreaterThan_Throws()
        {
            // Arrange
            int arg1 = 1;
            int arg2 = 0;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsLessThan(arg2));

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
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsLessThan(arg2));

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
                Guard.Check(() => arg1).IsLessThan(arg2);
            });
        }

        [Test]
        public void IsEqual_WhenArgumentIsNotEqual_Throws()
        {
            // Arrange
            int arg1 = 0;
            int arg2 = 1;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsEqual(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
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
                Guard.Check(() => arg1).IsEqual(arg2);
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
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg1).IsEqual(arg2));

            // Assert
            AssertArgumentOfRangeException(exception, "arg1");
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
                Guard.Check(() => arg1).IsEqual(arg2);
            });
        }

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
                Guard.Check(() => arg).IsInRange(start, stop);
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
                Guard.Check(() => arg).IsInRange(start, stop);
            });
        }

        [Test]
        public void IsInRange_WhenArgumentOutOfRange_Throws()
        {
            // Arrange
            DateTime arg = DateTime.Now.AddDays(-1);
            DateTime start = DateTime.Now;
            DateTime stop = DateTime.Now.AddDays(1);

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Guard.Check(() => arg).IsInRange(start, stop);
            });
        }


        #region ----- Helper functions -----

        private T GetException<T>(Action action) where T : Exception
        {
            T actualException = null;
            try
            {
                action();
            }
            catch (T ex)
            {
                actualException = ex;
            }

            return actualException;
        }

        private static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string message, string paramName, object actualValue)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(actualValue, exception.ActualValue);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: {1}\r\nActual value was {2}.", message, paramName, actualValue), exception.Message);
        }

        private static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(string.Format("Specified argument was out of the range of valid values.\r\nParameter name: {0}", paramName), exception.Message);
        }

        private static void AssertArgumentException(ArgumentException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        private static void AssertArgumentNullException(ArgumentNullException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        #endregion


    }
}
