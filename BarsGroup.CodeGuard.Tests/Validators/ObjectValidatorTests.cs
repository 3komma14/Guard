using System.Collections.Generic;
using BarsGroup.CodeGuard.Exceptions;
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
            AssertArgumentException(exception, "Value cannot be the default value.", "arg1");
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsClassAndIsNull_Throws()
        {
            // Arrange
            var arg1 = default(object);

            // Act
            var exception =
                GetException<ArgumentException>(() => Guard.That(arg1, nameof(arg1)).IsNotDefault());

            // Assert
            AssertArgumentException(exception,"Value cannot be the default value.", "arg1");
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
        public void IsTrue_WhenArgumentIsTrue_NotThrows()
        {
            // Arrange
            var arg1 = 1;

            // Act/Assert
                Guard.That(arg1).IsTrue(x => x == arg1, "Must be over 50");
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

        [Fact]
        public void NotNull_ArgumentNotNull_DoesNotThrow()
        {
            // Arrange
            var arg = new TestClass();

            // Act/Assert
            Guard.That(arg);
        }


        [Fact]
        public void NotNull_IArgIsNull_Throws()
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => ((IArg<object>)null).IsNotNull());
        }


        [Fact]
        public void NotNull_ArgumentIsNull_Throws()
        {
            // Arrange
            TestClass arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(arg).IsNotNull());
        }

        [Fact]
        public void NotNull_NullableTypeIsNull_Throws()
        {
            // Arrange
            int? arg = null;

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => Guard.That(arg).IsNotNull());
        }

        [Fact]
        public void Is_Interface_NotThrows()
        {
            // Arrange
            var arg = new List<string>();

            // Act/Assert
            Guard.That(arg).Is<List<string>, IList<string>>();
        }

        [Fact]
        public void Is_DiffrentTypes_Throws()
        {
            // Arrange
            var arg = new List<string>();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(arg).Is<List<string>, string>());
        }


        private class TestClass
        { }

        private class MyBase { }

        private class MyClass : MyBase { }
    }

}
