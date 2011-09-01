using System;

namespace Seterlund.CodeGuard
{
    public static class ObjectValidatorExtensions
    {
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static Arg<T> Is<T>(this Arg<T> arg, Type type)
        {
            var isType = arg.Value.GetType().Equals(type);
            if (!isType)
            {
                arg.ArgumentMessage(string.Format("Value is not <{0}>", type.Name));
            }

            return arg;            
        }

        /// <summary>
        /// Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public static Arg<T> IsNotDefault<T>(this Arg<T> arg)
        {
            if (default(T).Equals(arg.Value))
            {
                arg.ArgumentMessage("Value cannot be the default value.");
            }

            return arg;
        }

        /// <summary>
        /// Is the fucntion true for the argument.
        /// </summary>
        /// <returns></returns>
        public static Arg<T> IsTrue<T>(this Arg<T> arg, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (!booleanFunction(arg.Value))
            {
                arg.ArgumentMessage(exceptionMessage);
            }

            return arg;
        }

    }
}
