using System;

namespace BarsGroup.CodeGuard.Exceptions
{
    public class GreaterThenExpectedException<TValue> : GuardException
    {
        public GreaterThenExpectedException(TValue value, TValue max, string paramName)
            : base(GenerateMessage(paramName, value, max))
        {

        }

        private static string GenerateMessage(string paramName, TValue value, TValue max)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is larger than '{max}'"
                : $"The value '{value}' of '{paramName}' is larger than '{max}'";
        }
    }
}