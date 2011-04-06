using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class StringValidatorTests
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
        public void NotNull_WhenStringArgumentIsNull_Throws()
        {

            // Arrange
            string arg = null;

            // Act
            ArgumentNullException exception =
                GetException<ArgumentNullException>(() => Guard.Check(() => arg).IsNotNull());
                
            // Assert
            AssertArgumentNullException(exception, "arg", "Value cannot be null.\r\nParameter name: arg");
        }

        [Test]
        public void NotNull_WhenArgumentIsNotNull_DoesNotThrow()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => text).IsNotNull());
        }

        [Test]
        public void NotEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            string arg = string.Empty;

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.Check(() => arg).IsNotEmpty());

            // Assert
            AssertArgumentException(exception, "arg", "String is empty\r\nParameter name: arg");
        }

        [Test]
        public void NotEmpty_WhenArgumentIsNotEmpty_DoesNotThrow()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.Check(() => text).IsNotEmpty();
            });
        }

        [Test]
        public void NotEmpty_WhenArgumentIsNull_DoesNotThrow()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.Check(() => text).IsNotEmpty();
            });
        }

        [Test]
        public void NotNullOrEmpty_WhenArgumentIsValid_DoesNotThrow()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.Check(() => text).IsNotNullOrEmpty();
            });
        }

        [Test]
        public void NotNullOrEmpty_WhenArgumentIsNull_Throws()
        {
            // Arrange
            string text = null;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).IsNotNullOrEmpty());
        }

        [Test]
        public void NotNullOrEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).IsNotNullOrEmpty());
        }

        [Test]
        public void Contains_ArgumentContainsValue_DoesNotThrow()
        {
            // Arrange
            var text = "big brown car";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => text).Contains("brown"));
        }

        [Test]
        public void Contains_ArgumentContainsValueWrongCase_Throws()
        {
            // Arrange
            var text = "BIG BROWN CAR";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).Contains("brown"));
        }

        [Test]
        public void Contains_ArgumentDoesNotContainValue_Throws()
        {
            // Arrange
            var text = "Yellow Submarine";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).Contains("brown"));
        }

        [Test]
        public void Length_ArgumentHasSameLength_DoesNotThrow()
        {
            // Arrange
            var text = "0123456789";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => text).Length(10));
        }

        [Test]
        public void Length_ArgumentHasDifferentLength_Throws()
        {
            // Arrange
            var text = "0123";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).Length(10));
        }

        [Test]
        public void StartsWith_ArgumentStartsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "Start of string";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => text).StartsWith("Start"));
        }

        [Test]
        public void StartsWith_ArgumentDoesNotStartWithValue_Throws()
        {
            // Arrange
            var text = "Some string";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).StartsWith("Start"));
        }

        [Test]
        public void EndsWith_ArgumentEndsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.Check(() => text).EndsWith("near"));
        }

        [Test]
        public void EndsWith_ArgumentDoesNotEndWithValue_Throws()
        {
            // Arrange
            var text = "The end is near";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.Check(() => text).EndsWith("Start"));
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
