using System;
using System.Linq.Expressions;

namespace Seterlund.CodeGuard
{
    public static class Guard
    {
        /// <summary>
        /// Create an ArgumentValidator 
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
        public static ArgumentValidatorBase<T> Check<T>(Func<T> argument)
        {
            return new ArgumentValidator<T>(argument);
        }

        public static ArgumentValidatorBase<T> Contract<T>(Expression<Func<T>> argument)
        {
            return new ExpressionValidator<T>(argument);
        }
    }
}