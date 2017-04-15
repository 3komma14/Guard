namespace BarsGroup.CodeGuard.Exceptions
{
    public class OutOfRangeException<TValue> : GuardException
    {
        public OutOfRangeException(TValue value, TValue min, TValue max, string paramName)
            : base(GenerateMessage(paramName, value, min, max))
        {

        }

        private static string GenerateMessage(string paramName, TValue value, TValue min, TValue max)
        {
            return string.IsNullOrEmpty(paramName)
                ? $"The value '{value}' is not in its allowed range of '{min}' to '{max}'"
                : $"The value '{value}' of '{paramName}' is not in its allowed range of '{min}' to '{max}'";
        }
    }
}