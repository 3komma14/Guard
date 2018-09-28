using CodeGuard.dotNetCore.Internals;
using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore
{
    public static class Validate
    {
        #region Public Methods

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
            Contract.Requires(argument != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            return new AccumulateErrorsArg<T>(argument);
        }

        #endregion Public Methods
    }
}
