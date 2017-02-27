using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class ObjectValidatorTests : BaseTests
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
        public void Is_ArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            var arg = 3;

            // Act/Assert
            Guard.That(arg).Is(typeof(int));
        }

        [Fact]
        public void Is_ArgumentIsDifferentType_Throws()
        {
            // Arrange
            var arg = new MyBase();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).Is(typeof(int)));
        }

        [Fact]
        public void Is_ArgumentTestedAgainstBaseType_DoesNotThrow()
        {
            // Arrange
            var arg = new MyClass();

            // Act/Assert
            Guard.That(arg).Is(typeof(MyBase));
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsValueTypeAndValueIsDefault_Throws()
        {
            // Arrange
            var arg1 = default(int);

            // Act
            var exception =
                GetException<ArgumentException>(() => Guard.That(arg1, nameof(arg1)).IsNotDefault());

            // Assert
            AssertArgumentException(exception, "arg1", "Value cannot be the default value.\r\nParameter name: arg1");
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsValueTypeAndValueIsNotDefault_DoesNotThrow()
        {
            // Arrange
            var arg1 = default(int) + 1;

            // Act/Assert
                Guard.That(arg1).IsNotDefault();
        }


        [Fact]
        public void IsNotDefault_WhenArgumentIsReferenceTypeAndValueIsNotDefault_DoesNotThrow()
        {
            // Arrange
            var arg1 = new object();

            // Act/Assert
                Guard.That(arg1).IsNotDefault();
        }

        [Fact]
        public void IsTrue_WhenArgumentIsFalse_Throws()
        {
            // Arrange
            var arg1 = 1;

            // Act/Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Guard.That(arg1).IsTrue(x => x > 50, "Must be over 50");
            });
        }

        [Fact]
        public void IsOneOf_WhenArgumentIsInCollection_DoesNotThrow()
        {
            // Arrange
            var arg = 1;
            var data = new[] { 1, 2, 3 };

            // Act/Assert
            Guard.That(arg).IsOneOf(data);
        }

        [Fact]
        public void IsOneOf_WhenArgumentIsNotInCollection_Throws()
        {
            // Arrange
            var arg = 4;
            var data = new[] { 1, 2, 3 };

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).IsOneOf(data));
        }

        private class MyBase { }

        private class MyClass : MyBase { }
    }

}
