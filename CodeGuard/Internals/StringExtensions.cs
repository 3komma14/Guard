namespace CodeGuard.dotNetCore.Internals
{
    public static class StringExtensions
    {
        #region Public Methods

        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return true;
            return string.IsNullOrEmpty(value.Trim());
        }

        #endregion Public Methods
    }
}
