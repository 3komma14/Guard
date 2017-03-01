namespace BarsGroup.CodeGuard.Internals
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value?.Trim());
        }
    }
}