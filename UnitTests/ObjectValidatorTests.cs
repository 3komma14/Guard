using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class ObjectValidatorTests : BaseTests
    {
        #region ----- Fixture setup -----

        /// <summary>
        /// Called once before first test is executed
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            // Init tests
        }

        /// <summary>
        /// Called once after last test is executed
        /// </summary>
        [TestFixtureTearDown]
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
        public void Is_ArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            var arg = 3;

            // Act/Assert
            Assert.DoesNotThrow(() => Guard.That(() => arg).Is(typeof(int)));
        }

        [Test]
        public void Is_ArgumentIsDifferentType_Throws()
        {
            // Arrange
            var arg = new MyBase();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).Is(typeof(int)));
        }

        [Test]
        public void Is_ArgumentTestedAgainstBaseType_Throws()
        {
            // Arrange
            var arg = new MyClass();

            // Act/Assert
            Assert.Throws<ArgumentException>(() => Guard.That(() => arg).Is(typeof(MyBase)));
        }

        [Test]
        public void IsNotDefault_WhenArgumentIsDefault_Throws()
        {
            // Arrange
            int arg1 = default(int);

            // Act
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg1).IsNotDefault());

            // Assert
            AssertArgumentException(exception, "arg1", "Value cannot be the default value.\r\nParameter name: arg1");
        }

        [Test]
        public void IsNotDefault_WhenArgumentIsNotDefault_DoesNotThrow()
        {
            // Arrange
            int arg1 = default(int) + 1;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).IsNotDefault();
            });
        }

        [Test]
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


        private class MyBase {}

        private class MyClass : MyBase {}
    }

}
