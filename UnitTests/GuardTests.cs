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
        public void Is_WhenArgumentIsSameType_DoesNotThrow()
        {
            // Arrange
            int arg1 = 0;

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is<int>();
            });
        }

        [Test]
        public void Is_WhenArgumentIsWrongType_Throws()
        {
            // Arrange
            int arg1 = 0;

            // Act
            ArgumentException exception = 
                GetException<ArgumentException>(() => Guard.That(() => arg1).Is<string>());

            // Assert
            AssertArgumentException(exception, "arg1", "Value is not <String>\r\nParameter name: arg1");
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
        public void Is_WhenArgumentImplementsType_DoesNotThrow()
        {
            // Arrange
            var arg1 = new ImplementationOfITest();

            // Act/Assert
            Assert.DoesNotThrow(() =>
            {
                Guard.That(() => arg1).Is<ITest>();
            });
        }

        [Test]
        public void Is_WhenArgumentDoesNotImplementType_Throws()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act/Assert
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.That(() => arg1).Is<ITest>());
        
            // Assert
            AssertArgumentException(exception, "arg1", "Value is not <ITest>\r\nParameter name: arg1");
        }

        [Test]
        public void GetResult_WhenCalledWithOneFailingCheck_ReturnListWithOneMessage()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act
            var result = Guard.Validate(() => arg1).Is<ITest>().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetResult_WhenCalledWithtwoFailingChecks_ReturnListWithTwoMessages()
        {
            // Arrange
            int arg1 = 100;

            // Act
            var result = Guard.Validate(() => arg1).IsGreaterThan(200).IsEqual(1).GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
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
