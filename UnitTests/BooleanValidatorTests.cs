using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class BooleanValidatorTests
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
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg).IsTrue());

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
                Guard.Check(() => arg).IsTrue();
            });
        }

        [Test]
        public void IsFalse_WhenArgumentIsTrue_Throws()
        {
            // Arrange
            bool arg = true;

            // Act
            ArgumentOutOfRangeException exception =
                GetException<ArgumentOutOfRangeException>(() => Guard.Check(() => arg).IsFalse());

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
                Guard.Check(() => arg).IsFalse();
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
