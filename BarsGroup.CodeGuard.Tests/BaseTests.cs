using System;
using BarsGroup.CodeGuard.Exceptions;
using Xunit;
using ArgumentException = BarsGroup.CodeGuard.Exceptions.ArgumentException;
using ArgumentNullException = BarsGroup.CodeGuard.Exceptions.ArgumentNullException;

namespace BarsGroup.CodeGuard.Tests
{
    public abstract class BaseTests
    {
        #region ----- Helper functions -----

        protected T GetException<T>(Action action) where T : Exception
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

        protected static void AssertOutOfRangeException<T>(OutOfRangeException<T> exception, string paramName, T actualValue, T min, T max)
        {
            Assert.NotNull(exception);

            var expectedMessage = new OutOfRangeException<T>(actualValue, min, max, paramName).Message;
            Assert.Equal(expectedMessage, exception.Message);
        }

        protected static void AssertLessThenExpectedException<T>(LessThenExpectedException<T> exception, string paramName, T actualValue, T max)
        {
            Assert.NotNull(exception);
            var expectedMessage = new LessThenExpectedException<T>(actualValue, max, paramName).Message;

            Assert.Equal(expectedMessage, exception.Message);
        }

        protected static void AssertGreaterThenExpectedException<T>(GreaterThenExpectedException<T> exception,
            T actualValue, T expectedValue, string paramName)
        {
            Assert.NotNull(exception);
            var message = new GreaterThenExpectedException<T>(actualValue, expectedValue, paramName).Message;
            Assert.Equal(message, exception.Message);
        }


        protected static void AssertNotExpectedException<T>(NotExpectedException<T> exception, string paramName, T actualValue, T expectedValue)
        {
            Assert.NotNull(exception);

            var message = new NotExpectedException<T>(actualValue, expectedValue, paramName).Message;
            Assert.Equal(message, exception.Message);
        }

        protected void AssertArgumentNotEqualException(ArgumentOutOfRangeException exception, string paramName, object actualValue, object expectedValue)
        {
            Assert.NotNull(exception);
            //Assert.Equal(paramName, exception.ParamName);
            //Assert.Equal(actualValue, exception.ActualValue);
            var expectedMessage =
                string.Format(
                    "The value '{0}' is not equal max '{1}'\r\nParameter name: {2}\r\nActual value was {0}.",
                    actualValue, expectedValue, paramName);
            Assert.Equal(expectedMessage, exception.Message);
        }


        protected static void AssertArgumentException(ArgumentException exception, string message,  string paramName)
        {
            Assert.NotNull(exception);

            var expectedMessage = new ArgumentException(message, paramName);

            Assert.Equal(expectedMessage.Message, exception.Message);
        }

        protected static void AssertArgumentNullException(ArgumentNullException exception, string paramName, string message)
        {
            Assert.NotNull(exception);

            var expectedMessage = new ArgumentNullException( paramName).Message;
            Assert.Equal(expectedMessage, exception.Message);
        }

        #endregion


    }
}
