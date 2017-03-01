using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ObjectValidatorExtensions
    {
        /// <summary>
        ///     Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T> Is<T>(this IArg<T> arg, Type type)
        {
            Guard.That(arg).IsNotNull();


            var isType = type.GetTypeInfo().IsInstanceOfType(arg.Value);
            if (!isType)
                arg.ThrowArgument(string.Format("Value is not <{0}>", type.Name));

            return arg;
        }

        /// <summary>
        ///     Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public static IArg<T> IsNotDefault<T>(this IArg<T> arg)
        {
            Guard.That(arg).IsNotNull();


            var defaultValue = default(T);
            if (defaultValue == null)
            {
                if (arg.Value == null)
                    arg.ThrowArgument("Value cannot be the default value.");
            }
            else
            {
                if (default(T).Equals(arg.Value))
                    arg.ThrowArgument("Value cannot be the default value.");
            }

            return arg;
        }

        /// <summary>
        ///     Is the function true for the argument.
        /// </summary>
        /// <returns></returns>
        public static IArg<T> IsTrue<T>(this IArg<T> arg, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            Guard.That(arg).IsNotNull();


            if (!booleanFunction(arg.Value))
                arg.ThrowArgument(exceptionMessage);

            return arg;
        }

        public static IArg<T> IsOneOf<T>(this IArg<T> arg, IReadOnlyList<T> collection)
        {
            Guard.That(arg).IsNotNull();


            if (!collection.Contains(arg.Value))
                arg.ThrowArgument(string.Format("The value of the parameter is not one of {0}",
                    string.Join(", ", collection.Select(x => x.ToString()).ToArray())));

            return arg;
        }
    }
}