using CodeGuard.dotNetCore.Validators;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class EnumerableValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void Contains_ArgumentContainsElement_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>() { "SomeItem" };

            // Act/Assert
            Guard.That(() => arg).Contains(x => x == "SomeItem");
        }

        [Fact]
        public void Contains_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).Contains(x => x == "SomeItem"));
        }

        [Fact]
        public void IsNotEmpty_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsNotEmpty());
        }

        [Fact]
        public void IsNotEmpty_ArgumentIsListWithItems_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>() { "Item1" };

            // Act/Assert
            Guard.That(() => arg).IsNotEmpty();
        }

        [Fact]
        public void Length_ArgumenIsNull_Throws()
        {
            // Arrange
            IEnumerable<string> arg = null;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).Length(1));
        }

        [Fact]
        public void Length_ArgumentLengthIsEqual_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>() { "First" };

            // Act/Assert
            Guard.That(() => arg).Length(1);
        }

        [Fact]
        public void Length_ArgumentLengthIsUnequal_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Guard.That(() => arg).Length(1));
        }

        #endregion Public Methods
    }
}
