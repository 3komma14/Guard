using BarsGroup.CodeGuard.Internals;

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
            return new ArgBase<T>(argument, argumentName);
        }
    }
}