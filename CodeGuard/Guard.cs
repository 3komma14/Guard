using CodeGuard.dotNetCore.Internals;
using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore
{
    public static class Guard
    {
        #region Public Methods

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
        public static IArg<T> That<T>(Expression<Func<T>> argument)
        {
            Contract.Requires(argument != null);

            return new ThrowOnFirstErrorArg<T>(argument);
        }

        /// <summary>
        /// Check the argument
        /// </summary>
        /// <typeparam name="T">
        /// Type of the argument
        /// </typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <returns>
        /// An ArgumentValidator
        /// </returns>
        public static IArg<T> That<T>(T argument, string argumentName = "")
        {
            Contract.Requires(argument != null);
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            if (string.IsNullOrEmpty(argumentName))
            {
                return new ThrowOnFirstErrorArg<T>(argument);
            }
            return new ThrowOnFirstErrorArg<T>(argument, argumentName);
        }

        #endregion Public Methods
    }
}
