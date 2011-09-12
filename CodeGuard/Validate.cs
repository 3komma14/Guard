using System;
using System.Linq.Expressions;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public static class Validate
    {
        /// <summary>
        /// Validate the argument 
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
        public static Arg<T> That<T>(Expression<Func<T>> argument)
        {
            return new Arg<T>(argument, new SaveErrorHandler());

        }
    }
}