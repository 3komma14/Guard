using System;
using System.Linq.Expressions;
using BarsGroup.CodeGuard.Internals;
using BarsGroup.CodeGuard.Validators;

namespace BarsGroup.CodeGuard.Tests
{
    public static class Validate
    {
        /// <summary>
        ///     Validate the argument
        /// </summary>
        /// <param name="argument">
        ///     The argument.
        /// </param>
        /// <typeparam name="T">
        ///     Type of the argument
        /// </typeparam>
        /// <returns>
        ///     An ArgumentValidator
        /// </returns>
        public static IArg<T> That<T>(Expression<Func<T>> argument)
        {
            Guard.That(argument).IsNotNull();

            return new AccumulateErrorsArg<T>(argument);
        }
    }
}