using System;

namespace Seterlund.CodeGuard
{
    public static class ComparableValidatorExtensions
    {
        public static Arg<T> IsEqual<T>(this Arg<T> arg, T param) where T : IComparable
        {
            return IsEqual(arg, () => param);
        }

        public static Arg<T> IsEqual<T>(this Arg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) != 0)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<T> IsNotEqual<T>(this Arg<T> arg, T param) where T: IComparable
        {
            return IsNotEqual(arg, () => param);
        }
         
        public static Arg<T> IsNotEqual<T>(this Arg<T> arg, Func<T> param) where T: IComparable
        {
            if (arg.Value.CompareTo(param()) == 0)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<T> IsGreaterThan<T>(this Arg<T> arg, T param) where T : IComparable
        {
            return IsGreaterThan(arg, () => param);
        }

        public static Arg<T> IsGreaterThan<T>(this Arg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) <= 0)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<T> IsLessThan<T>(this Arg<T> arg, T param) where T : IComparable
        {
            return IsLessThan(arg, () => param);
        }

        public static Arg<T> IsLessThan<T>(this Arg<T> arg, Func<T> param) where T : IComparable
        {
            if (arg.Value.CompareTo(param()) >= 0)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }

        public static Arg<T> IsInRange<T>(this Arg<T> arg, T start, T end) where T : IComparable
        {
            if (arg.Value.CompareTo(start) < 0 || arg.Value.CompareTo(end) > 0)
            {
                arg.ArgumentOutRangeMessage();
            }

            return arg;
        }
    }
}