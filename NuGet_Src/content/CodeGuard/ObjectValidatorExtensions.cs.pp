using System;
using $rootnamespace$.CodeGuard.Internals;

namespace $rootnamespace$.CodeGuard
{
    public static class ObjectValidatorExtensions
    {
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static IArg<T> Is<T>(this IArg<T> arg, Type type)
        {
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
            if (default(T).Equals(arg.Value))
            {
                arg.Message.Set("Value cannot be the default value.");
               
            }

            return arg;
        }

        /// <summary>
        /// Is the fucntion true for the argument.
        /// </summary>
        /// <returns></returns>
        public static IArg<T> IsTrue<T>(this IArg<T> arg, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (!booleanFunction(arg.Value))
            {
                arg.Message.Set(exceptionMessage);
            }

            return arg;
        }

    }
}
