using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class ObjectValidatorTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void Is_ArgumentIsDifferentType_Throws()
        {
            // Arrange
            var arg = new MyBase();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).Is(typeof(int)));
        }

        [Fact]
        public void Is_ArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            var arg = 3;

            // Act/Assert
            Guard.That(() => arg).Is(typeof(int));
        }

        [Fact]
        public void Is_ArgumentTestedAgainstBaseType_DoesNotThrow()
        {
            // Arrange
            var arg = new MyClass();

            // Act/Assert
            Guard.That(() => arg).Is(typeof(MyBase));
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsReferenceTypeAndValueIsDefault_Throws()
        {
            // Arrange
            object arg1 = null;

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg1).IsNotDefault());

            // Assert
            AssertArgumentException(exception, "arg1", "Value cannot be the default value.\r\nParameter name: arg1");
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsReferenceTypeAndValueIsNotDefault_DoesNotThrow()
        {
            // Arrange
            object arg1 = new object();

            // Act/Assert
            Guard.That(() => arg1).IsNotDefault();
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsValueTypeAndValueIsDefault_Throws()
        {
            // Arrange
            int arg1 = default(int);

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg1).IsNotDefault());

            // Assert
            AssertArgumentException(exception, "arg1", "Value cannot be the default value.\r\nParameter name: arg1");
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsValueTypeAndValueIsNotDefault_DoesNotThrow()
        {
            // Arrange
            int arg1 = default(int) + 1;

            // Act/Assert
            Guard.That(() => arg1).IsNotDefault();
        }

        [Fact]
        public void IsOneOf_WhenArgumentIsInCollection_DoesNotThrow()
        {
            // Arrange
            int arg = 1;
            var data = new int[3] { 1, 2, 3 };

            // Act/Assert
            Guard.That(() => arg).IsOneOf(data);
        }

        [Fact]
        public void IsOneOf_WhenArgumentIsNotInCollection_Throws()
        {
            // Arrange
            int arg = 4;
            var data = new int[3] { 1, 2, 3 };

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).IsOneOf(data));
        }

        [Fact]
        public void IsTrue_WhenArgumentIsFalse_Throws()
        {
            // Arrange
            int arg1 = 1;

            // Act/Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Guard.That(() => arg1).IsTrue(x => x > 50, "Must be over 50");
            });
        }

        #endregion Public Methods

        #region Private Classes

        private class MyBase { }

        private class MyClass : MyBase { }

        #endregion Private Classes
    }
}
