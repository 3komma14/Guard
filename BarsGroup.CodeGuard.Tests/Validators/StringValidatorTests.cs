using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class StringValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        public void Cleanup()
        {
            // Cleanup tests
        }

        #endregion

        #region ------ Test setup -----

        /// <summary>
        /// Called before each test
        /// </summary>
        public void Setup()
        {
            // Setup test
        }

        /// <summary>
        /// Called before each test
        /// </summary>
        public void TearDown()
        {
            // Cleanup after test       
        }

        #endregion

        [Fact]
        public void NotNull_WhenStringArgumentIsNull_Throws()
        {

            // Arrange
            string arg = null;

            // Act
            var exception =
                GetException<ArgumentNullException>(() => Guard.That(arg, nameof(arg)).IsNotNull());

            // Assert
            AssertArgumentNullException(exception, "arg", "Argument is null.");
        }

        [Fact]
        public void NotNull_WhenArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            var text = string.Empty;

            // Act/Assert
            Guard.That(text).IsNotNull();
        }

        [Fact]
        public void NotEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            var arg = string.Empty;

            // Act
            var exception =
                GetException<ArgumentException>(() => Guard.That(arg, nameof(arg)).IsNotEmpty());

            // Assert
            AssertArgumentException(exception,  "String is empty", "arg");
        }

        [Fact]
        public void NotEmpty_WhenArgumentIsNotEmpty_DoesNotThrow()
        {
            // Arrange
            var text = "hello";

            // Act/Assert
                Guard.That(text).IsNotEmpty();
        }

        [Fact]
        public void NotEmpty_WhenArgumentIsNull_DoesNotThrow()
        {
            // Arrange
            var text = "hello";

            // Act/Assert
                Guard.That(text).IsNotEmpty();
        }

        [Fact]
        public void NotNullOrEmpty_WhenArgumentIsValid_DoesNotThrow()
        {
            // Arrange
            var text = "hello";

            // Act/Assert
                Guard.That(text).IsNotNullOrEmpty();
        }

        [Fact]
        public void NotNullOrEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            var text = string.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).IsNotNullOrEmpty());
        }

        [Fact]
        public void Contains_ArgumentContainsValue_DoesNotThrow()
        {
            // Arrange
            var text = "big brown car";

            // Act/Assert
            Guard.That(text).Contains("brown");
        }

        [Fact]
        public void Contains_ArgumentContainsValueWrongCase_Throws()
        {
            // Arrange
            var text = "BIG BROWN CAR";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).Contains("brown"));
        }

        [Fact]
        public void Contains_ArgumentDoesNotContainValue_Throws()
        {
            // Arrange
            var text = "Yellow Submarine";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).Contains("brown"));
        }

        [Fact]
        public void Length_ArgumentHasSameLength_DoesNotThrow()
        {
            // Arrange
            var text = "0123456789";

            // Act/Assert
            Guard.That(text).Length(10);
        }

        [Fact]
        public void Length_ArgumentHasDifferentLength_Throws()
        {
            // Arrange
            var text = "0123";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).Length(10));
        }

        [Fact]
        public void StartsWith_ArgumentStartsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "Start of string";

            // Act/Assert
            Guard.That(text).StartsWith("Start");
        }

        [Fact]
        public void StartsWith_ArgumentDoesNotStartWithValue_Throws()
        {
            // Arrange
            var text = "Some string";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).StartsWith("Start"));
        }

        [Fact]
        public void EndsWith_ArgumentEndsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Guard.That(text).EndsWith("near");
        }

        [Fact]
        public void EndsWith_ArgumentDoesNotEndWithValue_Throws()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).EndsWith("Start"));
        }

        [Theory]
        [InlineData("NOMATCH", @"\d")]
        [InlineData("perij@online", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentDoesNotMatch_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(text).IsMatch(pattern));
        }

        [Theory]
        [InlineData("1234", @"\d")]
        [InlineData("perij@online.no", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentNotMatches_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Guard.That(text).IsMatch(pattern);
        }

        [Fact]
        public void NotNullOrWhiteSpace_WhenStringArgumentIsWhiteSpace_Throws()
        {

            // Arrange
            var arg = " ";

            // Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg, nameof(arg)).IsNotNullOrWhiteSpace());
        }

        [Fact]
        public void NotNullOrWhiteSpace_WhenStringArgumentNotNullOrWhitespace_DoesNotThrow()
        {

            // Arrange
            var arg = "Test";

            // Assert
            Guard.That(arg).IsNotNullOrWhiteSpace();
        }

    }
}
