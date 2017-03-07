using System.Collections.Generic;
using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class EnumerableValidatorTests : BaseTests
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
        public void IsNotEmpty_ArgumentIsListWithItems_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string> { "Item1" };

            // Act/Assert
            Guard.That(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).IsNotEmpty());
        }

        [Fact]
        public void Contains_ArgumentContainsElement_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string> {"SomeItem"};

            // Act/Assert
            Guard.That(arg).Contains(x => x == "SomeItem");
        }

        [Fact]
        public void Contains_ArgumentIsEmptyList_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).Contains(x => x == "SomeItem"));
        }

        [Fact]
        public void Length_ArgumenIsNull_Throws()
        {
            // Arrange
            IEnumerable<string> arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(arg, nameof(arg)).Length(1));
        }

        [Fact]
        public void Length_ArgumentLengthIsUnequal_Throws()
        {
            // Arrange
            IEnumerable<string> arg = new List<string>();

            // Act/Assert
            Assert.Throws<NotExpectedException<int>>(() => Guard.That(arg).Length(1));
        }

        [Fact]
        public void Length_ArgumentLengthIsEqual_DoesNotThrow()
        {
            // Arrange
            IEnumerable<string> arg = new List<string> {"First"};

            // Act/Assert
            Guard.That(arg).Length(1);
        }

    }
}
