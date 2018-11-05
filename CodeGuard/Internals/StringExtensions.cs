namespace CodeGuard.dotNetCore.Internals
{
    internal static class StringExtensions
    {
        #region Internal Methods

        internal static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return true;
            return string.IsNullOrEmpty(value.Trim());
        }

        #endregion Internal Methods
    }
}
