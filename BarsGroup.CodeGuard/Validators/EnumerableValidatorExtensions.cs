using System;
using System.Collections.Generic;
using System.Linq;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumerableValidatorExtensions
    {
        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value;
            if (value == null || !value.Any())
                arg.ThrowArgument("Collection is empty");

            return arg;
        }

        public static IArg<IEnumerable<T>> Length<T>(this IArg<IEnumerable<T>> arg, int length)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value;
            if (value == null || value.Count() != length)
                arg.ThrowArgumentOutRange();

            return arg;
        }

        public static IArg<IEnumerable<T>> Contains<T>(this IArg<IEnumerable<T>> arg, Func<T, bool> predicate)
        {
            Guard.That(arg).IsNotNull();
            Guard.That(predicate).IsNotNull();

            var value = arg.Value;
            if (value == null || !value.Any(predicate))
                arg.ThrowArgument("Collection does not contain required object");

            return arg;
        }
    }
}