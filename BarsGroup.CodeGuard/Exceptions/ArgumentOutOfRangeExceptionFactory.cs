using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Exceptions
{
    public static class ArgumentOutOfRangeExceptionFactory
    {
        public static ArgumentOutOfRangeException NotEqual<T>(IArg<T> arg, T expected)
        {
            var message = ErrorMessageFactory.NotEqual(arg, expected);
            return CreateException(arg, message);
        }

        private static ArgumentOutOfRangeException CreateException<T>(IArg<T> arg, string message)
        {
            if (!arg.HasName)
                return new ArgumentOutOfRangeException(message, (Exception) null);

            return new ArgumentOutOfRangeException(arg.Name, arg.Value, message);
        }
    }
}