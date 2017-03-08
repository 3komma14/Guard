using System;
using System.Collections.Generic;
using System.Linq;
using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumerableValidatorExtensions
    {
        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            Guard.That(arg).IsNotNull();


            var value = arg.Value;
            // ReSharper disable once UseMethodAny.2
            if (value == null || value.Count() == 0)
                arg.ThrowArgument("Collection is empty");

            return arg;
        }

        public static IArg<IEnumerable<T>> Length<T>(this IArg<IEnumerable<T>> arg, int length)
        {
            Guard.That(arg).IsNotNull();
            Guard.That(arg.Value).IsNotNull();

            var value = arg.Value;
            var count = value.Count();
            if (value == null || count != length)
                throw new NotExpectedException<int>(count, length, arg.Name); 

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