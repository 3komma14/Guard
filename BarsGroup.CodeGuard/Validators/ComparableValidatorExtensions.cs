using System;
using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class ComparableValidatorExtensions
    {
        public static ArgBase<T> IsEqual<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) != 0)
                arg.ThrowNotEqual(param);

            return arg;
        }

        public static ArgBase<T> IsEqual<T>(this ArgBase<T> arg, Func<T> fun) where T : IComparable
        {
            Guard.That(fun).IsNotNull();


            return IsEqual(arg, fun());
        }

        public static ArgBase<T> IsNotEqual<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) == 0)
                arg.ThrowNotEqual(param);

            return arg;
        }

        public static ArgBase<T> IsNotEqual<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(param).IsNotNull();

            return IsNotEqual(arg, param());
        }

        public static ArgBase<T> IsGreaterThan<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) <= 0)
                arg.ThrowGreaterThenExpected(param);

            return arg;

        }

        public static ArgBase<T> IsGreaterThan<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(param).IsNotNull();


            return IsGreaterThan(arg, param());
        }

        public static ArgBase<T> IsGreaterThanOrEqualTo<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) < 0)
                arg.ThrowGreaterThenExpected(param);

            return arg;

        }

        public static ArgBase<T> IsGreaterThanOrEqualTo<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(param).IsNotNull();

            return IsGreaterThanOrEqualTo(arg,  param());
        }

        public static ArgBase<T> IsLessThan<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) >= 0)
                arg.ThrowLessThenExpected(param);

            return arg;
        }

        public static ArgBase<T> IsLessThan<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(param).IsNotNull();

            return IsLessThan(arg,  param());
        }

        public static ArgBase<T> IsLessThanOrEqualTo<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) > 0)
                arg.ThrowLessThenExpected(param);

            return arg;
            
        }

        public static ArgBase<T> IsLessThanOrEqualTo<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            Guard.That(param).IsNotNull();

            return IsLessThanOrEqualTo(arg,  param());

        }

        public static ArgBase<T> IsInRange<T>(this ArgBase<T> arg, T start, T end) where T : IComparable
        {
            if (arg.Value.CompareTo(start) < 0 || arg.Value.CompareTo(end) > 0)
                arg.ThrowArgumentOutRange(start, end);

            return arg;
        }
    }
}