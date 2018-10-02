using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CodeGuard.dotNetCore.Validators
{
    public static class EnumerableValidatorExtensions
    {
        #region Public Methods

        public static IArg<IEnumerable<T>> Contains<T>(this IArg<IEnumerable<T>> arg, Func<T, bool> predicate)
        {
            Contract.Requires(arg != null);
            Contract.Requires(predicate != null);
            Contract.Ensures(Contract.Result<IArg<IEnumerable<T>>>() != null);

            var value = arg.Value;
            if (value == null || !value.Any(predicate))
            {
                arg.Message.Set("Collection does not contain required object");
            }

            return arg;
        }

        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<IEnumerable<T>>>() != null);

            var value = arg.Value;
            if (value == null || !value.Any())
            {
                arg.Message.Set("Collection is empty");
            }

            return arg;
        }

        public static IArg<IEnumerable<T>> Length<T>(this IArg<IEnumerable<T>> arg, int length)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<IEnumerable<T>>>() != null);

            var value = arg.Value;
            if (value == null || value.Count() != length)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        #endregion Public Methods
    }
}
