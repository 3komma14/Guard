namespace BarsGroup.CodeGuard.Exceptions
{
    public class EvenValueExpectedException<TValue> : GuardException
    {
        public EvenValueExpectedException(TValue value, string paramName)
            : base(GenerateMessage(paramName, value))
        {

        }

        private static string GenerateMessage(string paramName, TValue value)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not a even number'"
                : $"The value '{value}' of '{paramName}'  is not a even number'";
        }
    }
}