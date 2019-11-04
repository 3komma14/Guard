using CodeGuard.dotNetCore.Validators;
using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests.Validators
{
    public class ComplexExpressionTests : BaseTests
    {
        #region Public Methods

        [Fact]
        public void ComplexGuardInsideMethod_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo();

            // Act/Assert
            obj.TryGuard(new Bar());
        }

        [Fact]
        public void ComplexGuardInsideMethod_ValidResultNonExpression_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo();

            // Act/Assert
            obj.TryGuard2(new Bar());
        }

        [Fact]
        public void ProperyWithField_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo() { BarProp = new Bar() };

            // Act/Assert
            Guard.That(() => obj.BarProp.Field).IsLessThan(1);
        }

        [Fact]
        public void ProperyWithProperty_InvalidResult_Throws()
        {
            // Arrange
            var obj = new Foo() { BarProp = new Bar() { Prop = "" } };

            // Act
            ArgumentException exception = GetException<ArgumentException>(() => Guard.That(() => obj.BarProp.Prop).IsNotEmpty());

            // Assert
            AssertArgumentException(exception, "Prop", "String is empty (Parameter 'Prop')");
        }

        [Fact]
        public void ProperyWithProperty_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo() { BarProp = new Bar() { Prop = "A" } };

            // Act/Assert

            Guard.That(() => obj.BarProp.Prop).IsNotEmpty();
        }

        #endregion Public Methods

        #region Public Classes

        public class Bar
        {
            #region Public Fields
            public int Field;
            #endregion Public Fields

            #region Public Properties
            public string Prop { get; set; }
            #endregion Public Properties
        }

        public class Foo
        {
            #region Public Properties
            public Bar BarProp { get; set; }
            #endregion Public Properties

            #region Public Methods

            public void TryGuard(Bar bar)
            {
                Guard.That(() => bar).NotNull();
                Guard.That(() => bar.Prop).IsNotEmpty();
            }

            public void TryGuard2(Bar bar)
            {
                Guard.That(() => bar).NotNull();
                Guard.That(bar.Prop).IsNotEmpty();
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}
