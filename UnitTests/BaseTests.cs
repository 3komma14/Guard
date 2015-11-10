using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Seterlund.CodeGuard.UnitTests
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

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName, object actualValue, object to, object from)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(actualValue, exception.ActualValue);
            var expectedMessage =
                string.Format(
                    "The value '{0}' of '{1}' is not in its allowed range of '{2}' to '{3}'\r\nParameter name: {1}\r\nActual value was {0}.",
                    actualValue, paramName, to, from);
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(string.Format("Specified argument was out of the range of valid values.\r\nParameter name: {0}", paramName), exception.Message);
        }

        protected void AssertArgumentNotEqualException(ArgumentOutOfRangeException exception, string paramName, object actualValue, object expectedValue)
        {
            Assert.IsNotNull(exception);
            //Assert.AreEqual(paramName, exception.ParamName);
            //Assert.AreEqual(actualValue, exception.ActualValue);
            var expectedMessage =
                string.Format(
                    "The value '{0}' is not equal to '{1}'\r\nParameter name: {2}\r\nActual value was {0}.",
                    actualValue, expectedValue, paramName);
            Assert.AreEqual(expectedMessage, exception.Message);
        }


        protected static void AssertArgumentException(ArgumentException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        protected static void AssertArgumentNullException(ArgumentNullException exception, string paramName, string message)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(message, exception.Message);
        }

        #endregion


    }
}
