namespace BarsGroup.CodeGuard.Exceptions
{
    public class NegativeValueExpectedException<TValue> : GuardException
    {
        public NegativeValueExpectedException(TValue value, string paramName)
            : base(GenerateMessage(paramName, value))
        {
        }

        private static string GenerateMessage(string paramName, TValue value)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not a negative number'"
                : $"The value '{value}' of '{paramName}'  is not a negative number'";
        }
    }
}