namespace BarsGroup.CodeGuard.Exceptions
{
    public class PrimeValueExpectedException<TValue> : GuardException
    {
        public PrimeValueExpectedException(TValue value, string paramName)
            : base(GenerateMessage(paramName, value))
        {

        }

        private static string GenerateMessage(string paramName, TValue value)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not a prime number'"
                : $"The value '{value}' of '{paramName}'  is not a prime number'";
        }
    }
}