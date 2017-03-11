using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ObjectValidatorExtensions
    {
        public static ArgBase<T> IsNotNull<T>(this ArgBase<T> arg) where T: class 
        {
            if (arg.Value == null)
                arg.ThrowArgumentNull();

            return arg;
        }

        public static ArgBase<T> Is<T, TType>(this ArgBase<T> arg)
        {
            if (!(arg.Value is TType))
                arg.ThrowArgument($"Value is not <{typeof(TType).Name}>");

            return arg;
        }

        /// <summary>
        ///     Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static ArgBase<T> Is<T>(this ArgBase<T> arg, Type type)
        {
            var isType = type.GetTypeInfo().IsInstanceOfType(arg.Value);
            if (!isType)
                arg.ThrowArgument($"Value is not <{type.Name}>");

            return arg;
        }

        /// <summary>
        ///     Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public static ArgBase<T> IsNotDefault<T>(this ArgBase<T> arg)
        {
            var defaultValue = default(T);
            if (defaultValue == null)
            {
                if (arg.Value == null)
                    arg.ThrowArgument("Value cannot be the default value.");
            }
            else
            {
                if (defaultValue.Equals(arg.Value))
                    arg.ThrowArgument("Value cannot be the default value.");
            }

            return arg;
        }

        /// <summary>
        ///     Is the function true for the argument.
        /// </summary>
        /// <returns></returns>
        public static ArgBase<T> IsTrue<T>(this ArgBase<T> arg, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (!booleanFunction(arg.Value))
                arg.ThrowArgument(exceptionMessage);

            return arg;
        }

        public static ArgBase<T> IsOneOf<T>(this ArgBase<T> arg, IReadOnlyList<T> collection)
        {
            if (!collection.Contains(arg.Value))
                arg.ThrowArgument(
                    $"The value of the parameter is not one of {string.Join(", ", collection.Select(x => x.ToString()).ToArray())}");

            return arg;
        }
    }
}