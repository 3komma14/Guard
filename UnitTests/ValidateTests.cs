using System;
using NUnit.Framework;
using System.Linq;
using Seterlund.CodeGuard.Validators;

namespace Seterlund.CodeGuard.UnitTests
{
    [TestFixture]
    public class ValidateTests : BaseTests
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
        public void GetResult_WhenCalledWithOneFailingCheck_ReturnListWithOneMessage()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act
            var result = Validate.That(() => arg1).Is(typeof(ITest)).Errors;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetResult_WhenCalledWithtwoFailingChecks_ReturnListWithTwoMessages()
        {
            // Arrange
            int arg1 = 100;

            // Act
            var result = Validate.That(() => arg1).IsGreaterThan(200).IsEqual(1).Errors;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
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
