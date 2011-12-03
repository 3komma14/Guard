using System;
using System.Collections.Generic;
using System.Linq;

namespace Seterlund.CodeGuard
{
    public static class EnumerableValidatorExtensions
    {
        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            if (!arg.Value.Any())
            {
                arg.Message.Set("Collection is empty");
            }

            return arg;
        }

        public static IArg<IEnumerable<T>> Length<T>(this IArg<IEnumerable<T>> arg, int length)
        {
            if (arg.Value.Count() != length)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<IEnumerable<T>> Contains<T>(this IArg<IEnumerable<T>> arg, Func<T, bool> predicate)
        {

            if (!arg.Value.Any(predicate))
            {
                arg.Message.Set("Collection does not contain required object");
            }

            return arg;
        }
    }
}
