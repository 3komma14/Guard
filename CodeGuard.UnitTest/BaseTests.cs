using System;
using Xunit;

namespace CodeGuard.dotNetCore.UnitTests
{
    public abstract class BaseTests
    {
        #region Protected Methods

        protected static void AssertArgumentException(ArgumentException exception, string paramName, string message)
        {
            Assert.NotNull(exception);
            Assert.Equal(paramName, exception.ParamName);
            Assert.Equal(message, exception.Message);
        }

        protected static void AssertArgumentNullException(ArgumentNullException exception, string paramName, string message)
        {
            Assert.NotNull(exception);
            Assert.Equal(paramName, exception.ParamName);
            Assert.Equal(message, exception.Message);
        }

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName, object actualValue, object to, object from)
        {
            Assert.NotNull(exception);
            Assert.Equal(paramName, exception.ParamName);
            Assert.Equal(actualValue, exception.ActualValue);
            var expectedMessage =
                string.Format(
                    "The value '{0}' of '{1}' is not in its allowed range of '{2}' to '{3}' (Parameter '{1}')\r\nActual value was {0}.",
                    actualValue, paramName, to, from);
            Assert.Equal(expectedMessage, exception.Message);
        }

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName)
        {
            Assert.NotNull(exception);
            Assert.Equal(paramName, exception.ParamName);
            Assert.Equal(string.Format("Specified argument was out of the range of valid values. (Parameter '{0}')", paramName), exception.Message);
        }

        protected void AssertArgumentNotEqualException(ArgumentOutOfRangeException exception, string paramName, object actualValue, object expectedValue)
        {
            Assert.NotNull(exception);
            //Assert.Equal(paramName, exception.ParamName);
            //Assert.Equal(actualValue, exception.ActualValue);
            var expectedMessage =
                string.Format(
                    "The value '{0}' is not equal to '{1}' (Parameter '{2}')\r\nActual value was {0}.",
                    actualValue, expectedValue, paramName);
            Assert.Equal(expectedMessage, exception.Message);
        }

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

        #endregion Protected Methods
    }
}
