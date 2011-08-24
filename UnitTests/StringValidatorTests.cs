using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class StringValidatorTests : BaseTests
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
                GetException<ArgumentNullException>(() => Guard.That(() => arg).IsNotNull());
                
            // Assert
            AssertArgumentNullException(exception, "arg", "Value cannot be null.\r\nParameter name: arg");
        }

        [Test]
        public void NotNull_WhenArgumentIsNotNull_DoesNotThrow()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).IsNotNull());
        }

        [Test]
        public void NotEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            string arg = string.Empty;

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());

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
                Guard.That(() => text).IsNotEmpty();
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
                Guard.That(() => text).IsNotEmpty();
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
                Guard.That(() => text).IsNotNullOrEmpty();
            });
        }

        [Test]
        public void NotNullOrEmpty_WhenArgumentIsNull_Throws()
        {
            // Arrange
            string text = null;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsNotNullOrEmpty());
        }

        [Test]
        public void NotNullOrEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsNotNullOrEmpty());
        }

        [Test]
        public void Contains_ArgumentContainsValue_DoesNotThrow()
        {
            // Arrange
            var text = "big brown car";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).Contains("brown"));
        }

        [Test]
        public void Contains_ArgumentContainsValueWrongCase_Throws()
        {
            // Arrange
            var text = "BIG BROWN CAR";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Contains("brown"));
        }

        [Test]
        public void Contains_ArgumentDoesNotContainValue_Throws()
        {
            // Arrange
            var text = "Yellow Submarine";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Contains("brown"));
        }

        [Test]
        public void Length_ArgumentHasSameLength_DoesNotThrow()
        {
            // Arrange
            var text = "0123456789";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).Length(10));
        }

        [Test]
        public void Length_ArgumentHasDifferentLength_Throws()
        {
            // Arrange
            var text = "0123";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Length(10));
        }

        [Test]
        public void StartsWith_ArgumentStartsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "Start of string";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).StartsWith("Start"));
        }

        [Test]
        public void StartsWith_ArgumentDoesNotStartWithValue_Throws()
        {
            // Arrange
            var text = "Some string";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).StartsWith("Start"));
        }

        [Test]
        public void EndsWith_ArgumentEndsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).EndsWith("near"));
        }

        [Test]
        public void EndsWith_ArgumentDoesNotEndWithValue_Throws()
        {
            // Arrange
            var text = "The end is near";
            
            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).EndsWith("Start"));
        }

        [TestCase("NOMATCH", @"\d")]
        [TestCase("perij@online", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentDoesNotMatch_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsMatch(pattern));
        }

        [TestCase("1234", @"\d")]
        [TestCase("perij@online.no", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentNotMatches_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => text).IsMatch(pattern));
        }

    }
}
