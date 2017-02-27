using System;
using BarsGroup.CodeGuard.Internals;
using BarsGroup.CodeGuard.Validators;

namespace BarsGroup.CodeGuard
{
    public static class Guard
    {
        /// <summary>
        ///     Check the argument
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the argument
        /// </typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <returns>
        ///     An ArgumentValidator
        /// </returns>
        public static IArg<T> That<T>(T argument, string argumentName = "")
        {
            return string.IsNullOrEmpty(argumentName)
                ? new ThrowOnFirstErrorArg<T>(argument)
                : new ThrowOnFirstErrorArg<T>(argument, argumentName);
        }
    }
}