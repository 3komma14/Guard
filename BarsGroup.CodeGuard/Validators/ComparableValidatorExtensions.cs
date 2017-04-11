using System;
using BarsGroup.CodeGuard.Internals;
using ArgumentNullException = BarsGroup.CodeGuard.Exceptions.ArgumentNullException;

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
            if (fun == null)
                throw new ArgumentNullException(nameof(fun));

            return IsEqual(arg, fun());
        }

        public static ArgBase<T> IsNotEqual<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) == 0)
                arg.ThrowNotEqual(param);

            return arg;
        }

        public static ArgBase<T> IsNotEqual<T>(this ArgBase<T> arg, Func<T> fun) where T : IComparable
        {
            if (fun == null)
                throw new ArgumentNullException(nameof(fun));

            return IsNotEqual(arg, fun());
        }

        public static ArgBase<T> IsGreaterThan<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) <= 0)
                arg.ThrowGreaterThenExpected(param);

            return arg;
        }

        public static ArgBase<T> IsGreaterThan<T>(this ArgBase<T> arg, Func<T> fun) where T : IComparable
        {
            if (fun == null)
                throw new ArgumentNullException(nameof(fun));

            return IsGreaterThan(arg, fun());
        }

        public static ArgBase<T> IsGreaterThanOrEqualTo<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) < 0)
                arg.ThrowGreaterThenExpected(param);

            return arg;
        }

        public static ArgBase<T> IsGreaterThanOrEqualTo<T>(this ArgBase<T> arg, Func<T> fun) where T : IComparable
        {
            if (fun == null)
                throw new ArgumentNullException(nameof(fun));

            return IsGreaterThanOrEqualTo(arg, fun());
        }

        public static ArgBase<T> IsLessThan<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) >= 0)
                arg.ThrowLessThenExpected(param);

            return arg;
        }

        public static ArgBase<T> IsLessThan<T>(this ArgBase<T> arg, Func<T> fun) where T : IComparable
        {
            if (fun == null)
                throw new ArgumentNullException(nameof(fun));

            return IsLessThan(arg, fun());
        }

        public static ArgBase<T> IsLessThanOrEqualTo<T>(this ArgBase<T> arg, T param) where T : IComparable
        {
            if (arg.Value.CompareTo(param) > 0)
                arg.ThrowLessThenExpected(param);

            return arg;
        }

        public static ArgBase<T> IsLessThanOrEqualTo<T>(this ArgBase<T> arg, Func<T> param) where T : IComparable
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));

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