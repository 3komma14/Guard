using System;
using System.Collections.Generic;
using System.Linq;

namespace Seterlund.CodeGuard
{
    public static class EnumerableValidatorExtensions
    {
        public static Arg<IEnumerable<T>> IsNotEmpty<T>(this Arg<IEnumerable<T>> arg)
        {
            if (!arg.Value.Any())
            {
                arg.ArgumentMessage("Collection is empty");
            }

            return arg;
        }

        public static Arg<IEnumerable<T>> Length<T>(this Arg<IEnumerable<T>> arg, int length)
        {
            if (arg.Value.Count() != length)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<IEnumerable<T>> Contains<T>(this Arg<IEnumerable<T>> arg, Func<T, bool> predicate)
        {

            if (!arg.Value.Any(predicate))
            {
                arg.ArgumentMessage("Collection does not contain required object");
            }

            return arg;
        }
    }
}
