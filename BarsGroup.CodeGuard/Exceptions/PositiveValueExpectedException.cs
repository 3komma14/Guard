namespace BarsGroup.CodeGuard.Exceptions
{
    public class PositiveValueExpectedException<TValue> : GuardException
    {
        public PositiveValueExpectedException(TValue value, string paramName)
            : base(GenerateMessage(paramName, value))
        {

        }

        private static string GenerateMessage(string paramName, TValue value)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not a positive number'"
                : $"The value '{value}' of '{paramName}'  is not a positive number'";
        }
    }
}