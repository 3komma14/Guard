using System;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class GuardTests
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
                Guard.Check(() => arg1).Is<int>();
            });
        }

        [Test]
        public void Is_WhenArgumentIsWrongType_Throws()
        {
            // Arrange
            int arg1 = 0;

            // Act
            ArgumentException exception = 
                GetException<ArgumentException>(() => Guard.Check(() => arg1).Is<string>());

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
                GetException<ArgumentException>(() => Guard.Check(() => arg1).IsNotDefault());

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
                Guard.Check(() => arg1).IsNotDefault();
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
                Guard.Check(() => arg1).Is<ITest>();
            });
        }

        [Test]
        public void Is_WhenArgumentDoesNotImplementType_Throws()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act/Assert
            ArgumentException exception =
                GetException<ArgumentException>(() => Guard.Check(() => arg1).Is<ITest>());
        
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


        #region ----- Helper functions -----

        private T GetException<T>(Action action) where T : Exception
        {
            T actualException = null;
            try
            {
                action();
            }
            catch (T ex)
            {
                actualException = ex;
            }

            return actualException;
        }

        private static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string message, string paramName, object actualValue)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(actualValue, exception.ActualValue);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: {1}\r\nActual value was {2}.", message, paramName, actualValue), exception.Message);
        }

        private static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(string.Format("Specified argument was out of the range of valid values.\r\nParameter name: {0}", paramName), exception.Message);
        }

        private static void AssertArgumentException(ArgumentException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        private static void AssertArgumentNullException(ArgumentNullException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        #endregion


    }
}
