using System;
using BarsGroup.CodeGuard.Exceptions;

namespace BarsGroup.CodeGuard.Internals
{
    internal static class ThrowMessageHelper
    {
        public static void ThrowArgument<T>(this IArg<T> arg, string message)
        {
            if (!arg.HasName)
                throw new ArgumentException(message);

            throw new ArgumentException(message, arg.Name);
        }

        public static void ThrowArgumentNull<T>(this IArg<T> arg)
        {
            if (!arg.HasName)
                throw new ArgumentNullException();

            throw new ArgumentNullException(arg.Name);
        }

        public static void ThrowArgumentOutRange<T>(this IArg<T> arg, T min, T max)
        {
            throw new ArgumentOutOfRangeException<T>(arg.Value, min, max, arg.Name);
        }

        public static void ThrowArgumentLessThan<T>(this IArg<T> arg, T min)
        {
            var message = ErrorMessageFactory.LessThan(arg, min);
            arg.ThrowArgumentOutRange(message);
        }

        public static void ThrowArgumentLargerThan<T>(this IArg<T> arg, T max)
        {
            var message = ErrorMessageFactory.LessThan(arg, max);
            arg.ThrowArgumentOutRange(message);
        }

        public static void ThrowArgumentNotEqual<T>(this IArg<T> arg, T expected)
        {
            throw new NotExpectedException<>().NotEqual(arg, expected);
        }
    }
}