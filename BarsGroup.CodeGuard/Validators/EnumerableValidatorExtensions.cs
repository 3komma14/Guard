using System;
using System.Collections.Generic;
using System.Linq;
using BarsGroup.CodeGuard.Exceptions;
using BarsGroup.CodeGuard.Internals;
using ArgumentNullException = BarsGroup.CodeGuard.Exceptions.ArgumentNullException;

namespace BarsGroup.CodeGuard.Validators
{
    public static class EnumerableValidatorExtensions
    {
        private const string CollectionIsEmpty = "Collection is empty";

        public static ArgBase<IEnumerable<T>> IsNotEmpty<T>(this ArgBase<IEnumerable<T>> arg)
        {
            arg.IsNotNull();

            // ReSharper disable once UseMethodAny.2
            if (arg.Value.Count() == 0)
                arg.ThrowArgument(CollectionIsEmpty);

            return arg;
        }

        public static ArgBase<IEnumerable<T>> Length<T>(this ArgBase<IEnumerable<T>> arg, int length)
        {
            arg.IsNotNull();

            var count = arg.Value.Count();
            if (count != length)
                throw new NotExpectedException<int>(count, length, arg.Name); 

            return arg;
        }

        public static ArgBase<IEnumerable<T>> Contains<T>(this ArgBase<IEnumerable<T>> arg, T expectedValue)
        {
            arg.IsNotNull();

            if (!arg.Value.Contains(expectedValue))
                arg.ThrowArgument("Collection does not contain required object");

            return arg;
        }

        public static ArgBase<IEnumerable<T>> Contains<T>(this ArgBase<IEnumerable<T>> arg, Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            arg.IsNotNull();

            if (!arg.Value.Any(predicate))
                arg.ThrowArgument("Collection does not contain required object");

            return arg;
        }
    }
}