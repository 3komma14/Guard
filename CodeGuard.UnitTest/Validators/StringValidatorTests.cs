using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class StringValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void Contains_ArgumentContainsValue_DoesNotThrow()
        {
            // Arrange
            var text = "big brown car";

            // Act/Assert
            Guard.That(() => text).Contains("brown");
        }

        [Fact]
        public void Contains_ArgumentContainsValueWrongCase_Throws()
        {
            // Arrange
            var text = "BIG BROWN CAR";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Contains("brown"));
        }

        [Fact]
        public void Contains_ArgumentDoesNotContainValue_Throws()
        {
            // Arrange
            var text = "Yellow Submarine";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Contains("brown"));
        }

        [Fact]
        public void Empty_WhenArgumentIsNotEmpty_Throws()
        {
            // Arrange
            string arg = "AAA";

            // Act
            ArgumentException exception = GetException<ArgumentException>(() => Guard.That(() => arg).IsEmpty());

            // Assert
            AssertArgumentException(exception, "arg", "String is not empty\r\nParameter name: arg");
        }

        [Fact]
        public void EndsWith_ArgumentDoesNotEndWithValue_Throws()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).EndsWith("Start"));
        }

        [Fact]
        public void EndsWith_ArgumentEndsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "The end is near";

            // Act/Assert
            Guard.That(() => text).EndsWith("near");
        }

        [Fact]
        public void IsEmpty_WhenArgumentIsEmpty_DoesNotThrow()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Guard.That(() => text).IsEmpty();
        }

        [Theory]
        [InlineData("NOMATCH", @"\d")]
        [InlineData("perij@online", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentDoesNotMatch_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsMatch(pattern));
        }

        [Theory]
        [InlineData("1234", @"\d")]
        [InlineData("perij@online.no", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")]
        public void IsMatch_ArgumentNotMatches_Throws(string value, string pattern)
        {
            // Arrange
            var text = value;

            // Act/Assert
            Guard.That(() => text).IsMatch(pattern);
        }

        [Fact]
        public void Length_ArgumentHasDifferentLength_Throws()
        {
            // Arrange
            var text = "0123";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).Length(10));
        }

        [Fact]
        public void Length_ArgumentHasSameLength_DoesNotThrow()
        {
            // Arrange
            var text = "0123456789";

            // Act/Assert
            Guard.That(() => text).Length(10);
        }

        [Fact]
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

        [Fact]
        public void NotEmpty_WhenArgumentIsNotEmpty_DoesNotThrow()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Guard.That(() => text).IsNotEmpty();
        }

        [Fact]
        public void NotEmpty_WhenArgumentIsNull_DoesNotThrow()
        {
            // Arrange
            string text = null;

            // Act/Assert

            Guard.That(() => text).IsNotEmpty();
        }

        [Fact]
        public void NotNull_WhenArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Guard.That(() => text).NotNull();
        }

        [Fact]
        public void NotNull_WhenStringArgumentIsNull_Throws()
        {
            // Arrange
            string arg = null;

            // Act
            ArgumentNullException exception =
                GetException<ArgumentNullException>(() => Guard.That(() => arg).NotNull());

            // Assert
            AssertArgumentNullException(exception, "arg", "Value cannot be null.\r\nParameter name: arg");
        }

        [Fact]
        public void NotNullOrEmpty_WhenArgumentIsEmpty_Throws()
        {
            // Arrange
            string text = string.Empty;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).NotNullOrEmpty());
        }

        [Fact]
        public void NotNullOrEmpty_WhenArgumentIsNull_Throws()
        {
            // Arrange
            string text = null;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).NotNullOrEmpty());
        }

        [Fact]
        public void NotNullOrWhiteSpace_WhenStringArgumentIsNull_Throws()
        {
            // Arrange
            string arg = null;

            // Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).NotNullOrWhiteSpace());
        }

        [Fact]
        public void NotNullOrWhiteSpace_WhenStringArgumentNotNullOrWhitespace_DoesNotThrow()
        {
            // Arrange
            string arg = "Test";

            // Assert
            Guard.That(() => arg).NotNullOrWhiteSpace();
        }

        [Fact]
        public void Null_WhenArgumentNull_DoesNotThrow()
        {
            // Arrange
            string text = null;

            // Act/Assert
            Guard.That(() => text).Null();
        }

        [Fact]
        public void Null_WhenStringArgumentIsNotNull_Throws()
        {
            // Arrange
            string arg = "hello";

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(() => arg).Null());
        }

        [Fact]
        public void NullOrEmpty_WhenArgumentIsNotEmpty_Throws()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsNullOrEmpty());
        }

        [Fact]
        public void NullOrEmpty_WhenArgumentIsNotNull_Throws()
        {
            // Arrange
            string text = "hello";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).IsNullOrEmpty());
        }

        [Fact]
        public void NullOrEmpty_WhenArgumentIsValid_DoesNotThrow()
        {
            // Arrange
            string text = null;
            string text2 = string.Empty;

            // Act/Assert

            Guard.That(() => text).IsNullOrEmpty();
            Guard.That(() => text2).IsNullOrEmpty();
        }

        [Fact]
        public void NullOrWhiteSpace_WhenStringArgumentHasValue_Throws()
        {
            // Arrange
            string arg = "hello";

            // Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNullOrWhiteSpace());
        }

        [Fact]
        public void NullOrWhiteSpace_WhenStringArgumentIsValid_DoesNotThrows()
        {
            // Arrange
            string arg1 = " ";
            string arg2 = string.Empty;

            // Assert
            Guard.That(() => arg1).IsNullOrWhiteSpace();
            Guard.That(() => arg2).IsNullOrWhiteSpace();
        }

        [Fact]
        public void StartsWith_ArgumentDoesNotStartWithValue_Throws()
        {
            // Arrange
            var text = "Some string";

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => text).StartsWith("Start"));
        }

        [Fact]
        public void StartsWith_ArgumentStartsWithValue_DoesNotThrow()
        {
            // Arrange
            var text = "Start of string";

            // Act/Assert
            Guard.That(() => text).StartsWith("Start");
        }

        #endregion Public Methods
    }
}
