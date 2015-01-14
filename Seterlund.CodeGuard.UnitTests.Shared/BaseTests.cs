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

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string message, string paramName, object actualValue)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(actualValue, exception.ActualValue);
            Assert.AreEqual(string.Format("{0}\r\nParameter name: {1}\r\nActual value was {2}.", message, paramName, actualValue), exception.Message);
        }

        protected static void AssertArgumentOfRangeException(ArgumentOutOfRangeException exception, string paramName)
        {
            Assert.IsNotNull(exception);
            Assert.AreEqual(paramName, exception.ParamName);
            Assert.AreEqual(string.Format("Specified argument was out of the range of valid values.\r\nParameter name: {0}", paramName), exception.Message);
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
