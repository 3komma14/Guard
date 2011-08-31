using System;
using System.Linq.Expressions;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class Guard
    {
        /// <summary>
        /// Check the argument 
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <typeparam name="T">
        /// Type of the argument
        /// </typeparam>
        /// <returns>
        /// An ArgumentValidator
        /// </returns>
        public static ArgumentBase<T> That<T>(Expression<Func<T>> argument)
        {
            return new ThrowValidator<T>(argument);
        }

        /// <summary>
        /// Check the argument
        /// </summary>
        /// <typeparam name="T">
        /// Type of the argument
        /// </typeparam>
        /// <param name="argument"></param>
        /// <returns>
        /// An ArgumentValidator
        /// </returns>
        public static ArgumentBase<T> That<T>(T argument)
        {
            return new ThrowValidator<T>(argument);
        }
    }
}