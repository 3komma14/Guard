using System;

namespace Seterlund.CodeGuard
{
    public static class ComparableValidatorExtensions
    {
        public static ArgumentBase<T> IsEqual<T>(this ArgumentBase<T> argument, T param) where T : IComparable
        {
            return IsEqual(argument, () => param);
        }

        public static ArgumentBase<T> IsEqual<T>(this ArgumentBase<T> argument, Func<T> param) where T : IComparable
        {
            if (argument.Value.CompareTo(param()) != 0)
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<T> IsGreaterThan<T>(this ArgumentBase<T> argument, T param) where T : IComparable
        {
            return IsGreaterThan(argument, () => param);
        }

        public static ArgumentBase<T> IsGreaterThan<T>(this ArgumentBase<T> argument, Func<T> param) where T : IComparable
        {
            if (argument.Value.CompareTo(param()) <= 0)
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<T> IsLessThan<T>(this ArgumentBase<T> argument, T param) where T : IComparable
        {
            return IsLessThan(argument, () => param);
        }

        public static ArgumentBase<T> IsLessThan<T>(this ArgumentBase<T> argument, Func<T> param) where T : IComparable
        {
            if (argument.Value.CompareTo(param()) >= 0)
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }

        public static ArgumentBase<T> IsInRange<T>(this ArgumentBase<T> argument, T start, T end) where T : IComparable
        {
            if (argument.Value.CompareTo(start) < 0 || argument.Value.CompareTo(end) > 0)
            {
                argument.ArgumentOutRangeMessage();
            }

            return argument;
        }
    }
}