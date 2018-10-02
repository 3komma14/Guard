using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CodeGuard.dotNetCore.Validators
{
    public static class ObjectValidatorExtensions
    {
        #region Public Methods

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T> Is<T>(this IArg<T> arg, Type type)
        {
            Contract.Requires(arg != null);
            Contract.Requires(type != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            var isType = type.IsInstanceOfType(arg.Value);
            if (!isType)
            {
                arg.Message.Set(string.Format("Value is not <{0}>", type.Name));
            }

            return arg;
        }

        /// <summary>
        /// Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public static IArg<T> IsNotDefault<T>(this IArg<T> arg)
        {
            Contract.Requires(arg != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            T defautlValue = default(T);
            if (defautlValue == null)
            {
                if (arg.Value == null)
                {
                    arg.Message.Set("Value cannot be the default value.");
                }
            }
            else
            {
                if (default(T).Equals(arg.Value))
                {
                    arg.Message.Set("Value cannot be the default value.");
                }
            }

            return arg;
        }

        public static IArg<T> IsOneOf<T>(this IArg<T> arg, IEnumerable<T> collection)
        {
            Contract.Requires(arg != null);
            Contract.Requires(collection != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            if (!collection.Contains(arg.Value))
            {
                arg.Message.Set(string.Format("The value of the parameter is not one of {0}", string.Join(", ", collection.Select(x => x.ToString()).ToArray())));
            }

            return arg;
        }

        /// <summary>
        /// Is the function true for the argument.
        /// </summary>
        /// <returns></returns>
        public static IArg<T> IsTrue<T>(this IArg<T> arg, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            Contract.Requires(arg != null);
            Contract.Requires(booleanFunction != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            if (!booleanFunction(arg.Value))
            {
                arg.Message.Set(exceptionMessage);
            }

            return arg;
        }

        #endregion Public Methods
    }
}
