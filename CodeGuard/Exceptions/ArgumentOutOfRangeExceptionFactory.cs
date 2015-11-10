using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard.Exceptions
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
            if (string.IsNullOrEmpty(arg.Name))
            {
                return new ArgumentOutOfRangeException(message, (Exception) null);
            }

            return new ArgumentOutOfRangeException(arg.Name, arg.Value, message);
        }
    }
}
