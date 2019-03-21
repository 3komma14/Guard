using System;
using NUnit.Framework;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests.Validators
{
    [TestFixture]
    public class ComplexExpressionTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        [OneTimeTearDown]
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
        public void ProperyWithProperty_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo(){BarProp = new Bar(){Prop = "A"}};

            // Act/Assert
            Assert.DoesNotThrow(() =>
                                    {
                                        Guard.That(() => obj.BarProp.Prop).IsNotEmpty();
                                    });
        }

        [Test]
        public void ProperyWithField_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo(){BarProp = new Bar()};

            // Act/Assert
            Assert.DoesNotThrow(() =>
                                    {
                                        Guard.That(() => obj.BarProp.Field).IsLessThan(1);
                                    });
        }

        [Test]
        public void ProperyWithProperty_InvalidResult_Throws()
        {
            // Arrange
            var obj = new Foo(){BarProp = new Bar(){Prop = ""}};

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => obj.BarProp.Prop).IsNotEmpty());

            // Assert
            AssertArgumentException(exception, "Prop", "String is empty\r\nParameter name: Prop");

        }

        [Test]
        public void ComplexGuardInsideMethod_ValidResult_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo();

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                obj.TryGuard(new Bar());
            });
        }

        [Test]
        public void ComplexGuardInsideMethod_ValidResultNonExpression_DoesNotThrow()
        {
            // Arrange
            var obj = new Foo();

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                obj.TryGuard2(new Bar());
            });
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
                Guard.That(() => bar).IsNotNull();
                Guard.That(() => bar.Prop).IsNotEmpty();
            }

            public void TryGuard2(Bar bar)
            {
                Guard.That(() => bar).IsNotNull();
                Guard.That(bar.Prop).IsNotEmpty();
            }
        }


    }
}
