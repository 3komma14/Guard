using CodeGuard.dotNetCore.Internals;
using System;

namespace CodeGuard.dotNetCore.Exceptions
{
    public static class ArgumentOutOfRangeExceptionFactory
    {
        #region Public Methods

        public static ArgumentOutOfRangeException NotEqual<T>(IArg<T> arg, T expected)
        {
            var message = ErrorMessageFactory.NotEqual(arg, expected);
            return CreateException(arg, message);
        }

        #endregion Public Methods

        #region Private Methods

        private static ArgumentOutOfRangeException CreateException<T>(IArg<T> arg, string message)
        {
            if (!arg.HasName)
            {
                return new ArgumentOutOfRangeException(message, (Exception)null);
            }

            return new ArgumentOutOfRangeException(arg.Name, arg.Value, message);
        }

        #endregion Private Methods
    }
}
