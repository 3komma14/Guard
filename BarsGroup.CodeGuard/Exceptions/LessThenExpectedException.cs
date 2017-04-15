namespace BarsGroup.CodeGuard.Exceptions
{
    public class LessThenExpectedException<TValue> : GuardException
    {
        public LessThenExpectedException(TValue value, TValue max, string paramName)
            : base(GenerateMessage(paramName, value, max))
        {

        }

        private static string GenerateMessage(string paramName, TValue value, TValue max)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is less than '{max}'"
                : $"The value '{value}' of '{paramName}' is less than '{max}'";
        }
    }
}