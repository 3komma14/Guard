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
        public static ValidatorBase<T> Check<T>(Expression<Func<T>> argument)
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
        public static ValidatorBase<T> Check<T>(T argument)
        {
            return new ThrowValidator<T>(argument);
        }

        public static ValidatorBase<T> Validate<T>(Expression<Func<T>> argument)
        {
            return new Validator<T>(argument);
        }

    }
}