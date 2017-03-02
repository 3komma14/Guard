using System;

namespace BarsGroup.CodeGuard.Exceptions
{
    public class NotExpectedException<TValue> : GuardException
    {
        public NotExpectedException(TValue actualValue, TValue expectedValue, string paramName = "")
            : base(GenerateMessage(actualValue, expectedValue, paramName))
        {
        }


        private static string GenerateMessage(TValue actualValue, TValue expectedValue, string paramName )
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{actualValue}' is not expected. Expected value is '{expectedValue}'"
                : $"The value '{actualValue}' of '{paramName}' is not expected. Expected value is '{expectedValue}.'";
        }
    }
}