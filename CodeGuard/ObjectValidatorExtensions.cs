using System;

namespace Seterlund.CodeGuard
{
    public static class ObjectValidatorExtensions
    {
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <returns></returns>
        public static ArgumentBase<T> Is<T>(this ArgumentBase<T> argument, Type type)
        {
            var isType = argument.Value.GetType().Equals(type);
            if (!isType)
            {
                argument.ArgumentMessage(string.Format("Value is not <{0}>", type.Name));
            }

            return argument;            
        }

        /// <summary>
        /// Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public static ArgumentBase<T> IsNotDefault<T>(this ArgumentBase<T> argument)
        {
            if (default(T).Equals(argument.Value))
            {
                argument.ArgumentMessage("Value cannot be the default value.");
            }

            return argument;
        }

        /// <summary>
        /// Is the fucntion true for the argument.
        /// </summary>
        /// <returns></returns>
        public static ArgumentBase<T> IsTrue<T>(this ArgumentBase<T> argument, Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (!booleanFunction(argument.Value))
            {
                argument.ArgumentMessage(exceptionMessage);
            }

            return argument;
        }

    }
}
