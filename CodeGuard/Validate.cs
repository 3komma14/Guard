using System;
using System.Linq.Expressions;
using Seterlund.CodeGuard.Internals;
using System.Diagnostics.Contracts;

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
        public static IArg<T> That<T>(Expression<Func<T>> argument)
        {
#if !NET35
            Contract.Requires(argument != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);
#endif
            return new AccumulateErrorsArg<T>(argument);
        }
    }
}