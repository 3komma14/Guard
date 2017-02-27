using System;
using BarsGroup.CodeGuard.Validators;
using Xunit;

namespace BarsGroup.CodeGuard.Tests.Validators
{
    
    public class ComplexExpressionTests : BaseTests
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
        public void ProperyWithProperty_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo(){BarProp = new Bar(){Prop = "A"}};

            // Act/Assert
                                        Guard.That(obj.BarProp.Prop).IsNotEmpty();
        }

        [Fact]
        public void ProperyWithField_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo() {BarProp = new Bar()};

            // Act/Assert
            Guard.That(obj.BarProp.Field).IsLessThan(1);
        }

        [Fact]
        public void ProperyWithProperty_InvalidResult_Throws()
        {
            // Arrange
            var obj = new Foo(){BarProp = new Bar(){Prop = ""}};

            // Act
            var exception =
                GetException<ArgumentException>(() => Guard.That(obj.BarProp.Prop, nameof(obj.BarProp.Prop)).IsNotEmpty());

            // Assert
            AssertArgumentException(exception, "Prop", "String is empty\r\nParameter name: Prop");

        }

        public class Bar
        {
            public string Prop { get; set; }
            public int Field;

        }

        public class Foo
        {
            public Bar BarProp { get; set; }

            public void TryGuard(Bar bar)
            {
                Guard.That(bar).IsNotNull();
                Guard.That(bar.Prop).IsNotEmpty();
            }
            
        }


    }
}
