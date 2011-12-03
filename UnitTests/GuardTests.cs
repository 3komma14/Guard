using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class GuardTests : BaseTests
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
        public void That_CalledWithFunc_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(() => arg1);

            // Assert
            Assert.IsNotNull(actual.Message);
        }

        [Test]
        public void That_CalledWithValue_MessageHandlerISet()
        {
            // Arrange
            int arg1 = 0;

            // Act
            var actual = Guard.That(arg1);

            // Assert
            Assert.IsNotNull(actual.Message);
        }


        [Test]
        public void Is_WhenArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is(typeof(int));
            });
        }

        [Test]
        public void Is_WhenArgumentIsWrongType_Throws()
        {
            // Arrange
            int arg1 = 0;

            // Act
            ArgumentException exception = 
                GetException<ArgumentException>(() => Guard.That(() => arg1).Is(typeof(string)));

            // Assert
            AssertArgumentException(exception, "arg1", "Value is not <String>\r\nParameter name: arg1");
        }


        [Test]
        public void Is_WhenArgumentImplementsType_DoesNotThrow()
        {
            // Arrange
            var arg1 = new ImplementationOfITest();

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is(typeof(ITest));
            });
        }

        [Test]
        public void Is_WhenArgumentDoesNotImplementType_Throws()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act/Assert
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg1).Is(typeof(ITest)));
        
            // Assert
            AssertArgumentException(exception, "arg1", "Value is not <ITest>\r\nParameter name: arg1");
        }

        public interface ITest 
        {
            void Ping();
        }

        public class ImplementationOfITest : ITest
        {
            public void Ping()
            {
                throw new NotImplementedException();
            }
        }

        public class NotImplementationOfITest
        {
            public void Echo()
            {
                throw new NotImplementedException();
            }
        }


    }
}
