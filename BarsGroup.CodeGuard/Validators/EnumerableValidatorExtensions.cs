using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumerableValidatorExtensions
    {
        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value;
            if (value == null || !value.Any())
                arg.Message.Set("Collection is empty");

            return arg;
        }

        public static IArg<IEnumerable<T>> Length<T>(this IArg<IEnumerable<T>> arg, int length)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value;
            if (value == null || value.Count() != length)
                arg.Message.SetArgumentOutRange();

            return arg;
        }

        public static IArg<IEnumerable<T>> Contains<T>(this IArg<IEnumerable<T>> arg, Func<T, bool> predicate)
        {
            Guard.That(arg).IsNotNull();
            Guard.That(predicate).IsNotNull();

            var value = arg.Value;
            if (value == null || !value.Any(predicate))
                arg.Message.Set("Collection does not contain required object");

            return arg;
        }
    }
}