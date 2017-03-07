using BarsGroup.CodeGuard.Exceptions;
using ArgumentException = BarsGroup.CodeGuard.Exceptions.ArgumentException;

namespace BarsGroup.CodeGuard.Internals
{
    internal static class ThrowMessageHelper
    {
        public static void ThrowArgument<T>(this IArg<T> arg, string message)
        {
            if (string.IsNullOrEmpty(arg.Name))
                throw new ArgumentException(message);

            throw new ArgumentException(message, arg.Name);
        }

        public static void ThrowArgumentNull<T>(this IArg<T> arg)
        {
            if (string.IsNullOrEmpty(arg.Name))
                throw new ArgumentNullException();

            throw new ArgumentNullException(arg.Name);
        }

        public static void ThrowGreaterThenExpected<T>(this IArg<T> arg, T max)
        {
            throw new GreaterThenExpectedException<T>(arg.Value, max, arg.Name);
        }

        public static void ThrowOddValueExpected<T>(this IArg<T> arg)
        {
            throw new OddValueExpectedException<T>(arg.Value, arg.Name);
        }

        public static void ThrowEvenValueExpected<T>(this IArg<T> arg)
        {
            throw new EvenValueExpectedException<T>(arg.Value, arg.Name);
        }

        public static void ThrowPrimeValueExpected<T>(this IArg<T> arg)
        {
            throw new PrimeValueExpectedException<T>(arg.Value, arg.Name);
        }

        public static void ThrowNegativeValueExpected<T>(this IArg<T> arg)
        {
            throw new NegativeValueExpectedException<T>(arg.Value, arg.Name);
        }

        public static void ThrowPositiveValueExpected<T>(this IArg<T> arg)
        {
            throw new PositiveValueExpectedException<T>(arg.Value, arg.Name);
        }

        public static void ThrowLessThenExpected<T>(this IArg<T> arg, T min)
        {
            throw new LessThenExpectedException<T>(arg.Value, min, arg.Name);
        }

        public static void ThrowArgumentOutRange<T>(this IArg<T> arg, T min, T max)
        {
            throw new OutOfRangeException<T>(arg.Value, min, max, arg.Name);
        }
        

        public static void ThrowNotEqual<T>(this IArg<T> arg, T expected)
        {
            throw new NotExpectedException<T>(arg.Value, expected, arg.Name);
        }
    }
}