using CodeGuard.dotNetCore.Validators;
using System;
using System.Linq;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests
{
    public class ValidateTests : BaseTests
    {
        #region Public Interfaces

        public interface ITest
        {
            #region Public Methods

            void Ping();

            #endregion Public Methods
        }

        #endregion Public Interfaces

        #region Public Methods

        [Fact]
        public void GetResult_WhenCalledWithOneFailingCheck_ReturnListWithOneMessage()
        {
            // Arrange
            var arg1 = new NotImplementationOfITest();

            // Act
            var result = Validate.That(() => arg1).Is(typeof(ITest)).Errors;

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetResult_WhenCalledWithtwoFailingChecks_ReturnListWithTwoMessages()
        {
            // Arrange
            int arg1 = 100;

            // Act
            var result = Validate.That(() => arg1).IsGreaterThan(200).IsEqual(1).Errors;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        #endregion Public Methods

        #region Public Classes

        public class ImplementationOfITest : ITest
        {
            #region Public Methods

            public void Ping()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        public class NotImplementationOfITest
        {
            #region Public Methods

            public void Echo()
            {
                throw new NotImplementedException();
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}
