using System;

namespace Seterlund.CodeGuard
{
    public static class ComparableValidatorExtensions
    {
        public static IArg<T> IsEqual<T>(this IArg<T> arg, T param) where T : IComparable
        {
            return IsEqual(arg, () => param);
        }

        public static IArg<T> IsEqual<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) != 0)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<T> IsNotEqual<T>(this IArg<T> arg, T param) where T: IComparable
        {
            return IsNotEqual(arg, () => param);
        }
         
        public static IArg<T> IsNotEqual<T>(this IArg<T> arg, Func<T> param) where T: IComparable
        {
            if (arg.Value.CompareTo(param()) == 0)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<T> IsGreaterThan<T>(this IArg<T> arg, T param) where T : IComparable
        {
            return IsGreaterThan(arg, () => param);
        }

        public static IArg<T> IsGreaterThan<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) <= 0)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<T> IsLessThan<T>(this IArg<T> arg, T param) where T : IComparable
        {
            return IsLessThan(arg, () => param);
        }

        public static IArg<T> IsLessThan<T>(this IArg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) >= 0)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }

        public static IArg<T> IsInRange<T>(this IArg<T> arg, T start, T end) where T : IComparable
        {
            if (arg.Value.CompareTo(start) < 0 || arg.Value.CompareTo(end) > 0)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }
    }
}