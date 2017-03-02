namespace BarsGroup.CodeGuard.Exceptions
{
    public class OddValueExpectedException<TValue> : GuardException
    {
        public OddValueExpectedException(TValue value, string paramName)
            : base(GenerateMessage(paramName, value))
        {

        }

        private static string GenerateMessage(string paramName, TValue value)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not a odd number'"
                : $"The value '{value}' of '{paramName}'  is not a odd number'";
        }
    }
}